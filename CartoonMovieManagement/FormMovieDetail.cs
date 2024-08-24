using CartoonMovieManagement.Models;
using Microsoft.VisualBasic.Devices;

namespace CartoonMovieManagement
{
    public partial class FormMovieDetail : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private int? movieId;
        private FormDashboard formDashboard;

        Button btnDelete = new Button();

        public FormMovieDetail(int? id, FormDashboard formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
            movieId = id;
        }

        public void UpdateData(int selectedId)
        {
            // Update the form's data based on the new selectedId
            movieId = selectedId;
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
                if (permission != null && permission.Delete && movieId != 0)
                    CreateDeleteButton();
                else
                    DeleteDeleteButton();
            }
            else
            {
                MessageBox.Show("Error");
                this.Close();
            }

            if (movieId != 0)
            {
                var movie = context.CartoonMovies.FirstOrDefault(m => m.CartoonMovieId == movieId);
                if (movie != null)
                {
                    tbId.Text = movie.CartoonMovieId.ToString();
                    tbName.Text = movie.Name;
                    tbDescription.Text = movie.Description;
                    checkActive.Checked = movie.IsActive;
                    cbProject.SelectedValue = movie.ProjectId;
                }
            }
            else
            {
                tbId.Text = string.Empty;
                tbName.Text = string.Empty;
                tbDescription.Text = string.Empty;
                checkActive.Checked = false;
                cbProject.SelectedIndex = 0;
            }
        }

        private void FormMovieDetail_Load(object sender, EventArgs e)
        {
            // Create a placeholder item
            var placeholder = new Project { ProjectId = -1, Name = "Please select..." };

            // Retrieve the data and add the placeholder item
            var dataProject = context.Projects.Where(p => p.DeletedDate == null).ToList();
            dataProject.Insert(0, placeholder); // Add placeholder to the beginning of the list

            // Set the data source and configure the ComboBox
            cbProject.DataSource = dataProject;
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "ProjectId";

            LoadData();
        }

        private void CreateDeleteButton()
        {
            // Create a new button
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
            btnDelete.Location = new Point(652, 342);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(136, 35);
            btnDelete.TabIndex = 29;
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

            CartoonMovie cartoonMovie = new CartoonMovie
            {
                ProjectId = (int?)cbProject.SelectedValue ?? 0,
                Name = tbName.Text,
                Description = tbDescription.Text,
                IsActive = checkActive.Checked,
                CreatedDate = DateTime.Now,
                ReleasedDate = DateTime.Now
            };

            if (movieId == 0)
            {
                context.CartoonMovies.Add(cartoonMovie);
            }
            else
            {
                var movie = context.CartoonMovies.FirstOrDefault(m => m.CartoonMovieId == movieId);
                if (movie != null)
                {
                    movie.Name = cartoonMovie.Name;
                    movie.Description = cartoonMovie.Description;
                    movie.ProjectId = cartoonMovie.ProjectId;
                    movie.ReleasedDate = DateTime.Now;
                    movie.IsActive = cartoonMovie.IsActive;

                    context.CartoonMovies.Update(movie);
                }
            }

            context.SaveChanges();
            MessageBox.Show("Save successfully");
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
                var movie = context.CartoonMovies.FirstOrDefault(p => p.CartoonMovieId == movieId);
                if (movie != null)
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

                    context.SaveChanges();
                    MessageBox.Show("Deletion complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formDashboard.LoadData("Movie");
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
