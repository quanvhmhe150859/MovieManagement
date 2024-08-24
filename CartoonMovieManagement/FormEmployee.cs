using CartoonMovieManagement.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class FormEmployee : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();
        private FormDashboard formDashboard;
        private int selectedId;

        private FormHistoryLog formHistoryLog;
        private FormProfile formProfile;
        private FormAccount formAccount;
        private FormHistoryLog formEmployeeHistoryLog;
        private FormManagement formManagement;

        public FormEmployee(FormDashboard formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
        }

        private void LoadData()
        {
            selectedId = 0;
            btnEmployee.Text = "Create Employee";
            btnCreateAccount.Enabled = false;

            var employee = context.Employees
                .Include(e => e.Accounts)
                .AsNoTracking()
                .Where(e => e.Accounts.Any(a => a.RoleId != 1) || !e.Accounts.Any())
                .ToList();

            dgvEmployee.DataSource = employee;

            dgvEmployee.Columns["Accounts"].Visible = false;
            dgvEmployee.Columns["Department"].Visible = false;
            dgvEmployee.Columns["EmployeeHistories"].Visible = false;
            dgvEmployee.Columns["SalaryChangeLogs"].Visible = false;
            dgvEmployee.Columns["Studio"].Visible = false;
            dgvEmployee.Columns["StudioDevices"].Visible = false;
            dgvEmployee.Columns["Tasks"].Visible = false;

            lbId.Text = string.Empty;
            lbName.Text = string.Empty;
            tbNote.Text = string.Empty;
            numChange.Value = 0;
            numOld.Value = 0;
            numNew.Value = 0;
            btnSubmit.Enabled = false;
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal money = numChange.Value;

            if (money == 0)
            {
                MessageBox.Show("Not Change");
            }
            else
            {
                // Show a confirmation message box
                var result = MessageBox.Show("Are you sure you want to update salary?", "Confirm Update",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == Int32.Parse(lbId.Text));
                    if (employee != null)
                    {
                        employee.Salary = numNew.Value;

                        context.Employees.Update(employee);

                        SalaryChangeLog salaryChangeLog = new SalaryChangeLog
                        {
                            EmployeeId = Int32.Parse(lbId.Text),
                            Change = money,
                            CreatedDate = DateTime.Now,
                            AccountId = formDashboard.accountId,
                            Note = tbNote.Text
                        };

                        context.SalaryChangeLogs.Add(salaryChangeLog);

                        context.SaveChanges();

                        MessageBox.Show("Update complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Employee not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    // Deletion was canceled
                    MessageBox.Show("Update canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];

                lbId.Text = row.Cells["EmployeeId"].Value.ToString();

                lbName.Text = row.Cells["FullName"].Value.ToString();
                if (row.Cells["Salary"].Value != null && Decimal.TryParse(row.Cells["Salary"].Value.ToString(), out decimal salary))
                {
                    numOld.Value = salary;
                }
                else
                {
                    // Handle the case where the value is null or not a valid decimal.
                    numOld.Value = 0; // or some default value
                }
                numNew.Value = numOld.Value + numChange.Value;
                numChange.Value = numNew.Value - numOld.Value;

                btnSubmit.Enabled = true;

                //Manage Account and Employee
                selectedId = Int32.Parse(row.Cells["EmployeeId"].Value.ToString());
                btnEmployee.Text = "Edit Employee";

                btnCreateAccount.Enabled = true;
                var account = context.Accounts.FirstOrDefault(a => a.EmployeeId == selectedId);
                if (account != null)
                    btnCreateAccount.Text = "Edit Account";
                else
                    btnCreateAccount.Text = "Create Account";

            }
        }

        private bool isUpdating = false;

        private void numChange_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            isUpdating = true;
            numNew.Value = numOld.Value + numChange.Value;
            isUpdating = false;
        }

        private void numNew_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            isUpdating = true;
            numChange.Value = numNew.Value - numOld.Value;
            isUpdating = false;
        }

        private void btnSalaryLog_Click(object sender, EventArgs e)
        {
            if (formHistoryLog == null || formHistoryLog.IsDisposed)
            {
                // If the form does not exist or was closed, create a new instance
                formHistoryLog = new FormHistoryLog("Salary", formDashboard);
                formHistoryLog.Show();
            }
            else
            {
                formHistoryLog.BringToFront();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (formProfile == null || formProfile.IsDisposed)
            {
                formProfile = new FormProfile(selectedId, "Admin", this);
                formProfile.Show();
            }
            else
            {
                formProfile.Close();
                formProfile = new FormProfile(selectedId, "Admin", this);
                formProfile.Show();
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (formAccount == null || formAccount.IsDisposed)
            {
                formAccount = new FormAccount(selectedId, "Admin");
                formAccount.Show();
            }
            else
            {
                formAccount.Close();
                formAccount = new FormAccount(selectedId, "Admin");
                formAccount.Show();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (formEmployeeHistoryLog == null || formEmployeeHistoryLog.IsDisposed)
            {
                formEmployeeHistoryLog = new FormHistoryLog("EmployeeHistory", formDashboard);
                formEmployeeHistoryLog.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                formEmployeeHistoryLog.BringToFront();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (formManagement == null || formManagement.IsDisposed)
            {
                formManagement = new FormManagement();
                formManagement.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                formManagement.BringToFront();
            }
        }
    }
}
