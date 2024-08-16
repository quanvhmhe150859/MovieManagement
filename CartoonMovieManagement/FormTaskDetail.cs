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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Task = CartoonMovieManagement.Models.Task;

namespace CartoonMovieManagement
{
    public partial class FormTaskDetail : Form
    {
        private int? taskId;
        private FormDashboard formDashboard;

        private int? projectSelected;
        private int? movieSelected;
        private int? episodeSelected;

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        public FormTaskDetail(int? id, FormDashboard formDashboard, int? projectSelected, int? movieSelected, int? episodeSelected)
        {
            InitializeComponent();
            taskId = id;
            this.formDashboard = formDashboard;

            this.projectSelected = projectSelected;
            this.movieSelected = movieSelected;
            this.episodeSelected = episodeSelected;

            dtbDeadLine.Format = DateTimePickerFormat.Custom;
            dtbDeadLine.CustomFormat = "dd/MM/yyyy hh:mm tt";
        }

        private void FormTaskDetail_Load(object sender, EventArgs e)
        {
            if(taskId != 0)
                CreateDeleteButton();

            //Error
            errorProject.Text = "";
            errorMovie.Text = "";
            errorEpisode.Text = "";
            errorName.Text = "";
            errorDeadline.Text = "";

            //Employee
            var cbData = context.Employees
                .Include(e => e.Accounts)
                .Where(e => e.Accounts.Any(a => a.RoleId != 1))
                .ToList();
            cbEmployee.DataSource = cbData;
            cbEmployee.DisplayMember = "FullName";
            cbEmployee.ValueMember = "EmployeeId";

            // Create a placeholder item
            var placeholder = new Project { ProjectId = -1, Name = "Please select..." };

            // Retrieve the data and add the placeholder item
            var dataProject = context.Projects.Where(p => p.DeletedDate == null).ToList();
            dataProject.Insert(0, placeholder); // Add placeholder to the beginning of the list

            // Set the data source and configure the ComboBox
            cbProject.DataSource = dataProject;
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "ProjectId";

            //Status
            var statusData = context.Statuses.ToList();
            cbStatus.DataSource = statusData;
            cbStatus.DisplayMember = "Name";
            cbStatus.ValueMember = "StatusId";

            cbProject.SelectedValue = projectSelected;
            cbMovie.SelectedValue = movieSelected == 0 ? -1 : movieSelected;
            cbEpisode.SelectedValue = episodeSelected == 0 ? -1 : episodeSelected;

            if (taskId != 0)
            {
                var task = context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
                var episode = context.EpisodeMovies.FirstOrDefault(e => e.EpisodeMovieId == task.EpisodeMovieId);
                var movie = context.CartoonMovies.FirstOrDefault(m => m.CartoonMovieId == episode.CartoonMovieId);
                var project = context.Projects.FirstOrDefault(p => p.ProjectId == movie.ProjectId);
                if (task != null)
                {
                    tbId.Text = task.TaskId.ToString();
                    cbEmployee.SelectedValue = task.ReceiverId;
                    cbProject.SelectedValue = movie.ProjectId;
                    cbMovie.SelectedValue = movie.CartoonMovieId;
                    cbEpisode.SelectedValue = episode.EpisodeMovieId;
                    cbTaskParent.SelectedValue = task.TaskParentId ?? 0;
                    tbName.Text = task.Name;
                    tbDescription.Text = task.Description;
                    dtbDeadLine.Value = task.DeadlineDate;
                    cbStatus.SelectedIndex = task.StatusId - 1;
                    tbFilePath.Text = task.ResourceLink;
                }
            }
        }

