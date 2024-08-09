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

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
