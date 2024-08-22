namespace CartoonMovieManagement
{
    partial class FormProfile
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
            tbId = new TextBox();
            tbFullName = new TextBox();
            label2 = new Label();
            tbEmail = new TextBox();
            label3 = new Label();
            tbPhoneNumber = new TextBox();
            label4 = new Label();
            label5 = new Label();
            dtpDOB = new DateTimePicker();
            label6 = new Label();
            tbSML = new TextBox();
            label7 = new Label();
            pbAvatar = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            dtpCreatedDate = new DateTimePicker();
            numSalary = new NumericUpDown();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            tbCI = new TextBox();
            label13 = new Label();
            btnUploadAvatar = new Button();
            btnSave = new Button();
            cbDepartment = new ComboBox();
            cbStudio = new ComboBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            cbGender = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSalary).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(68, 15);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 0;
            label1.Text = "Employee Id: ";
            // 
            // tbId
            // 
            tbId.Enabled = false;
            tbId.Font = new Font("Segoe UI", 12F);
            tbId.Location = new Point(176, 12);
            tbId.Name = "tbId";
            tbId.Size = new Size(275, 29);
            tbId.TabIndex = 1;
            tbId.TextAlign = HorizontalAlignment.Right;
            // 
            // tbFullName
            // 
            tbFullName.Font = new Font("Segoe UI", 12F);
            tbFullName.Location = new Point(176, 47);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(275, 29);
            tbFullName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(82, 50);
            label2.Name = "label2";
            label2.Size = new Size(88, 21);
            label2.TabIndex = 2;
            label2.Text = "Full Name: ";
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F);
            tbEmail.Location = new Point(176, 82);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(275, 29);
            tbEmail.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(115, 85);
            label3.Name = "label3";
            label3.Size = new Size(55, 21);
            label3.TabIndex = 4;
            label3.Text = "Email: ";
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.Font = new Font("Segoe UI", 12F);
            tbPhoneNumber.Location = new Point(176, 117);
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(275, 29);
            tbPhoneNumber.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(50, 120);
            label4.Name = "label4";
            label4.Size = new Size(120, 21);
            label4.TabIndex = 6;
            label4.Text = "Phone number: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(102, 155);
            label5.Name = "label5";
            label5.Size = new Size(68, 21);
            label5.TabIndex = 8;
            label5.Text = "Gender: ";
            // 
            // dtpDOB
            // 
            dtpDOB.Font = new Font("Segoe UI", 12F);
            dtpDOB.Location = new Point(176, 187);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(275, 29);
            dtpDOB.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(66, 193);
            label6.Name = "label6";
            label6.Size = new Size(104, 21);
            label6.TabIndex = 11;
            label6.Text = "Date of birth: ";
            // 
            // tbSML
            // 
            tbSML.Font = new Font("Segoe UI", 12F);
            tbSML.Location = new Point(176, 222);
            tbSML.Name = "tbSML";
            tbSML.Size = new Size(275, 29);
            tbSML.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(32, 225);
            label7.Name = "label7";
            label7.Size = new Size(138, 21);
            label7.TabIndex = 12;
            label7.Text = "Social Media Link: ";
            // 
            // pbAvatar
            // 
            pbAvatar.BorderStyle = BorderStyle.FixedSingle;
            pbAvatar.Location = new Point(589, 12);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(199, 199);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pbAvatar.TabIndex = 14;
            pbAvatar.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label8.Location = new Point(521, 11);
            label8.Name = "label8";
            label8.Size = new Size(62, 21);
            label8.TabIndex = 15;
            label8.Text = "Avatar: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(63, 403);
            label9.Name = "label9";
            label9.Size = new Size(107, 21);
            label9.TabIndex = 17;
            label9.Text = "Created Date: ";
            // 
            // dtpCreatedDate
            // 
            dtpCreatedDate.Enabled = false;
            dtpCreatedDate.Font = new Font("Segoe UI", 12F);
            dtpCreatedDate.Location = new Point(176, 397);
            dtpCreatedDate.Name = "dtpCreatedDate";
            dtpCreatedDate.Size = new Size(275, 29);
            dtpCreatedDate.TabIndex = 16;
            // 
            // numSalary
            // 
            numSalary.Enabled = false;
            numSalary.Font = new Font("Segoe UI", 12F);
            numSalary.Location = new Point(176, 257);
            numSalary.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numSalary.Minimum = new decimal(new int[] { 1000000000, 0, 0, int.MinValue });
            numSalary.Name = "numSalary";
            numSalary.Size = new Size(275, 29);
            numSalary.TabIndex = 18;
            numSalary.TextAlign = HorizontalAlignment.Right;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(110, 259);
            label10.Name = "label10";
            label10.Size = new Size(60, 21);
            label10.TabIndex = 19;
            label10.Text = "Salary: ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(70, 295);
            label11.Name = "label11";
            label11.Size = new Size(100, 21);
            label11.TabIndex = 20;
            label11.Text = "Department: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(109, 330);
            label12.Name = "label12";
            label12.Size = new Size(61, 21);
            label12.TabIndex = 22;
            label12.Text = "Studio: ";
            // 
            // tbCI
            // 
            tbCI.Enabled = false;
            tbCI.Font = new Font("Segoe UI", 12F);
            tbCI.Location = new Point(176, 362);
            tbCI.Name = "tbCI";
            tbCI.Size = new Size(275, 29);
            tbCI.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(12, 365);
            label13.Name = "label13";
            label13.Size = new Size(158, 21);
            label13.TabIndex = 24;
            label13.Text = "Citizen Identification: ";
            // 
            // btnUploadAvatar
            // 
            btnUploadAvatar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnUploadAvatar.Location = new Point(589, 217);
            btnUploadAvatar.Name = "btnUploadAvatar";
            btnUploadAvatar.Size = new Size(199, 32);
            btnUploadAvatar.TabIndex = 26;
            btnUploadAvatar.Text = "Upload Avatar";
            btnUploadAvatar.UseVisualStyleBackColor = true;
            btnUploadAvatar.Click += btnUploadAvatar_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnSave.Location = new Point(589, 392);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(199, 32);
            btnSave.TabIndex = 27;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cbDepartment
            // 
            cbDepartment.Enabled = false;
            cbDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbDepartment.FormattingEnabled = true;
            cbDepartment.Location = new Point(176, 292);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(275, 29);
            cbDepartment.TabIndex = 28;
            // 
            // cbStudio
            // 
            cbStudio.Enabled = false;
            cbStudio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbStudio.FormattingEnabled = true;
            cbStudio.Location = new Point(176, 327);
            cbStudio.Name = "cbStudio";
            cbStudio.Size = new Size(275, 29);
            cbStudio.TabIndex = 29;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.Red;
            label14.Location = new Point(457, 55);
            label14.Name = "label14";
            label14.Size = new Size(44, 15);
            label14.TabIndex = 30;
            label14.Text = "label14";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.Red;
            label15.Location = new Point(457, 90);
            label15.Name = "label15";
            label15.Size = new Size(44, 15);
            label15.TabIndex = 31;
            label15.Text = "label15";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.Red;
            label16.Location = new Point(457, 125);
            label16.Name = "label16";
            label16.Size = new Size(44, 15);
            label16.TabIndex = 32;
            label16.Text = "label16";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.Red;
            label17.Location = new Point(457, 198);
            label17.Name = "label17";
            label17.Size = new Size(44, 15);
            label17.TabIndex = 33;
            label17.Text = "label17";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = Color.Red;
            label18.Location = new Point(457, 370);
            label18.Name = "label18";
            label18.Size = new Size(44, 15);
            label18.TabIndex = 34;
            label18.Text = "label18";
            // 
            // cbGender
            // 
            cbGender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Male", "Female", "Not to say" });
            cbGender.Location = new Point(176, 152);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(275, 29);
            cbGender.TabIndex = 35;
            // 
            // FormProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 465);
            Controls.Add(cbGender);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(cbStudio);
            Controls.Add(cbDepartment);
            Controls.Add(btnSave);
            Controls.Add(btnUploadAvatar);
            Controls.Add(tbCI);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(numSalary);
            Controls.Add(label9);
            Controls.Add(dtpCreatedDate);
            Controls.Add(label8);
            Controls.Add(pbAvatar);
            Controls.Add(tbSML);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dtpDOB);
            Controls.Add(label5);
            Controls.Add(tbPhoneNumber);
            Controls.Add(label4);
            Controls.Add(tbEmail);
            Controls.Add(label3);
            Controls.Add(tbFullName);
            Controls.Add(label2);
            Controls.Add(tbId);
            Controls.Add(label1);
            Name = "FormProfile";
            Text = "FormProfile";
            Load += FormProfile_Load;
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSalary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbId;
        private TextBox tbFullName;
        private Label label2;
        private TextBox tbEmail;
        private Label label3;
        private TextBox tbPhoneNumber;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpDOB;
        private Label label6;
        private TextBox tbSML;
        private Label label7;
        private PictureBox pbAvatar;
        private Label label8;
        private Label label9;
        private DateTimePicker dtpCreatedDate;
        private NumericUpDown numSalary;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox tbCI;
        private Label label13;
        private Button btnUploadAvatar;
        private Button btnSave;
        private ComboBox cbDepartment;
        private ComboBox cbStudio;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private ComboBox cbGender;
    }
}