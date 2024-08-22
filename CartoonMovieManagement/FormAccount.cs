using CartoonMovieManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartoonMovieManagement
{
    public partial class FormAccount : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();
        private int employeeId;
        private string type;
        TextBox tbCreatePassword = new TextBox();

        public FormAccount(int employeeId, string type)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.type = type;
        }

        private void FormAccount_Load(object sender, EventArgs e)
        {
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";

            var employees = context.Employees.ToList();
            cbEmployee.DataSource = employees;
            cbEmployee.DisplayMember = "FullName";
            cbEmployee.ValueMember = "EmployeeId";

            if (type == "Admin")
            {
                Label label9 = new Label();
                label9.AutoSize = true;
                label9.Font = new Font("Segoe UI", 11.25F);
                label9.Location = new Point(332, 177);
                label9.Name = "label9";
                label9.Size = new Size(77, 20);
                label9.TabIndex = 19;
                label9.Text = "Password: ";
                this.Controls.Add(label9);

                tbCreatePassword.Font = new Font("Segoe UI", 11.25F);
                tbCreatePassword.Location = new Point(415, 174);
                tbCreatePassword.Name = "tbCreatePassword";
                tbCreatePassword.Size = new Size(269, 27);
                tbCreatePassword.TabIndex = 20;
                this.Controls.Add(tbCreatePassword);

                checkAccountActive.Enabled = true;
                tbOldPassword.Enabled = false;
                tbNewPassword.Enabled = false;
                tbConfirmPassword.Enabled = false;
                btnChangePassword.Enabled = false;
                label2.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
            }

            var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                cbEmployee.SelectedValue = employee.EmployeeId;
                tbRoleName.Text = "Employee";
                tbEmail.Text = employee.Email;

                var account = context.Accounts.FirstOrDefault(a => a.EmployeeId == employeeId);
                if (account != null)
                {
                    tbEmail.Text = account.Email;
                    tbId.Text = account.AccountId.ToString();
                }
            }
            else
            {
                MessageBox.Show("Not found");
                this.Close();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if(tbEmail.Text.Trim() == "")
            {
                MessageBox.Show("Need Email");
            }
            else
            {
                Account account = new Account
                {
                    Email = tbEmail.Text,
                    Password = tbCreatePassword.Text,
                    CreatedDate = DateTime.Now,
                    IsActive = checkAccountActive.Checked,
                    RoleId = 2,
                    EmployeeId = (int?)cbEmployee.SelectedValue ?? 0
                };

                if (tbId.Text == "")
                {
                    if (tbCreatePassword.Text.Trim() == "")
                        MessageBox.Show("Need Password");
                    else
                    {
                        context.Accounts.Add(account);
                    }
                }
                else
                {
                    var tempAccount = context.Accounts
                        .FirstOrDefault(a => a.AccountId == Int32.Parse(tbId.Text));
                    if (tempAccount != null)
                    {
                        tempAccount.IsActive = checkAccountActive.Checked;
                        tempAccount.Email = tbEmail.Text.Trim();
                        if (tbCreatePassword.Text.Trim() != "")
                            tempAccount.Password = tbCreatePassword.Text.Trim();
                        context.Accounts.Update(tempAccount);
                    }
                    else
                    {
                        MessageBox.Show("Not found");
                        this.Close();
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Save successful");
                this.Close();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var account = context.Accounts.FirstOrDefault(a => a.AccountId == Int32.Parse(tbId.Text));
            if (account != null)
            {
                bool isValid = true;
                if (tbOldPassword.Text.Trim() == "")
                {
                    isValid = false;
                    label9.Text = "Invalid";
                }
                else if (tbOldPassword.Text != account.Password)
                {
                    isValid = false;
                    label9.Text = "Wrong Old Password";
                }
                else
                {
                    label9.Text = "";
                }

                if (tbNewPassword.Text.Trim() == "")
                {
                    isValid = false;
                    label10.Text = "Invalid";
                }
                else
                {
                    label10.Text = "";
                }

                if (tbConfirmPassword.Text.Trim() == "")
                {
                    isValid = false;
                    label11.Text = "Invalid";
                }
                else if(tbNewPassword.Text.Trim() != tbConfirmPassword.Text.Trim())
                {
                    isValid = false;
                    label11.Text = "Password not match";
                }
                else
                {
                    label11.Text = "";
                }

                if (isValid)
                {
                    account.Password = tbConfirmPassword.Text.Trim();
                    context.Accounts.Update(account);
                    context.SaveChanges();
                    MessageBox.Show("Save Changes");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error");
                this.Close();
            }
        }
    }
}
