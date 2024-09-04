using CartoonMovieManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public partial class FormSubmit : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private int taskId;
        private FormMain formMain;

        public FormSubmit(int taskId, FormMain formMain)
        {
            InitializeComponent();
            this.taskId = taskId;
            this.formMain = formMain;
        }

        private void FormSubmit_Load(object sender, EventArgs e)
        {
            var task = context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                lbId.Text = task.TaskId.ToString();
                lTaskName.Text = task.Name;
                tbNote.Text = task.Note;
                tbFile.Text = task.SubmitLink;

                var status = context.Statuses
                .Where(s => s.ForAdmin == false)
                .ToList();
                cbStatus.DataSource = status;
                cbStatus.DisplayMember = "Name";
                cbStatus.ValueMember = "StatusId";

                cbStatus.SelectedValue = task.StatusId;
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var task = context.Tasks
                .Include(t => t.EpisodeMovie)
                .Include(t => t.Receiver)
                .FirstOrDefault(t => t.TaskId == Int32.Parse(lbId.Text));
            if (task != null)
            {
                // Get the file name
                string fileName = Path.GetFileName(tbFile.Text);

                if (!fileName.IsNullOrEmpty() && task.SubmitLink != fileName)
                {
                    // Get the path to the "Uploads" folder
                    string? projectDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
                    if (projectDirectory != null)
                    {
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
                }
                else
                {
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

                formMain.LoadTaskEmployee(task.ReceiverId ?? 0);
				formMain.LoadTreeView("Employee");
                this.Close();
            }
            else
            {
                MessageBox.Show("Task not found");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbFile.Text = string.Empty;
        }
    }
}
