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
        public int accountId;
        private Form1 loginForm;

        private Timer countdownTimer;

        private int selectedId;
        private string selectedName;

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
            selectedName = "";
            string key = tbSearch.Text.ToLower();
            bool del = checkActive.Checked;

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
                    .Where(p => p.Name.ToLower().Contains(key))
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

                if (del)
                    data = data.Where(p => p.DeletedDate != null).ToList();
                else
                    data = data.Where(p => p.DeletedDate == null).ToList();

                dgvDashboard.DataSource = data;

                dgvDashboard.Columns["ProjectId"].Visible = false;
                dgvDashboard.Columns["Countdown"].Visible = false;
                dgvDashboard.Columns["CategoryId"].HeaderText = "Category Name";
                dgvDashboard.Columns["CategoryId"].Width = 150;
                dgvDashboard.Columns["CreatedDate"].HeaderText = "Created Date";
                dgvDashboard.Columns["DeletedDate"].HeaderText = "Deleted Date";
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
                    .Include(p => p.Project)
                    .AsNoTracking()
                    .Where(p => /*p.Project.DeletedDate == null &&*/
                        (p.Name.ToLower().Contains(key) ||
                        p.Project.Name.ToLower().Contains(key)))
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

                if (del)
                    data = data.Where(p => p.DeletedDate != null).ToList();
                else
                    data = data.Where(p => p.DeletedDate == null).ToList();

                dgvDashboard.DataSource = data;

                dgvDashboard.Columns["CartoonMovieId"].Visible = false;
                dgvDashboard.Columns["Countdown"].Visible = false;
                dgvDashboard.Columns["ProjectId"].HeaderText = "Project Name";
                dgvDashboard.Columns["ProjectId"].Width = 150;
                dgvDashboard.Columns["CreatedDate"].HeaderText = "Created Date";
                dgvDashboard.Columns["DeletedDate"].HeaderText = "Deleted Date";
                dgvDashboard.Columns["IsActive"].HeaderText = "Is Active";
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
                    .Include(p => p.CartoonMovie)
                    //.ThenInclude(cm => cm.Project)
                    .AsNoTracking()
                    .Where(p => /*p.CartoonMovie.DeletedDate == null &&
                        p.CartoonMovie.Project.DeletedDate == null &&*/
                        (p.Name.ToLower().Contains(key) ||
                        p.CartoonMovie.Name.ToLower().Contains(key)))
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

                if (del)
                    data = data.Where(p => p.DeletedDate != null).ToList();
                else
                    data = data.Where(p => p.DeletedDate == null).ToList();

                dgvDashboard.DataSource = data;

                dgvDashboard.Columns["EpisodeMovieId"].Visible = false;
                dgvDashboard.Columns["CartoonMovieId"].HeaderText = "Movie Name";
                dgvDashboard.Columns["CreatedDate"].HeaderText = "Created Date";
                dgvDashboard.Columns["DeletedDate"].HeaderText = "Deleted Date";
                dgvDashboard.Columns["IsActive"].HeaderText = "Is Active";
                dgvDashboard.Columns["MovieLink"].HeaderText = "Movie Link";

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
                    .Include(p => p.EpisodeMovie)
                    //.ThenInclude(em => em.CartoonMovie)
                    //.ThenInclude(cm => cm.Project)
                    .AsNoTracking()
                    .Where(p => /*p.EpisodeMovie.DeletedDate == null &&
                        p.EpisodeMovie.CartoonMovie.DeletedDate == null &&
                        p.EpisodeMovie.CartoonMovie.Project.DeletedDate == null &&*/
                        (p.Name.ToLower().Contains(key) ||
                        p.EpisodeMovie.Name.ToLower().Contains(key)))
                    .Select(t => new
                    {
                        EpisodeMovieId = t.EpisodeMovieId,
                        Name = t.Name,
                        Description = t.Description,
                        CreatedDate = t.CreatedDate,
                        AssignedDate = t.AssignedDate,
                        DeletedDate = t.DeletedDate,
                        DeadlineDate = t.DeadlineDate,
                        ReceiverId = t.ReceiverId,
                        StatusId = t.StatusId,
                        Note = t.Note,
                        ResourceLink = t.ResourceLink,
                        SubmitLink = t.SubmitLink,
                        TaskParentId = t.TaskParentId,
                        TaskId = t.TaskId
                    })
                    .ToList();

                if (del)
                    data = data.Where(p => p.DeletedDate != null).ToList();
                else
                    data = data.Where(p => p.DeletedDate == null).ToList();

                dgvDashboard.DataSource = data;

                //dgvDashboard.Columns["TaskId"].Visible = false;
                dgvDashboard.Columns["EpisodeMovieId"].HeaderText = "Episode Name";
                dgvDashboard.Columns["EpisodeMovieId"].Width = 150;
                dgvDashboard.Columns["ReceiverId"].HeaderText = "Employee Name";
                dgvDashboard.Columns["ReceiverId"].Width = 150;
                dgvDashboard.Columns["StatusId"].HeaderText = "Status";
                dgvDashboard.Columns["CreatedDate"].HeaderText = "Created Date";
                dgvDashboard.Columns["DeletedDate"].HeaderText = "Deleted Date";
                dgvDashboard.Columns["AssignedDate"].HeaderText = "Submit Date";
                dgvDashboard.Columns["DeadlineDate"].HeaderText = "Deadline Date";
                dgvDashboard.Columns["TaskParentId"].HeaderText = "Task Parent";
                dgvDashboard.Columns["ResourceLink"].HeaderText = "Resource Link";
                dgvDashboard.Columns["SubmitLink"].HeaderText = "Submit Link";

                dgvDashboard.Columns["ResourceLink"].Visible = false;
                dgvDashboard.Columns["Countdown"].Visible = true;

                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                linkColumn.Name = "ResourceLink";
                //linkColumn.HeaderText = "Download";
                linkColumn.DataPropertyName = "ResourceLink"; // This should match your property name in the data source
                linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
                dgvDashboard.Columns.Add(linkColumn);

                dgvDashboard.Columns["SubmitLink"].Visible = false;
                DataGridViewLinkColumn linkColumn2 = new DataGridViewLinkColumn();
                linkColumn2.Name = "SubmitLink";
                //linkColumn.HeaderText = "Download";
                linkColumn2.DataPropertyName = "SubmitLink"; // This should match your property name in the data source
                linkColumn2.LinkBehavior = LinkBehavior.AlwaysUnderline;
                dgvDashboard.Columns.Add(linkColumn2);

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
            if (!dgvDashboard.Columns.Contains("DeadlineDate"))
            {
                // If the column doesn't exist, simply return to avoid errors
                return;
            }

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
                    selectedName = "Project";
                }
                else if (btnCreateMovie.Enabled)
                {
                    btnCreateMovie.Text = "Edit Movie";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["CartoonMovieId"].Value);
                    selectedName = "Movie";
                }
                else if (btnCreateEpisode.Enabled)
                {
                    btnCreateEpisode.Text = "Edit Episode";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["EpisodeMovieId"].Value);
                    selectedName = "Episode";
                }
                else if (btnCreateTask.Enabled)
                {
                    btnCreateTask.Text = "Edit Task";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["TaskId"].Value);
                    selectedName = "Task";
                }
            }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            FormTaskDetail formTaskDetail = new FormTaskDetail(selectedId, this, 0, 0, 0);
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

            if (dgvDashboard.Columns[e.ColumnIndex].Name == "SubmitLink")
            {
                string resourceLink = dgvDashboard.Rows[e.RowIndex].Cells["SubmitLink"].Value.ToString();
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
                            string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Results");
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

        private void btnStatusSetting_Click(object sender, EventArgs e)
        {
            FormStatusSetting formStatusSetting = new FormStatusSetting();
            formStatusSetting.Show();
        }

        private void dgvDashboard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedName == "Project")
            {
                FormTaskDetail formTaskDetail = new FormTaskDetail(0, this, selectedId, 0, 0);
                formTaskDetail.Show();
            }
            else if (selectedName == "Movie")
            {
                var movie = context.CartoonMovies.FirstOrDefault(m => m.CartoonMovieId == selectedId);
                FormTaskDetail formTaskDetail = new FormTaskDetail(0, this, movie?.ProjectId, selectedId, 0);
                formTaskDetail.Show();
            }
            else if (selectedName == "Episode")
            {
                var episode = context.EpisodeMovies.Include(e => e.CartoonMovie).FirstOrDefault(e => e.EpisodeMovieId == selectedId);
                FormTaskDetail formTaskDetail = new FormTaskDetail(0, this, episode?.CartoonMovie.ProjectId, episode?.CartoonMovieId, selectedId);
                formTaskDetail.Show();
            }
        }

        private void btnTaskLog_Click(object sender, EventArgs e)
        {
            FormHistoryLog formHistoryLog = new FormHistoryLog();
            formHistoryLog.Show();
        }
    }
}
