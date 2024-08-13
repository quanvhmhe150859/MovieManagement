namespace CartoonMovieManagement
{
    partial class FormMovieDetail
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
            tbId = new TextBox();
            btnSubmit = new Button();
            tbDescription = new TextBox();
            tbName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbProject = new ComboBox();
            label7 = new Label();
            checkActive = new CheckBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // tbId
            // 
            tbId.Enabled = false;
            tbId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbId.Location = new Point(174, 8);
            tbId.Name = "tbId";
            tbId.Size = new Size(113, 33);
            tbId.TabIndex = 24;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnSubmit.Location = new Point(327, 342);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(136, 35);
            btnSubmit.TabIndex = 22;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // tbDescription
            // 
            tbDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbDescription.Location = new Point(135, 137);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(382, 84);
            tbDescription.TabIndex = 19;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbName.Location = new Point(135, 98);
            tbName.Name = "tbName";
            tbName.Size = new Size(382, 33);
            tbName.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(12, 137);
            label3.Name = "label3";
            label3.Size = new Size(117, 25);
            label3.TabIndex = 15;
            label3.Text = "Description: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(12, 101);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 14;
            label2.Text = "Name: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(150, 32);
            label1.TabIndex = 13;
            label1.Text = "Movie Detail";
            // 
            // cbProject
            // 
            cbProject.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbProject.FormattingEnabled = true;
            cbProject.Location = new Point(135, 59);
            cbProject.Name = "cbProject";
            cbProject.Size = new Size(382, 33);
            cbProject.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label7.Location = new Point(12, 62);
            label7.Name = "label7";
            label7.Size = new Size(80, 25);
            label7.TabIndex = 25;
            label7.Text = "Project: ";
            // 
            // checkActive
            // 
            checkActive.AutoSize = true;
            checkActive.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            checkActive.Location = new Point(135, 227);
            checkActive.Name = "checkActive";
            checkActive.RightToLeft = RightToLeft.No;
            checkActive.Size = new Size(36, 29);
            checkActive.TabIndex = 27;
            checkActive.Text = " ";
            checkActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(12, 228);
            label4.Name = "label4";
            label4.Size = new Size(72, 25);
            label4.TabIndex = 28;
            label4.Text = "Active: ";
            // 
            // FormMovieDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 389);
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
            Name = "FormMovieDetail";
            Text = "FormMovieDetail";
            Load += FormMovieDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbId;
        private Button btnSubmit;
        private TextBox tbDescription;
        private TextBox tbName;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbProject;
        private Label label7;
        private CheckBox checkActive;
        private Label label4;
    }
}