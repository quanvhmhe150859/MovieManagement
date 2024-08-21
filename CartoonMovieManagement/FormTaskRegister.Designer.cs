namespace CartoonMovieManagement
{
    partial class FormTaskRegister
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
            cbEpisode = new ComboBox();
            button1 = new Button();
            btnRegister = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 395);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // cbEpisode
            // 
            cbEpisode.FormattingEnabled = true;
            cbEpisode.Location = new Point(12, 12);
            cbEpisode.Name = "cbEpisode";
            cbEpisode.Size = new Size(286, 23);
            cbEpisode.TabIndex = 18;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(304, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 25);
            button1.TabIndex = 17;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegister.Enabled = false;
            btnRegister.Location = new Point(713, 10);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 25);
            btnRegister.TabIndex = 19;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // FormTaskRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(cbEpisode);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "FormTaskRegister";
            Text = "FormTaskRegister";
            Load += FormTaskRegister_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cbEpisode;
        private Button button1;
        private Button btnRegister;
    }
}