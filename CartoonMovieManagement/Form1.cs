using CartoonMovieManagement.Models;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.NativeInterop;

namespace CartoonMovieManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //fix
            //Form2 form2 = new Form2(2, this);
            //form2.Show();

            FormDashboard formDashboard = new FormDashboard(2, this);
            formDashboard.Show();
        }

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            var account = context.Accounts.FirstOrDefault(a => a.Email == email && a.Password == password);
            
            if (account == null)
            {
                MessageBox.Show("Wrong email or password");
            }
            else
            {
                int accountId = account.AccountId;
                MessageBox.Show("Login successful");
                if(account.RoleId == 1)
                {
                    //this.Hide();
                    FormDashboard formDashboard = new FormDashboard(accountId, this);
                    formDashboard.Show();
                }
                else
                {
                    //this.Hide();
                    Form2 form2 = new Form2(accountId, this);
                    form2.Show();
                }
            }
        }
    }
}
