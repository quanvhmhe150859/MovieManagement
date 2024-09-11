namespace CartoonMovieManagement
{
    partial class FormMain
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			menuStrip1 = new MenuStrip();
			projectToolStripMenuItem = new ToolStripMenuItem();
			createNewProjectToolStripMenuItem = new ToolStripMenuItem();
			editProjectToolStripMenuItem = new ToolStripMenuItem();
			viewProjectTreeToolStripMenuItem = new ToolStripMenuItem();
			projectDataToolStripMenuItem = new ToolStripMenuItem();
			movieToolStripMenuItem = new ToolStripMenuItem();
			createNewMovieToolStripMenuItem = new ToolStripMenuItem();
			editMovieToolStripMenuItem = new ToolStripMenuItem();
			movieDataToolStripMenuItem = new ToolStripMenuItem();
			episodeToolStripMenuItem = new ToolStripMenuItem();
			createNewEpisodeToolStripMenuItem = new ToolStripMenuItem();
			editEpisodeToolStripMenuItem = new ToolStripMenuItem();
			episodeDataToolStripMenuItem = new ToolStripMenuItem();
			taskToolStripMenuItem = new ToolStripMenuItem();
			createNewTaskToolStripMenuItem = new ToolStripMenuItem();
			editTaskToolStripMenuItem = new ToolStripMenuItem();
			taskDataToolStripMenuItem = new ToolStripMenuItem();
			taskLogToolStripMenuItem = new ToolStripMenuItem();
			taskSubmitToolStripMenuItem = new ToolStripMenuItem();
			employeeToolStripMenuItem = new ToolStripMenuItem();
			viewEmployeeTreeToolStripMenuItem = new ToolStripMenuItem();
			employeeDataToolStripMenuItem = new ToolStripMenuItem();
			settingToolStripMenuItem = new ToolStripMenuItem();
			statusSettingToolStripMenuItem = new ToolStripMenuItem();
			categorySettingToolStripMenuItem = new ToolStripMenuItem();
			otherSettingToolStripMenuItem = new ToolStripMenuItem();
			toolStrip = new ToolStrip();
			toolStripLabel1 = new ToolStripLabel();
			toolStripTextBox2 = new ToolStripTextBox();
			toolStripButton1 = new ToolStripButton();
			statusStrip1 = new StatusStrip();
			tSSLabelAccountName = new ToolStripStatusLabel();
			panel1 = new Panel();
			treeViewData = new TreeView();
			imageList = new ImageList(components);
			tabControlData = new TabControl();
			splitter1 = new Splitter();
			menuStrip1.SuspendLayout();
			toolStrip.SuspendLayout();
			statusStrip1.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(40, 40);
			menuStrip1.Items.AddRange(new ToolStripItem[] { projectToolStripMenuItem, movieToolStripMenuItem, episodeToolStripMenuItem, taskToolStripMenuItem, employeeToolStripMenuItem, settingToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(15, 5, 0, 5);
			menuStrip1.Size = new Size(1943, 55);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// projectToolStripMenuItem
			// 
			projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewProjectToolStripMenuItem, editProjectToolStripMenuItem, viewProjectTreeToolStripMenuItem, projectDataToolStripMenuItem });
			projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			projectToolStripMenuItem.Size = new Size(134, 45);
			projectToolStripMenuItem.Text = "Project";
			// 
			// createNewProjectToolStripMenuItem
			// 
			createNewProjectToolStripMenuItem.Image = Properties.Resources.icons8_edit;
			createNewProjectToolStripMenuItem.Name = "createNewProjectToolStripMenuItem";
			createNewProjectToolStripMenuItem.Size = new Size(438, 54);
			createNewProjectToolStripMenuItem.Text = "Create New Project";
			createNewProjectToolStripMenuItem.Click += createNewProjectToolStripMenuItem_Click;
			// 
			// editProjectToolStripMenuItem
			// 
			editProjectToolStripMenuItem.Enabled = false;
			editProjectToolStripMenuItem.Name = "editProjectToolStripMenuItem";
			editProjectToolStripMenuItem.Size = new Size(438, 54);
			editProjectToolStripMenuItem.Text = "Edit Project";
			editProjectToolStripMenuItem.Click += editToolStripMenuItem_Click;
			// 
			// viewProjectTreeToolStripMenuItem
			// 
			viewProjectTreeToolStripMenuItem.Image = Properties.Resources.Iconsmind_Outline_Tree_22_512;
			viewProjectTreeToolStripMenuItem.Name = "viewProjectTreeToolStripMenuItem";
			viewProjectTreeToolStripMenuItem.Size = new Size(438, 54);
			viewProjectTreeToolStripMenuItem.Text = "View Project Tree";
			viewProjectTreeToolStripMenuItem.Click += viewProjectTreeToolStripMenuItem_Click;
			// 
			// projectDataToolStripMenuItem
			// 
			projectDataToolStripMenuItem.Image = Properties.Resources.Icons8_Ios7_Data_Database_512;
			projectDataToolStripMenuItem.Name = "projectDataToolStripMenuItem";
			projectDataToolStripMenuItem.Size = new Size(438, 54);
			projectDataToolStripMenuItem.Text = "Project Data";
			projectDataToolStripMenuItem.Click += projectDataToolStripMenuItem_Click;
			// 
			// movieToolStripMenuItem
			// 
			movieToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewMovieToolStripMenuItem, editMovieToolStripMenuItem, movieDataToolStripMenuItem });
			movieToolStripMenuItem.Name = "movieToolStripMenuItem";
			movieToolStripMenuItem.Size = new Size(124, 45);
			movieToolStripMenuItem.Text = "Movie";
			// 
			// createNewMovieToolStripMenuItem
			// 
			createNewMovieToolStripMenuItem.Image = Properties.Resources.icons8_edit;
			createNewMovieToolStripMenuItem.Name = "createNewMovieToolStripMenuItem";
			createNewMovieToolStripMenuItem.Size = new Size(428, 54);
			createNewMovieToolStripMenuItem.Text = "Create New Movie";
			createNewMovieToolStripMenuItem.Click += createNewMovieToolStripMenuItem_Click;
			// 
			// editMovieToolStripMenuItem
			// 
			editMovieToolStripMenuItem.Enabled = false;
			editMovieToolStripMenuItem.Name = "editMovieToolStripMenuItem";
			editMovieToolStripMenuItem.Size = new Size(428, 54);
			editMovieToolStripMenuItem.Text = "Edit Movie";
			editMovieToolStripMenuItem.Click += editMovieToolStripMenuItem_Click;
			// 
			// movieDataToolStripMenuItem
			// 
			movieDataToolStripMenuItem.Image = Properties.Resources.Icons8_Ios7_Data_Database_512;
			movieDataToolStripMenuItem.Name = "movieDataToolStripMenuItem";
			movieDataToolStripMenuItem.Size = new Size(428, 54);
			movieDataToolStripMenuItem.Text = "Movie Data";
			movieDataToolStripMenuItem.Click += movieDataToolStripMenuItem_Click;
			// 
			// episodeToolStripMenuItem
			// 
			episodeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewEpisodeToolStripMenuItem, editEpisodeToolStripMenuItem, episodeDataToolStripMenuItem });
			episodeToolStripMenuItem.Name = "episodeToolStripMenuItem";
			episodeToolStripMenuItem.Size = new Size(147, 45);
			episodeToolStripMenuItem.Text = "Episode";
			// 
			// createNewEpisodeToolStripMenuItem
			// 
			createNewEpisodeToolStripMenuItem.Image = Properties.Resources.icons8_edit;
			createNewEpisodeToolStripMenuItem.Name = "createNewEpisodeToolStripMenuItem";
			createNewEpisodeToolStripMenuItem.Size = new Size(451, 54);
			createNewEpisodeToolStripMenuItem.Text = "Create New Episode";
			createNewEpisodeToolStripMenuItem.Click += createNewEpisodeToolStripMenuItem_Click;
			// 
			// editEpisodeToolStripMenuItem
			// 
			editEpisodeToolStripMenuItem.Enabled = false;
			editEpisodeToolStripMenuItem.Name = "editEpisodeToolStripMenuItem";
			editEpisodeToolStripMenuItem.Size = new Size(451, 54);
			editEpisodeToolStripMenuItem.Text = "Edit Episode";
			editEpisodeToolStripMenuItem.Click += editEpisodeToolStripMenuItem_Click;
			// 
			// episodeDataToolStripMenuItem
			// 
			episodeDataToolStripMenuItem.Image = Properties.Resources.Icons8_Ios7_Data_Database_512;
			episodeDataToolStripMenuItem.Name = "episodeDataToolStripMenuItem";
			episodeDataToolStripMenuItem.Size = new Size(451, 54);
			episodeDataToolStripMenuItem.Text = "Episode Data";
			episodeDataToolStripMenuItem.Click += episodeDataToolStripMenuItem_Click;
			// 
			// taskToolStripMenuItem
			// 
			taskToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createNewTaskToolStripMenuItem, editTaskToolStripMenuItem, taskDataToolStripMenuItem, taskLogToolStripMenuItem, taskSubmitToolStripMenuItem });
			taskToolStripMenuItem.Name = "taskToolStripMenuItem";
			taskToolStripMenuItem.Size = new Size(98, 45);
			taskToolStripMenuItem.Text = "Task";
			// 
			// createNewTaskToolStripMenuItem
			// 
			createNewTaskToolStripMenuItem.Image = Properties.Resources.icons8_edit;
			createNewTaskToolStripMenuItem.Name = "createNewTaskToolStripMenuItem";
			createNewTaskToolStripMenuItem.Size = new Size(402, 54);
			createNewTaskToolStripMenuItem.Text = "Create New Task";
			createNewTaskToolStripMenuItem.Click += createNewTaskToolStripMenuItem_Click;
			// 
			// editTaskToolStripMenuItem
			// 
			editTaskToolStripMenuItem.Enabled = false;
			editTaskToolStripMenuItem.Name = "editTaskToolStripMenuItem";
			editTaskToolStripMenuItem.Size = new Size(402, 54);
			editTaskToolStripMenuItem.Text = "Edit Task";
			editTaskToolStripMenuItem.Click += editTaskToolStripMenuItem_Click;
			// 
			// taskDataToolStripMenuItem
			// 
			taskDataToolStripMenuItem.Image = Properties.Resources.Icons8_Ios7_Data_Database_512;
			taskDataToolStripMenuItem.Name = "taskDataToolStripMenuItem";
			taskDataToolStripMenuItem.Size = new Size(402, 54);
			taskDataToolStripMenuItem.Text = "Task Data";
			taskDataToolStripMenuItem.Click += taskDataToolStripMenuItem_Click;
			// 
			// taskLogToolStripMenuItem
			// 
			taskLogToolStripMenuItem.Image = Properties.Resources.Github_Octicons_Log_24_512;
			taskLogToolStripMenuItem.Name = "taskLogToolStripMenuItem";
			taskLogToolStripMenuItem.Size = new Size(402, 54);
			taskLogToolStripMenuItem.Text = "Task Log";
			taskLogToolStripMenuItem.Click += taskLogToolStripMenuItem_Click;
			// 
			// taskSubmitToolStripMenuItem
			// 
			taskSubmitToolStripMenuItem.Enabled = false;
			taskSubmitToolStripMenuItem.Image = Properties.Resources.icons8_submit_document_50;
			taskSubmitToolStripMenuItem.Name = "taskSubmitToolStripMenuItem";
			taskSubmitToolStripMenuItem.Size = new Size(402, 54);
			taskSubmitToolStripMenuItem.Text = "Task Submit";
			taskSubmitToolStripMenuItem.Click += taskSubmitToolStripMenuItem_Click;
			// 
			// employeeToolStripMenuItem
			// 
			employeeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewEmployeeTreeToolStripMenuItem, employeeDataToolStripMenuItem });
			employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
			employeeToolStripMenuItem.Size = new Size(173, 45);
			employeeToolStripMenuItem.Text = "Employee";
			// 
			// viewEmployeeTreeToolStripMenuItem
			// 
			viewEmployeeTreeToolStripMenuItem.Image = Properties.Resources.Iconsmind_Outline_Tree_22_512;
			viewEmployeeTreeToolStripMenuItem.Name = "viewEmployeeTreeToolStripMenuItem";
			viewEmployeeTreeToolStripMenuItem.Size = new Size(466, 54);
			viewEmployeeTreeToolStripMenuItem.Text = "Employee Status Tree";
			viewEmployeeTreeToolStripMenuItem.Click += viewEmployeeTreeToolStripMenuItem_Click;
			// 
			// employeeDataToolStripMenuItem
			// 
			employeeDataToolStripMenuItem.Image = Properties.Resources.icons8_employee_32;
			employeeDataToolStripMenuItem.Name = "employeeDataToolStripMenuItem";
			employeeDataToolStripMenuItem.Size = new Size(466, 54);
			employeeDataToolStripMenuItem.Text = "List Employee";
			employeeDataToolStripMenuItem.Click += employeeDataToolStripMenuItem_Click;
			// 
			// settingToolStripMenuItem
			// 
			settingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { statusSettingToolStripMenuItem, categorySettingToolStripMenuItem, otherSettingToolStripMenuItem });
			settingToolStripMenuItem.Name = "settingToolStripMenuItem";
			settingToolStripMenuItem.Size = new Size(136, 45);
			settingToolStripMenuItem.Text = "Setting";
			// 
			// statusSettingToolStripMenuItem
			// 
			statusSettingToolStripMenuItem.Name = "statusSettingToolStripMenuItem";
			statusSettingToolStripMenuItem.Size = new Size(407, 54);
			statusSettingToolStripMenuItem.Text = "Status Setting";
			statusSettingToolStripMenuItem.Click += statusSettingToolStripMenuItem_Click;
			// 
			// categorySettingToolStripMenuItem
			// 
			categorySettingToolStripMenuItem.Name = "categorySettingToolStripMenuItem";
			categorySettingToolStripMenuItem.Size = new Size(407, 54);
			categorySettingToolStripMenuItem.Text = "Category Setting";
			categorySettingToolStripMenuItem.Click += categorySettingToolStripMenuItem_Click;
			// 
			// otherSettingToolStripMenuItem
			// 
			otherSettingToolStripMenuItem.Name = "otherSettingToolStripMenuItem";
			otherSettingToolStripMenuItem.Size = new Size(407, 54);
			otherSettingToolStripMenuItem.Text = "Other Setting";
			otherSettingToolStripMenuItem.Click += otherSettingToolStripMenuItem_Click;
			// 
			// toolStrip
			// 
			toolStrip.ImageScalingSize = new Size(40, 40);
			toolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripTextBox2, toolStripButton1 });
			toolStrip.Location = new Point(0, 66);
			toolStrip.Name = "toolStrip";
			toolStrip.Padding = new Padding(0, 0, 5, 0);
			toolStrip.Size = new Size(1943, 68);
			toolStrip.TabIndex = 2;
			toolStrip.Text = "toolStrip1";
			toolStrip.Visible = false;
			toolStrip.ItemClicked += toolStrip1_ItemClicked;
			// 
			// toolStripLabel1
			// 
			toolStripLabel1.Name = "toolStripLabel1";
			toolStripLabel1.Size = new Size(106, 61);
			toolStripLabel1.Text = "Search";
			// 
			// toolStripTextBox2
			// 
			toolStripTextBox2.Name = "toolStripTextBox2";
			toolStripTextBox2.Size = new Size(237, 68);
			// 
			// toolStripButton1
			// 
			toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolStripButton1.Image = Properties.Resources.icons8_reset_48;
			toolStripButton1.ImageTransparentColor = Color.Magenta;
			toolStripButton1.Name = "toolStripButton1";
			toolStripButton1.Size = new Size(58, 61);
			toolStripButton1.Text = "toolStripButton1";
			// 
			// statusStrip1
			// 
			statusStrip1.ImageScalingSize = new Size(40, 40);
			statusStrip1.Items.AddRange(new ToolStripItem[] { tSSLabelAccountName });
			statusStrip1.Location = new Point(0, 1176);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Padding = new Padding(2, 0, 34, 0);
			statusStrip1.Size = new Size(1943, 54);
			statusStrip1.TabIndex = 3;
			statusStrip1.Text = "statusStrip1";
			// 
			// tSSLabelAccountName
			// 
			tSSLabelAccountName.IsLink = true;
			tSSLabelAccountName.Name = "tSSLabelAccountName";
			tSSLabelAccountName.Size = new Size(206, 41);
			tSSLabelAccountName.Text = "AccountName";
			tSSLabelAccountName.Click += tSSLabelAccountName_Click;
			// 
			// panel1
			// 
			panel1.Controls.Add(treeViewData);
			panel1.Dock = DockStyle.Left;
			panel1.Location = new Point(0, 55);
			panel1.Margin = new Padding(7, 8, 7, 8);
			panel1.Name = "panel1";
			panel1.Size = new Size(486, 1121);
			panel1.TabIndex = 5;
			// 
			// treeViewData
			// 
			treeViewData.Dock = DockStyle.Fill;
			treeViewData.ImageIndex = 0;
			treeViewData.ImageList = imageList;
			treeViewData.Location = new Point(0, 0);
			treeViewData.Margin = new Padding(7, 8, 7, 8);
			treeViewData.Name = "treeViewData";
			treeViewData.SelectedImageIndex = 0;
			treeViewData.Size = new Size(486, 1121);
			treeViewData.TabIndex = 6;
			// 
			// imageList
			// 
			imageList.ColorDepth = ColorDepth.Depth32Bit;
			imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
			imageList.TransparentColor = Color.Transparent;
			imageList.Images.SetKeyName(0, "icons8-approval-48.png");
			imageList.Images.SetKeyName(1, "icons8-reset-48.png");
			imageList.Images.SetKeyName(2, "icons8-task-48.png");
			imageList.Images.SetKeyName(3, "icons8-task-completed-48.png");
			imageList.Images.SetKeyName(4, "icons8-employee-32.png");
			imageList.Images.SetKeyName(5, "icons8-wait-24.png");
			imageList.Images.SetKeyName(6, "icons8-journal-50.png");
			imageList.Images.SetKeyName(7, "icons8-movie-50.png");
			imageList.Images.SetKeyName(8, "icons8-episode-48.png");
			// 
			// tabControlData
			// 
			tabControlData.Dock = DockStyle.Fill;
			tabControlData.Location = new Point(486, 55);
			tabControlData.Margin = new Padding(7, 8, 7, 8);
			tabControlData.Name = "tabControlData";
			tabControlData.SelectedIndex = 0;
			tabControlData.Size = new Size(1457, 1121);
			tabControlData.TabIndex = 9;
			tabControlData.SelectedIndexChanged += tabControlData_SelectedIndexChanged;
			tabControlData.ControlAdded += tabControlData_ControlAdded;
			// 
			// splitter1
			// 
			splitter1.Location = new Point(486, 55);
			splitter1.Margin = new Padding(7, 8, 7, 8);
			splitter1.Name = "splitter1";
			splitter1.Size = new Size(7, 1121);
			splitter1.TabIndex = 11;
			splitter1.TabStop = false;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(17F, 41F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1943, 1230);
			Controls.Add(splitter1);
			Controls.Add(tabControlData);
			Controls.Add(panel1);
			Controls.Add(statusStrip1);
			Controls.Add(toolStrip);
			Controls.Add(menuStrip1);
			IsMdiContainer = true;
			MainMenuStrip = menuStrip1;
			Margin = new Padding(7, 8, 7, 8);
			Name = "FormMain";
			Text = "FormMain";
			WindowState = FormWindowState.Maximized;
			FormClosing += FormMain_FormClosing;
			FormClosed += FormMain_FormClosed;
			Load += FormMain_Load;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			toolStrip.ResumeLayout(false);
			toolStrip.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
        private ToolStrip toolStrip;
        private StatusStrip statusStrip1;
        private Panel panel1;
        private TreeView treeViewData;
        private ImageList imageList;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem createNewProjectToolStripMenuItem;
        private ToolStripMenuItem movieToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem employeeToolStripMenuItem;
        private ToolStripStatusLabel tSSLabelAccountName;
        private ToolStripMenuItem viewProjectTreeToolStripMenuItem;
        private ToolStripMenuItem projectDataToolStripMenuItem;
        private ToolStripMenuItem createNewMovieToolStripMenuItem;
        private ToolStripMenuItem episodeToolStripMenuItem;
        private ToolStripMenuItem createNewEpisodeToolStripMenuItem;
        private ToolStripMenuItem taskToolStripMenuItem;
        private ToolStripMenuItem createNewTaskToolStripMenuItem;
        private ToolStripMenuItem editProjectToolStripMenuItem;
        private ToolStripMenuItem editMovieToolStripMenuItem;
        private ToolStripMenuItem editEpisodeToolStripMenuItem;
        private ToolStripMenuItem editTaskToolStripMenuItem;
        private ToolStripMenuItem viewEmployeeTreeToolStripMenuItem;
        private ToolStripMenuItem employeeDataToolStripMenuItem;
        private ToolStripMenuItem movieDataToolStripMenuItem;
        private ToolStripMenuItem episodeDataToolStripMenuItem;
        private ToolStripMenuItem taskDataToolStripMenuItem;
        private ToolStripMenuItem taskLogToolStripMenuItem;
        private ToolStripMenuItem statusSettingToolStripMenuItem;
        private ToolStripMenuItem categorySettingToolStripMenuItem;
        private ToolStripMenuItem taskSubmitToolStripMenuItem;
        private TabControl tabControlData;
        private Splitter splitter1;
        private ToolStripMenuItem otherSettingToolStripMenuItem;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripButton toolStripButton1;
    }
}