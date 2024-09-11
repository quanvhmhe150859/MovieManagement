namespace CartoonMovieManagement
{
    partial class FormTaskDetail
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
			tbDescription = new TextBox();
			tbName = new TextBox();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			dtbDeadLine = new DateTimePicker();
			cbStatus = new ComboBox();
			label7 = new Label();
			tbFilePath = new TextBox();
			label5 = new Label();
			btnUpload = new Button();
			btnSubmit = new Button();
			cbEmployee = new ComboBox();
			label6 = new Label();
			cbProject = new ComboBox();
			label8 = new Label();
			cbMovie = new ComboBox();
			label9 = new Label();
			cbEpisode = new ComboBox();
			label10 = new Label();
			cbTaskParent = new ComboBox();
			label11 = new Label();
			errorProject = new Label();
			errorMovie = new Label();
			errorEpisode = new Label();
			errorName = new Label();
			errorDeadline = new Label();
			tbId = new TextBox();
			btnClear = new Button();
			SuspendLayout();
			// 
			// tbDescription
			// 
			tbDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbDescription.Location = new Point(384, 702);
			tbDescription.Margin = new Padding(7, 8, 7, 8);
			tbDescription.Multiline = true;
			tbDescription.Name = "tbDescription";
			tbDescription.Size = new Size(922, 223);
			tbDescription.TabIndex = 16;
			// 
			// tbName
			// 
			tbName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbName.Location = new Point(384, 596);
			tbName.Margin = new Padding(7, 8, 7, 8);
			tbName.Name = "tbName";
			tbName.Size = new Size(922, 71);
			tbName.TabIndex = 15;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label4.Location = new Point(29, 948);
			label4.Margin = new Padding(7, 0, 7, 0);
			label4.Name = "label4";
			label4.Size = new Size(350, 65);
			label4.TabIndex = 13;
			label4.Text = "Deadline Date: ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label3.Location = new Point(29, 702);
			label3.Margin = new Padding(7, 0, 7, 0);
			label3.Name = "label3";
			label3.Size = new Size(292, 65);
			label3.TabIndex = 12;
			label3.Text = "Description: ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label2.Location = new Point(29, 604);
			label2.Margin = new Padding(7, 0, 7, 0);
			label2.Name = "label2";
			label2.Size = new Size(177, 65);
			label2.TabIndex = 11;
			label2.Text = "Name: ";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label1.Location = new Point(29, 25);
			label1.Margin = new Padding(7, 0, 7, 0);
			label1.Name = "label1";
			label1.Size = new Size(315, 81);
			label1.TabIndex = 10;
			label1.Text = "Task Detail";
			// 
			// dtbDeadLine
			// 
			dtbDeadLine.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			dtbDeadLine.Location = new Point(384, 948);
			dtbDeadLine.Margin = new Padding(7, 8, 7, 8);
			dtbDeadLine.Name = "dtbDeadLine";
			dtbDeadLine.Size = new Size(922, 71);
			dtbDeadLine.TabIndex = 20;
			// 
			// cbStatus
			// 
			cbStatus.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbStatus.FormattingEnabled = true;
			cbStatus.Location = new Point(384, 1055);
			cbStatus.Margin = new Padding(7, 8, 7, 8);
			cbStatus.Name = "cbStatus";
			cbStatus.Size = new Size(922, 70);
			cbStatus.TabIndex = 22;
			cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label7.Location = new Point(29, 1063);
			label7.Margin = new Padding(7, 0, 7, 0);
			label7.Name = "label7";
			label7.Size = new Size(178, 65);
			label7.TabIndex = 21;
			label7.Text = "Status: ";
			// 
			// tbFilePath
			// 
			tbFilePath.Enabled = false;
			tbFilePath.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbFilePath.Location = new Point(384, 1162);
			tbFilePath.Margin = new Padding(7, 8, 7, 8);
			tbFilePath.Name = "tbFilePath";
			tbFilePath.Size = new Size(922, 71);
			tbFilePath.TabIndex = 24;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label5.Location = new Point(29, 1170);
			label5.Margin = new Padding(7, 0, 7, 0);
			label5.Name = "label5";
			label5.Size = new Size(348, 65);
			label5.TabIndex = 23;
			label5.Text = "Resource Path: ";
			// 
			// btnUpload
			// 
			btnUpload.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnUpload.Location = new Point(1326, 1162);
			btnUpload.Margin = new Padding(7, 8, 7, 8);
			btnUpload.Name = "btnUpload";
			btnUpload.Size = new Size(313, 90);
			btnUpload.TabIndex = 25;
			btnUpload.Text = "Upload File";
			btnUpload.UseVisualStyleBackColor = true;
			btnUpload.Click += btnUpload_Click;
			// 
			// btnSubmit
			// 
			btnSubmit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnSubmit.Location = new Point(828, 1588);
			btnSubmit.Margin = new Padding(7, 8, 7, 8);
			btnSubmit.Name = "btnSubmit";
			btnSubmit.Size = new Size(313, 87);
			btnSubmit.TabIndex = 26;
			btnSubmit.Text = "Submit";
			btnSubmit.UseVisualStyleBackColor = true;
			btnSubmit.Click += btnSubmit_Click;
			// 
			// cbEmployee
			// 
			cbEmployee.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbEmployee.FormattingEnabled = true;
			cbEmployee.Location = new Point(384, 1268);
			cbEmployee.Margin = new Padding(7, 8, 7, 8);
			cbEmployee.Name = "cbEmployee";
			cbEmployee.Size = new Size(922, 70);
			cbEmployee.TabIndex = 28;
			cbEmployee.SelectedIndexChanged += cbEmployee_SelectedIndexChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label6.Location = new Point(29, 1276);
			label6.Margin = new Padding(7, 0, 7, 0);
			label6.Name = "label6";
			label6.Size = new Size(228, 65);
			label6.TabIndex = 27;
			label6.Text = "Receiver: ";
			// 
			// cbProject
			// 
			cbProject.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbProject.FormattingEnabled = true;
			cbProject.Location = new Point(384, 169);
			cbProject.Margin = new Padding(7, 8, 7, 8);
			cbProject.Name = "cbProject";
			cbProject.Size = new Size(922, 70);
			cbProject.TabIndex = 30;
			cbProject.SelectedIndexChanged += cbProject_SelectedIndexChanged;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label8.Location = new Point(29, 178);
			label8.Margin = new Padding(7, 0, 7, 0);
			label8.Name = "label8";
			label8.Size = new Size(198, 65);
			label8.TabIndex = 29;
			label8.Text = "Project: ";
			// 
			// cbMovie
			// 
			cbMovie.Enabled = false;
			cbMovie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbMovie.FormattingEnabled = true;
			cbMovie.Location = new Point(384, 276);
			cbMovie.Margin = new Padding(7, 8, 7, 8);
			cbMovie.Name = "cbMovie";
			cbMovie.Size = new Size(922, 70);
			cbMovie.TabIndex = 32;
			cbMovie.SelectedIndexChanged += cbMovie_SelectedIndexChanged;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label9.Location = new Point(29, 284);
			label9.Margin = new Padding(7, 0, 7, 0);
			label9.Name = "label9";
			label9.Size = new Size(182, 65);
			label9.TabIndex = 31;
			label9.Text = "Movie: ";
			// 
			// cbEpisode
			// 
			cbEpisode.Enabled = false;
			cbEpisode.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbEpisode.FormattingEnabled = true;
			cbEpisode.Location = new Point(384, 383);
			cbEpisode.Margin = new Padding(7, 8, 7, 8);
			cbEpisode.Name = "cbEpisode";
			cbEpisode.Size = new Size(922, 70);
			cbEpisode.TabIndex = 34;
			cbEpisode.SelectedIndexChanged += cbEpisode_SelectedIndexChanged;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label10.Location = new Point(29, 391);
			label10.Margin = new Padding(7, 0, 7, 0);
			label10.Name = "label10";
			label10.Size = new Size(216, 65);
			label10.TabIndex = 33;
			label10.Text = "Episode: ";
			// 
			// cbTaskParent
			// 
			cbTaskParent.Enabled = false;
			cbTaskParent.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbTaskParent.FormattingEnabled = true;
			cbTaskParent.Location = new Point(384, 489);
			cbTaskParent.Margin = new Padding(7, 8, 7, 8);
			cbTaskParent.Name = "cbTaskParent";
			cbTaskParent.Size = new Size(922, 70);
			cbTaskParent.TabIndex = 36;
			cbTaskParent.SelectedIndexChanged += cbTaskParent_SelectedIndexChanged;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label11.Location = new Point(29, 497);
			label11.Margin = new Padding(7, 0, 7, 0);
			label11.Name = "label11";
			label11.Size = new Size(286, 65);
			label11.TabIndex = 35;
			label11.Text = "Task Parent: ";
			// 
			// errorProject
			// 
			errorProject.AutoSize = true;
			errorProject.ForeColor = Color.Red;
			errorProject.Location = new Point(1326, 200);
			errorProject.Margin = new Padding(7, 0, 7, 0);
			errorProject.Name = "errorProject";
			errorProject.Size = new Size(113, 41);
			errorProject.TabIndex = 37;
			errorProject.Text = "label12";
			// 
			// errorMovie
			// 
			errorMovie.AutoSize = true;
			errorMovie.ForeColor = Color.Red;
			errorMovie.Location = new Point(1326, 312);
			errorMovie.Margin = new Padding(7, 0, 7, 0);
			errorMovie.Name = "errorMovie";
			errorMovie.Size = new Size(113, 41);
			errorMovie.TabIndex = 38;
			errorMovie.Text = "label12";
			// 
			// errorEpisode
			// 
			errorEpisode.AutoSize = true;
			errorEpisode.ForeColor = Color.Red;
			errorEpisode.Location = new Point(1326, 418);
			errorEpisode.Margin = new Padding(7, 0, 7, 0);
			errorEpisode.Name = "errorEpisode";
			errorEpisode.Size = new Size(113, 41);
			errorEpisode.TabIndex = 39;
			errorEpisode.Text = "label12";
			// 
			// errorName
			// 
			errorName.AutoSize = true;
			errorName.ForeColor = Color.Red;
			errorName.Location = new Point(1326, 631);
			errorName.Margin = new Padding(7, 0, 7, 0);
			errorName.Name = "errorName";
			errorName.Size = new Size(113, 41);
			errorName.TabIndex = 40;
			errorName.Text = "label12";
			// 
			// errorDeadline
			// 
			errorDeadline.AutoSize = true;
			errorDeadline.ForeColor = Color.Red;
			errorDeadline.Location = new Point(1326, 987);
			errorDeadline.Margin = new Padding(7, 0, 7, 0);
			errorDeadline.Name = "errorDeadline";
			errorDeadline.Size = new Size(113, 41);
			errorDeadline.TabIndex = 41;
			errorDeadline.Text = "label12";
			// 
			// tbId
			// 
			tbId.Enabled = false;
			tbId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbId.Location = new Point(384, 22);
			tbId.Margin = new Padding(7, 8, 7, 8);
			tbId.Name = "tbId";
			tbId.Size = new Size(213, 71);
			tbId.TabIndex = 42;
			// 
			// btnClear
			// 
			btnClear.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnClear.Location = new Point(1654, 1162);
			btnClear.Margin = new Padding(7, 8, 7, 8);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(192, 90);
			btnClear.TabIndex = 43;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// FormTaskDetail
			// 
			AutoScaleDimensions = new SizeF(17F, 41F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1943, 1708);
			Controls.Add(btnClear);
			Controls.Add(tbId);
			Controls.Add(errorDeadline);
			Controls.Add(errorName);
			Controls.Add(errorEpisode);
			Controls.Add(errorMovie);
			Controls.Add(errorProject);
			Controls.Add(cbTaskParent);
			Controls.Add(label11);
			Controls.Add(cbEpisode);
			Controls.Add(label10);
			Controls.Add(cbMovie);
			Controls.Add(label9);
			Controls.Add(cbProject);
			Controls.Add(label8);
			Controls.Add(cbEmployee);
			Controls.Add(label6);
			Controls.Add(btnSubmit);
			Controls.Add(btnUpload);
			Controls.Add(tbFilePath);
			Controls.Add(label5);
			Controls.Add(cbStatus);
			Controls.Add(label7);
			Controls.Add(dtbDeadLine);
			Controls.Add(tbDescription);
			Controls.Add(tbName);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Margin = new Padding(7, 8, 7, 8);
			Name = "FormTaskDetail";
			Text = "FormTaskDetail";
			Load += FormTaskDetail_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox tbDescription;
        private TextBox tbName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtbDeadLine;
        private ComboBox cbStatus;
        private Label label7;
        private TextBox tbFilePath;
        private Label label5;
        private Button btnUpload;
        private Button btnSubmit;
        private ComboBox cbEmployee;
        private Label label6;
        private ComboBox cbProject;
        private Label label8;
        private ComboBox cbMovie;
        private Label label9;
        private ComboBox cbEpisode;
        private Label label10;
        private ComboBox cbTaskParent;
        private Label label11;
        private Label errorProject;
        private Label errorMovie;
        private Label errorEpisode;
        private Label errorName;
        private Label errorDeadline;
        private TextBox tbId;
        private Button btnClear;
	}
}