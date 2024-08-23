namespace CartoonMovieManagement
{
    partial class FormManagement
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
            dgvData = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbName = new TextBox();
            tbDescription = new TextBox();
            btnDepartment = new Button();
            btnStudio = new Button();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            lbId = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            checkCreate = new CheckBox();
            lbPermission = new Label();
            lbRole = new Label();
            lbObject = new Label();
            checkRead = new CheckBox();
            checkUpdate = new CheckBox();
            checkDelete = new CheckBox();
            panel2 = new Panel();
            btnChange = new Button();
            btnPermission = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(12, 12);
            dgvData.Name = "dgvData";
            dgvData.Size = new Size(633, 452);
            dgvData.TabIndex = 0;
            dgvData.CellClick += dgvData_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 18);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 1;
            label1.Text = "Id: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 49);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 2;
            label2.Text = "Name: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 78);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 3;
            label3.Text = "Description: ";
            // 
            // tbName
            // 
            tbName.Location = new Point(106, 46);
            tbName.Name = "tbName";
            tbName.Size = new Size(176, 23);
            tbName.TabIndex = 5;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(106, 75);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(176, 23);
            tbDescription.TabIndex = 6;
            // 
            // btnDepartment
            // 
            btnDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDepartment.Location = new Point(849, 12);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Size = new Size(89, 23);
            btnDepartment.TabIndex = 7;
            btnDepartment.Text = "Department";
            btnDepartment.UseVisualStyleBackColor = true;
            btnDepartment.Click += btnDepartment_Click;
            // 
            // btnStudio
            // 
            btnStudio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStudio.Location = new Point(849, 41);
            btnStudio.Name = "btnStudio";
            btnStudio.Size = new Size(89, 23);
            btnStudio.TabIndex = 8;
            btnStudio.Text = "Studio";
            btnStudio.UseVisualStyleBackColor = true;
            btnStudio.Click += btnStudio_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(3, 119);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(89, 23);
            btnCreate.TabIndex = 9;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(98, 119);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(89, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(193, 119);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(89, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(lbId);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnCreate);
            panel1.Controls.Add(tbName);
            panel1.Controls.Add(tbDescription);
            panel1.Location = new Point(651, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 154);
            panel1.TabIndex = 13;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(106, 18);
            lbId.Name = "lbId";
            lbId.Size = new Size(17, 15);
            lbId.TabIndex = 12;
            lbId.Text = "Id";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 39);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 14;
            label4.Text = "Role: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 71);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 15;
            label5.Text = "Object: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 103);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 16;
            label6.Text = "Create: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 11);
            label7.Name = "label7";
            label7.Size = new Size(84, 15);
            label7.TabIndex = 17;
            label7.Text = "Permission Id: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(48, 131);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 18;
            label8.Text = "Read: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(36, 161);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 19;
            label9.Text = "Update: ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(41, 192);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 20;
            label10.Text = "Delete: ";
            // 
            // checkCreate
            // 
            checkCreate.AutoSize = true;
            checkCreate.Location = new Point(93, 103);
            checkCreate.Name = "checkCreate";
            checkCreate.Size = new Size(15, 14);
            checkCreate.TabIndex = 21;
            checkCreate.UseVisualStyleBackColor = true;
            // 
            // lbPermission
            // 
            lbPermission.AutoSize = true;
            lbPermission.Location = new Point(93, 11);
            lbPermission.Name = "lbPermission";
            lbPermission.Size = new Size(17, 15);
            lbPermission.TabIndex = 22;
            lbPermission.Text = "Id";
            // 
            // lbRole
            // 
            lbRole.AutoSize = true;
            lbRole.Location = new Point(93, 39);
            lbRole.Name = "lbRole";
            lbRole.Size = new Size(39, 15);
            lbRole.TabIndex = 23;
            lbRole.Text = "Name";
            // 
            // lbObject
            // 
            lbObject.AutoSize = true;
            lbObject.Location = new Point(93, 71);
            lbObject.Name = "lbObject";
            lbObject.Size = new Size(39, 15);
            lbObject.TabIndex = 24;
            lbObject.Text = "Name";
            // 
            // checkRead
            // 
            checkRead.AutoSize = true;
            checkRead.Location = new Point(93, 131);
            checkRead.Name = "checkRead";
            checkRead.Size = new Size(15, 14);
            checkRead.TabIndex = 25;
            checkRead.UseVisualStyleBackColor = true;
            // 
            // checkUpdate
            // 
            checkUpdate.AutoSize = true;
            checkUpdate.Location = new Point(93, 161);
            checkUpdate.Name = "checkUpdate";
            checkUpdate.Size = new Size(15, 14);
            checkUpdate.TabIndex = 26;
            checkUpdate.UseVisualStyleBackColor = true;
            // 
            // checkDelete
            // 
            checkDelete.AutoSize = true;
            checkDelete.Location = new Point(93, 192);
            checkDelete.Name = "checkDelete";
            checkDelete.Size = new Size(15, 14);
            checkDelete.TabIndex = 27;
            checkDelete.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(checkDelete);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(checkUpdate);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(checkRead);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(lbObject);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(lbRole);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(lbPermission);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(checkCreate);
            panel2.Location = new Point(651, 230);
            panel2.Name = "panel2";
            panel2.Size = new Size(187, 234);
            panel2.TabIndex = 28;
            // 
            // btnChange
            // 
            btnChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChange.Enabled = false;
            btnChange.Location = new Point(844, 441);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(94, 23);
            btnChange.TabIndex = 29;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnPermission
            // 
            btnPermission.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPermission.Location = new Point(844, 230);
            btnPermission.Name = "btnPermission";
            btnPermission.Size = new Size(94, 23);
            btnPermission.TabIndex = 28;
            btnPermission.Text = "Permission";
            btnPermission.UseVisualStyleBackColor = true;
            btnPermission.Click += btnPermission_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(651, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(89, 23);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // FormManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 476);
            Controls.Add(btnChange);
            Controls.Add(btnRefresh);
            Controls.Add(panel2);
            Controls.Add(btnPermission);
            Controls.Add(panel1);
            Controls.Add(dgvData);
            Controls.Add(btnDepartment);
            Controls.Add(btnStudio);
            Name = "FormManagement";
            Text = "FormManagement";
            Load += FormManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvData;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbName;
        private TextBox tbDescription;
        private Button btnDepartment;
        private Button btnStudio;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private CheckBox checkCreate;
        private Label lbPermission;
        private Label lbRole;
        private Label lbObject;
        private CheckBox checkRead;
        private CheckBox checkUpdate;
        private CheckBox checkDelete;
        private Panel panel2;
        private Button btnPermission;
        private Button btnChange;
        private Label lbId;
        private Button btnRefresh;
    }
}