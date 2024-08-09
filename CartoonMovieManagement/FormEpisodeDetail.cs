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
        private int? taskId;
        private FormDashboard formDashboard;
        private string selectedVideoPath;

        CartoonProductManagementContext context = new CartoonProductManagementContext();

        public FormEpisodeDetail(int? id, FormDashboard formDashboard)
        {
            InitializeComponent();
            taskId = id;
            this.formDashboard = formDashboard;
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

                    // Play the video in the Windows Media Player control
                    axWindowsMediaPlayer1.URL = selectedVideoPath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();7
                }
            }
        }
    }
}
