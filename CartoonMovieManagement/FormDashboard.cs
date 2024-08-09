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
        }

        public void LoadData(string type)
        {
            selectedId = 0;

            if (type == "Project")
            {
                btnCreateProject.Enabled = true;
                btnCreateMovie.Enabled = false;
                btnCreateTask.Enabled = false;
                btnCreateEpisode.Enabled = false;
                btnCreateProject.Text = "Create Project";

                dgvDashboard.DataSource = null;
                var data = context.Projects.AsNoTracking().ToList();
                dgvDashboard.DataSource = data;
            }
            else if (type == "Movie")
            {
                btnCreateProject.Enabled = false;
                btnCreateMovie.Enabled = true;
                btnCreateTask.Enabled = false;
                btnCreateEpisode.Enabled = false;
                btnCreateMovie.Text = "Create Movie";

                dgvDashboard.DataSource = null;
                var data = context.CartoonMovies.AsNoTracking().ToList();
                dgvDashboard.DataSource = data;
            }
            else if (type == "Task")
            {
                btnCreateProject.Enabled = false;
                btnCreateMovie.Enabled = false;
                btnCreateTask.Enabled = true;
                btnCreateEpisode.Enabled = false;
                btnCreateTask.Text = "Create Task";

                dgvDashboard.DataSource = null;
                var data = context.Tasks.AsNoTracking().ToList();
                dgvDashboard.DataSource = data;
                //InitializeTimer();
            }
            else if (type == "Episode")
            {
                btnCreateProject.Enabled = false;
                btnCreateMovie.Enabled = false;
                btnCreateTask.Enabled = false;
                btnCreateEpisode.Enabled = true;
                btnCreateEpisode.Text = "Create Episode";

                dgvDashboard.DataSource = null;
                var data = context.EpisodeMovies.AsNoTracking().ToList();
                dgvDashboard.DataSource = data;
            }
        }

        private void InitializeTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1 second interval
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDashboard.Rows)
            {
                if (row.Cells["Deadline"].Value is TimeSpan countdown)
                {
                    TimeSpan updatedCountdown = countdown - TimeSpan.FromSeconds(1);
                    if (updatedCountdown.TotalSeconds <= 0)
                    {
                        updatedCountdown = TimeSpan.Zero;
                    }
                    row.Cells["Deadline"].Value = updatedCountdown;
                }
            }
            dgvDashboard.Refresh(); // Refresh to update UI
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadData("Project");
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
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["MovieId"].Value);
                }
                else if (btnCreateTask.Enabled)
                {
                    btnCreateTask.Text = "Edit Task";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["TaskId"].Value);
                }
                else if (btnCreateEpisode.Enabled)
                {
                    btnCreateEpisode.Text = "Edit Task";
                    selectedId = Convert.ToInt32(dgvDashboard.Rows[e.RowIndex].Cells["EpisodeId"].Value);
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
    }
}
