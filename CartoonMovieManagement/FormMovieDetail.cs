using CartoonMovieManagement.Models;

namespace CartoonMovieManagement
{
    public partial class FormMovieDetail : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private int? movieId;
        private FormDashboard formDashboard;

        public FormMovieDetail(int? id, FormDashboard formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
            movieId = id;
        }

        private void FormMovieDetail_Load(object sender, EventArgs e)
        {
            // Create a placeholder item
            var placeholder = new Project { ProjectId = -1, Name = "Please select..." };

            // Retrieve the data and add the placeholder item
            var dataProject = context.Projects.ToList();
            dataProject.Insert(0, placeholder); // Add placeholder to the beginning of the list

            // Set the data source and configure the ComboBox
            cbProject.DataSource = dataProject;
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "ProjectId";

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
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
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
    }
}
