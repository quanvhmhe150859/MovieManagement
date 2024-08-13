using CartoonMovieManagement.Models;
using Microsoft.EntityFrameworkCore;
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

            if (!dataGridView1.Columns.Contains("DownloadColumn"))
            {
                // Create a new DataGridViewLinkColumn
                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                linkColumn.Name = "DownloadColumn";
                linkColumn.HeaderText = "Download";
                linkColumn.Text = "Download";
                linkColumn.UseColumnTextForLinkValue = true; // Use the text specified above as the link text

                // Add the column to the DataGridView
                dataGridView1.Columns.Add(linkColumn);
            }

            var cbData = context.Statuses
                .ToList();
            cbStatus.DataSource = cbData;
            cbStatus.DisplayMember = "Name";
            cbStatus.ValueMember = "StatusId";

            dataGridView1.DataSource = null;

            var data = context.Tasks
                .Include(t => t.Status)
                .Include(t => t.EpisodeMovie)
                .Where(t => t.ReceiverId == employeeId)
                .Select(t => new
                {
                    TaskId = t.TaskId,
                    Name = t.Name,
                    Description = t.Description,
                    CreatedDate = t.CreatedDate,
                    AssignedDate = t.AssignedDate,
                    DeadlineDate = t.DeadlineDate,
                    Status = t.Status.Name,
                    Note = t.Note,
                    ResourceLink = t.ResourceLink,
                    SubmitLink = t.SubmitLink,
                    EpisodeMovie = t.EpisodeMovie.Name
                })
                .ToList();

            dataGridView1.DataSource = data;

            dataGridView1.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["DeadlineDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var employee = context.Employees.FirstOrDefault(a => a.EmployeeId == employeeId);
            if (employee != null)
            {
                linkLabel1.Text = employee.FullName;
            }

            LoadData();

            loginForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbStatus.Enabled = false;
            tbNote.Enabled = false;
            btnUploadFile.Enabled = false;
            LoadData();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var task = context.Tasks.FirstOrDefault(t => t.TaskId == Int32.Parse(lbId.Text));
            if(task != null)
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
                        string sourceFilePath = openFileDialog.FileName;

                        // Get the file name
                        string fileName = Path.GetFileName(sourceFilePath);

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
                        File.Copy(sourceFilePath, destinationFilePath, true);

                        task.SubmitLink = fileName;
                        task.StatusId = (int?)cbStatus.SelectedValue ?? 0;
                        task.Note = tbNote.Text;

                        context.Tasks.Update(task);
                        context.SaveChanges();

                        MessageBox.Show("File uploaded successfully");
                    }
                }
            }
            else
            {
                MessageBox.Show("Task not exist");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbStatus.Enabled = true;
            tbNote.Enabled = true;
            btnUploadFile.Enabled = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Display the data in the labels
                lTaskName.Text = row.Cells["Name"].Value.ToString();
                lbId.Text = row.Cells["TaskId"].Value.ToString();

                var status = context.Statuses.FirstOrDefault(s => s.Name == row.Cells["Status"].Value.ToString());
                cbStatus.SelectedValue = status?.StatusId;
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
            // Check if the clicked cell is in the 'DownloadColumn'
            if (e.ColumnIndex == dataGridView1.Columns["DownloadColumn"].Index && e.RowIndex >= 0)
            {
                // Retrieve the data you need (e.g., file path or URL) from the corresponding row
                var filePath = dataGridView1.Rows[e.RowIndex].Cells["ResourceLink"].Value.ToString();

                // Start the download or handle the file as needed
                DownloadFile(filePath);
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
    }
}
