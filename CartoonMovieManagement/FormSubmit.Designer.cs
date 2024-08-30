namespace CartoonMovieManagement
{
    partial class FormSubmit
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
            btnSubmit = new Button();
            label5 = new Label();
            tbFile = new TextBox();
            lbId = new Label();
            label6 = new Label();
            lTaskName = new Label();
            tbNote = new TextBox();
            btnUploadFile = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbStatus = new ComboBox();
            btnClear = new Button();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 14.25F);
            btnSubmit.Location = new Point(95, 320);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(139, 44);
            btnSubmit.TabIndex = 32;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.Location = new Point(39, 196);
            label5.Name = "label5";
            label5.Size = new Size(50, 25);
            label5.TabIndex = 31;
            label5.Text = "File: ";
            // 
            // tbFile
            // 
            tbFile.Enabled = false;
            tbFile.Font = new Font("Segoe UI", 14.25F);
            tbFile.Location = new Point(95, 196);
            tbFile.Name = "tbFile";
            tbFile.Size = new Size(378, 33);
            tbFile.TabIndex = 30;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI", 14.25F);
            lbId.Location = new Point(95, 9);
            lbId.Name = "lbId";
            lbId.Size = new Size(28, 25);
            lbId.TabIndex = 29;
            lbId.Text = "Id";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F);
            label6.Location = new Point(12, 9);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 28;
            label6.Text = "Task Id: ";
            // 
            // lTaskName
            // 
            lTaskName.AutoSize = true;
            lTaskName.Font = new Font("Segoe UI", 14.25F);
            lTaskName.Location = new Point(95, 34);
            lTaskName.Name = "lTaskName";
            lTaskName.Size = new Size(62, 25);
            lTaskName.TabIndex = 25;
            lTaskName.Text = "Name";
            // 
            // tbNote
            // 
            tbNote.Font = new Font("Segoe UI", 14.25F);
            tbNote.Location = new Point(95, 101);
            tbNote.Multiline = true;
            tbNote.Name = "tbNote";
            tbNote.Size = new Size(454, 89);
            tbNote.TabIndex = 27;
            // 
            // btnUploadFile
            // 
            btnUploadFile.Font = new Font("Segoe UI", 14.25F);
            btnUploadFile.Location = new Point(95, 235);
            btnUploadFile.Name = "btnUploadFile";
            btnUploadFile.Size = new Size(139, 37);
            btnUploadFile.TabIndex = 21;
            btnUploadFile.Text = "Upload File";
            btnUploadFile.UseVisualStyleBackColor = true;
            btnUploadFile.Click += btnUploadFile_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(27, 101);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 26;
            label4.Text = "Note: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(18, 59);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 24;
            label3.Text = "Status: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(33, 34);
            label2.Name = "label2";
            label2.Size = new Size(56, 25);
            label2.TabIndex = 22;
            label2.Text = "Task: ";
            // 
            // cbStatus
            // 
            cbStatus.Font = new Font("Segoe UI", 14.25F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(95, 62);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(454, 33);
            cbStatus.TabIndex = 23;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 14.25F);
            btnClear.Location = new Point(479, 196);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(70, 33);
            btnClear.TabIndex = 33;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // FormSubmit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 386);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(label5);
            Controls.Add(tbFile);
            Controls.Add(lbId);
            Controls.Add(label6);
            Controls.Add(lTaskName);
            Controls.Add(tbNote);
            Controls.Add(btnUploadFile);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbStatus);
            Name = "FormSubmit";
            Text = "FormSubmit";
            Load += FormSubmit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmit;
        private Label label5;
        private TextBox tbFile;
        private Label lbId;
        private Label label6;
        private Label lTaskName;
        private TextBox tbNote;
        private Button btnUploadFile;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cbStatus;
        private Button btnClear;
    }
}