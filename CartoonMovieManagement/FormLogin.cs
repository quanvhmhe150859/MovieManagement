using CartoonMovieManagement.Models;
using Microsoft.Identity.Client;

namespace CartoonMovieManagement
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            //hard code
            //Form2 form2 = new Form2(2, this);
            //form2.Show();

            //FormDashboard formDashboard = new FormDashboard(2, this);
            //formDashboard.Show();

            FormMain formMain = new FormMain(2, this);
            formMain.Show();

			FormMain formMain2 = new FormMain(3, this);
			formMain2.Show();
			//hard code
		}

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            var account = context.Accounts
                .FirstOrDefault(a => a.Email == email && a.Password == password && 
                a.DeletedDate == null);
            
            if (account == null)
            {
                MessageBox.Show("Wrong email or password");
            }
            else
            {
                if(account.IsActive)
                {
                    int accountId = account.AccountId;
                    MessageBox.Show("Login successful");

                    //if (account.RoleId == 1)
                    //{
                    //    FormDashboard formDashboard = new FormDashboard(accountId, this);
                    //    formDashboard.Show();
                    //}
                    //else
                    //{
                    //    Form2 form2 = new Form2(account.EmployeeId, this);
                    //    form2.Show();
                    //}

                    FormMain formMain = new FormMain(accountId, this);
                    formMain.Show();

					this.Hide();
                }
                else
                {
                    MessageBox.Show("Account not active");
                }
            }
        }
    }
}
