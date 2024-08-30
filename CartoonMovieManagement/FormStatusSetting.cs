using CartoonMovieManagement.Models;
using System.Data;
using ComboBox = System.Windows.Forms.ComboBox;
using Status = CartoonMovieManagement.Models.Status;

namespace CartoonMovieManagement
{
    public partial class FormStatusSetting : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();
        private string type;
        ComboBox cbCategory = new ComboBox();
        CheckBox checkDeleted = new CheckBox();

        public FormStatusSetting(string type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void FormStatusSetting_Load(object sender, EventArgs e)
        {
            if(type == "Category")
            {
                lbId.Text = "Id: ";
                lbName.Text = "Category: ";
                lbDescription.Text = "Description: ";
                lbBool.Text = "Is Active: ";

                Label label7 = new Label();
                label7.AutoSize = true;
                label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
                label7.Location = new Point(13, 246);
                label7.Name = "label7";
                label7.Size = new Size(156, 25);
                label7.TabIndex = 42;
                label7.Text = "Category Parent: ";
                panel1.Controls.Add(label7);

                cbCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
                cbCategory.FormattingEnabled = true;
                cbCategory.Location = new Point(171, 243);
                cbCategory.Name = "cbCategory";
                cbCategory.Size = new Size(188, 33);
                cbCategory.TabIndex = 43;
                panel1.Controls.Add(cbCategory);

                checkDeleted.AutoSize = true;
                checkDeleted.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
                checkDeleted.Location = new Point(263, 382);
                checkDeleted.Name = "checkDeleted";
                checkDeleted.RightToLeft = RightToLeft.No;
                checkDeleted.Size = new Size(96, 29);
                checkDeleted.TabIndex = 42;
                checkDeleted.Text = "Deleted";
                checkDeleted.UseVisualStyleBackColor = true;
                panel1.Controls.Add(checkDeleted);
            }
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

            if (type == "Status")
            {
                var status = context.Statuses
                    .Select(p => new
                    {
                        StatusId = p.StatusId,
                        Name = p.Name,
                        Description = p.Description,
                        ForAdmin = p.ForAdmin
                    })
                    .ToList();
                dataGridView1.DataSource = status;
                dataGridView1.Columns["Description"].MinimumWidth = 100;
                dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (type == "Category")
            {
                var category = context.Categories.ToList();
                if (checkDeleted.Checked)
                    category = category.Where(c => c.DeletedDate != null).ToList();
                else
                    category = category.Where(c => c.DeletedDate == null).ToList();

                dataGridView1.DataSource = category;
                var categories = context.Categories.Where(c => c.CategoryParentId == null &&
                    c.DeletedDate == null && c.IsActive).ToList();
                categories.Insert(0, new Category { CategoryId = -1, Name = "None" });
                cbCategory.DataSource = categories;
                cbCategory.DisplayMember = "Name";
                cbCategory.ValueMember = "CategoryId";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (type == "Status")
                {
                    // Display the data in the labels
                    tbId.Text = row.Cells["StatusId"].Value.ToString();
                    tbName.Text = row.Cells["Name"].Value.ToString();
                    tbDescription.Text = row.Cells["Description"].Value != null
                         ? row.Cells["Description"].Value.ToString()
                         : "";
                    checkForAdmin.Checked = Convert.ToBoolean(row.Cells["ForAdmin"].Value);

                    int id;
                    if (int.TryParse(tbId.Text, out id) && new[] { 1, 2, 3, 6, 7 }.Contains(id))
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnCreate.Enabled = false;
                    }
                    else
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnCreate.Enabled = false;
                    }
                }
                else if (type == "Category")
                {
                    // Display the data in the labels
                    tbId.Text = row.Cells["CategoryId"].Value.ToString();
                    tbName.Text = row.Cells["Name"].Value.ToString();
                    tbDescription.Text = row.Cells["Description"].Value != null
                         ? row.Cells["Description"].Value.ToString()
                         : "";
                    checkForAdmin.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                    var categories = context.Categories.Where(c => c.CategoryParentId == null &&
                        c.CategoryId != Int32.Parse(tbId.Text) &&
                        c.DeletedDate == null && c.IsActive).ToList();
                    categories.Insert(0, new Category { CategoryId = -1, Name = "None" });
                    cbCategory.DataSource = categories;
                    cbCategory.DisplayMember = "Name";
                    cbCategory.ValueMember = "CategoryId";
                    cbCategory.SelectedValue = row.Cells["CategoryParentId"].Value ?? -1;

                    var currentCate = context.Categories
                        .FirstOrDefault(c => c.CategoryId == Int32.Parse(tbId.Text) &&
                        c.DeletedDate == null);
                    if (currentCate != null)
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnCreate.Enabled = false;
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnCreate.Enabled = false;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (type == "Status")
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
                        ForAdmin = checkForAdmin.Checked
                    });
                    context.SaveChanges();
                    LoadData();
                }
            }
            else if (type == "Category")
            {
                var category = context.Categories
                    .FirstOrDefault(c => c.Name == tbName.Text.Trim() && c.DeletedDate == null);
                if (tbName.Text.Trim() == "")
                    MessageBox.Show("Need Name");
                else if (category != null)
                {
                    MessageBox.Show("Same Name");
                }
                else
                {
                    context.Categories.Add(new Category
                    {
                        Name = tbName.Text.Trim(),
                        Description = tbDescription.Text.Trim(),
                        CreatedDate = DateTime.Now,
                        IsActive = checkForAdmin.Checked,
                        CategoryParentId = (int?)cbCategory.SelectedValue == -1 ? null : (int?)cbCategory.SelectedValue
                    });
                    context.SaveChanges();
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (type == "Status")
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
                    if (s != null)
                    {
                        s.Name = tbName.Text.Trim();
                        s.Description = tbDescription.Text.Trim();
                        s.ForAdmin = checkForAdmin.Checked;
                        context.Statuses.Update(s);
                        context.SaveChanges();
                        MessageBox.Show("Success");
                        LoadData();
                    }
                    else
                        MessageBox.Show("Not found");
                }
            }
            else if (type == "Category")
            {
                var category = context.Categories
                    .FirstOrDefault(s => s.Name == tbName.Text.Trim() && 
                    s.CategoryId != Int32.Parse(tbId.Text) && s.DeletedDate == null);

                if (tbName.Text.Trim() == "")
                    MessageBox.Show("Need Name");
                else if (category != null)
                {
                    MessageBox.Show("Same Name");
                }
                else
                {
                    var s = context.Categories.FirstOrDefault(s => s.CategoryId == Int32.Parse(tbId.Text));
                    if (s != null)
                    {
                        s.Name = tbName.Text.Trim();
                        s.Description = tbDescription.Text.Trim();
                        s.IsActive = checkForAdmin.Checked;
                        s.CategoryParentId = (int?)cbCategory.SelectedValue == -1 ? null : (int?)cbCategory.SelectedValue;
                        context.Categories.Update(s);
                        context.SaveChanges();
                        MessageBox.Show("Success");
                        LoadData();
                    }
                    else
                        MessageBox.Show("Not found");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (type == "Status")
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
            else if (type == "Category")
            {
                var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    var category = context.Categories.FirstOrDefault(s => s.CategoryId == Int32.Parse(tbId.Text));
                    if (category != null)
                    {
                        category.DeletedDate = DateTime.Now;
                        context.Categories.Update(category);

                        var cateChild = context.Categories.Where(c => c.CategoryParentId == category.CategoryId).ToList();
                        foreach (var item in cateChild)
                        {
                            item.CategoryParentId = null;
                            context.Categories.Update(item);
                        }

                        context.SaveChanges();
                        LoadData();
                    }
                }
            }
        }
    }
}