        private void CreateDeleteButton()
        {
            // Create a new button
            Button btnDelete = new Button();

            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
            btnDelete.Location = new Point(652, 578);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(136, 35);
            btnDelete.TabIndex = 43;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // Add the button to the form
            this.Controls.Add(btnDelete);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            //Error
            errorProject.Text = "";
            errorMovie.Text = "";
            errorEpisode.Text = "";
            errorName.Text = "";
            errorDeadline.Text = "";

            if (tbName.Text.Trim() == "")
            {
                errorName.Text = "Need Name";
                isValid = false;
            }
            if ((int?)cbProject.SelectedValue == -1 || cbProject.SelectedValue == null)
            {
                errorProject.Text = "Need Project";
                errorMovie.Text = "Need Movie";
                errorEpisode.Text = "Need Episode";
                isValid = false;
            }
            if ((int?)cbMovie.SelectedValue == -1 || cbMovie.SelectedValue == null)
            {
                errorMovie.Text = "Need Movie";
                errorEpisode.Text = "Need Episode";
                isValid = false;
            }
            if ((int?)cbEpisode.SelectedValue == -1 || cbEpisode.SelectedValue == null)
            {
                errorEpisode.Text = "Need Episode";
                isValid = false;
            }
            if (dtbDeadLine.Value < DateTime.Now)
            {
                errorDeadline.Text = "Deadline must be future date";
                isValid = false;
            }

            if (isValid)
            {
                Task newTask = new Task
                {
                    Name = tbName.Text,
                    Description = tbDescription.Text,
                    CreatedDate = DateTime.Now,
                    ReceiverId = (int?)cbEmployee.SelectedValue,
                    CreaterId = formDashboard.accountId, //dang fix cung
                    StatusId = (int)(cbStatus.SelectedValue ?? 0),
                    EpisodeMovieId = (int?)cbEpisode.SelectedValue ?? 0,
                    DeadlineDate = dtbDeadLine.Value,
                    ResourceLink = tbFilePath.Text,
                    TaskParentId = (int?)cbTaskParent.SelectedValue
                };
                Task tempTask = new Task();
                bool isLinkChange = false;
                if (taskId != 0)
                {
                    tempTask = context.Tasks.FirstOrDefault(t => t.TaskId == Int32.Parse(tbId.Text));
                    if (tempTask != null)
                    {
                        tempTask.Name = newTask.Name;
                        tempTask.Description = newTask.Description;
                        tempTask.AssignedDate = newTask.AssignedDate;
                        tempTask.DeadlineDate = newTask.DeadlineDate;
                        tempTask.StatusId = newTask.StatusId;
                        tempTask.EpisodeMovieId = newTask.EpisodeMovieId;
                        tempTask.TaskParentId = newTask.TaskParentId;

                        if (tempTask.ResourceLink != newTask.ResourceLink)
                            isLinkChange = true;
                    }
                }

                if (newTask.TaskParentId == 0)
                {
                    newTask.TaskParentId = null;
                    tempTask.TaskParentId = null;
                }

                // Ensure a file is selected
                if ((!string.IsNullOrEmpty(tbFilePath.Text) && taskId == 0) || isLinkChange)
                {
                    try
                    {
                        //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                        //string uploadsFolderPath = Path.Combine(projectDirectory, "Uploads");

                        //// Ensure the "Uploads" folder exists
                        //if (!Directory.Exists(uploadsFolderPath))
                        //{
                        //    Directory.CreateDirectory(uploadsFolderPath);
                        //}
                        // Define the upload folder
                        string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                        string uploadsFolderPath = Path.Combine(projectRootPath, "Uploads", "Resources");

                        // Get the file name and destination path
                        string fileName = Path.GetFileName(tbFilePath.Text);
                        string destPath = Path.Combine(uploadsFolderPath, fileName);

                        // Copy the file to the upload folder
                        File.Copy(tbFilePath.Text, destPath, true);

                        newTask.ResourceLink = fileName;
                        tempTask.ResourceLink = fileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }

                if (tbId.Text != "")
                {
                    context.Tasks.Update(tempTask);

                    context.TaskHistoryLogs.Add(new TaskHistoryLog
                    {
                        TaskId = tempTask.TaskId,
                        LogAction = "Update",
                        UpdatedDate = DateTime.Now,
                        Name = tempTask.Name,
                        Description = tempTask.Description,
                        EpisodeName = tempTask.EpisodeMovie.Name,
                        ReceiverName = tempTask.Receiver?.FullName,
                        DeadlineDate = tempTask.DeadlineDate,
                        SubmitedDate = tempTask.AssignedDate,
                        ResourceLink = tempTask.ResourceLink,
                        SubmitLink = tempTask.SubmitLink,
                        Status = tempTask.Status.Name,
                        Note = tempTask.Note
                    });
                }
                else
                {
                    context.Tasks.Add(newTask);
                    context.SaveChanges();

                    context.TaskHistoryLogs.Add(new TaskHistoryLog
                    {
                        TaskId = newTask.TaskId,
                        LogAction = "Create",
                        UpdatedDate = DateTime.Now,
                        Name = newTask.Name,
                        Description = newTask.Description,
                        EpisodeName = newTask.EpisodeMovie.Name,
                        ReceiverName = newTask.Receiver?.FullName,
                        DeadlineDate = newTask.DeadlineDate,
                        SubmitedDate = newTask.AssignedDate,
                        ResourceLink = newTask.ResourceLink,
                        SubmitLink = newTask.SubmitLink,
                        Status = newTask.Status.Name,
                        Note = newTask.Note
                    });
                }
                context.SaveChanges();

                MessageBox.Show("Save changes successfully.");

                formDashboard.LoadData("Task");

                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void cbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected value from cbProject
            int selectedProjectId;
            if (cbProject.SelectedValue != null && int.TryParse(cbProject.SelectedValue.ToString(), out selectedProjectId))
            {
                // Query the database to get movies based on the selected project ID
                var dataMovie = context.CartoonMovies
                    .Where(c => c.ProjectId == selectedProjectId && c.DeletedDate == null)
                    .ToList();

                if (dataMovie.Count > 0)
                {
                    cbMovie.Enabled = true;

                    // Create a placeholder item
                    var placeholder = new CartoonMovie { CartoonMovieId = -1, Name = "Please select..." };

                    dataMovie.Insert(0, placeholder); // Add placeholder to the beginning of the list

                    // Set up the data source for cbMovie
                    cbMovie.DataSource = dataMovie;
                    cbMovie.DisplayMember = "Name";
                    cbMovie.ValueMember = "CartoonMovieId";
                }
                else
                {
                    // Handle the case where no valid project is selected (optional)
                    cbMovie.DataSource = null;
                    cbMovie.Enabled = false; // Optionally disable cbMovie if no valid selection

                    cbEpisode.DataSource = null;
                    cbEpisode.Enabled = false;

                    cbTaskParent.DataSource = null;
                    cbTaskParent.Enabled = false;
                }
            }
        }

        private void cbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected value from cbProject
            int selectedProjectId;
            if (cbMovie.SelectedValue != null && int.TryParse(cbMovie.SelectedValue.ToString(), out selectedProjectId))
            {
                // Query the database to get movies based on the selected project ID
                var dataEpisode = context.EpisodeMovies
                    .Where(c => c.CartoonMovieId == selectedProjectId && c.DeletedDate == null)
                    .ToList();

                if (dataEpisode.Count > 0)
                {
                    cbEpisode.Enabled = true;

                    // Create a placeholder item
                    var placeholder = new EpisodeMovie { EpisodeMovieId = -1, Name = "Please select..." };

                    dataEpisode.Insert(0, placeholder); // Add placeholder to the beginning of the list

                    // Set up the data source for cbMovie
                    cbEpisode.DataSource = dataEpisode;
                    cbEpisode.DisplayMember = "Name";
                    cbEpisode.ValueMember = "EpisodeMovieId";
                }
                else
                {
                    // Handle the case where no valid project is selected (optional)
                    cbEpisode.DataSource = null;
                    cbEpisode.Enabled = false; // Optionally disable cbMovie if no valid selection

                    cbTaskParent.DataSource = null;
                    cbTaskParent.Enabled = false;
                }
            }
        }

        private void cbEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected value from cbProject
            int selectedProjectId;
            if (cbEpisode.SelectedValue != null && int.TryParse(cbEpisode.SelectedValue.ToString(), out selectedProjectId))
            {
                // Query the database to get movies based on the selected project ID
                var dataTask = context.Tasks
                    .Where(c => c.EpisodeMovieId == selectedProjectId && c.DeletedDate == null && c.TaskId != taskId)
                    .ToList();

                if (dataTask.Count > 0)
                {
                    cbTaskParent.Enabled = true;

                    // Create a placeholder item
                    var placeholder = new Task { EpisodeMovieId = -1, Name = "No Parent" };

                    dataTask.Insert(0, placeholder); // Add placeholder to the beginning of the list

                    // Set up the data source for cbMovie
                    cbTaskParent.DataSource = dataTask;
                    cbTaskParent.DisplayMember = "Name";
                    cbTaskParent.ValueMember = "TaskId";
                }
                else
                {
                    // Handle the case where no valid project is selected (optional)
                    cbTaskParent.DataSource = null;
                    cbTaskParent.Enabled = false; // Optionally disable cbMovie if no valid selection
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                var task = context.Tasks.FirstOrDefault(p => p.TaskId == taskId);
                if (task != null)
                {
                    task.DeletedDate = DateTime.Now;

                    context.Tasks.Update(task);

                    context.TaskHistoryLogs.Add(new TaskHistoryLog
                    {
                        TaskId = task.TaskId,
                        LogAction = "Delete",
                        UpdatedDate = DateTime.Now,
                        Name = task.Name,
                        Description = task.Description,
                        EpisodeName = task.EpisodeMovie.Name,
                        ReceiverName = task.Receiver?.FullName,
                        DeadlineDate = task.DeadlineDate,
                        SubmitedDate = task.AssignedDate,
                        ResourceLink = task.ResourceLink,
                        SubmitLink = task.SubmitLink,
                        Status = task.Status.Name,
                        Note = task.Note
                    });

                    context.SaveChanges();
                    MessageBox.Show("Deletion complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formDashboard.LoadData("Task");
                    this.Close();
                }
            }
            else
            {
                // Deletion was canceled
                MessageBox.Show("Deletion canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
