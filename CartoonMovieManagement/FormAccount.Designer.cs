namespace CartoonMovieManagement
{
    partial class FormAccount
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
			label1 = new Label();
			tbEmail = new TextBox();
			tbOldPassword = new TextBox();
			label2 = new Label();
			label3 = new Label();
			dtpCreatedDate = new DateTimePicker();
			checkAccountActive = new CheckBox();
			label4 = new Label();
			label5 = new Label();
			tbNewPassword = new TextBox();
			label6 = new Label();
			tbConfirmPassword = new TextBox();
			label7 = new Label();
			tbRoleName = new TextBox();
			btnChangePassword = new Button();
			label8 = new Label();
			btnSaveChanges = new Button();
			tbId = new TextBox();
			cbEmployee = new ComboBox();
			label9 = new Label();
			label10 = new Label();
			label11 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11.25F);
			label1.Location = new Point(762, 391);
			label1.Margin = new Padding(7, 0, 7, 0);
			label1.Name = "label1";
			label1.Size = new Size(232, 51);
			label1.TabIndex = 0;
			label1.Text = "Email Login: ";
			// 
			// tbEmail
			// 
			tbEmail.Font = new Font("Segoe UI", 11.25F);
			tbEmail.Location = new Point(1008, 385);
			tbEmail.Margin = new Padding(7, 8, 7, 8);
			tbEmail.Name = "tbEmail";
			tbEmail.Size = new Size(648, 57);
			tbEmail.TabIndex = 1;
			// 
			// tbOldPassword
			// 
			tbOldPassword.Font = new Font("Segoe UI", 11.25F);
			tbOldPassword.Location = new Point(369, 738);
			tbOldPassword.Margin = new Padding(7, 8, 7, 8);
			tbOldPassword.Name = "tbOldPassword";
			tbOldPassword.Size = new Size(597, 57);
			tbOldPassword.TabIndex = 3;
			tbOldPassword.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 11.25F);
			label2.Location = new Point(100, 746);
			label2.Margin = new Padding(7, 0, 7, 0);
			label2.Name = "label2";
			label2.Size = new Size(265, 51);
			label2.TabIndex = 2;
			label2.Text = "Old Password: ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 11.25F);
			label3.Location = new Point(741, 227);
			label3.Margin = new Padding(7, 0, 7, 0);
			label3.Name = "label3";
			label3.Size = new Size(260, 51);
			label3.TabIndex = 4;
			label3.Text = "Created Date: ";
			// 
			// dtpCreatedDate
			// 
			dtpCreatedDate.Enabled = false;
			dtpCreatedDate.Font = new Font("Segoe UI", 11.25F);
			dtpCreatedDate.Location = new Point(1008, 213);
			dtpCreatedDate.Margin = new Padding(7, 8, 7, 8);
			dtpCreatedDate.Name = "dtpCreatedDate";
			dtpCreatedDate.Size = new Size(648, 57);
			dtpCreatedDate.TabIndex = 5;
			// 
			// checkAccountActive
			// 
			checkAccountActive.AutoSize = true;
			checkAccountActive.Enabled = false;
			checkAccountActive.Font = new Font("Segoe UI", 11.25F);
			checkAccountActive.Location = new Point(1353, 303);
			checkAccountActive.Margin = new Padding(7, 8, 7, 8);
			checkAccountActive.Name = "checkAccountActive";
			checkAccountActive.Size = new Size(313, 55);
			checkAccountActive.TabIndex = 6;
			checkAccountActive.Text = "Account Active";
			checkAccountActive.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 11.25F);
			label4.Location = new Point(884, 131);
			label4.Margin = new Padding(7, 0, 7, 0);
			label4.Name = "label4";
			label4.Size = new Size(113, 51);
			label4.TabIndex = 7;
			label4.Text = "Role: ";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 11.25F);
			label5.Location = new Point(797, 41);
			label5.Margin = new Padding(7, 0, 7, 0);
			label5.Name = "label5";
			label5.Size = new Size(203, 51);
			label5.TabIndex = 9;
			label5.Text = "Employee: ";
			// 
			// tbNewPassword
			// 
			tbNewPassword.Font = new Font("Segoe UI", 11.25F);
			tbNewPassword.Location = new Point(369, 828);
			tbNewPassword.Margin = new Padding(7, 8, 7, 8);
			tbNewPassword.Name = "tbNewPassword";
			tbNewPassword.Size = new Size(597, 57);
			tbNewPassword.TabIndex = 12;
			tbNewPassword.UseSystemPasswordChar = true;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 11.25F);
			label6.Location = new Point(85, 836);
			label6.Margin = new Padding(7, 0, 7, 0);
			label6.Name = "label6";
			label6.Size = new Size(280, 51);
			label6.TabIndex = 11;
			label6.Text = "New Password: ";
			// 
			// tbConfirmPassword
			// 
			tbConfirmPassword.Font = new Font("Segoe UI", 11.25F);
			tbConfirmPassword.Location = new Point(369, 918);
			tbConfirmPassword.Margin = new Padding(7, 8, 7, 8);
			tbConfirmPassword.Name = "tbConfirmPassword";
			tbConfirmPassword.Size = new Size(597, 57);
			tbConfirmPassword.TabIndex = 14;
			tbConfirmPassword.UseSystemPasswordChar = true;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 11.25F);
			label7.Location = new Point(29, 927);
			label7.Margin = new Padding(7, 0, 7, 0);
			label7.Name = "label7";
			label7.Size = new Size(340, 51);
			label7.TabIndex = 13;
			label7.Text = "Confirm Password: ";
			// 
			// tbRoleName
			// 
			tbRoleName.Enabled = false;
			tbRoleName.Font = new Font("Segoe UI", 11.25F);
			tbRoleName.Location = new Point(1010, 123);
			tbRoleName.Margin = new Padding(7, 8, 7, 8);
			tbRoleName.Name = "tbRoleName";
			tbRoleName.Size = new Size(645, 57);
			tbRoleName.TabIndex = 15;
			// 
			// btnChangePassword
			// 
			btnChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnChangePassword.Location = new Point(369, 1044);
			btnChangePassword.Margin = new Padding(7, 8, 7, 8);
			btnChangePassword.Name = "btnChangePassword";
			btnChangePassword.Size = new Size(602, 82);
			btnChangePassword.TabIndex = 16;
			btnChangePassword.Text = "Change Password";
			btnChangePassword.UseVisualStyleBackColor = true;
			btnChangePassword.Click += btnChangePassword_Click;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
			label8.Location = new Point(29, 25);
			label8.Margin = new Padding(7, 0, 7, 0);
			label8.Name = "label8";
			label8.Size = new Size(597, 106);
			label8.TabIndex = 17;
			label8.Text = "Account Detail";
			// 
			// btnSaveChanges
			// 
			btnSaveChanges.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnSaveChanges.Location = new Point(1008, 593);
			btnSaveChanges.Margin = new Padding(7, 8, 7, 8);
			btnSaveChanges.Name = "btnSaveChanges";
			btnSaveChanges.Size = new Size(653, 82);
			btnSaveChanges.TabIndex = 18;
			btnSaveChanges.Text = "Save Changes";
			btnSaveChanges.UseVisualStyleBackColor = true;
			btnSaveChanges.Click += btnSaveChanges_Click;
			// 
			// tbId
			// 
			tbId.Enabled = false;
			tbId.Font = new Font("Segoe UI", 11.25F);
			tbId.Location = new Point(1379, 1052);
			tbId.Margin = new Padding(7, 8, 7, 8);
			tbId.Name = "tbId";
			tbId.Size = new Size(276, 57);
			tbId.TabIndex = 20;
			// 
			// cbEmployee
			// 
			cbEmployee.Enabled = false;
			cbEmployee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbEmployee.FormattingEnabled = true;
			cbEmployee.Location = new Point(1010, 30);
			cbEmployee.Margin = new Padding(7, 8, 7, 8);
			cbEmployee.Name = "cbEmployee";
			cbEmployee.Size = new Size(645, 58);
			cbEmployee.TabIndex = 21;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.ForeColor = Color.Red;
			label9.Location = new Point(986, 757);
			label9.Margin = new Padding(7, 0, 7, 0);
			label9.Name = "label9";
			label9.Size = new Size(97, 41);
			label9.TabIndex = 22;
			label9.Text = "label9";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.ForeColor = Color.Red;
			label10.Location = new Point(986, 847);
			label10.Margin = new Padding(7, 0, 7, 0);
			label10.Name = "label10";
			label10.Size = new Size(113, 41);
			label10.TabIndex = 23;
			label10.Text = "label10";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.ForeColor = Color.Red;
			label11.Location = new Point(986, 938);
			label11.Margin = new Padding(7, 0, 7, 0);
			label11.Name = "label11";
			label11.Size = new Size(113, 41);
			label11.TabIndex = 24;
			label11.Text = "label11";
			// 
			// FormAccount
			// 
			AutoScaleDimensions = new SizeF(17F, 41F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1690, 1159);
			Controls.Add(label11);
			Controls.Add(label10);
			Controls.Add(label9);
			Controls.Add(cbEmployee);
			Controls.Add(tbId);
			Controls.Add(btnSaveChanges);
			Controls.Add(label8);
			Controls.Add(btnChangePassword);
			Controls.Add(tbRoleName);
			Controls.Add(tbConfirmPassword);
			Controls.Add(label7);
			Controls.Add(tbNewPassword);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(checkAccountActive);
			Controls.Add(dtpCreatedDate);
			Controls.Add(label3);
			Controls.Add(tbOldPassword);
			Controls.Add(label2);
			Controls.Add(tbEmail);
			Controls.Add(label1);
			Margin = new Padding(7, 8, 7, 8);
			Name = "FormAccount";
			Text = "FormAccount";
			Load += FormAccount_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private TextBox tbEmail;
        private TextBox tbOldPassword;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpCreatedDate;
        private CheckBox checkAccountActive;
        private Label label4;
        private Label label5;
        private TextBox tbNewPassword;
        private Label label6;
        private TextBox tbConfirmPassword;
        private Label label7;
        private TextBox tbRoleName;
        private Button btnChangePassword;
        private Label label8;
        private Button btnSaveChanges;
        private TextBox tbId;
        private ComboBox cbEmployee;
        private Label label9;
        private Label label10;
        private Label label11;
	}
}