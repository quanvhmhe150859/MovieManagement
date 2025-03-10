﻿namespace CartoonMovieManagement
{
    partial class FormStatusSetting
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
            dataGridView1 = new DataGridView();
            lbId = new Label();
            lbDescription = new Label();
            lbName = new Label();
            tbId = new TextBox();
            tbDescription = new TextBox();
            tbName = new TextBox();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            lbBool = new Label();
            checkForAdmin = new CheckBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(470, 426);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI", 14.25F);
            lbId.Location = new Point(13, 6);
            lbId.Name = "lbId";
            lbId.Size = new Size(92, 25);
            lbId.TabIndex = 1;
            lbId.Text = "Status Id: ";
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.Font = new Font("Segoe UI", 14.25F);
            lbDescription.Location = new Point(13, 97);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(117, 25);
            lbDescription.TabIndex = 2;
            lbDescription.Text = "Description: ";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 14.25F);
            lbName.Location = new Point(13, 49);
            lbName.Name = "lbName";
            lbName.Size = new Size(126, 25);
            lbName.TabIndex = 3;
            lbName.Text = "Status Name: ";
            // 
            // tbId
            // 
            tbId.Enabled = false;
            tbId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbId.Location = new Point(171, 3);
            tbId.Name = "tbId";
            tbId.Size = new Size(100, 33);
            tbId.TabIndex = 4;
            // 
            // tbDescription
            // 
            tbDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbDescription.Location = new Point(171, 94);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(188, 94);
            tbDescription.TabIndex = 5;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbName.Location = new Point(171, 49);
            tbName.Name = "tbName";
            tbName.Size = new Size(188, 33);
            tbName.TabIndex = 6;
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Segoe UI", 14.25F);
            btnCreate.Location = new Point(13, 314);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(92, 41);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 14.25F);
            btnEdit.Location = new Point(171, 314);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 41);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.Control;
            btnDelete.Font = new Font("Segoe UI", 14.25F);
            btnDelete.Location = new Point(263, 314);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(98, 41);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 14.25F);
            btnRefresh.Location = new Point(13, 375);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(244, 41);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lbBool
            // 
            lbBool.AutoSize = true;
            lbBool.Font = new Font("Segoe UI", 14.25F);
            lbBool.Location = new Point(13, 199);
            lbBool.Name = "lbBool";
            lbBool.Size = new Size(152, 25);
            lbBool.TabIndex = 11;
            lbBool.Text = "For Admin Only: ";
            // 
            // checkForAdmin
            // 
            checkForAdmin.AutoSize = true;
            checkForAdmin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            checkForAdmin.Location = new Point(171, 205);
            checkForAdmin.Name = "checkForAdmin";
            checkForAdmin.RightToLeft = RightToLeft.No;
            checkForAdmin.Size = new Size(15, 14);
            checkForAdmin.TabIndex = 41;
            checkForAdmin.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(tbId);
            panel1.Controls.Add(checkForAdmin);
            panel1.Controls.Add(lbId);
            panel1.Controls.Add(lbBool);
            panel1.Controls.Add(lbDescription);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(lbName);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(tbDescription);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(tbName);
            panel1.Controls.Add(btnCreate);
            panel1.Location = new Point(488, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(364, 426);
            panel1.TabIndex = 42;
            // 
            // FormStatusSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 450);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "FormStatusSetting";
            Text = "FormSetting";
            Load += FormStatusSetting_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lbId;
        private Label lbDescription;
        private Label lbName;
        private TextBox tbId;
        private TextBox tbDescription;
        private TextBox tbName;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lbBool;
        private CheckBox checkForAdmin;
        private Panel panel1;
    }
}