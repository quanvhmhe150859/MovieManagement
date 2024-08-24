using CartoonMovieManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartoonMovieManagement
{
    public partial class FormProfile : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();
        private int employeeId;
        private string type;
        private FormEmployee? formEmployee;

        private FormAccount formAccount;

        public FormProfile(int employeeId, string type, FormEmployee? formEmployee)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.type = type;
            this.formEmployee = formEmployee;
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {

            cbGender.SelectedIndex = 0;

            var employee = context.Employees
                .Include(e => e.Department)
                .Include(e => e.Studio)
                .FirstOrDefault(e => e.EmployeeId == employeeId);

            var department = context.Departments.ToList();
            cbDepartment.DataSource = department;
            cbDepartment.DisplayMember = "Name";
            cbDepartment.ValueMember = "DepartmentId";

            var studio = context.Studios.ToList();
            cbStudio.DataSource = studio;
            cbStudio.DisplayMember = "Name";
            cbStudio.ValueMember = "StudioId";

            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";

            if (type == "Employee" && employee == null)
            {
                MessageBox.Show("Not found");
                this.Close();
            }
            else if (type == "Admin")
            {
                cbDepartment.Enabled = true;
                cbStudio.Enabled = true;
                tbCI.Enabled = true;
            }
            else if (type == "Employee")
            {
                Button btnAccount = new Button();
                btnAccount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
                btnAccount.Location = new Point(589, 255);
                btnAccount.Name = "btnAccount";
                btnAccount.Size = new Size(199, 32);
                btnAccount.TabIndex = 36;
                btnAccount.Text = "Account";
                btnAccount.UseVisualStyleBackColor = true;
                btnAccount.Click += btnAccount_Click;
                this.Controls.Add(btnAccount);
            }

            if (employee != null)
            {
                tbFullName.Text = employee.FullName;
                tbEmail.Text = employee.Email;
                tbPhoneNumber.Text = employee.PhoneNumber;
                cbGender.SelectedItem = employee.Gender;

                // Assuming employee.DateOfBirth is of type DateOnly
                DateOnly dateOnly = employee.DateOfBirth ?? new DateOnly();

                // Convert DateOnly to DateTime
                DateTime dateTime = new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);

                // Assign to DateTimePicker
                dtpDOB.Value = dateTime;

                tbSML.Text = employee.SocialMediaLink;
                dtpCreatedDate.Value = employee.CreatedDate;
                numSalary.Value = employee.Salary;
                tbCI.Text = employee.CitizenIdentification;
                tbId.Text = employee.EmployeeId.ToString();

                cbDepartment.SelectedValue = employee.DepartmentId;
                cbStudio.SelectedValue = employee.StudioId;

                if (employee.Avatar != null)
                {
                    pbAvatar.Name = employee.Avatar;

                    string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                    string uploadsFolderPath = Path.Combine(projectRootPath, "Uploads", "Avatar");
                    string filePath = Path.Combine(uploadsFolderPath, employee.Avatar);

                    // Check if the file exists
                    if (File.Exists(filePath))
                    {
                        // Load the image into the PictureBox
                        pbAvatar.Image = Image.FromFile(filePath);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";

            bool isValid = true;
            if (tbFullName.Text.Trim() == "")
            {
                isValid = false;
                label14.Text = "Need Name";
            }
            if (tbEmail.Text.Trim() == "") //validate Email
            {
                isValid = false;
                label15.Text = "Email invalid";
            }
            if (tbPhoneNumber.Text.Trim() == "") //validate Phone number
            {
                isValid = false;
                label16.Text = "Phone number invalid";
            }
            if (dtpDOB.Value > DateTime.Now) //validate DOB > 18 years old
            {
                isValid = false;
                label17.Text = "Must > 18 years old";
            }
            if (tbCI.Text.Length != 12)
            {
                isValid = false;
                label18.Text = "Invalid Citizen Identification";
            }

            if (isValid)
            {
                Employee employee = new Employee
                {
                    FullName = tbFullName.Text.Trim(),
                    Email = tbEmail.Text.Trim(),
                    PhoneNumber = tbPhoneNumber.Text.Trim(),
                    Gender = cbGender.SelectedItem?.ToString(),
                    DateOfBirth = new DateOnly(dtpDOB.Value.Year, dtpDOB.Value.Month, dtpDOB.Value.Day),
                    SocialMediaLink = tbSML.Text.Trim(),
                    //Avatar = "",
                    CreatedDate = DateTime.Now,
                    Salary = numSalary.Value,
                    DepartmentId = (int?)cbDepartment.SelectedValue,
                    StudioId = (int?)cbStudio.SelectedValue,
                    CitizenIdentification = tbCI.Text.Trim()

                };

                if (pbAvatar.Image != null && tbId.Text == "")
                {
                    string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                    string uploadsFolderPath = Path.Combine(projectRootPath, "Uploads", "Avatar");

                    // Ensure the Uploads folder exists
                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        Directory.CreateDirectory(uploadsFolderPath);
                    }

                    // Define the full path including the image name
                    //string fileName = "your_image_name_here.jpg"; // Or use a dynamic name
                    //string fullImagePath = Path.Combine(uploadsFolderPath, fileName);
                    // Save the image
                    //pbAvatar.Image.Save(fullImagePath);

                    string fileName = Guid.NewGuid().ToString() + ".jpg"; // Or ".png" depending on your image format

                    // Combine the folder path and file name
                    string filePath = Path.Combine(uploadsFolderPath, fileName);

                    // Save the image from the PictureBox
                    pbAvatar.Image.Save(filePath, ImageFormat.Jpeg);

                    employee.Avatar = fileName;
                }

                if (tbId.Text == "")
                {
                    context.Employees.Add(employee);
                }
                else
                {
                    var tempEmployee = context.Employees
                        .FirstOrDefault(e => e.EmployeeId == Int32.Parse(tbId.Text));
                    if (tempEmployee != null)
                    {
                        tempEmployee.FullName = employee.FullName;
                        tempEmployee.Email = employee.Email;
                        tempEmployee.PhoneNumber = employee.PhoneNumber;
                        tempEmployee.Gender = employee.Gender;
                        tempEmployee.DateOfBirth = employee.DateOfBirth;
                        tempEmployee.SocialMediaLink = employee.SocialMediaLink;
                        tempEmployee.DepartmentId = employee.DepartmentId;
                        tempEmployee.StudioId = employee.StudioId;
                        tempEmployee.CitizenIdentification = employee.CitizenIdentification;

                        if (pbAvatar.Image != null && pbAvatar.Name != tempEmployee.Avatar)
                        {
                            string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                            string uploadsFolderPath = Path.Combine(projectRootPath, "Uploads", "Avatar");

                            // Ensure the Uploads folder exists
                            if (!Directory.Exists(uploadsFolderPath))
                            {
                                Directory.CreateDirectory(uploadsFolderPath);
                            }

                            // Define the full path including the image name
                            //string fileName = "your_image_name_here.jpg"; // Or use a dynamic name
                            //string fullImagePath = Path.Combine(uploadsFolderPath, fileName);
                            // Save the image
                            //pbAvatar.Image.Save(fullImagePath);

                            string fileName = Guid.NewGuid().ToString() + ".jpg"; // Or ".png" depending on your image format

                            // Combine the folder path and file name
                            string filePath = Path.Combine(uploadsFolderPath, fileName);

                            // Save the image from the PictureBox
                            pbAvatar.Image.Save(filePath, ImageFormat.Jpeg);

                            if (tempEmployee.Avatar != null)
                            {
                                string deleteOldfilePath = Path.Combine(uploadsFolderPath, tempEmployee.Avatar);
                                if (File.Exists(deleteOldfilePath))
                                {
                                    try
                                    {
                                        // Delete the file
                                        File.Delete(deleteOldfilePath);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"An error occurred while deleting the file: {ex.Message}");
                                    }
                                }
                            }

                            tempEmployee.Avatar = fileName;
                        }

                        context.Employees.Update(tempEmployee);
                    }
                    else
                        MessageBox.Show("Not found");
                }
                context.SaveChanges();
                MessageBox.Show("Save successful");
                formEmployee?.Refresh();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnUploadAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter for image files (you can modify this as needed)
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an Image";

                // Show the OpenFileDialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image into the PictureBox
                    pbAvatar.Image = Image.FromFile(openFileDialog.FileName);
                    pbAvatar.Name = openFileDialog.FileName;
                    // Optional: Adjust the PictureBox size mode if needed
                    //pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (formAccount == null || formAccount.IsDisposed)
            {
                formAccount = new FormAccount(employeeId, "Employee");
                formAccount.Show();
            }
            else
            {
                // If the form is already open, bring it to the front
                formAccount.BringToFront();
            }
        }
    }
}
