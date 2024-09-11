using CartoonMovieManagement.Models;
using System.Data;

namespace CartoonMovieManagement
{
    public partial class FormProjectDetail : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private int? projectId;
        private FormMain formDashboard;

        Button btnDelete = new Button();

        public FormProjectDetail(int? id, FormMain formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
            projectId = id;
        }

        public void UpdateData(int selectedId)
        {
            // Update the form's data based on the new selectedId
            projectId = selectedId;
            // Refresh the form with the new data as needed
            LoadData();
        }

        private void LoadData()
        {
            var account = context.Accounts.FirstOrDefault(a => a.AccountId == formDashboard.accountId);
            if (account != null)
            {
                var permission = context.Permissions
                    .FirstOrDefault(p => p.RoleId == account.RoleId && p.TypeId == 1);
                if (permission != null && permission.Delete && projectId != 0)
                    CreateDeleteButton();
                else
                    DeleteDeleteButton();
            }
            else
            {
                MessageBox.Show("Error");
                this.Close();
            }

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
            else
            {
                tbId.Text = string.Empty;
                tbName.Text = string.Empty;
                tbDescription.Text = string.Empty;
                cbCategory.SelectedIndex = 0;
                numBudget.Value = 0;
            }
        }

        private void FormProjectDetail_Load(object sender, EventArgs e)
        {
            var category = context.Categories.Where(c => c.DeletedDate == null && c.IsActive).ToList();
            cbCategory.DataSource = category;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryId";

            LoadData();
        }

        private void CreateDeleteButton()
        {
            // Create a new button
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
            btnDelete.Location = new Point(1614, 1102);
			btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(330, 96);
			btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

			// Add the button to the form
			this.Controls.Add(btnDelete);
        }

        private void DeleteDeleteButton()
        {
            this.Controls.Remove(btnDelete);
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
                    tempProject.Budget = project.Budget;
                    tempProject.CategoryId = project.CategoryId;

                    context.Update(tempProject);
                }
            }
            context.SaveChanges();

            formDashboard.LoadData("Project", formDashboard.dgvDataProject);
            formDashboard.LoadTreeView("Project");
            this.Close();
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            // Show a confirmation message box
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                var project = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                if (project != null)
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
                    //formDashboard.LoadData("Project");
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
