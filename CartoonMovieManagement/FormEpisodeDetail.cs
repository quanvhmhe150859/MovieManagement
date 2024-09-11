using CartoonMovieManagement.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.Devices;
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
    public partial class FormEpisodeDetail : Form
    {
        private int? episodeId;
        private FormMain formDashboard;
        private string? selectedVideoPath;
        private double videoDuration;

        Button btnDelete = new Button();

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        public FormEpisodeDetail(int? id, FormMain formDashboard)
        {
            InitializeComponent();
            episodeId = id;
            this.formDashboard = formDashboard;
        }

        public void UpdateData(int selectedId)
        {
            // Update the form's data based on the new selectedId
            episodeId = selectedId;
            // Refresh the form with the new data as needed
            LoadData();
        }

        private void LoadData()
        {
            var account = context.Accounts.FirstOrDefault(a => a.AccountId == formDashboard.accountId);
            if (account != null)
            {
                var permission = context.Permissions
                    .FirstOrDefault(p => p.RoleId == account.RoleId && p.TypeId == 1);
                if (permission != null && permission.Delete && episodeId != 0)
                    CreateDeleteButton();
                else
                    DeleteDeleteButton();
            }
            else
            {
                MessageBox.Show("Error");
                this.Close();
            }

            if (episodeId != 0)
            {
                var episode = context.EpisodeMovies.FirstOrDefault(e => e.EpisodeMovieId == episodeId);
                if(episode != null)
                {
                    var movie = context.CartoonMovies.FirstOrDefault(m => m.CartoonMovieId == episode.CartoonMovieId);

                    tbId.Text = episode?.EpisodeMovieId.ToString();
                    tbName.Text = episode?.Name;
                    tbDescription.Text = episode?.Description;
                    cbProject.SelectedValue = movie?.ProjectId;
                    cbMovie.SelectedValue = episode?.CartoonMovieId;
                    tbDuration.Text = $"{TimeSpan.FromSeconds((double?)episode?.Duration ?? 0):hh\\:mm\\:ss}";

                    // Load and play the video
                    if (episode != null && !episode.MovieLink.IsNullOrEmpty())
                    {
                        string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
                        string uploadsFolder = Path.Combine("Uploads", "Movies");
                        if(projectRootPath != null)
                        {
                            string fullVideoPath = Path.Combine(projectRootPath, uploadsFolder, episode.MovieLink ?? "");

                            axWindowsMediaPlayer1.URL = fullVideoPath;
                            axWindowsMediaPlayer1.Ctlcontrols.play();
                        }
                    }
                }
            }
            else
            {
                tbId.Text = string.Empty;
                tbName.Text = string.Empty;
                tbDescription.Text = string.Empty;
                cbProject.SelectedIndex = 0;
                tbDuration.Text = string.Empty;

                selectedVideoPath = string.Empty;
                //// Stop the current video
                //axWindowsMediaPlayer1.Ctlcontrols.stop();

                //// Clear the URL to remove the loaded video
                //axWindowsMediaPlayer1.URL = string.Empty;
            }
        }

        private void FormEpisodeDetail_Load(object sender, EventArgs e)
        {
            // Create a placeholder item
            var placeholder = new Project { ProjectId = -1, Name = "Please select..." };

            // Retrieve the data and add the placeholder item
            var dataProject = context.Projects.Where(p => p.DeletedDate == null).ToList();
            dataProject.Insert(0, placeholder); // Add placeholder to the beginning of the list

            // Set the data source and configure the ComboBox
            cbProject.DataSource = dataProject;
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "ProjectId";

            LoadData();
        }

        private void CreateDeleteButton()
        {
            // Create a new button
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
			btnDelete.Location = new Point(2543, 1399);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(330, 96);
			btnDelete.TabIndex = 49;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

			// Add the button to the form
			this.Controls.Add(btnDelete);
        }

        private void DeleteDeleteButton()
        {
            this.Controls.Remove(btnDelete);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.wmv;*.mov";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected video file path
                    selectedVideoPath = openFileDialog.FileName;

                    tbMovieLink.Text = selectedVideoPath;
                    // Play the video in the Windows Media Player control
                    axWindowsMediaPlayer1.URL = selectedVideoPath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();

                    // Wait for the media to load and retrieve its duration
                    axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer1_PlayStateChange);
                }
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Get the duration of the video in seconds
                videoDuration = axWindowsMediaPlayer1.currentMedia.duration;

                // Display the duration in a label or MessageBox
                tbDuration.Text = $"{TimeSpan.FromSeconds(videoDuration):hh\\:mm\\:ss}";

                // Stop the video from playing (optional)
                //axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
                MessageBox.Show("Need Name");
            //else if (string.IsNullOrEmpty(selectedVideoPath) && episodeId == 0)
            //    MessageBox.Show("Please upload a video before submitting.");
            else
            {
                EpisodeMovie episodeMovie = new EpisodeMovie
                {
                    Name = tbName.Text,
                    CartoonMovieId = (int?)cbMovie.SelectedValue ?? 0,
                    Description = tbDescription.Text,
                    IsActive = checkActive.Checked,
                    CreatedDate = DateTime.Now,
                    ReleasedDate = DateTime.Now //chua lam
                };

                if (!string.IsNullOrEmpty(selectedVideoPath))
                {
                    // Ensure the Uploads folder exists
                    string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
                    if(projectRootPath != null)
                    {
                        string uploadsFolderPath = Path.Combine(projectRootPath, "Uploads", "Movies");

                        // Generate the destination file path
                        string fileName = Path.GetFileName(selectedVideoPath);
                        string destinationPath = Path.Combine(uploadsFolderPath, fileName);

                        // Save the file to the Uploads folder
                        File.Copy(selectedVideoPath, destinationPath, true);

                        episodeMovie.MovieLink = fileName;//destinationPath;
                        episodeMovie.Duration = Convert.ToInt32(videoDuration);
                    }
                }

                if (episodeId == 0)
                {
                    context.EpisodeMovies.Add(episodeMovie);
                }
                else
                {
                    var episode = context.EpisodeMovies.FirstOrDefault(e => e.EpisodeMovieId == episodeId);
                    if (episode != null)
                    {
                        episode.CartoonMovieId = episodeMovie.CartoonMovieId;
                        episode.Name = episodeMovie.Name;
                        episode.Description = episodeMovie.Description;
                        episode.IsActive = episodeMovie.IsActive;
                        episode.ReleasedDate = DateTime.Now;
                        if (!string.IsNullOrEmpty(selectedVideoPath))
                        {
                            episode.MovieLink = episodeMovie.MovieLink;
                            episode.Duration = episodeMovie.Duration;
                        }

                        context.EpisodeMovies.Update(episode);
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Save successfully");

                formDashboard.LoadData("Episode", formDashboard.dgvDataEpisode);
                formDashboard.LoadTreeView("Project");
                this.Close();
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
                }
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            // Show a confirmation message box
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                var episode = context.EpisodeMovies.FirstOrDefault(p => p.EpisodeMovieId == episodeId);
                if (episode != null)
                {
                    episode.DeletedDate = DateTime.Now;

                    context.EpisodeMovies.Update(episode);

                    var tasks = context.Tasks.Where(t => t.EpisodeMovieId == episode.EpisodeMovieId).ToList();
                    foreach (var task in tasks)
                    {
                        task.DeletedDate = DateTime.Now;

                        context.Tasks.Update(task);
                    }

                    context.SaveChanges();
                    MessageBox.Show("Deletion complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //formDashboard.LoadData("Episode");
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
