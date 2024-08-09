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
    public partial class FormProjectDetail : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private int? projectId;
        private FormDashboard formDashboard;

        public FormProjectDetail(int? id, FormDashboard formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
            projectId = id;
        }

        private void FormProjectDetail_Load(object sender, EventArgs e)
        {
            var category = context.Categories.ToList();
            cbCategory.DataSource = category;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryId";

            if (projectId != 0)
            {
                var project = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                if (project != null)
                {
                    tbId.Text = project.ProjectId.ToString();
                    tbName.Text = project.Name;
                    tbDescription.Text = project.Description;
                    cbCategory.SelectedValue = project.CategoryId;
                    numBudget.Value = project.Budget ?? 0;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Project project = new Project
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                CreatedDate = DateTime.Now,
                CategoryId = (int?)cbCategory.SelectedValue ?? 0,
                Budget = numBudget.Value,
            };

            if (tbId.Text == "")
            {
                context.Projects.Add(project);
            }
            else
            {
                var tempProject = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                if(tempProject != null)
                {
                    tempProject.Name = project.Name;
                    tempProject.Description = project.Description;
                    tempProject.CreatedDate = DateTime.Now;
                    tempProject.Budget = project.Budget;
                    tempProject.CategoryId = project.CategoryId;

                    context.Update(tempProject);
                }
            }
            context.SaveChanges();

            formDashboard.LoadData("Project");

            this.Close();
        }
    }
}
