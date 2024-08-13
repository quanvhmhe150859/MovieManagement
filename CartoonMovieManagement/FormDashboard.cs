using CartoonMovieManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CartoonMovieManagement
{
    public partial class FormDashboard : Form
    {
        private int accountId;
        private Form1 loginForm;

        private Timer countdownTimer;

        private int selectedId;

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        public FormDashboard(int accountId, Form1 form1)
        {
            InitializeComponent();
            this.accountId = accountId;
            this.loginForm = form1;

            dgvDashboard.CellFormatting += dgvDashboard_CellFormatting;
        }

        public void LoadData(string type)
        {
            selectedId = 0;

            // Assuming the DataGridView is named dgvDashboard
            if (!dgvDashboard.Columns.Contains("Countdown"))
            {
                DataGridViewTextBoxColumn countdownColumn = new DataGridViewTextBoxColumn();
                countdownColumn.Name = "Countdown";
                countdownColumn.HeaderText = "Time Remaining";
                dgvDashboard.Columns.Insert(0, countdownColumn); // Insert at the first position
            }

            if (type == "Project")
            {
                btnCreateProject.Enabled = true;
                btnCreateMovie.Enabled = false;
                btnCreateTask.Enabled = false;
                btnCreateEpisode.Enabled = false;
                btnCreateProject.Text = "Create Project";

                dgvDashboard.DataSource = null;
                var data = context.Projects
                    .AsNoTracking()
                    .Select(p => new
                    {
                        ProjectId = p.ProjectId,
                        CategoryId = p.CategoryId,
                        Name = p.Name,
                        Description = p.Description,
                        CreatedDate = p.CreatedDate,
                        DeletedDate = p.DeletedDate,
                        Budget = p.Budget
                    })
                    .ToList();
                dgvDashboard.DataSource = data;

                dgvDashboard.Columns["ProjectId"].Visible = false;
                dgvDashboard.Columns["Countdown"].Visible = false;
                dgvDashboard.Columns["CategoryId"].HeaderText = "Category Name";
                dgvDashboard.Columns["CategoryId"].Width = 150;
                dgvDashboard.Columns["Description"].Width = 150;
            }
            else if (type == "Movie")
            {
                btnCreateProject.Enabled = false;
                btnCreateMovie.Enabled = true;
                btnCreateTask.Enabled = false;
                btnCreateEpisode.Enabled = false;
                btnCreateMovie.Text = "Create Movie";

                dgvDashboard.DataSource = null;
                var data = context.CartoonMovies
                    .AsNoTracking()
                    .Select(m => new
                    {
                        CartoonMovieId = m.CartoonMovieId,
                        ProjectId = m.ProjectId,
                        Name = m.Name,
                        Description = m.Description,
                        CreatedDate = m.CreatedDate,
                        DeletedDate = m.DeletedDate,
                        IsActive = m.IsActive
                    })
                    .ToList();
                dgvDashboard.DataSource = data;

                dgvDashboard.Columns["CartoonMovieId"].Visible = false;
                dgvDashboard.Columns["Countdown"].Visible = false;
                dgvDashboard.Columns["ProjectId"].HeaderText = "Project Name";
                dgvDashboard.Columns["ProjectId"].Width = 150;
            }
            else if (type == "Episode")
            {
                btnCreateProject.Enabled = false;
                btnCreateMovie.Enabled = false;
                btnCreateTask.Enabled = false;
                btnCreateEpisode.Enabled = true;
                btnCreateEpisode.Text = "Create Episode";

                dgvDashboard.DataSource = null;
                var data = context.EpisodeMovies
                    .AsNoTracking()
                    .Select(e => new
                    {
                        EpisodeMovieId = e.EpisodeMovieId,
                        CartoonMovieId = e.CartoonMovieId,
                        Name = e.Name,
                        Description = e.Description,
                        CreatedDate = e.CreatedDate,
                        DeletedDate = e.DeletedDate,
                        MovieLink = e.MovieLink,
                        Duration = e.Duration,
                        IsActive = e.IsActive
                    })
                    .ToList();
                dgvDashboard.DataSource = data;

                dgvDashboard.Columns["EpisodeMovieId"].Visible = false;
                dgvDashboard.Columns["CartoonMovieId"].HeaderText = "Movie Name";

                dgvDashboard.Columns["MovieLink"].Visible = false;
                dgvDashboard.Columns["Countdown"].Visible = false;

                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                linkColumn.Name = "MovieLink";
                linkColumn.DataPropertyName = "MovieLink"; // This should match your property name in the data source
                linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
                dgvDashboard.Columns.Add(linkColumn);
            }
            else if (type == "Task")
            {
                btnCreateProject.Enabled = false;
                btnCreateMovie.Enabled = false;
                btnCreateTask.Enabled = true;
                btnCreateEpisode.Enabled = false;
                btnCreateTask.Text = "Create Task";

                dgvDashboard.DataSource = null;
                var data = context.Tasks
                    .AsNoTracking()
                    .Select(t => new
                    {
                        TaskId = t.TaskId,
                        EpisodeMovieId = t.EpisodeMovieId,
                        Name = t.Name,
                        Description = t.Description,
                        CreatedDate = t.CreatedDate,
                        DeletedDate = t.DeletedDate,
                        AssignedDate = t.AssignedDate,
                        DeadlineDate = t.DeadlineDate,
                        ReceiverId = t.ReceiverId,
                        StatusId = t.StatusId,
                        Note = t.Note,
                        ResourceLink = t.ResourceLink,
                        SubmitLink = t.SubmitLink,
                        TaskParentId = t.TaskParentId
                    })
                    .ToList();
                dgvDashboard.DataSource = data;

                dgvDashboard.Columns["TaskId"].Visible = false;
                dgvDashboard.Columns["EpisodeMovieId"].HeaderText = "Episode Name";
                dgvDashboard.Columns["EpisodeMovieId"].Width = 150;
                dgvDashboard.Columns["ReceiverId"].HeaderText = "Employee Name";
                dgvDashboard.Columns["ReceiverId"].Width = 150;
                dgvDashboard.Columns["StatusId"].HeaderText = "Status";

                dgvDashboard.Columns["ResourceLink"].Visible = false;
                dgvDashboard.Columns["Countdown"].Visible = true;
                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                linkColumn.Name = "ResourceLink";
                //linkColumn.HeaderText = "Download";
                linkColumn.DataPropertyName = "ResourceLink"; // This should match your property name in the data source
                linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
                dgvDashboard.Columns.Add(linkColumn);

                foreach (DataGridViewRow row in dgvDashboard.Rows)
                {
                    if (row.Cells["DeadlineDate"].Value is DateTime deadlineDate)
                    {
                        TimeSpan timeRemaining = deadlineDate - DateTime.Now;

                        // Format the countdown based on the time remaining
                        string countdownText;
                        if (timeRemaining.TotalSeconds <= 0)
                        {
                            countdownText = "Expired";
                        }
                        else if (timeRemaining.TotalDays >= 1)
                        {
                            countdownText = $"{timeRemaining.Days} days left";
                        }
                        else if (timeRemaining.TotalHours >= 1)
                        {
                            countdownText = $"{timeRemaining.Hours} hours left";
                        }
                        else
                        {
                            countdownText = $"{timeRemaining.Minutes} minutes left";
                        }

                        row.Cells["Countdown"].Value = countdownText;
                    }
                }     
            }
        }

        private void dgvDashboard_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDashboard.Columns[e.ColumnIndex].Name == "Duration")
            {
                if (e.Value != null && e.Value is int)
                {
                    int totalMinutes = (int)e.Value;

                    // Convert total minutes to hours and minutes
                    TimeSpan time = TimeSpan.FromMinutes(totalMinutes);
                    string formattedTime = $"{time.Hours:D2}:{time.Minutes:D2}";

                    // Set the formatted value
                    e.Value = formattedTime;
                    e.FormattingApplied = true;
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "ProjectId")
            {
                if (e.Value != null)
                {
                    int projectId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var project = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                    if (project != null)
                    {
                        e.Value = project.Name;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "CategoryId")
            {
                if (e.Value != null)
                {
                    int categoryId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var category = context.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
                    if (category != null)
                    {
                        e.Value = category.Name;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "CartoonMovieId")
            {
                if (e.Value != null)
                {
                    int movieId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var movie = context.CartoonMovies.FirstOrDefault(p => p.CartoonMovieId == movieId);
                    if (movie != null)
                    {
                        e.Value = movie.Name;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "EpisodeMovieId")
            {
                if (e.Value != null)
                {
                    int episodeId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var episode = context.EpisodeMovies.FirstOrDefault(p => p.EpisodeMovieId == episodeId);
                    if (episode != null)
                    {
                        e.Value = episode.Name;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "TaskParentId")
            {
                if (e.Value != null)
                {
                    int taskId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var task = context.Tasks.FirstOrDefault(p => p.TaskId == taskId);
                    if (task != null)
                    {
                        e.Value = task.Name;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "ReceiverId")
            {
                if (e.Value != null)
                {
                    int employeeId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var employee = context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
                    if (employee != null)
                    {
                        e.Value = employee.FullName;
                        e.FormattingApplied = true;
                    }
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "StatusId")
            {
                if (e.Value != null)
                {
                    int statusId = (int)e.Value;

                    // Lookup the project name based on the projectId
                    var status = context.Statuses.FirstOrDefault(p => p.StatusId == statusId);
                    if (status != null)
                    {
                        e.Value = status.Name;
                        e.FormattingApplied = true;
                    }
                }
            }

            //if (dgvDashboard.Columns[e.ColumnIndex].Name == "ResourceLink")
            //{
            //    if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            //    {
            //        e.Value = "Download";
            //        e.FormattingApplied = true;
            //    }
            //    else
            //    {
            //        e.Value = string.Empty;
            //        e.FormattingApplied = true;
            //    }
            //}
        }

        private void InitializeCountdownTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 60000; // Update every minute
            countdownTimer.Tick += (s, e) => UpdateCountdown();
            countdownTimer.Start();
        }

        private void UpdateCountdown()
        {
            foreach (DataGridViewRow row in dgvDashboard.Rows)
            {
                if (row.Cells["DeadlineDate"].Value is DateTime deadlineDate)
                {
                    TimeSpan timeRemaining = deadlineDate - DateTime.Now;

                    string countdownText;
                    if (timeRemaining.TotalSeconds <= 0)
                    {
                        countdownText = "Expired";
                    }
                    else if (timeRemaining.TotalDays >= 1)
                    {
                        countdownText = $"{timeRemaining.Days} days left";
                    }
                    else if (timeRemaining.TotalHours >= 1)
                    {
                        countdownText = $"{timeRemaining.Hours} hours left";
                    }
                    else
                    {
                        countdownText = $"{timeRemaining.Minutes} minutes left";
                    }

                    row.Cells["Countdown"].Value = countdownText;
                }
            }
        }


        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadData("Project");
            InitializeCountdownTimer();
        }

        private void FormDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close();
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            LoadData("Project");
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            LoadData("Movie");
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            LoadData("Task");
        }

        private void btnEpisode_Click(object sender, EventArgs e)
        {
            LoadData("Episode");
        }

        private void dgvDashboard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (btnCreateProject.Enabled)
                {
                    btnCreateProject.Text = "Edit Project";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["ProjectId"].Value);
                }
                else if (btnCreateMovie.Enabled)
                {
                    btnCreateMovie.Text = "Edit Movie";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["CartoonMovieId"].Value);
                }
                else if (btnCreateTask.Enabled)
                {
                    btnCreateTask.Text = "Edit Task";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["TaskId"].Value);
                }
                else if (btnCreateEpisode.Enabled)
                {
                    btnCreateEpisode.Text = "Edit Task";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["EpisodeMovieId"].Value);
                }
            }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            FormTaskDetail formTaskDetail = new FormTaskDetail(selectedId, this);
            formTaskDetail.Show();
        }


        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            FormProjectDetail formProjectDetail = new FormProjectDetail(selectedId, this);
            formProjectDetail.Show();
        }

        private void btnCreateMovie_Click(object sender, EventArgs e)
        {
            FormMovieDetail formMovieDetail = new FormMovieDetail(selectedId, this);
            formMovieDetail.Show();
        }

        private void btnCreateEpisode_Click(object sender, EventArgs e)
        {
            FormEpisodeDetail formEpisodeDetail = new FormEpisodeDetail(selectedId, this);
            formEpisodeDetail.Show();
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDashboard.Columns[e.ColumnIndex].Name == "ResourceLink")
            {
                string resourceLink = dgvDashboard.Rows[e.RowIndex].Cells["ResourceLink"].Value.ToString();
                if (!string.IsNullOrEmpty(resourceLink))
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
                        saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string destinationPath = saveFileDialog.FileName;

                            string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                            string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Resources");
                            string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
                            string fullFilePath = Path.Combine(uploadsFolder, fileName);
                            // Here you would implement the logic to download the file to the selected path
                            // For example, using WebClient or HttpClient to download the file from resourceLink
                            using (var client = new WebClient())
                            {
                                client.DownloadFile(fullFilePath, destinationPath);
                            }

                            MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "MovieLink")
            {
                string resourceLink = dgvDashboard.Rows[e.RowIndex].Cells["MovieLink"].Value.ToString();
                if (!string.IsNullOrEmpty(resourceLink))
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
                        saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string destinationPath = saveFileDialog.FileName;

                            string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                            string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Movies");
                            string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
                            string fullFilePath = Path.Combine(uploadsFolder, fileName);

                            // Here you would implement the logic to download the file to the selected path
                            // For example, using WebClient or HttpClient to download the file from resourceLink
                            using (var client = new WebClient())
                            {
                                client.DownloadFile(fullFilePath, destinationPath);
                            }

                            MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
