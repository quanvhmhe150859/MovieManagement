namespace CartoonMovieManagement
{
    partial class FormEpisodeDetail
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEpisodeDetail));
			label4 = new Label();
			checkActive = new CheckBox();
			cbProject = new ComboBox();
			label7 = new Label();
			tbId = new TextBox();
			btnSubmit = new Button();
			tbDescription = new TextBox();
			tbName = new TextBox();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			cbMovie = new ComboBox();
			label5 = new Label();
			tbMovieLink = new TextBox();
			label8 = new Label();
			axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
			btnUpload = new Button();
			tbDuration = new TextBox();
			label9 = new Label();
			((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
			SuspendLayout();
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label4.Location = new Point(29, 836);
			label4.Margin = new Padding(7, 0, 7, 0);
			label4.Name = "label4";
			label4.Size = new Size(180, 65);
			label4.TabIndex = 39;
			label4.Text = "Active: ";
			// 
			// checkActive
			// 
			checkActive.AutoSize = true;
			checkActive.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			checkActive.Location = new Point(328, 834);
			checkActive.Margin = new Padding(7, 8, 7, 8);
			checkActive.Name = "checkActive";
			checkActive.RightToLeft = RightToLeft.No;
			checkActive.Size = new Size(79, 69);
			checkActive.TabIndex = 38;
			checkActive.Text = " ";
			checkActive.UseVisualStyleBackColor = true;
			// 
			// cbProject
			// 
			cbProject.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbProject.FormattingEnabled = true;
			cbProject.Location = new Point(328, 161);
			cbProject.Margin = new Padding(7, 8, 7, 8);
			cbProject.Name = "cbProject";
			cbProject.Size = new Size(922, 70);
			cbProject.TabIndex = 37;
			cbProject.SelectedIndexChanged += cbProject_SelectedIndexChanged;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label7.Location = new Point(29, 169);
			label7.Margin = new Padding(7, 0, 7, 0);
			label7.Name = "label7";
			label7.Size = new Size(198, 65);
			label7.TabIndex = 36;
			label7.Text = "Project: ";
			// 
			// tbId
			// 
			tbId.Enabled = false;
			tbId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbId.Location = new Point(447, 22);
			tbId.Margin = new Padding(7, 8, 7, 8);
			tbId.Name = "tbId";
			tbId.Size = new Size(269, 71);
			tbId.TabIndex = 35;
			// 
			// btnSubmit
			// 
			btnSubmit.Anchor = AnchorStyles.Bottom;
			btnSubmit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnSubmit.Location = new Point(1270, 1399);
			btnSubmit.Margin = new Padding(7, 8, 7, 8);
			btnSubmit.Name = "btnSubmit";
			btnSubmit.Size = new Size(330, 96);
			btnSubmit.TabIndex = 34;
			btnSubmit.Text = "Submit";
			btnSubmit.UseVisualStyleBackColor = true;
			btnSubmit.Click += btnSubmit_Click;
			// 
			// tbDescription
			// 
			tbDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbDescription.Location = new Point(328, 481);
			tbDescription.Margin = new Padding(7, 8, 7, 8);
			tbDescription.Multiline = true;
			tbDescription.Name = "tbDescription";
			tbDescription.Size = new Size(922, 223);
			tbDescription.TabIndex = 33;
			// 
			// tbName
			// 
			tbName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbName.Location = new Point(328, 374);
			tbName.Margin = new Padding(7, 8, 7, 8);
			tbName.Name = "tbName";
			tbName.Size = new Size(922, 71);
			tbName.TabIndex = 32;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label3.Location = new Point(29, 481);
			label3.Margin = new Padding(7, 0, 7, 0);
			label3.Name = "label3";
			label3.Size = new Size(292, 65);
			label3.TabIndex = 31;
			label3.Text = "Description: ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label2.Location = new Point(29, 383);
			label2.Margin = new Padding(7, 0, 7, 0);
			label2.Name = "label2";
			label2.Size = new Size(177, 65);
			label2.TabIndex = 30;
			label2.Text = "Name: ";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label1.Location = new Point(29, 25);
			label1.Margin = new Padding(7, 0, 7, 0);
			label1.Name = "label1";
			label1.Size = new Size(411, 81);
			label1.TabIndex = 29;
			label1.Text = "Episode Detail";
			// 
			// cbMovie
			// 
			cbMovie.Enabled = false;
			cbMovie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbMovie.FormattingEnabled = true;
			cbMovie.Location = new Point(328, 268);
			cbMovie.Margin = new Padding(7, 8, 7, 8);
			cbMovie.Name = "cbMovie";
			cbMovie.Size = new Size(922, 70);
			cbMovie.TabIndex = 41;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label5.Location = new Point(29, 276);
			label5.Margin = new Padding(7, 0, 7, 0);
			label5.Name = "label5";
			label5.Size = new Size(182, 65);
			label5.TabIndex = 40;
			label5.Text = "Movie: ";
			// 
			// tbMovieLink
			// 
			tbMovieLink.Enabled = false;
			tbMovieLink.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbMovieLink.Location = new Point(1817, 36);
			tbMovieLink.Margin = new Padding(7, 8, 7, 8);
			tbMovieLink.Name = "tbMovieLink";
			tbMovieLink.Size = new Size(1056, 71);
			tbMovieLink.TabIndex = 43;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label8.Location = new Point(1270, 44);
			label8.Margin = new Padding(7, 0, 7, 0);
			label8.Name = "label8";
			label8.Size = new Size(182, 65);
			label8.TabIndex = 44;
			label8.Text = "Movie: ";
			// 
			// axWindowsMediaPlayer1
			// 
			axWindowsMediaPlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			axWindowsMediaPlayer1.Enabled = true;
			axWindowsMediaPlayer1.Location = new Point(1270, 161);
			axWindowsMediaPlayer1.Margin = new Padding(7, 8, 7, 8);
			axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
			axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
			axWindowsMediaPlayer1.Size = new Size(1603, 742);
			axWindowsMediaPlayer1.TabIndex = 45;
			// 
			// btnUpload
			// 
			btnUpload.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnUpload.Location = new Point(1462, 33);
			btnUpload.Margin = new Padding(7, 8, 7, 8);
			btnUpload.Name = "btnUpload";
			btnUpload.Size = new Size(340, 90);
			btnUpload.TabIndex = 46;
			btnUpload.Text = "Upload Video";
			btnUpload.UseVisualStyleBackColor = true;
			btnUpload.Click += btnUpload_Click;
			// 
			// tbDuration
			// 
			tbDuration.Enabled = false;
			tbDuration.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbDuration.Location = new Point(328, 727);
			tbDuration.Margin = new Padding(7, 8, 7, 8);
			tbDuration.Name = "tbDuration";
			tbDuration.Size = new Size(922, 71);
			tbDuration.TabIndex = 48;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label9.Location = new Point(29, 735);
			label9.Margin = new Padding(7, 0, 7, 0);
			label9.Name = "label9";
			label9.Size = new Size(236, 65);
			label9.TabIndex = 47;
			label9.Text = "Duration: ";
			// 
			// FormEpisodeDetail
			// 
			AutoScaleDimensions = new SizeF(17F, 41F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(2907, 1528);
			Controls.Add(tbDuration);
			Controls.Add(label9);
			Controls.Add(btnUpload);
			Controls.Add(axWindowsMediaPlayer1);
			Controls.Add(label8);
			Controls.Add(tbMovieLink);
			Controls.Add(cbMovie);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(checkActive);
			Controls.Add(cbProject);
			Controls.Add(label7);
			Controls.Add(tbId);
			Controls.Add(btnSubmit);
			Controls.Add(tbDescription);
			Controls.Add(tbName);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Margin = new Padding(7, 8, 7, 8);
			Name = "FormEpisodeDetail";
			Text = "FormEpisodeDetail";
			Load += FormEpisodeDetail_Load;
			((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label4;
        private CheckBox checkActive;
        private ComboBox cbProject;
        private Label label7;
        private TextBox tbId;
        private Button btnSubmit;
        private TextBox tbDescription;
        private TextBox tbName;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbMovie;
        private Label label5;
        private TextBox tbMovieLink;
        private Label label8;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button btnUpload;
        private TextBox tbDuration;
        private Label label9;
	}
}