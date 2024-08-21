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

namespace CartoonMovieManagement
{
    public partial class FormHistoryLog : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();
        private FormDashboard formDashboard;
        private string type;
        private Button btnEditTask = new Button();
        private int selectedId;

        public FormHistoryLog(string type, FormDashboard formDashboard)
        {
            InitializeComponent();
            this.formDashboard = formDashboard;
            this.type = type;
        }

        private void FormHistoryLog_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (type == "Task")
            {
                this.Controls.Remove(btnEditTask);

                Button btnRequestList = new Button();
                btnRequestList.Location = new Point(93, 12);
                btnRequestList.Name = "btnRequestList";
                btnRequestList.Size = new Size(102, 23);
                btnRequestList.TabIndex = 2;
                btnRequestList.Text = "Request List";
                btnRequestList.UseVisualStyleBackColor = true;
                btnRequestList.Click += btnRequestList_Click;
                this.Controls.Add(btnRequestList);

                dataGridView1.DataSource = null;
                var data = context.TaskHistoryLogs
                    .OrderByDescending(t => t.TaskHistoryLogId)
                    .ToList();
                dataGridView1.DataSource = data;

                dataGridView1.Columns["Task"].Visible = false;
                dataGridView1.Columns["TaskHistoryLogId"].Visible = false;
                dataGridView1.Columns["TaskId"].HeaderText = "Task Id";
                dataGridView1.Columns["LogAction"].HeaderText = "Log Action";
                dataGridView1.Columns["UpdatedDate"].HeaderText = "Updated Date";
                dataGridView1.Columns["EpisodeName"].HeaderText = "Episode";
                dataGridView1.Columns["ReceiverName"].HeaderText = "Receiver";
                dataGridView1.Columns["DeadlineDate"].HeaderText = "Deadline Date";
                dataGridView1.Columns["SubmitLink"].HeaderText = "Submit Link";
                dataGridView1.Columns["SubmitedDate"].Visible = false;
                dataGridView1.Columns["ResourceLink"].Visible = false;
                dataGridView1.Columns["UpdatedDate"].Width = 150;
                dataGridView1.Columns["DeadlineDate"].Width = 150;

                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                linkColumn.Name = "ResourceLink";
                linkColumn.HeaderText = "Resource Link";
                linkColumn.DataPropertyName = "ResourceLink"; // This should match your property name in the data source
                linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
                dataGridView1.Columns.Add(linkColumn);
                linkColumn.DisplayIndex = 12;

                dataGridView1.Columns["SubmitLink"].Visible = false;
                DataGridViewLinkColumn linkColumn2 = new DataGridViewLinkColumn();
                linkColumn2.Name = "SubmitLink";
                linkColumn2.HeaderText = "Submit Link";
                linkColumn2.DataPropertyName = "SubmitLink"; // This should match your property name in the data source
                linkColumn2.LinkBehavior = LinkBehavior.AlwaysUnderline;
                dataGridView1.Columns.Add(linkColumn2);
                linkColumn2.DisplayIndex = 13;

                dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            }
            else if (type == "Salary")
            {
                dataGridView1.DataSource = null;
                var data = context.SalaryChangeLogs
                    .Select(m => new
                    {
                        SalaryChangeLogId = m.SalaryChangeLogId,
                        Employee = m.Employee.FullName,
                        Change = m.Change,
                        CreatedDate = m.CreatedDate,
                        Provider = m.Account.Email,
                        Note = m.Note
                    })
                    .OrderByDescending(m => m.SalaryChangeLogId)
                    .ToList();
                dataGridView1.DataSource = data;

                dataGridView1.Columns["SalaryChangeLogId"].Visible = false;
                dataGridView1.Columns["Note"].MinimumWidth = 300;
                dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["CreatedDate"].HeaderText = "Created Date";
                dataGridView1.Columns["CreatedDate"].Width = 150;

            }
        }

        private void btnRequestList_Click(object? sender, EventArgs e)
        {
            btnEditTask.Enabled = false;
            btnEditTask.Location = new Point(673, 12);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(75, 23);
            btnEditTask.TabIndex = 3;
            btnEditTask.Text = "Edit Task";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += btnEditTask_Click;
            this.Controls.Add(btnEditTask);

            dataGridView1.DataSource = null;
            var data = context.TaskHistoryLogs
                .Include(d => d.Task)
                .Where(d => d.LogAction == "Request taking" && d.Task.ReceiverId == null && 
                    d.Task.DeletedDate == null)
                .OrderByDescending(t => t.TaskHistoryLogId)
                .ToList();
            dataGridView1.DataSource = data;

            dataGridView1.Columns["Task"].Visible = false;
            dataGridView1.Columns["TaskHistoryLogId"].Visible = false;
            dataGridView1.Columns["TaskId"].HeaderText = "Task Id";
            dataGridView1.Columns["LogAction"].HeaderText = "Log Action";
            dataGridView1.Columns["UpdatedDate"].HeaderText = "Updated Date";
            dataGridView1.Columns["EpisodeName"].HeaderText = "Episode";
            dataGridView1.Columns["ReceiverName"].HeaderText = "Receiver";
            dataGridView1.Columns["DeadlineDate"].HeaderText = "Deadline Date";
            dataGridView1.Columns["SubmitLink"].HeaderText = "Submit Link";
            dataGridView1.Columns["SubmitedDate"].Visible = false;
            dataGridView1.Columns["ResourceLink"].Visible = false;
            dataGridView1.Columns["UpdatedDate"].Width = 150;
            dataGridView1.Columns["DeadlineDate"].Width = 150;

            DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
            linkColumn.Name = "ResourceLink";
            linkColumn.HeaderText = "Resource Link";
            linkColumn.DataPropertyName = "ResourceLink"; // This should match your property name in the data source
            linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
            dataGridView1.Columns.Add(linkColumn);
            linkColumn.DisplayIndex = 12;

            dataGridView1.Columns["SubmitLink"].Visible = false;
            DataGridViewLinkColumn linkColumn2 = new DataGridViewLinkColumn();
            linkColumn2.Name = "SubmitLink";
            linkColumn2.HeaderText = "Submit Link";
            linkColumn2.DataPropertyName = "SubmitLink"; // This should match your property name in the data source
            linkColumn2.LinkBehavior = LinkBehavior.AlwaysUnderline;
            dataGridView1.Columns.Add(linkColumn2);
            linkColumn2.DisplayIndex = 13;

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void btnEditTask_Click(object? sender, EventArgs e)
        {
            var taskHistory = context.TaskHistoryLogs
                .Include(t => t.Task)
                .ThenInclude(t => t.EpisodeMovie)
                .ThenInclude(t => t.CartoonMovie)
                .FirstOrDefault(t => t.TaskHistoryLogId == selectedId);
            if (taskHistory != null)
            {
                var employee = context.Employees.FirstOrDefault(e => e.FullName == taskHistory.ReceiverName);
                //var task = context.Tasks.FirstOrDefault(t => t.TaskId == taskHistory.TaskId);
                //var episode = context.EpisodeMovies.FirstOrDefault(e => e.EpisodeMovieId == task.EpisodeMovieId);
                //var movie = context.CartoonMovies.FirstOrDefault(m => m.CartoonMovieId == episode.CartoonMovieId);
                if (employee != null)
                {
                    FormTaskDetail formTaskDetail = new FormTaskDetail(taskHistory.TaskId, formDashboard,
                        taskHistory.Task.EpisodeMovie.CartoonMovie.ProjectId,
                        taskHistory.Task.EpisodeMovie.CartoonMovieId,
                        taskHistory.Task.EpisodeMovieId,
                        employee.EmployeeId);
                    formTaskDetail.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TaskHistoryLogId"].Value);
                if (selectedId != 0)
                    btnEditTask.Enabled = true;
                else btnEditTask.Enabled = false;
            }
        }
    }
}
