using CartoonMovieManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CartoonMovieManagement
{
    public partial class Form2 : Form
    {
        private int employeeId;
        private Form1 loginForm;

        private Timer countdownTimer;

        public Form2(int employeeId, Form1 form1)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.loginForm = form1;

            //InitializeDataGridView();
            InitializeTimer();
        }

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private void LoadData()
        {
            if (!dataGridView1.Columns.Contains("Deadline"))
            {
                // Add Countdown column
                var countdownColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Deadline",
                    HeaderText = "Deadline",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = @"dd\:hh\:mm\:ss" }
                };
                dataGridView1.Columns.Insert(0, countdownColumn);
            }

            var cbStatus = context.Statuses
                .Where(s => s.ForAdmin == false)
                .ToList();
            this.cbStatus.DataSource = cbStatus;
            this.cbStatus.DisplayMember = "Name";
            this.cbStatus.ValueMember = "StatusId";

            dataGridView1.DataSource = null;

            // Step 1: Extract the EpisodeMovieId values from uniqueEpisodeIdList
            var episodeMovieIds = new List<int>();

            foreach (var item in cbEpisode.Items)
            {
                var episodeMovie = item as dynamic; // Use 'dynamic' if it's an anonymous type, or cast to the specific type
                episodeMovieIds.Add(episodeMovie.EpisodeMovieId);
            }

            // Step 2: Query to get tasks where EpisodeMovieId is in the episodeMovieIds list
            var data = context.Tasks
                .Include(t => t.Status)
                .Include(t => t.EpisodeMovie)
                .Include(t => t.Status)
                .AsNoTracking()
                .Where(t => episodeMovieIds.Contains(t.EpisodeMovieId) && t.Status.Name != "Not Start" && t.DeletedDate == null)
                .Select(t => new
                {
                    TaskId = t.TaskId,
                    Name = t.Name,
                    Description = t.Description,
                    //AssignedDate = t.AssignedDate,
                    DeadlineDate = t.DeadlineDate,
                    ReceiverId = t.ReceiverId,
                    Status = t.Status.Name,
                    Note = t.Note,
                    ResourceLink = t.ResourceLink,
                    SubmitLink = t.SubmitLink,
                    EpisodeMovie = t.EpisodeMovie.Name,
                    EpisodeMovieId = t.EpisodeMovieId
                })
                .ToList();

            if ((int?)cbEpisode.SelectedValue != -1)
                data = data.Where(t => t.EpisodeMovieId == (int?)cbEpisode.SelectedValue).ToList();

            dataGridView1.DataSource = data;

            dataGridView1.Columns["DeadlineDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["TaskId"].Visible = false;
            dataGridView1.Columns["EpisodeMovieId"].Visible = false;
            dataGridView1.Columns["ReceiverId"].Visible = false;
            dataGridView1.Columns["ResourceLink"].Visible = false;
            dataGridView1.Columns["SubmitLink"].Visible = false;
            dataGridView1.Columns["DeadlineDate"].HeaderText = "Deadline Date";
            dataGridView1.Columns["EpisodeMovie"].HeaderText = "Episode Movie";

            if (!dataGridView1.Columns.Contains("DownloadColumn"))
            {
                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                linkColumn.Name = "Resource Link";
                //linkColumn.HeaderText = "Download";
                linkColumn.DataPropertyName = "ResourceLink"; // This should match your property name in the data source
                linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
                dataGridView1.Columns.Insert(1, linkColumn);

                DataGridViewLinkColumn linkColumn2 = new DataGridViewLinkColumn();
                linkColumn2.Name = "Submit Link";
                //linkColumn.HeaderText = "Download";
                linkColumn2.DataPropertyName = "SubmitLink"; // This should match your property name in the data source
                linkColumn2.LinkBehavior = LinkBehavior.AlwaysUnderline;

                // Add the column to the DataGridView
                dataGridView1.Columns.Insert(2, linkColumn2);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var employee = context.Employees.FirstOrDefault(a => a.EmployeeId == employeeId);
            if (employee != null)
            {
                linkLabel1.Text = employee.FullName;
            }

            // Get a list of unique EpisodeId values from the Tasks table
            var uniqueEpisodeIdList = context.Tasks
                .Include(t => t.EpisodeMovie)
                .Where(t => t.ReceiverId == employeeId && t.Status.Name != "Not Start" && t.DeletedDate == null)
                .Select(t => new { EpisodeMovieName = t.EpisodeMovie.Name, t.EpisodeMovieId })  // Create an anonymous type
                .Distinct()  // Apply Distinct to get unique combinations of EpisodeMovieName and EpisodeMovieId
                .ToList();

            // Create a placeholder item
            var placeholder = new { EpisodeMovieName = "All", EpisodeMovieId = -1 };

            // Insert the placeholder at the beginning of the list
            uniqueEpisodeIdList.Insert(0, placeholder);

            // Bind the list to the ComboBox
            cbEpisode.DataSource = uniqueEpisodeIdList;
            cbEpisode.DisplayMember = "EpisodeMovieName";  // Display the EpisodeMovieName in the ComboBox
            cbEpisode.ValueMember = "EpisodeMovieId";  // Use EpisodeMovieId as the value

            LoadData();

            loginForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbStatus.Enabled = false;
            tbNote.Enabled = false;
            btnUploadFile.Enabled = false;
            btnSubmit.Enabled = false;
            LoadData();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    tbFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Display the data in the labels
                lTaskName.Text = row.Cells["Name"].Value.ToString();
                lbId.Text = row.Cells["TaskId"].Value.ToString();
                tbNote.Text = row.Cells["Note"].Value?.ToString();
                tbFile.Text = row.Cells["SubmitLink"].Value?.ToString();

                var status = context.Statuses.FirstOrDefault(s => s.Name == row.Cells["Status"].Value.ToString());
                cbStatus.SelectedValue = status?.StatusId;

                if (status.Name == "Passed" ||
                    (row.Cells["DeadlineDate"].Value != null &&
                    Convert.ToDateTime(row.Cells["DeadlineDate"].Value) < DateTime.Now) ||
                    (row.Cells["ReceiverId"].Value != null &&
                    employeeId != Convert.ToInt32(row.Cells["ReceiverId"].Value)))
                {
                    cbStatus.Enabled = false;
                    tbNote.Enabled = false;
                    btnUploadFile.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                else
                {
                    cbStatus.Enabled = true;
                    tbNote.Enabled = true;
                    btnUploadFile.Enabled = true;
                    btnSubmit.Enabled = true;
                }


            }
        }

        //private void InitializeDataGridView()
        //{
        //    dataTable = new DataTable();
        //    dataTable.Columns.Add("Task");
        //    dataTable.Columns.Add("Countdown", typeof(TimeSpan));

        //    // Add some example data
        //    dataTable.Rows.Add("Task 1", TimeSpan.FromMinutes(5));
        //    dataTable.Rows.Add("Task 2", TimeSpan.FromMinutes(10));
        //    dataTable.Rows.Add("Task 3", TimeSpan.FromMinutes(15));

        //    dataGridView1.DataSource = dataTable;

        //    // Optionally set columns width
        //    dataGridView1.Columns["Task"].Width = 150;
        //    dataGridView1.Columns["Countdown"].Width = 100;
        //}

        private void InitializeTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1 second interval
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var deadlineDateCell = row.Cells["DeadlineDate"];
                if (deadlineDateCell.Value is DateTime deadlineDate)
                {
                    TimeSpan countdown = deadlineDate - DateTime.Now;
                    if (countdown.TotalSeconds <= 0)
                    {
                        countdown = TimeSpan.Zero;
                    }
                    row.Cells["Deadline"].Value = countdown;
                }
            }
            dataGridView1.Refresh(); // Refresh to update UI
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ResourceLink")
            {
                string resourceLink = dataGridView1.Rows[e.RowIndex].Cells["ResourceLink"].Value.ToString();
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

            if (dataGridView1.Columns[e.ColumnIndex].Name == "SubmitLink")
            {
                string resourceLink = dataGridView1.Rows[e.RowIndex].Cells["SubmitLink"].Value.ToString();
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
        }

        //private void DownloadFile(string filePath)
        //{
        //    try
        //    {
        //        // Ensure the file exists
        //        if (System.IO.File.Exists(filePath))
        //        {
        //            // Open the file with its associated application
        //            System.Diagnostics.Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        //        }
        //        else
        //        {
        //            MessageBox.Show("File not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //}

        private void DownloadFile(string fileUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    // Extract the file name from the URL
                    string fileName = Path.GetFileName(new Uri(fileUrl).AbsolutePath);

                    // Define the local path, for example, on the Desktop
                    string localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                    // Download the file with its original name
                    webClient.DownloadFile(fileUrl, localPath);

                    // Optionally, open the downloaded file
                    System.Diagnostics.Process.Start(new ProcessStartInfo(localPath) { UseShellExecute = true });

                    MessageBox.Show($"Download completed. File saved to: {localPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var task = context.Tasks.Include(t => t.EpisodeMovie).FirstOrDefault(t => t.TaskId == Int32.Parse(lbId.Text));
            if (task != null)
            {
                // Get the file name
                string fileName = Path.GetFileName(tbFile.Text);

                if (!fileName.IsNullOrEmpty())
                {
                    // Get the path to the "Uploads" folder
                    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                    string uploadsFolderPath = Path.Combine(projectDirectory, "Uploads", "Results");

                    // Ensure the "Uploads" folder exists
                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        Directory.CreateDirectory(uploadsFolderPath);
                    }

                    // Combine the destination folder path and file name
                    string destinationFilePath = Path.Combine(uploadsFolderPath, fileName);

                    // Copy the file to the "Uploads" folder
                    File.Copy(tbFile.Text, destinationFilePath, true);

                    task.SubmitLink = fileName;
                }

                task.StatusId = (int?)cbStatus.SelectedValue ?? 0;
                task.Note = tbNote.Text;

                context.Tasks.Update(task);

                context.TaskHistoryLogs.Add(new TaskHistoryLog
                {
                    TaskId = task.TaskId,
                    LogAction = "Submit",
                    UpdatedDate = DateTime.Now,
                    Name = task.Name,
                    Description = task.Description,
                    EpisodeName = task.EpisodeMovie?.Name ?? "N/A", // Handle null EpisodeMovie
                    ReceiverName = task.Receiver?.FullName ?? "N/A", // Handle null Receiver
                    DeadlineDate = task.DeadlineDate,
                    SubmitedDate = task.AssignedDate,
                    ResourceLink = task.ResourceLink,
                    SubmitLink = task.SubmitLink,
                    Status = task.Status?.Name ?? "Unknown", // Handle null Status
                    Note = task.Note
                });

                context.SaveChanges();

                MessageBox.Show("Submit successfully");
            }
            else
            {
                MessageBox.Show("Task not found");
            }
        }

        private void btnGetTask_Click(object sender, EventArgs e)
        {
            FormTaskRegister formTaskRegister = new FormTaskRegister(employeeId);
            formTaskRegister.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormProfile formProfile = new FormProfile(employeeId, "Employee", null);
            formProfile.Show();
        }
    }
}
