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
    public partial class FormStatusSetting : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        public FormStatusSetting()
        {
            InitializeComponent();
        }

        private void FormStatusSetting_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            tbId.Text = string.Empty;
            tbName.Text = string.Empty;
            tbDescription.Text = string.Empty;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCreate.Enabled = true;

            var status = context.Statuses
                .Select(p => new
                {
                    StatusId = p.StatusId,
                    Name = p.Name,
                    Description = p.Description
                })
                .ToList();
            dataGridView1.DataSource = status;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Display the data in the labels
                tbId.Text = row.Cells["StatusId"].Value.ToString();
                tbName.Text = row.Cells["Name"].Value.ToString();
                tbDescription.Text = row.Cells["Description"].Value != null
                     ? row.Cells["Description"].Value.ToString()
                     : "";


                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnCreate.Enabled = false;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var status = context.Statuses.FirstOrDefault(s => s.Name == tbName.Text.Trim());

            if (tbName.Text.Trim() == "")
                MessageBox.Show("Need Name");
            else if (status != null)
            {
                MessageBox.Show("Same Name");
            }
            else
            {
                context.Statuses.Add(new Status
                {
                    Name = tbName.Text.Trim(),
                    Description = tbDescription.Text.Trim(),
                });
                context.SaveChanges();
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var status = context.Statuses.FirstOrDefault(s => s.Name == tbName.Text.Trim()
                && s.StatusId != Int32.Parse(tbId.Text));

            if (tbName.Text.Trim() == "")
                MessageBox.Show("Need Name");
            else if (status != null)
            {
                MessageBox.Show("Same Name");
            }
            else
            {
                var s = context.Statuses.FirstOrDefault(s => s.StatusId == Int32.Parse(tbId.Text));
                s.Name = tbName.Text.Trim();
                s.Description = tbDescription.Text.Trim();
                context.Statuses.Update(s);
                context.SaveChanges();
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
                var status = context.Statuses.FirstOrDefault(s => s.StatusId == Int32.Parse(tbId.Text));
                if (status != null)
                {
                    context.Remove(status);
                    context.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}
