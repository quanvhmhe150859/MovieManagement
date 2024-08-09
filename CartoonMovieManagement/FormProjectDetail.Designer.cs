namespace CartoonMovieManagement
{
    partial class FormProjectDetail
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tbName = new TextBox();
            tbDescription = new TextBox();
            cbCategory = new ComboBox();
            label6 = new Label();
            btnSubmit = new Button();
            numBudget = new NumericUpDown();
            tbId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numBudget).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(156, 32);
            label1.TabIndex = 0;
            label1.Text = "Project Detail";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 1;
            label2.Text = "Name: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(117, 25);
            label3.TabIndex = 2;
            label3.Text = "Description: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(12, 214);
            label4.Name = "label4";
            label4.Size = new Size(97, 25);
            label4.TabIndex = 3;
            label4.Text = "Category: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label5.Location = new Point(12, 260);
            label5.Name = "label5";
            label5.Size = new Size(81, 25);
            label5.TabIndex = 4;
            label5.Text = "Budget: ";
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbName.Location = new Point(135, 69);
            tbName.Name = "tbName";
            tbName.Size = new Size(382, 33);
            tbName.TabIndex = 5;
            // 
            // tbDescription
            // 
            tbDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbDescription.Location = new Point(135, 114);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(382, 84);
            tbDescription.TabIndex = 6;
            // 
            // cbCategory
            // 
            cbCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(135, 211);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(382, 33);
            cbCategory.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label6.Location = new Point(495, 260);
            label6.Name = "label6";
            label6.Size = new Size(22, 25);
            label6.TabIndex = 9;
            label6.Text = "$";
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnSubmit.Location = new Point(353, 403);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(136, 35);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // numBudget
            // 
            numBudget.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            numBudget.Location = new Point(135, 258);
            numBudget.Name = "numBudget";
            numBudget.Size = new Size(354, 33);
            numBudget.TabIndex = 11;
            numBudget.TextAlign = HorizontalAlignment.Right;
            // 
            // tbId
            // 
            tbId.Enabled = false;
            tbId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tbId.Location = new Point(174, 8);
            tbId.Name = "tbId";
            tbId.Size = new Size(113, 33);
            tbId.TabIndex = 12;
            // 
            // FormProjectDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 450);
            Controls.Add(tbId);
            Controls.Add(numBudget);
            Controls.Add(btnSubmit);
            Controls.Add(label6);
            Controls.Add(cbCategory);
            Controls.Add(tbDescription);
            Controls.Add(tbName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormProjectDetail";
            Text = "FormProjectDetail";
            Load += FormProjectDetail_Load;
            ((System.ComponentModel.ISupportInitialize)numBudget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox tbName;
        private TextBox tbDescription;
        private ComboBox cbCategory;
        private Label label6;
        private Button btnSubmit;
        private NumericUpDown numBudget;
        private TextBox tbId;
    }
}