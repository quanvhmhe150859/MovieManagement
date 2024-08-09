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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 394);
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
            button1.Location = new Point(35, 247);
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
            btnUploadFile.Location = new Point(35, 218);
            btnUploadFile.Name = "btnUploadFile";
            btnUploadFile.Size = new Size(75, 23);
            btnUploadFile.TabIndex = 7;
            btnUploadFile.Text = "Upload File";
            btnUploadFile.UseVisualStyleBackColor = true;
            btnUploadFile.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 8;
            label2.Text = "Task: ";
            // 
            // cbStatus
            // 
            cbStatus.Enabled = false;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(51, 34);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(101, 23);
            cbStatus.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 37);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 10;
            label3.Text = "Status: ";
            // 
            // lTaskName
            // 
            lTaskName.AutoSize = true;
            lTaskName.Location = new Point(51, 11);
            lTaskName.Name = "lTaskName";
            lTaskName.Size = new Size(0, 15);
            lTaskName.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 69);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 12;
            label4.Text = "Note: ";
            // 
            // tbNote
            // 
            tbNote.Enabled = false;
            tbNote.Location = new Point(51, 66);
            tbNote.Multiline = true;
            tbNote.Name = "tbNote";
            tbNote.Size = new Size(100, 89);
            tbNote.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(lTaskName);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(tbNote);
            panel1.Controls.Add(btnUploadFile);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbStatus);
            panel1.Location = new Point(794, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(152, 281);
            panel1.TabIndex = 15;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 490);
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
    }
}