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

        public FormEmployee(FormDashboard formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
        }

        private void LoadData()
        {
            var employee = context.Employees
                .Include(e => e.Accounts)
                .Where(e => e.Accounts.Any(a => a.RoleId != 1))
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
            FormHistoryLog formHistoryLog = new FormHistoryLog("Salary", formDashboard);
            formHistoryLog.Show();
        }
    }
}
