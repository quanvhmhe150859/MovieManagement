﻿namespace CartoonMovieManagement
{
    partial class FormEmployee
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
			dgvEmployee = new DataGridView();
			btnEmployee = new Button();
			numChange = new NumericUpDown();
			tbNote = new TextBox();
			btnSalaryLog = new Button();
			label3 = new Label();
			label1 = new Label();
			lbId = new Label();
			lbName = new Label();
			label5 = new Label();
			label6 = new Label();
			btnSubmit = new Button();
			label2 = new Label();
			numNew = new NumericUpDown();
			label4 = new Label();
			numOld = new NumericUpDown();
			label7 = new Label();
			btnRefresh = new Button();
			btnCreateAccount = new Button();
			btnEmployeeHistory = new Button();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)numChange).BeginInit();
			((System.ComponentModel.ISupportInitialize)numNew).BeginInit();
			((System.ComponentModel.ISupportInitialize)numOld).BeginInit();
			SuspendLayout();
			// 
			// dgvEmployee
			// 
			dgvEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEmployee.Location = new Point(29, 33);
			dgvEmployee.Margin = new Padding(7, 8, 7, 8);
			dgvEmployee.Name = "dgvEmployee";
			dgvEmployee.RowHeadersWidth = 102;
			dgvEmployee.Size = new Size(1484, 1164);
			dgvEmployee.TabIndex = 1;
			dgvEmployee.CellClick += dgvEmployee_CellClick;
			// 
			// btnEmployee
			// 
			btnEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnEmployee.Location = new Point(1528, 1110);
			btnEmployee.Margin = new Padding(7, 8, 7, 8);
			btnEmployee.Name = "btnEmployee";
			btnEmployee.Size = new Size(306, 87);
			btnEmployee.TabIndex = 15;
			btnEmployee.Text = "Create Employee";
			btnEmployee.UseVisualStyleBackColor = true;
			btnEmployee.Click += btnEmployee_Click;
			// 
			// numChange
			// 
			numChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			numChange.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			numChange.Increment = new decimal(new int[] { 100, 0, 0, 0 });
			numChange.Location = new Point(1702, 749);
			numChange.Margin = new Padding(7, 8, 7, 8);
			numChange.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			numChange.Minimum = new decimal(new int[] { 100000000, 0, 0, int.MinValue });
			numChange.Name = "numChange";
			numChange.Size = new Size(415, 71);
			numChange.TabIndex = 16;
			numChange.TextAlign = HorizontalAlignment.Right;
			numChange.ThousandsSeparator = true;
			numChange.ValueChanged += numChange_ValueChanged;
			// 
			// tbNote
			// 
			tbNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			tbNote.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbNote.Location = new Point(1702, 290);
			tbNote.Margin = new Padding(7, 8, 7, 8);
			tbNote.Multiline = true;
			tbNote.Name = "tbNote";
			tbNote.Size = new Size(410, 223);
			tbNote.TabIndex = 17;
			// 
			// btnSalaryLog
			// 
			btnSalaryLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnSalaryLog.Location = new Point(1880, 33);
			btnSalaryLog.Margin = new Padding(7, 8, 7, 8);
			btnSalaryLog.Name = "btnSalaryLog";
			btnSalaryLog.Size = new Size(238, 87);
			btnSalaryLog.TabIndex = 18;
			btnSalaryLog.Text = "Salary Log";
			btnSalaryLog.UseVisualStyleBackColor = true;
			btnSalaryLog.Click += btnSalaryLog_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 11.25F);
			label3.Location = new Point(1528, 128);
			label3.Margin = new Padding(7, 0, 7, 0);
			label3.Name = "label3";
			label3.Size = new Size(245, 51);
			label3.TabIndex = 19;
			label3.Text = "Employee Id: ";
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11.25F);
			label1.Location = new Point(1528, 210);
			label1.Margin = new Padding(7, 0, 7, 0);
			label1.Name = "label1";
			label1.Size = new Size(209, 51);
			label1.TabIndex = 20;
			label1.Text = "Full Name: ";
			// 
			// lbId
			// 
			lbId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lbId.AutoSize = true;
			lbId.Font = new Font("Segoe UI", 11.25F);
			lbId.Location = new Point(1783, 128);
			lbId.Margin = new Padding(7, 0, 7, 0);
			lbId.Name = "lbId";
			lbId.Size = new Size(54, 51);
			lbId.TabIndex = 21;
			lbId.Text = "Id";
			// 
			// lbName
			// 
			lbName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lbName.AutoSize = true;
			lbName.Font = new Font("Segoe UI", 11.25F);
			lbName.Location = new Point(1744, 210);
			lbName.Margin = new Padding(7, 0, 7, 0);
			lbName.Name = "lbName";
			lbName.Size = new Size(122, 51);
			lbName.TabIndex = 22;
			lbName.Text = "Name";
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 11.25F);
			label5.Location = new Point(1528, 290);
			label5.Margin = new Padding(7, 0, 7, 0);
			label5.Name = "label5";
			label5.Size = new Size(123, 51);
			label5.TabIndex = 23;
			label5.Text = "Note: ";
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 11.25F);
			label6.Location = new Point(1528, 765);
			label6.Margin = new Padding(7, 0, 7, 0);
			label6.Name = "label6";
			label6.Size = new Size(169, 51);
			label6.TabIndex = 24;
			label6.Text = "Change: ";
			// 
			// btnSubmit
			// 
			btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnSubmit.Enabled = false;
			btnSubmit.Location = new Point(1848, 856);
			btnSubmit.Margin = new Padding(7, 8, 7, 8);
			btnSubmit.Name = "btnSubmit";
			btnSubmit.Size = new Size(270, 87);
			btnSubmit.TabIndex = 25;
			btnSubmit.Text = "Submit";
			btnSubmit.UseVisualStyleBackColor = true;
			btnSubmit.Click += btnSubmit_Click;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 11.25F);
			label2.Location = new Point(1528, 659);
			label2.Margin = new Padding(7, 0, 7, 0);
			label2.Name = "label2";
			label2.Size = new Size(115, 51);
			label2.TabIndex = 27;
			label2.Text = "New: ";
			// 
			// numNew
			// 
			numNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			numNew.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			numNew.Increment = new decimal(new int[] { 100, 0, 0, 0 });
			numNew.Location = new Point(1702, 642);
			numNew.Margin = new Padding(7, 8, 7, 8);
			numNew.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			numNew.Minimum = new decimal(new int[] { 100000000, 0, 0, int.MinValue });
			numNew.Name = "numNew";
			numNew.Size = new Size(415, 71);
			numNew.TabIndex = 26;
			numNew.TextAlign = HorizontalAlignment.Right;
			numNew.ThousandsSeparator = true;
			numNew.ValueChanged += numNew_ValueChanged;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 11.25F);
			label4.Location = new Point(1528, 552);
			label4.Margin = new Padding(7, 0, 7, 0);
			label4.Name = "label4";
			label4.Size = new Size(100, 51);
			label4.TabIndex = 29;
			label4.Text = "Old: ";
			// 
			// numOld
			// 
			numOld.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			numOld.Enabled = false;
			numOld.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			numOld.Location = new Point(1702, 536);
			numOld.Margin = new Padding(7, 8, 7, 8);
			numOld.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			numOld.Name = "numOld";
			numOld.Size = new Size(415, 71);
			numOld.TabIndex = 28;
			numOld.TextAlign = HorizontalAlignment.Right;
			numOld.ThousandsSeparator = true;
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
			label7.Location = new Point(1528, 33);
			label7.Margin = new Padding(7, 0, 7, 0);
			label7.Name = "label7";
			label7.Size = new Size(351, 65);
			label7.TabIndex = 30;
			label7.Text = "Change Salary";
			// 
			// btnRefresh
			// 
			btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnRefresh.Location = new Point(1528, 856);
			btnRefresh.Margin = new Padding(7, 8, 7, 8);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(306, 87);
			btnRefresh.TabIndex = 31;
			btnRefresh.Text = "Refresh";
			btnRefresh.UseVisualStyleBackColor = true;
			btnRefresh.Click += btnRefresh_Click;
			// 
			// btnCreateAccount
			// 
			btnCreateAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnCreateAccount.Enabled = false;
			btnCreateAccount.Location = new Point(1848, 1110);
			btnCreateAccount.Margin = new Padding(7, 8, 7, 8);
			btnCreateAccount.Name = "btnCreateAccount";
			btnCreateAccount.Size = new Size(270, 87);
			btnCreateAccount.TabIndex = 32;
			btnCreateAccount.Text = "Create Account";
			btnCreateAccount.UseVisualStyleBackColor = true;
			btnCreateAccount.Click += btnCreateAccount_Click;
			// 
			// btnEmployeeHistory
			// 
			btnEmployeeHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnEmployeeHistory.Location = new Point(1528, 1007);
			btnEmployeeHistory.Margin = new Padding(7, 8, 7, 8);
			btnEmployeeHistory.Name = "btnEmployeeHistory";
			btnEmployeeHistory.Size = new Size(306, 87);
			btnEmployeeHistory.TabIndex = 33;
			btnEmployeeHistory.Text = "Employee History";
			btnEmployeeHistory.UseVisualStyleBackColor = true;
			btnEmployeeHistory.Visible = false;
			btnEmployeeHistory.Click += btnEmployeeHistory_Click;
			// 
			// FormEmployee
			// 
			AutoScaleDimensions = new SizeF(17F, 41F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(2147, 1230);
			Controls.Add(btnEmployeeHistory);
			Controls.Add(btnCreateAccount);
			Controls.Add(btnRefresh);
			Controls.Add(label7);
			Controls.Add(label4);
			Controls.Add(numOld);
			Controls.Add(label2);
			Controls.Add(numNew);
			Controls.Add(btnSubmit);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(lbName);
			Controls.Add(lbId);
			Controls.Add(label1);
			Controls.Add(label3);
			Controls.Add(btnSalaryLog);
			Controls.Add(tbNote);
			Controls.Add(numChange);
			Controls.Add(btnEmployee);
			Controls.Add(dgvEmployee);
			Margin = new Padding(7, 8, 7, 8);
			Name = "FormEmployee";
			Text = "FormEmployeeManagement";
			Load += FormEmployee_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			((System.ComponentModel.ISupportInitialize)numChange).EndInit();
			((System.ComponentModel.ISupportInitialize)numNew).EndInit();
			((System.ComponentModel.ISupportInitialize)numOld).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dgvEmployee;
        private Button btnEmployee;
        private NumericUpDown numChange;
        private TextBox tbNote;
        private Button btnSalaryLog;
        private Label label3;
        private Label label1;
        private Label lbId;
        private Label lbName;
        private Label label5;
        private Label label6;
        private Button btnSubmit;
        private Label label2;
        private NumericUpDown numNew;
        private Label label4;
        private NumericUpDown numOld;
        private Label label7;
        private Button btnRefresh;
        private Button btnCreateAccount;
		private Button btnEmployeeHistory;
	}
}