namespace CartoonMovieManagement
{
    partial class FormDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvDashboard = new DataGridView();
            btnProject = new Button();
            btnMovie = new Button();
            btnTask = new Button();
            btnCreateTask = new Button();
            btnCreateMovie = new Button();
            btnCreateProject = new Button();
            btnCreateEpisode = new Button();
            btnEpisode = new Button();
            label1 = new Label();
            tbSearch = new TextBox();
            panel1 = new Panel();
            checkActive = new CheckBox();
            btnStatusSetting = new Button();
            btnTaskLog = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDashboard
            // 
            dgvDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Location = new Point(12, 12);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.Size = new Size(658, 426);
            dgvDashboard.TabIndex = 0;
            dgvDashboard.CellClick += dgvDashboard_CellClick;
            dgvDashboard.CellContentClick += dgvDashboard_CellContentClick;
            dgvDashboard.CellDoubleClick += dgvDashboard_CellDoubleClick;
            // 
            // btnProject
            // 
            btnProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProject.Location = new Point(3, 0);
            btnProject.Name = "btnProject";
            btnProject.Size = new Size(89, 32);
            btnProject.TabIndex = 1;
            btnProject.Text = "Project";
            btnProject.UseVisualStyleBackColor = true;
            btnProject.Click += btnProject_Click;
            // 
            // btnMovie
            // 
            btnMovie.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMovie.Location = new Point(3, 38);
            btnMovie.Name = "btnMovie";
            btnMovie.Size = new Size(89, 32);
            btnMovie.TabIndex = 2;
            btnMovie.Text = "Movie";
            btnMovie.UseVisualStyleBackColor = true;
            btnMovie.Click += btnMovie_Click;
            // 
            // btnTask
            // 
            btnTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTask.Location = new Point(3, 114);
            btnTask.Name = "btnTask";
            btnTask.Size = new Size(89, 32);
            btnTask.TabIndex = 3;
            btnTask.Text = "Task";
            btnTask.UseVisualStyleBackColor = true;
            btnTask.Click += btnTask_Click;
            // 
            // btnCreateTask
            // 
            btnCreateTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateTask.Location = new Point(98, 114);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.Size = new Size(106, 32);
            btnCreateTask.TabIndex = 6;
            btnCreateTask.Text = "Create Task";
            btnCreateTask.UseVisualStyleBackColor = true;
            btnCreateTask.Click += btnCreateTask_Click;
            // 
            // btnCreateMovie
            // 
            btnCreateMovie.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateMovie.Location = new Point(98, 38);
            btnCreateMovie.Name = "btnCreateMovie";
            btnCreateMovie.Size = new Size(106, 32);
            btnCreateMovie.TabIndex = 5;
            btnCreateMovie.Text = "Create Movie";
            btnCreateMovie.UseVisualStyleBackColor = true;
            btnCreateMovie.Click += btnCreateMovie_Click;
            // 
            // btnCreateProject
            // 
            btnCreateProject.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateProject.Location = new Point(98, 0);
            btnCreateProject.Name = "btnCreateProject";
            btnCreateProject.Size = new Size(106, 32);
            btnCreateProject.TabIndex = 4;
            btnCreateProject.Text = "Create Project";
            btnCreateProject.UseVisualStyleBackColor = true;
            btnCreateProject.Click += btnCreateProject_Click;
            // 
            // btnCreateEpisode
            // 
            btnCreateEpisode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateEpisode.Location = new Point(98, 76);
            btnCreateEpisode.Name = "btnCreateEpisode";
            btnCreateEpisode.Size = new Size(106, 32);
            btnCreateEpisode.TabIndex = 8;
            btnCreateEpisode.Text = "Create Episode";
            btnCreateEpisode.UseVisualStyleBackColor = true;
            btnCreateEpisode.Click += btnCreateEpisode_Click;
            // 
            // btnEpisode
            // 
            btnEpisode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEpisode.Location = new Point(3, 76);
            btnEpisode.Name = "btnEpisode";
            btnEpisode.Size = new Size(89, 32);
            btnEpisode.TabIndex = 7;
            btnEpisode.Text = "Episode";
            btnEpisode.UseVisualStyleBackColor = true;
            btnEpisode.Click += btnEpisode_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(3, 153);
            label1.Name = "label1";
            label1.Size = new Size(54, 17);
            label1.TabIndex = 9;
            label1.Text = "Search: ";
            // 
            // tbSearch
            // 
            tbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbSearch.Location = new Point(63, 152);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(141, 23);
            tbSearch.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(checkActive);
            panel1.Controls.Add(btnCreateMovie);
            panel1.Controls.Add(tbSearch);
            panel1.Controls.Add(btnProject);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnMovie);
            panel1.Controls.Add(btnCreateEpisode);
            panel1.Controls.Add(btnTask);
            panel1.Controls.Add(btnEpisode);
            panel1.Controls.Add(btnCreateProject);
            panel1.Controls.Add(btnCreateTask);
            panel1.Location = new Point(676, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(207, 229);
            panel1.TabIndex = 11;
            // 
            // checkActive
            // 
            checkActive.AutoSize = true;
            checkActive.Font = new Font("Segoe UI", 9F);
            checkActive.Location = new Point(135, 181);
            checkActive.Name = "checkActive";
            checkActive.RightToLeft = RightToLeft.No;
            checkActive.Size = new Size(69, 19);
            checkActive.TabIndex = 40;
            checkActive.Text = " Deleted";
            checkActive.UseVisualStyleBackColor = true;
            // 
            // btnStatusSetting
            // 
            btnStatusSetting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStatusSetting.Location = new Point(794, 406);
            btnStatusSetting.Name = "btnStatusSetting";
            btnStatusSetting.Size = new Size(89, 32);
            btnStatusSetting.TabIndex = 12;
            btnStatusSetting.Text = "Status Setting";
            btnStatusSetting.UseVisualStyleBackColor = true;
            btnStatusSetting.Click += btnStatusSetting_Click;
            // 
            // btnTaskLog
            // 
            btnTaskLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTaskLog.Location = new Point(679, 406);
            btnTaskLog.Name = "btnTaskLog";
            btnTaskLog.Size = new Size(89, 32);
            btnTaskLog.TabIndex = 13;
            btnTaskLog.Text = "Task Log";
            btnTaskLog.UseVisualStyleBackColor = true;
            btnTaskLog.Click += btnTaskLog_Click;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 450);
            Controls.Add(btnTaskLog);
            Controls.Add(btnStatusSetting);
            Controls.Add(panel1);
            Controls.Add(dgvDashboard);
            Name = "FormDashboard";
            Text = "FormDashboard";
            FormClosed += FormDashboard_FormClosed;
            Load += FormDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDashboard;
        private Button btnProject;
        private Button btnMovie;
        private Button btnTask;
        private Button btnCreateTask;
        private Button btnCreateMovie;
        private Button btnCreateProject;
        private Button btnCreateEpisode;
        private Button btnEpisode;
        private Label label1;
        private TextBox tbSearch;
        private Panel panel1;
        private CheckBox checkActive;
        private Button btnStatusSetting;
        private Button btnTaskLog;
    }
}