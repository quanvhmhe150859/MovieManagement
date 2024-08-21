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
    public partial class FormProfile : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();
        private int employeeId;
        private string type;

        public FormProfile(int employeeId, string type)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.type = type;
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
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

            if (type == "Employee")
            {
                if (employee != null)
                {
                    tbFullName.Text = employee.FullName;
                    tbEmail.Text = employee.Email;
                    tbPhoneNumber.Text = employee.PhoneNumber;
                    cbGender.SelectedValue = employee.Gender;

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

                    //chua lam
                    pbAvatar.Name = "Avatar";
                }
                else
                {
                    MessageBox.Show("Not found");
                    this.Close();
                }
            }
            else if (type == "Admin")
            {
                if (employee != null)
                {
                    tbFullName.Text = employee.FullName;
                    tbEmail.Text = employee.Email;
                    tbPhoneNumber.Text = employee.PhoneNumber;
                    cbGender.SelectedValue = employee.Gender;

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

                    //chua lam
                    pbAvatar.Name = "Avatar";
                }
                else
                {
                    cbDepartment.Enabled = true;
                    cbStudio.Enabled = true;
                    tbCI.Enabled = true;
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
            if (tbCI.Text.Length != 13) //validate CI
            {
                isValid = false;
                label18.Text = "Invalid Citizen Identification";
            }

            if (isValid)
            {
                if(tbId.Text == "")
                {

                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
