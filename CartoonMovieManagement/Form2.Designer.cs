namespace CartoonMovieManagement
{
    partial class Form2
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
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            btnUploadFile = new Button();
            label2 = new Label();
            cbStatus = new ComboBox();
            label3 = new Label();
            lTaskName = new Label();
            label4 = new Label();
            tbNote = new TextBox();
            panel1 = new Panel();
            btnGetTask = new Button();
            cbEpisode = new ComboBox();
            btnSubmit = new Button();
            label5 = new Label();
            tbFile = new TextBox();
            lbId = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 497);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            linkLabel1.Location = new Point(12, 9);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(63, 30);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Email";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(423, 7);
            label1.Name = "label1";
            label1.Size = new Size(58, 32);
            label1.TabIndex = 5;
            label1.Text = "Task";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(36, 366);
            button1.Name = "button1";
            button1.Size = new Size(75, 25);
            button1.TabIndex = 6;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnUploadFile
            // 
            btnUploadFile.Enabled = false;
            btnUploadFile.Location = new Point(51, 217);
            btnUploadFile.Name = "btnUploadFile";
            btnUploadFile.Size = new Size(98, 23);
            btnUploadFile.TabIndex = 7;
            btnUploadFile.Text = "Upload File";
            btnUploadFile.UseVisualStyleBackColor = true;
            btnUploadFile.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 8;
            label2.Text = "Task: ";
            // 
            // cbStatus
            // 
            cbStatus.Enabled = false;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(51, 61);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(98, 23);
            cbStatus.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 64);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 10;
            label3.Text = "Status: ";
            // 
            // lTaskName
            // 
            lTaskName.AutoSize = true;
            lTaskName.Location = new Point(51, 38);
            lTaskName.Name = "lTaskName";
            lTaskName.Size = new Size(39, 15);
            lTaskName.TabIndex = 11;
            lTaskName.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 96);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 12;
            label4.Text = "Note: ";
            // 
            // tbNote
            // 
            tbNote.Enabled = false;
            tbNote.Location = new Point(51, 93);
            tbNote.Multiline = true;
            tbNote.Name = "tbNote";
            tbNote.Size = new Size(98, 89);
            tbNote.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(btnGetTask);
            panel1.Controls.Add(cbEpisode);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(tbFile);
            panel1.Controls.Add(lbId);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lTaskName);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(tbNote);
            panel1.Controls.Add(btnUploadFile);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbStatus);
            panel1.Location = new Point(794, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(152, 497);
            panel1.TabIndex = 15;
            // 
            // btnGetTask
            // 
            btnGetTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGetTask.Location = new Point(36, 469);
            btnGetTask.Name = "btnGetTask";
            btnGetTask.Size = new Size(75, 25);
            btnGetTask.TabIndex = 21;
            btnGetTask.Text = "Get Task";
            btnGetTask.UseVisualStyleBackColor = true;
            btnGetTask.Click += btnGetTask_Click;
            // 
            // cbEpisode
            // 
            cbEpisode.FormattingEnabled = true;
            cbEpisode.Location = new Point(3, 337);
            cbEpisode.Name = "cbEpisode";
            cbEpisode.Size = new Size(146, 23);
            cbEpisode.TabIndex = 16;
            // 
            // btnSubmit
            // 
            btnSubmit.Enabled = false;
            btnSubmit.Location = new Point(51, 261);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 20;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 191);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 19;
            label5.Text = "File: ";
            // 
            // tbFile
            // 
            tbFile.Enabled = false;
            tbFile.Location = new Point(51, 188);
            tbFile.Name = "tbFile";
            tbFile.Size = new Size(98, 23);
            tbFile.TabIndex = 18;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(58, 13);
            lbId.Name = "lbId";
            lbId.Size = new Size(17, 15);
            lbId.TabIndex = 16;
            lbId.Text = "Id";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 13);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 15;
            label6.Text = "Task Id: ";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 573);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private LinkLabel linkLabel1;
        private Label label1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Button btnUploadFile;
        private Label label2;
        private ComboBox cbStatus;
        private Label label3;
        private Label lTaskName;
        private Label label4;
        private TextBox tbNote;
        private Panel panel1;
        private Label lbId;
        private Label label6;
        private Label label5;
        private TextBox tbFile;
        private Button btnSubmit;
        private ComboBox cbEpisode;
        private Button btnGetTask;
    }
}