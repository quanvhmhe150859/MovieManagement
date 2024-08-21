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
    public partial class FormTaskRegister : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        private int employeeId;
        private int selectedId;

        public FormTaskRegister(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }

        private void LoadData()
        {
            btnRegister.Enabled = false;
            selectedId = 0;

            dataGridView1.DataSource = null;

            // Step 1: Extract the EpisodeMovieId values from uniqueEpisodeIdList
            var episodeMovieIds = new List<int>();

            foreach (var item in cbEpisode.Items)
            {
                var episodeMovie = item as dynamic; // Use 'dynamic' if it's an anonymous type, or cast to the specific type
                episodeMovieIds.Add(episodeMovie.EpisodeMovieId);
            }

            var taskLogIds = new List<int>();
            var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                var taskHistoryLogs = context.TaskHistoryLogs
                    .Where(t => t.ReceiverName == employee.FullName && t.LogAction == "Request taking")
                    .ToList();
                foreach (var item in taskHistoryLogs)
                {
                    var taskLogId = item as dynamic; // Use 'dynamic' if it's an anonymous type, or cast to the specific type
                    taskLogIds.Add(taskLogId.TaskId);
                }
            }
            // Step 2: Query to get tasks where EpisodeMovieId is in the episodeMovieIds list
            var data = context.Tasks
                .Include(t => t.Status)
                .Include(t => t.EpisodeMovie)
                .Include(t => t.Status)
                .AsNoTracking()
                .Where(t => episodeMovieIds.Contains(t.EpisodeMovieId) && 
                    t.StatusId == 7 && t.DeletedDate == null && !taskLogIds.Contains(t.TaskId))
                .Select(t => new
                {
                    TaskId = t.TaskId,
                    Name = t.Name,
                    Description = t.Description,
                    //AssignedDate = t.AssignedDate,
                    DeadlineDate = t.DeadlineDate,
                    Status = t.Status.Name,
                    Note = t.Note,
                    ResourceLink = t.ResourceLink,
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
            dataGridView1.Columns["ResourceLink"].Visible = false;
            dataGridView1.Columns["DeadlineDate"].HeaderText = "Deadline Date";
            dataGridView1.Columns["EpisodeMovie"].HeaderText = "Episode Movie";
        }

        private void FormTaskRegister_Load(object sender, EventArgs e)
        {
            // Get a list of unique EpisodeId values from the Tasks table
            var uniqueEpisodeIdList = context.Tasks
                .Include(t => t.EpisodeMovie)
                .Where(t => t.StatusId == 7 && t.DeletedDate == null)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TaskId"].Value);
                if (selectedId != 0)
                    btnRegister.Enabled = true;
                else btnRegister.Enabled = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var task = context.Tasks
                .Include(t => t.EpisodeMovie)
                .Include(t => t.Status)
                .FirstOrDefault(t => t.TaskId == selectedId && t.ReceiverId == null);
            var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (task != null && employee != null)
            {
                context.TaskHistoryLogs.Add(new TaskHistoryLog
                {
                    TaskId = task.TaskId,
                    LogAction = "Request taking",
                    UpdatedDate = DateTime.Now,
                    Name = task.Name,
                    Description = task.Description,
                    EpisodeName = task.EpisodeMovie.Name,
                    ReceiverName = employee.FullName,
                    DeadlineDate = task.DeadlineDate,
                    SubmitedDate = task.AssignedDate,
                    ResourceLink = task.ResourceLink,
                    SubmitLink = task.SubmitLink,
                    Status = task.Status.Name,
                    Note = task.Note
                });
                context.SaveChanges();

                LoadData();
                MessageBox.Show("Register task successful, wait for approved", task.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Task not found");
        }
    }
}
