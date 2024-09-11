using CartoonMovieManagement.Models;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
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
	public partial class FormEmployeeHistory : Form
	{
		CartoonProductManagementContext context = new CartoonProductManagementContext();

		public FormEmployeeHistory()
		{
			InitializeComponent();
		}

		private void FormEmployeeHistory_Load(object sender, EventArgs e)
		{
			//Employee
			var cbData = context.Employees
				.Include(e => e.Accounts)
				.Where(e => e.Accounts.Any(a => a.RoleId != 1))
				.ToList();
			cbEmployee.DataSource = cbData;
			cbEmployee.DisplayMember = "FullName";
			cbEmployee.ValueMember = "EmployeeId";

			LoadData();
		}
		private void LoadData()
		{
			var data = context.EmployeeHistories.ToList();
			dgvEmployeeHistory.DataSource = data;

			tbId.Text = string.Empty;
			tbWorkName.Text = string.Empty;

			btnCreate.Enabled = true;
			btnDelete.Enabled = false;
			btnEdit.Enabled = false;
		}

		private void dgvEmployeeHistory_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dgvEmployeeHistory.Rows[e.RowIndex];

				// Display the data in the labels
				tbId.Text = row.Cells["EmployeeId"].ToString();
				tbWorkName.Text = row.Cells["CompanyName"].Value.ToString();
				if (row.Cells["StartDate"].Value != null && row.Cells["StartDate"].Value is DateTime)
				{
					// Assign the DateTime value to the DateTimePicker
					dtbStart.Value = (DateTime)row.Cells["StartDate"].Value;
				}
				if (row.Cells["EndDate"].Value != null && row.Cells["EndDate"].Value is DateTime)
				{
					// Assign the DateTime value to the DateTimePicker
					dtbEnd.Value = (DateTime)row.Cells["EndDate"].Value;
				}
				cbEmployee.SelectedValue = row.Cells["EmployeeId"].Value;

				btnCreate.Enabled = false;
				btnDelete.Enabled = true;
				btnEdit.Enabled = true;
			}
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			context.EmployeeHistories.Add(new EmployeeHistory
			{
				EmployeeId = (int?)cbEmployee.SelectedValue ?? 0,
				CompanyName = tbWorkName.Text,
				StartDate = dtbStart.Value,
				EndDate = dtbEnd.Value
			});

			context.SaveChanges();

			MessageBox.Show("Save successful");

			LoadData();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			var history = context.EmployeeHistories.FirstOrDefault(e => e.EmployeeHistoryId == Int32.Parse(tbId.Text));
			if (history != null)
			{
				history.EmployeeId = (int?)cbEmployee.SelectedValue ?? -1;
				history.CompanyName = tbWorkName.Text;
				history.StartDate = dtbStart.Value;
				history.EndDate = dtbEnd.Value;

				context.EmployeeHistories.Update(history);
				context.SaveChanges();

				MessageBox.Show("Save successful");

				LoadData();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion",
											 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			// Check the user's response
			if (result == DialogResult.Yes)
			{
				var history = context.EmployeeHistories.FirstOrDefault(s => s.EmployeeHistoryId == Int32.Parse(tbId.Text));
				if (history != null)
				{
					context.EmployeeHistories.Remove(history);
					context.SaveChanges();

					MessageBox.Show("Save successful");

					LoadData();
				}
			}
		}
	}
}
