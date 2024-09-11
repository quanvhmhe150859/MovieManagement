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
			label1.Location = new Point(29, 25);
			label1.Margin = new Padding(7, 0, 7, 0);
			label1.Name = "label1";
			label1.Size = new Size(389, 81);
			label1.TabIndex = 0;
			label1.Text = "Project Detail";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label2.Location = new Point(29, 197);
			label2.Margin = new Padding(7, 0, 7, 0);
			label2.Name = "label2";
			label2.Size = new Size(177, 65);
			label2.TabIndex = 1;
			label2.Text = "Name: ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label3.Location = new Point(29, 320);
			label3.Margin = new Padding(7, 0, 7, 0);
			label3.Name = "label3";
			label3.Size = new Size(292, 65);
			label3.TabIndex = 2;
			label3.Text = "Description: ";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label4.Location = new Point(29, 585);
			label4.Margin = new Padding(7, 0, 7, 0);
			label4.Name = "label4";
			label4.Size = new Size(242, 65);
			label4.TabIndex = 3;
			label4.Text = "Category: ";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label5.Location = new Point(29, 711);
			label5.Margin = new Padding(7, 0, 7, 0);
			label5.Name = "label5";
			label5.Size = new Size(203, 65);
			label5.TabIndex = 4;
			label5.Text = "Budget: ";
			// 
			// tbName
			// 
			tbName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbName.Location = new Point(328, 189);
			tbName.Margin = new Padding(7, 8, 7, 8);
			tbName.Name = "tbName";
			tbName.Size = new Size(922, 71);
			tbName.TabIndex = 5;
			// 
			// tbDescription
			// 
			tbDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbDescription.Location = new Point(328, 312);
			tbDescription.Margin = new Padding(7, 8, 7, 8);
			tbDescription.Multiline = true;
			tbDescription.Name = "tbDescription";
			tbDescription.Size = new Size(922, 223);
			tbDescription.TabIndex = 6;
			// 
			// cbCategory
			// 
			cbCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			cbCategory.FormattingEnabled = true;
			cbCategory.Location = new Point(328, 577);
			cbCategory.Margin = new Padding(7, 8, 7, 8);
			cbCategory.Name = "cbCategory";
			cbCategory.Size = new Size(922, 70);
			cbCategory.TabIndex = 7;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			label6.Location = new Point(1202, 711);
			label6.Margin = new Padding(7, 0, 7, 0);
			label6.Name = "label6";
			label6.Size = new Size(54, 65);
			label6.TabIndex = 9;
			label6.Text = "$";
			// 
			// btnSubmit
			// 
			btnSubmit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			btnSubmit.Location = new Point(857, 1102);
			btnSubmit.Margin = new Padding(7, 8, 7, 8);
			btnSubmit.Name = "btnSubmit";
			btnSubmit.Size = new Size(330, 96);
			btnSubmit.TabIndex = 10;
			btnSubmit.Text = "Submit";
			btnSubmit.UseVisualStyleBackColor = true;
			btnSubmit.Click += btnSubmit_Click;
			// 
			// numBudget
			// 
			numBudget.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			numBudget.Location = new Point(328, 705);
			numBudget.Margin = new Padding(7, 8, 7, 8);
			numBudget.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			numBudget.Name = "numBudget";
			numBudget.Size = new Size(860, 71);
			numBudget.TabIndex = 11;
			numBudget.TextAlign = HorizontalAlignment.Right;
			numBudget.ThousandsSeparator = true;
			// 
			// tbId
			// 
			tbId.Enabled = false;
			tbId.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
			tbId.Location = new Point(423, 22);
			tbId.Margin = new Padding(7, 8, 7, 8);
			tbId.Name = "tbId";
			tbId.Size = new Size(269, 71);
			tbId.TabIndex = 12;
			// 
			// FormProjectDetail
			// 
			AutoScaleDimensions = new SizeF(17F, 41F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1960, 1230);
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
			Margin = new Padding(7, 8, 7, 8);
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