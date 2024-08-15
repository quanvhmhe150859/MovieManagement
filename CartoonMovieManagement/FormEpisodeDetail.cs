using CartoonMovieManagement.Models;
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
        private FormDashboard formDashboard;
        private string? selectedVideoPath;
        private double videoDuration;

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        public FormEpisodeDetail(int? id, FormDashboard formDashboard)
        {
            InitializeComponent();
            episodeId = id;
            this.formDashboard = formDashboard;
        }

        private void FormEpisodeDetail_Load(object sender, EventArgs e)
        {
            if(episodeId != 0)
                CreateDeleteButton();

            // Create a placeholder item
            var placeholder = new Project { ProjectId = -1, Name = "Please select..." };

            // Retrieve the data and add the placeholder item
            var dataProject = context.Projects.Where(p => p.DeletedDate == null).ToList();
            dataProject.Insert(0, placeholder); // Add placeholder to the beginning of the list

            // Set the data source and configure the ComboBox
            cbProject.DataSource = dataProject;
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "ProjectId";

            if (episodeId != 0)
            {
                var episode = context.EpisodeMovies.FirstOrDefault(e => e.EpisodeMovieId == episodeId);
                var movie = context.CartoonMovies.FirstOrDefault(m => m.CartoonMovieId == episode.CartoonMovieId);

                tbId.Text = episode?.EpisodeMovieId.ToString();
                tbName.Text = episode?.Name;
                tbDescription.Text = episode?.Description;
                cbProject.SelectedValue = movie?.ProjectId;
                cbMovie.SelectedValue = episode?.CartoonMovieId;
                tbDuration.Text = $"{TimeSpan.FromSeconds((double?)episode?.Duration ?? 0):hh\\:mm\\:ss}";

                // Load and play the video
                string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                string uploadsFolder = Path.Combine("Uploads", "Movies");
                string fullVideoPath = Path.Combine(projectRootPath, uploadsFolder, episode.MovieLink);

                axWindowsMediaPlayer1.URL = fullVideoPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void CreateDeleteButton()
        {
            // Create a new button
            Button btnDelete = new Button();

            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
            btnDelete.Location = new Point(1049, 512);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(136, 35);
            btnDelete.TabIndex = 49;
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
            else if (string.IsNullOrEmpty(selectedVideoPath) && episodeId == 0)
                MessageBox.Show("Please upload a video before submitting.");
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
                    string projectRootPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;

                    string uploadsFolderPath = Path.Combine(projectRootPath, "Uploads", "Movies");

                    // Generate the destination file path
                    string fileName = Path.GetFileName(selectedVideoPath);
                    string destinationPath = Path.Combine(uploadsFolderPath, fileName);

                    // Save the file to the Uploads folder
                    File.Copy(selectedVideoPath, destinationPath, true);

                    episodeMovie.MovieLink = fileName;//destinationPath;
                    episodeMovie.Duration = Convert.ToInt32(videoDuration);
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
                MessageBox.Show("Video uploaded and saved successfully!");
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

        private void btnDelete_Click(object sender, EventArgs e)
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
                    formDashboard.LoadData("Episode");
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
