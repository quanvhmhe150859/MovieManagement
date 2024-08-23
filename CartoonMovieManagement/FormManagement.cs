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
    public partial class FormManagement : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();
        private string type = "";
        public FormManagement()
        {
            InitializeComponent();
            dgvData.CellFormatting += dgvData_CellFormatting;
        }

        private void dgvData_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "RoleId")
            {
                if (e.Value != null)
                {
                    int roleId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var role = context.Roles.FirstOrDefault(p => p.RoleId == roleId);
                    if (role != null)
                    {
                        e.Value = role.Name;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (dgvData.Columns[e.ColumnIndex].Name == "TypeId")
            {
                if (e.Value != null)
                {
                    int typeId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var typeObject = context.Types.FirstOrDefault(p => p.TypeId == typeId);
                    if (typeObject != null)
                    {
                        e.Value = typeObject.Name;
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void LoadData()
        {
            lbId.Text = string.Empty;
            tbName.Text = string.Empty;
            tbDescription.Text = string.Empty;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnChange.Enabled = false;

            lbPermission.Text = string.Empty;
            lbRole.Text = string.Empty;
            lbObject.Text = string.Empty;

            if (type == "Department")
            {
                panel1.Enabled = true;
                panel2.Enabled = false;

                var departments = context.Departments.ToList();
                dgvData.DataSource = departments;
                dgvData.Columns["DepartmentId"].Visible = false;
                dgvData.Columns["Employees"].Visible = false;
                dgvData.Columns["Description"].MinimumWidth = 100;
                dgvData.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == "Studio")
            {
                panel1.Enabled = true;
                panel2.Enabled = false;

                var studios = context.Studios.ToList();
                dgvData.DataSource = studios;
                dgvData.Columns["StudioId"].Visible = false;
                dgvData.Columns["Employees"].Visible = false;
                dgvData.Columns["Description"].MinimumWidth = 100;
                dgvData.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == "Permission")
            {
                panel1.Enabled = false;
                panel2.Enabled = true;

                var permissions = context.Permissions.ToList();
                dgvData.DataSource = permissions;
                dgvData.Columns["PermissionId"].Visible = false;
                dgvData.Columns["Role"].Visible = false;
                dgvData.Columns["Type"].Visible = false;
                dgvData.Columns["RoleId"].HeaderText = "Role";
                dgvData.Columns["TypeId"].HeaderText = "Work with";
                dgvData.Columns["Create"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns["Read"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns["Update"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns["Delete"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void FormManagement_Load(object sender, EventArgs e)
        {
            type = "Department";
            LoadData();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            type = "Department";
            LoadData();
        }

        private void btnStudio_Click(object sender, EventArgs e)
        {
            type = "Studio";
            LoadData();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];

                if (type == "Department")
                {
                    // Display the data in the labels
                    lbId.Text = row.Cells["DepartmentId"].Value.ToString();
                    tbName.Text = row.Cells["Name"].Value.ToString();
                    tbDescription.Text = row.Cells["Description"].Value != null
                         ? row.Cells["Description"].Value.ToString()
                         : "";
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;

                }
                else if (type == "Studio")
                {
                    // Display the data in the labels
                    lbId.Text = row.Cells["StudioId"].Value.ToString();
                    tbName.Text = row.Cells["Name"].Value.ToString();
                    tbDescription.Text = row.Cells["Description"].Value != null
                         ? row.Cells["Description"].Value.ToString()
                         : "";
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else if (type == "Permission")
                {
                    // Display the data in the labels
                    lbPermission.Text = row.Cells["PermissionId"].Value.ToString();
                    lbRole.Text = context.Roles.FirstOrDefault(r => r.RoleId == (int)row.Cells["RoleId"].Value)?.Name;
                    lbObject.Text = context.Types.FirstOrDefault(r => r.TypeId == (int)row.Cells["TypeId"].Value)?.Name;
                    checkCreate.Checked = (bool)row.Cells["Create"].Value;
                    checkRead.Checked = (bool)row.Cells["Read"].Value;
                    checkUpdate.Checked = (bool)row.Cells["Update"].Value;
                    checkDelete.Checked = (bool)row.Cells["Delete"].Value;

                    if(lbRole.Text != "Admin")
                        btnChange.Enabled = true;
                    else
                        btnChange.Enabled = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("Need Name");
            }
            else if (type == "Department")
            {
                var department = context.Departments.FirstOrDefault(d => d.Name == tbName.Text.Trim());
                if (department != null)
                {
                    MessageBox.Show("Already have this Department");
                }
                else
                {
                    context.Departments.Add(new Department
                    {
                        Name = tbName.Text.Trim(),
                        Description = tbDescription.Text.Trim()
                    });
                    context.SaveChanges();
                    MessageBox.Show("Create success");
                    LoadData();
                }
            }
            else if (type == "Studio")
            {
                var studio = context.Studios.FirstOrDefault(d => d.Name == tbName.Text.Trim());
                if (studio != null)
                {
                    MessageBox.Show("Already have this Studio");
                }
                else
                {
                    context.Studios.Add(new Studio
                    {
                        Name = tbName.Text.Trim(),
                        Description = tbDescription.Text.Trim()
                    });
                    context.SaveChanges();
                    MessageBox.Show("Create success");
                    LoadData();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("Need Name");
            }
            else if (type == "Department")
            {
                var department = context.Departments
                    .FirstOrDefault(d => d.Name == tbName.Text.Trim() &&
                    d.DepartmentId != Int32.Parse(lbId.Text));
                if (department != null)
                {
                    MessageBox.Show("Already have this Department");
                }
                else
                {
                    var temp = context.Departments
                        .FirstOrDefault(t => t.DepartmentId == Int32.Parse(lbId.Text));
                    if (temp != null)
                    {
                        temp.Name = tbName.Text.Trim();
                        temp.Description = tbDescription.Text.Trim();

                        context.Departments.Update(temp);
                        context.SaveChanges();
                        MessageBox.Show("Update success");
                        LoadData();
                    }
                }
            }
            else if (type == "Studio")
            {
                var studio = context.Studios
                    .FirstOrDefault(d => d.Name == tbName.Text.Trim() &&
                    d.StudioId != Int32.Parse(lbId.Text));
                if (studio != null)
                {
                    MessageBox.Show("Already have this Studio");
                }
                else
                {
                    var temp = context.Studios
                        .FirstOrDefault(t => t.StudioId == Int32.Parse(lbId.Text));
                    if (temp != null)
                    {
                        temp.Name = tbName.Text.Trim();
                        temp.Description = tbDescription.Text.Trim();

                        context.Studios.Update(temp);
                        context.SaveChanges();
                        MessageBox.Show("Update success");
                        LoadData();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                if (type == "Department")
                {
                    var department = context.Departments
                        .FirstOrDefault(d => d.DepartmentId == Int32.Parse(lbId.Text));
                    if (department != null)
                    {
                        var employee = context.Employees
                            .FirstOrDefault(e => e.DepartmentId == department.DepartmentId);
                        if (employee != null)
                        {
                            MessageBox.Show("Still have employee in this department");
                        }
                        else
                        {
                            context.Departments.Remove(department);
                            context.SaveChanges();
                            MessageBox.Show("Delete success");
                            LoadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not found");
                    }
                }
                else if (type == "Studio")
                {
                    var studio = context.Studios
                        .FirstOrDefault(d => d.StudioId == Int32.Parse(lbId.Text));
                    if (studio != null)
                    {
                        var employee = context.Employees
                            .FirstOrDefault(e => e.StudioId == studio.StudioId);
                        if (employee != null)
                        {
                            MessageBox.Show("Still have employee in this studio");
                        }
                        else
                        {
                            context.Studios.Remove(studio);
                            context.SaveChanges();
                            MessageBox.Show("Delete success");
                            LoadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not found");
                    }
                }
            }
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            type = "Permission";
            LoadData();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var permisson = context.Permissions
                .FirstOrDefault(p => p.PermissionId == Int32.Parse(lbPermission.Text));
            if (permisson != null)
            {
                permisson.Create = checkCreate.Checked;
                permisson.Read = checkRead.Checked;
                permisson.Update = checkUpdate.Checked;
                permisson.Delete = checkDelete.Checked;

                context.Permissions.Update(permisson);
                context.SaveChanges();
                MessageBox.Show("Save changes successful");
                LoadData();
            }
            else
            {
                MessageBox.Show("Not found Permission");
            }
        }
    }
}
