using CartoonMovieManagement.Models;
using System.Data;

namespace CartoonMovieManagement
{
    public partial class FormProjectDetail : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private int? projectId;
        private FormDashboard formDashboard;

        public FormProjectDetail(int? id, FormDashboard formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
            projectId = id;
        }

        private void FormProjectDetail_Load(object sender, EventArgs e)
        {
            if(projectId != 0)
                CreateDeleteButton();

            var category = context.Categories.ToList();
            cbCategory.DataSource = category;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryId";

            if (projectId != 0)
            {
                var project = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                if (project != null)
                {
                    tbId.Text = project.ProjectId.ToString();
                    tbName.Text = project.Name;
                    tbDescription.Text = project.Description;
                    cbCategory.SelectedValue = project.CategoryId;
                    numBudget.Value = project.Budget ?? 0;
                }
            }
        }

        private void CreateDeleteButton()
        {
            // Create a new button
            Button btnDelete = new Button();

            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
            btnDelete.Location = new Point(659, 403);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(136, 35);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // Add the button to the form
            this.Controls.Add(btnDelete);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
                MessageBox.Show("Need Name");

            Project project = new Project
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                CreatedDate = DateTime.Now,
                CategoryId = (int?)cbCategory.SelectedValue ?? 0,
                Budget = numBudget.Value,
            };

            if (tbId.Text == "")
            {
                context.Projects.Add(project);
            }
            else
            {
                var tempProject = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                if (tempProject != null)
                {
                    tempProject.Name = project.Name;
                    tempProject.Description = project.Description;
                    tempProject.CreatedDate = DateTime.Now;
                    tempProject.Budget = project.Budget;
                    tempProject.CategoryId = project.CategoryId;

                    context.Update(tempProject);
                }
            }
            context.SaveChanges();

            formDashboard.LoadData("Project");

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                var project = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                if(project != null)
                {
                    project.DeletedDate = DateTime.Now;

                    context.Projects.Update(project);

                    var movies = context.CartoonMovies.Where(m => m.ProjectId == project.ProjectId).ToList();
                    foreach (var movie in movies)
                    {
                        movie.DeletedDate = DateTime.Now;

                        context.CartoonMovies.Update(movie);

                        var episodes = context.EpisodeMovies.Where(e => e.CartoonMovieId == movie.CartoonMovieId).ToList();
                        foreach (var episode in episodes)
                        {
                            episode.DeletedDate = DateTime.Now;
                            context.EpisodeMovies.Update(episode);

                            var tasks = context.Tasks.Where(t => t.EpisodeMovieId == episode.EpisodeMovieId).ToList();
                            foreach (var task in tasks)
                            {
                                task.DeletedDate = DateTime.Now;

                                context.Tasks.Update(task);
                            }
                        }
                    }

                    context.SaveChanges();
                    MessageBox.Show("Deletion complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formDashboard.LoadData("Project");
                    this.Close();
                }
            }
            else
            {
                // Deletion was canceled
                MessageBox.Show("Deletion canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
