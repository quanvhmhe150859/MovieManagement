namespace CartoonMovieManagement
{
	partial class FormEmployeeHistory
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
			dgvEmployeeHistory = new DataGridView();
			cbEmployee = new ComboBox();
			label7 = new Label();
			dtbStart = new DateTimePicker();
			tbWorkName = new TextBox();
			dtbEnd = new DateTimePicker();
			label5 = new Label();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			btnCreate = new Button();
			btnEdit = new Button();
			btnDelete = new Button();
			btnRefresh = new Button();
			tbId = new TextBox();
			((System.ComponentModel.ISupportInitialize)dgvEmployeeHistory).BeginInit();
			SuspendLayout();
			// 
			// dgvEmployeeHistory
			// 
			dgvEmployeeHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvEmployeeHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEmployeeHistory.Location = new Point(16, 17);
			dgvEmployeeHistory.Margin = new Padding(7, 8, 7, 8);
			dgvEmployeeHistory.Name = "dgvEmployeeHistory";
			dgvEmployeeHistory.RowHeadersWidth = 102;
			dgvEmployeeHistory.Size = new Size(1246, 1315);
			dgvEmployeeHistory.TabIndex = 2;
			dgvEmployeeHistory.CellClick += dgvEmployeeHistory_CellClick;
			// 
			// cbEmployee
			// 
			cbEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			cbEmployee.FormattingEnabled = true;
			cbEmployee.Location = new Point(1695, 142);
			cbEmployee.Margin = new Padding(7, 8, 7, 8);
			cbEmployee.Name = "cbEmployee";
			cbEmployee.Size = new Size(575, 49);
			cbEmployee.TabIndex = 17;
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
			label7.Location = new Point(1630, 17);
			label7.Margin = new Padding(7, 0, 7, 0);
			label7.Name = "label7";
			label7.Size = new Size(429, 65);
			label7.TabIndex = 31;
			label7.Text = "Employee History";
			// 
			// dtbStart
			// 
			dtbStart.Font = new Font("Segoe UI", 9F);
			dtbStart.Location = new Point(1695, 276);
			dtbStart.Margin = new Padding(7, 8, 7, 8);
			dtbStart.Name = "dtbStart";
			dtbStart.Size = new Size(575, 47);
			dtbStart.TabIndex = 33;
			// 
			// tbWorkName
			// 
			tbWorkName.Font = new Font("Segoe UI", 9F);
			tbWorkName.Location = new Point(1695, 207);
			tbWorkName.Margin = new Padding(7, 8, 7, 8);
			tbWorkName.Multiline = true;
			tbWorkName.Name = "tbWorkName";
			tbWorkName.Size = new Size(575, 53);
			tbWorkName.TabIndex = 32;
			// 
			// dtbEnd
			// 
			dtbEnd.Font = new Font("Segoe UI", 9F);
			dtbEnd.Location = new Point(1695, 339);
			dtbEnd.Margin = new Padding(7, 8, 7, 8);
			dtbEnd.Name = "dtbEnd";
			dtbEnd.Size = new Size(575, 47);
			dtbEnd.TabIndex = 34;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(1414, 210);
			label5.Margin = new Padding(7, 0, 7, 0);
			label5.Name = "label5";
			label5.Size = new Size(267, 41);
			label5.TabIndex = 35;
			label5.Text = "Name Work Place: ";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(1518, 281);
			label1.Margin = new Padding(7, 0, 7, 0);
			label1.Name = "label1";
			label1.Size = new Size(163, 41);
			label1.TabIndex = 36;
			label1.Text = "Start Date: ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(1528, 339);
			label2.Margin = new Padding(7, 0, 7, 0);
			label2.Name = "label2";
			label2.Size = new Size(153, 41);
			label2.TabIndex = 37;
			label2.Text = "End Date: ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(1430, 145);
			label3.Margin = new Padding(7, 0, 7, 0);
			label3.Name = "label3";
			label3.Size = new Size(251, 41);
			label3.TabIndex = 38;
			label3.Text = "Employee Name: ";
			// 
			// btnCreate
			// 
			btnCreate.Location = new Point(1528, 477);
			btnCreate.Margin = new Padding(7, 8, 7, 8);
			btnCreate.Name = "btnCreate";
			btnCreate.Size = new Size(238, 63);
			btnCreate.TabIndex = 39;
			btnCreate.Text = "Create New";
			btnCreate.UseVisualStyleBackColor = true;
			btnCreate.Click += btnCreate_Click;
			// 
			// btnEdit
			// 
			btnEdit.Enabled = false;
			btnEdit.Location = new Point(1780, 477);
			btnEdit.Margin = new Padding(7, 8, 7, 8);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(238, 63);
			btnEdit.TabIndex = 40;
			btnEdit.Text = "Edit";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// btnDelete
			// 
			btnDelete.Enabled = false;
			btnDelete.Location = new Point(2032, 477);
			btnDelete.Margin = new Padding(7, 8, 7, 8);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(238, 63);
			btnDelete.TabIndex = 41;
			btnDelete.Text = "Delete";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDelete_Click;
			// 
			// btnRefresh
			// 
			btnRefresh.Location = new Point(1276, 477);
			btnRefresh.Margin = new Padding(7, 8, 7, 8);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(238, 63);
			btnRefresh.TabIndex = 42;
			btnRefresh.Text = "Refresh";
			btnRefresh.UseVisualStyleBackColor = true;
			// 
			// tbId
			// 
			tbId.Enabled = false;
			tbId.Font = new Font("Segoe UI", 9F);
			tbId.Location = new Point(2073, 29);
			tbId.Margin = new Padding(7, 8, 7, 8);
			tbId.Multiline = true;
			tbId.Name = "tbId";
			tbId.Size = new Size(197, 53);
			tbId.TabIndex = 43;
			// 
			// FormEmployeeHistory
			// 
			AutoScaleDimensions = new SizeF(17F, 41F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(2286, 1349);
			Controls.Add(tbId);
			Controls.Add(btnRefresh);
			Controls.Add(btnDelete);
			Controls.Add(btnEdit);
			Controls.Add(btnCreate);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(label5);
			Controls.Add(dtbEnd);
			Controls.Add(dtbStart);
			Controls.Add(tbWorkName);
			Controls.Add(label7);
			Controls.Add(cbEmployee);
			Controls.Add(dgvEmployeeHistory);
			Name = "FormEmployeeHistory";
			Text = "FormEmployeeHistory";
			Load += FormEmployeeHistory_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployeeHistory).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dgvEmployeeHistory;
		private ComboBox cbEmployee;
		private Label label7;
		private DateTimePicker dtbStart;
		private TextBox tbWorkName;
		private DateTimePicker dtbEnd;
		private Label label5;
		private Label label1;
		private Label label2;
		private Label label3;
		private Button btnCreate;
		private Button btnEdit;
		private Button btnDelete;
		private Button btnRefresh;
		private TextBox tbId;
	}
}