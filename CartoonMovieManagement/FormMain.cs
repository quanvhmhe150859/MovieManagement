using CartoonMovieManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using SortOrder = System.Windows.Forms.SortOrder;
using System.Linq.Dynamic.Core;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using Timer = System.Windows.Forms.Timer;
using System.Net;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using DocumentFormat.OpenXml.Office2010.Ink;

namespace CartoonMovieManagement
{
	public partial class FormMain : Form
	{
		CartoonProductManagementContext context = new CartoonProductManagementContext();

		public int accountId;
		private FormLogin formLogin;
		private Timer? countdownTimer;
		private SortOrder sortOrder = SortOrder.None;
		private string sortColumn = "";
		private string key = "";
		private int selectedId;
		private string selectedName = "";
		private string selectedTab = "";
		private string typeTreeView = "";

		private FormProjectDetail? formProjectDetail;
		private FormMovieDetail? formMovieDetail;
		private FormEpisodeDetail? formEpisodeDetail;
		private FormTaskDetail? formTaskDetail;
		private FormEmployee? formEmployee;
		private FormHistoryLog? formHistoryLog;
		private FormStatusSetting? formStatusSetting;
		private FormStatusSetting? formCategorySetting;
		private FormProfile? formProfile;
		private FormManagement? formManagement;

		private FormSubmit? formSubmit;

		public DataGridView dgvDataProject = new DataGridView();
		public DataGridView dgvDataMovie = new DataGridView();
		public DataGridView dgvDataEpisode = new DataGridView();
		public DataGridView dgvDataTask = new DataGridView();

		public FormMain(int accountId, FormLogin formLogin)
		{
			InitializeComponent();
			this.accountId = accountId;
			this.formLogin = formLogin;

			SetUp();
		}

		private void SetUp()
		{
			dgvDataProject.CellFormatting += dgvData_CellFormatting;
			dgvDataProject.CellClick += dgvData_CellClick;
			dgvDataProject.CellContentClick += dgvData_CellContentClick;
			dgvDataProject.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;

			dgvDataMovie.CellFormatting += dgvData_CellFormatting;
			dgvDataMovie.CellClick += dgvData_CellClick;
			dgvDataMovie.CellContentClick += dgvData_CellContentClick;
			dgvDataMovie.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;

			dgvDataEpisode.CellFormatting += dgvData_CellFormatting;
			dgvDataEpisode.CellClick += dgvData_CellClick;
			dgvDataEpisode.CellContentClick += dgvData_CellContentClick;
			dgvDataEpisode.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;

			dgvDataTask.CellFormatting += dgvData_CellFormatting;
			dgvDataTask.CellClick += dgvData_CellClick;
			dgvDataTask.CellContentClick += dgvData_CellContentClick;
			dgvDataTask.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;

			tabControlData.DrawMode = TabDrawMode.OwnerDrawFixed;
			// Attach event handlers
			tabControlData.DrawItem += TabControl1_DrawItem;
			tabControlData.MouseDown += TabControl1_MouseDown;
			tabControlData.MouseMove += TabControl1_MouseMove;

			// Add event handler for DataBindingComplete
			dgvDataProject.DataBindingComplete += dgvDataProject_DataBindingComplete;
			dgvDataMovie.DataBindingComplete += dgvDataProject_DataBindingComplete;
			dgvDataEpisode.DataBindingComplete += dgvDataProject_DataBindingComplete;
			dgvDataTask.DataBindingComplete += dgvDataProject_DataBindingComplete;
		}

		private void dgvDataProject_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
		{
			DataGridView? dgvData = sender as DataGridView;

			if (dgvData != null)
			{
				//Check if the 'Status' column exists before proceeding
				if (dgvData.Columns.Contains("Status"))
				{
					var account = context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
					if (account != null)
					{
						foreach (DataGridViewRow row in dgvData.Rows)
						{
							// Now it's safe to access the 'Status' column
							string status = row.Cells["Status"].Value?.ToString() ?? string.Empty;

							if (status == "Approved" ||
								(row.Cells["DeadlineDate"].Value != null &&
								Convert.ToDateTime(row.Cells["DeadlineDate"].Value) < DateTime.Now) ||
								(row.Cells["ReceiverId"].Value != null &&
								account.EmployeeId != Convert.ToInt32(row.Cells["ReceiverId"].Value)))
							{
								// Replace the button with a text cell to remove it
								row.Cells["Submit"] = new DataGridViewTextBoxCell();
							}
						}
						dgvData.Columns["Submit"].ReadOnly = true;
					}
				}
				else if (dgvData.Columns.Contains("DeletedDate"))
				{
					foreach (DataGridViewRow row in dgvData.Rows)
					{
						// Now it's safe to access the 'Status' column
						string deletedDate = row.Cells["DeletedDate"].Value?.ToString() ?? string.Empty;

						if (deletedDate != "")
						{
							// Replace the button with a text cell to remove it
							row.Cells["Edit"] = new DataGridViewTextBoxCell();
						}
					}
					dgvData.Columns["Edit"].ReadOnly = true;
				}
			}
		}

		public void LoadData(string type, DataGridView dgvData)
		{
			selectedName = type;

			// Assuming the DataGridView is named dgvData
			if (!dgvData.Columns.Contains("Countdown"))
			{
				DataGridViewTextBoxColumn countdownColumn = new DataGridViewTextBoxColumn();
				countdownColumn.Name = "Countdown";
				countdownColumn.HeaderText = "Time Remaining";
				dgvData.Columns.Insert(0, countdownColumn); // Insert at the first position
				dgvData.Columns["Countdown"].Width = 150;
			}

			if (!dgvData.Columns.Contains("Edit") && type != "Employee" && type != "TaskEmployee")
			{
				// Add a new button column to the DataGridView
				DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
				editButtonColumn.Name = "Edit";
				editButtonColumn.HeaderText = "Action";
				editButtonColumn.Text = "Edit";
				editButtonColumn.UseColumnTextForButtonValue = true; // Show the same text for all buttons
				dgvData.Columns.Insert(0, editButtonColumn);
			}
			 
			if (type == "Project")
			{
				dgvData.DataSource = null;
				var data = context.Projects
					.AsNoTracking()
					.Where(p => p.Name.ToLower().Contains(key))
					.Select(p => new
					{
						ProjectId = p.ProjectId,
						CategoryId = p.CategoryId,
						Name = p.Name,
						Description = p.Description,
						CreatedDate = p.CreatedDate,
						DeletedDate = p.DeletedDate,
						Budget = p.Budget
					})
					.ToList();

				if (sortOrder != SortOrder.None)
				{
					// Determine the sort direction
					string sortDirection = sortOrder == SortOrder.Ascending ? "ASC" : "DESC";

					// Use Dynamic LINQ to apply sorting
					data = data.AsQueryable().OrderBy($"{sortColumn} {sortDirection}").ToList();
				}

				dgvData.DataSource = data;

				dgvData.Columns["ProjectId"].Visible = false;
				dgvData.Columns["Countdown"].Visible = false;
				dgvData.Columns["CategoryId"].HeaderText = "Category Name";
				dgvData.Columns["CategoryId"].Width = 150;
				dgvData.Columns["CreatedDate"].HeaderText = "Created Date";
				dgvData.Columns["CreatedDate"].Width = 150;
				dgvData.Columns["DeletedDate"].HeaderText = "Deleted Date";
				dgvData.Columns["DeletedDate"].Width = 150;
				dgvData.Columns["Name"].HeaderText = "Project Name";
				dgvData.Columns["Name"].Width = 150;
				dgvData.Columns["Description"].MinimumWidth = 150;
				dgvData.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
			else if (type == "Movie")
			{
				dgvData.DataSource = null;
				var data = context.CartoonMovies
					.Include(p => p.Project)
					.AsNoTracking()
					.Where(p => /*p.Project.DeletedDate == null &&*/
						(p.Name.ToLower().Contains(key) ||
						p.Project.Name.ToLower().Contains(key)))
					.Select(m => new
					{
						CartoonMovieId = m.CartoonMovieId,
						ProjectId = m.ProjectId,
						Name = m.Name,
						Description = m.Description,
						CreatedDate = m.CreatedDate,
						DeletedDate = m.DeletedDate,
						IsActive = m.IsActive
					})
					.ToList();

				if (sortOrder != SortOrder.None)
				{
					// Determine the sort direction
					string sortDirection = sortOrder == SortOrder.Ascending ? "ASC" : "DESC";

					// Use Dynamic LINQ to apply sorting
					data = data.AsQueryable().OrderBy($"{sortColumn} {sortDirection}").ToList();
				}

				dgvData.DataSource = data;

				dgvData.Columns["CartoonMovieId"].Visible = false;
				dgvData.Columns["Countdown"].Visible = false;
				dgvData.Columns["ProjectId"].HeaderText = "Project Name";
				dgvData.Columns["ProjectId"].Width = 150;
				dgvData.Columns["Name"].HeaderText = "Movie Name";
				dgvData.Columns["Name"].Width = 150;
				dgvData.Columns["CreatedDate"].HeaderText = "Created Date";
				dgvData.Columns["CreatedDate"].Width = 150;
				dgvData.Columns["DeletedDate"].HeaderText = "Deleted Date";
				dgvData.Columns["DeletedDate"].Width = 150;
				dgvData.Columns["IsActive"].HeaderText = "Is Active";
				dgvData.Columns["Description"].MinimumWidth = 150;
				dgvData.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
			else if (type == "Episode")
			{
				dgvData.DataSource = null;
				var data = context.EpisodeMovies
					.Include(p => p.CartoonMovie)
					//.ThenInclude(cm => cm.Project)
					.AsNoTracking()
					.Where(p => /*p.CartoonMovie.DeletedDate == null &&
                        p.CartoonMovie.Project.DeletedDate == null &&*/
						(p.Name.ToLower().Contains(key) ||
						p.CartoonMovie.Name.ToLower().Contains(key)))
					.Select(e => new
					{
						ProjectId = e.CartoonMovie.ProjectId,
						EpisodeMovieId = e.EpisodeMovieId,
						CartoonMovieId = e.CartoonMovieId,
						Name = e.Name,
						Description = e.Description,
						CreatedDate = e.CreatedDate,
						DeletedDate = e.DeletedDate,
						MovieLink = e.MovieLink,
						Duration = e.Duration,
						IsActive = e.IsActive
					})
					.ToList();

				if (sortOrder != SortOrder.None)
				{
					// Determine the sort direction
					string sortDirection = sortOrder == SortOrder.Ascending ? "ASC" : "DESC";

					// Use Dynamic LINQ to apply sorting
					data = data.AsQueryable().OrderBy($"{sortColumn} {sortDirection}").ToList();
				}

				dgvData.DataSource = data;

				dgvData.Columns["EpisodeMovieId"].Visible = false;
				dgvData.Columns["CartoonMovieId"].HeaderText = "Movie Name";
				dgvData.Columns["CartoonMovieId"].Width = 150;
				dgvData.Columns["ProjectId"].HeaderText = "Project Name";
				dgvData.Columns["ProjectId"].Width = 150;
				dgvData.Columns["Name"].HeaderText = "Episode Name";
				dgvData.Columns["Name"].Width = 150;
				dgvData.Columns["CreatedDate"].HeaderText = "Created Date";
				dgvData.Columns["CreatedDate"].Width = 150;
				dgvData.Columns["DeletedDate"].HeaderText = "Deleted Date";
				dgvData.Columns["DeletedDate"].Width = 150;
				dgvData.Columns["IsActive"].HeaderText = "Is Active";
				dgvData.Columns["MovieLink"].HeaderText = "Movie Link";

				dgvData.Columns["MovieLink"].Visible = false;
				dgvData.Columns["Countdown"].Visible = false;

				DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
				linkColumn.Name = "MovieLink";
				linkColumn.DataPropertyName = "MovieLink"; // This should match your property name in the data source
				linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
				dgvData.Columns.Add(linkColumn);
			}
			else if (type == "Task")
			{
				dgvData.DataSource = null;
				var data = context.Tasks
					.Include(p => p.EpisodeMovie)
					//.ThenInclude(em => em.CartoonMovie)
					//.ThenInclude(cm => cm.Project)
					.AsNoTracking()
					.Where(p => /*p.EpisodeMovie.DeletedDate == null &&
                        p.EpisodeMovie.CartoonMovie.DeletedDate == null &&
                        p.EpisodeMovie.CartoonMovie.Project.DeletedDate == null &&*/
						(p.Name.ToLower().Contains(key) ||
						p.EpisodeMovie.Name.ToLower().Contains(key) ||
						(p.Receiver != null && p.Receiver.FullName.ToLower().Contains(key))))
					.Select(t => new
					{
						TaskParentId = t.TaskParentId,
						Name = t.Name,
						Description = t.Description,
						ReceiverId = t.ReceiverId,
						AssignedDate = t.AssignedDate,
						StatusId = t.StatusId,
						Note = t.Note,
						SubmitLink = t.SubmitLink,
						ResourceLink = t.ResourceLink,
						DeadlineDate = t.DeadlineDate,
						CreatedDate = t.CreatedDate,
						DeletedDate = t.DeletedDate,
						ProjectId = t.EpisodeMovie.CartoonMovie.ProjectId,
						CartoonMovieId = t.EpisodeMovie.CartoonMovieId,
						EpisodeMovieId = t.EpisodeMovieId,
						TaskId = t.TaskId
					})
					.ToList();

				if (sortOrder != SortOrder.None)
				{
					// Determine the sort direction
					string sortDirection = sortOrder == SortOrder.Ascending ? "ASC" : "DESC";

					if (sortColumn == "Countdown")
						sortColumn = "DeadlineDate";

					// Use Dynamic LINQ to apply sorting
					data = data.AsQueryable().OrderBy($"{sortColumn} {sortDirection}").ToList();
				}

				dgvData.DataSource = data;

				//dgvData.Columns["TaskId"].Visible = false;
				dgvData.Columns["EpisodeMovieId"].HeaderText = "Episode Name";
				dgvData.Columns["EpisodeMovieId"].Width = 150;
				dgvData.Columns["ReceiverId"].HeaderText = "Employee Name";
				dgvData.Columns["ReceiverId"].Width = 150;
				dgvData.Columns["Name"].HeaderText = "Task Name";
				dgvData.Columns["StatusId"].HeaderText = "Status";
				dgvData.Columns["CreatedDate"].HeaderText = "Created Date";
				dgvData.Columns["DeletedDate"].HeaderText = "Deleted Date";
				dgvData.Columns["AssignedDate"].HeaderText = "Submit Date";
				dgvData.Columns["DeadlineDate"].HeaderText = "Deadline Date";
				dgvData.Columns["DeadlineDate"].Width = 150;
				dgvData.Columns["TaskParentId"].HeaderText = "Task Parent";

				dgvData.Columns["ResourceLink"].Visible = false;
				dgvData.Columns["Countdown"].Visible = true;

				DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
				linkColumn.Name = "ResourceLink";
				linkColumn.HeaderText = "Resource Link";
				linkColumn.DataPropertyName = "ResourceLink"; // This should match your property name in the data source
				linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
				dgvData.Columns.Add(linkColumn);
				linkColumn.DisplayIndex = 10;

				dgvData.Columns["SubmitLink"].Visible = false;
				DataGridViewLinkColumn linkColumn2 = new DataGridViewLinkColumn();
				linkColumn2.Name = "SubmitLink";
				linkColumn2.HeaderText = "Submit Link";
				linkColumn2.DataPropertyName = "SubmitLink"; // This should match your property name in the data source
				linkColumn2.LinkBehavior = LinkBehavior.AlwaysUnderline;
				dgvData.Columns.Add(linkColumn2);
				linkColumn2.DisplayIndex = 9;

				// Make TaskId the last column by setting its DisplayIndex
				dgvData.Columns["ProjectId"].DisplayIndex = dgvData.Columns.Count - 1;
				dgvData.Columns["CartoonMovieId"].DisplayIndex = dgvData.Columns.Count - 1;
				dgvData.Columns["EpisodeMovieId"].DisplayIndex = dgvData.Columns.Count - 1;
				dgvData.Columns["TaskId"].DisplayIndex = dgvData.Columns.Count - 1;
				dgvData.Columns["TaskId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgvData.Columns["TaskId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

				foreach (DataGridViewRow row in dgvData.Rows)
				{
					if (row.Cells["DeadlineDate"].Value is DateTime deadlineDate)
					{
						TimeSpan timeRemaining = deadlineDate - DateTime.Now;

						// Format the countdown based on the time remaining
						string countdownText;
						if (timeRemaining.TotalSeconds <= 0)
						{
							countdownText = "Expired";
						}
						else if (timeRemaining.TotalDays >= 1)
						{
							countdownText = $"{timeRemaining.Days} days left";
						}
						else if (timeRemaining.TotalHours >= 1)
						{
							countdownText = $"{timeRemaining.Hours} hours left";
						}
						else
						{
							countdownText = $"{timeRemaining.Minutes} minutes left";
						}

						row.Cells["Countdown"].Value = countdownText;
					}
				}
			}
		}

		private void dgvData_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView? dgvData = sender as DataGridView;

			if (dgvData != null)
			{
				if (dgvData.Columns[e.ColumnIndex].Name == "Duration")
				{
					if (e.Value != null && e.Value is int)
					{
						int totalMinutes = (int)e.Value;

						// Convert total minutes to hours and minutes
						TimeSpan time = TimeSpan.FromMinutes(totalMinutes);
						string formattedTime = $"{time.Hours:D2}:{time.Minutes:D2}";

						// Set the formatted value
						e.Value = formattedTime;
						e.FormattingApplied = true;
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "ProjectId")
				{
					if (e.Value != null)
					{
						int projectId = (int)e.Value;

						// Lookup the project name based on the projectId
						var project = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
						if (project != null)
						{
							e.Value = project.Name;
							e.FormattingApplied = true;
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "CategoryId")
				{
					if (e.Value != null)
					{
						int categoryId = (int)e.Value;

						// Lookup the project name based on the projectId
						var category = context.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
						if (category != null)
						{
							e.Value = category.Name;
							e.FormattingApplied = true;
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "CartoonMovieId")
				{
					if (e.Value != null)
					{
						int movieId = (int)e.Value;

						// Lookup the project name based on the projectId
						var movie = context.CartoonMovies.FirstOrDefault(p => p.CartoonMovieId == movieId);
						if (movie != null)
						{
							e.Value = movie.Name;
							e.FormattingApplied = true;
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "EpisodeMovieId")
				{
					if (e.Value != null)
					{
						int episodeId = (int)e.Value;

						// Lookup the project name based on the projectId
						var episode = context.EpisodeMovies.FirstOrDefault(p => p.EpisodeMovieId == episodeId);
						if (episode != null)
						{
							e.Value = episode.Name;
							e.FormattingApplied = true;
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "TaskParentId")
				{
					if (e.Value != null)
					{
						int taskId = (int)e.Value;

						// Lookup the project name based on the projectId
						var task = context.Tasks.FirstOrDefault(p => p.TaskId == taskId);
						if (task != null)
						{
							e.Value = task.Name;
							e.FormattingApplied = true;
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "ReceiverId")
				{
					if (e.Value != null)
					{
						int employeeId = (int)e.Value;

						// Lookup the project name based on the projectId
						var employee = context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
						if (employee != null)
						{
							e.Value = employee.FullName;
							e.FormattingApplied = true;
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "StatusId")
				{
					if (e.Value != null)
					{
						int statusId = (int)e.Value;

						// Lookup the project name based on the projectId
						var status = context.Statuses.FirstOrDefault(p => p.StatusId == statusId);
						if (status != null)
						{
							e.Value = status.Name;
							e.FormattingApplied = true;
						}
					}
				}
			}
		}

		public void LoadTreeView(string type)
		{
			if (typeTreeView == type && typeTreeView == "Project")
			{
				treeViewData.Nodes.Clear();

				var projects = context.Projects
						.AsNoTracking()
						.Where(p => p.DeletedDate == null).ToList();

				foreach (var project in projects)
				{
					TreeNode projectNode = new TreeNode(project.Name, 6, 6);
					treeViewData.Nodes.Add(projectNode);

					var movies = context.CartoonMovies
						.AsNoTracking()
						.Where(m => m.ProjectId == project.ProjectId && m.DeletedDate == null)
						.ToList();

					foreach (var movie in movies)
					{
						TreeNode movieNode = new TreeNode(movie.Name, 7, 7);
						projectNode.Nodes.Add(movieNode);

						var episodes = context.EpisodeMovies
							.AsNoTracking()
							.Where(e => e.CartoonMovieId == movie.CartoonMovieId && e.DeletedDate == null)
							.ToList();

						foreach (var episode in episodes)
						{
							TreeNode episodeNode = new TreeNode(episode.Name, 8, 8);
							movieNode.Nodes.Add(episodeNode);

							//var tasks = context.Tasks
							//    .Where(t => t.EpisodeMovieId == episode.EpisodeMovieId && t.DeletedDate == null)
							//    .ToList();

							//foreach (var task in tasks)
							//{
							//    TreeNode taskNode = new TreeNode(task.Name);
							//    episodeNode.Nodes.Add(taskNode);
							//}
						}
					}
				}
			}
			else if (typeTreeView == type && typeTreeView == "Employee")
			{
				treeViewData.Nodes.Clear();

				var employees = context.Employees
					.Include(e => e.Accounts)
					.AsNoTracking()
					.Where(e => e.Accounts.Any(a => a.RoleId != 1) || !e.Accounts.Any())
					.ToList();

				foreach (var employee in employees)
				{
					var tasks = context.Tasks
						.Include(t => t.Status)
						.AsNoTracking()
						.Where(t => t.ReceiverId == employee.EmployeeId && t.DeletedDate == null)
						.ToList();

					var status = "Free";

					// Check if the employee has any "On Going" tasks
					if (tasks.Any(t => t.Status.Name == "On Going"))
					{
						status = "On Task";
					}

					if (tasks.Any(t => t.Status.Name == "Finish"))
					{
						status = "Wait for Approve";
					}

					TreeNode employeeNode = new TreeNode(employee.FullName + " (" + status + ")", 4, 4)
					{ Tag = "Employee:" + employee.EmployeeId };
					treeViewData.Nodes.Add(employeeNode);

					foreach (var task in tasks)
					{
						TreeNode taskNode = new TreeNode(task.Name + " (" + task.Status.Name + ")")
						{ Tag = "Task:" + task.TaskId };

						if (task.StatusId == 1)
						{
							taskNode.ImageIndex = 2;
							taskNode.SelectedImageIndex = 2;
						}
						else if (task.StatusId == 2)
						{
							taskNode.ImageIndex = 3;
							taskNode.SelectedImageIndex = 3;
						}
						else if (task.StatusId == 6)
						{
							taskNode.ImageIndex = 0;
							taskNode.SelectedImageIndex = 0;
						}
						else
						{
							taskNode.ImageIndex = 5;
							taskNode.SelectedImageIndex = 5;
						}
						employeeNode.Nodes.Add(taskNode);

						if (task.Status.Name == "Finish" && task.SubmitLink != "")
						{
							TreeNode submitLink = new TreeNode(task.SubmitLink)
							{
								Tag = "Link:" + task.SubmitLink,
								ForeColor = Color.Blue,  // Change text color to blue
								NodeFont = new Font(treeViewData.Font, FontStyle.Underline)  // Underline the text
							};
							taskNode.Nodes.Add(submitLink);
						}
					}
				}
			}
		}

		// Event handler to draw the "X" on each tab
		private void TabControl1_DrawItem(object? sender, DrawItemEventArgs e)
		{
			// Get the TabControl
			TabControl? tabControl = sender as TabControl;
			if (tabControl != null)
			{
				Rectangle tabRect = tabControl.GetTabRect(e.Index);

				// Draw the tab text
				string tabText = tabControl.TabPages[e.Index].Text;
				e.Graphics.DrawString(tabText, tabControl.Font, Brushes.Black, tabRect.X + 2, tabRect.Y + 2);

				// Set up for drawing the "X" close icon
				Rectangle closeRect = new Rectangle(tabRect.Right - 38, tabRect.Top + 4, 36, 36);
				bool isHovered = (e.Index == hoveredTabIndex);

				// Draw the "X" icon with hover effect
				ControlPaint.DrawCaptionButton(e.Graphics, closeRect, CaptionButton.Close,
					isHovered ? ButtonState.Flat : ButtonState.Normal);
			}
		}

		private int hoveredTabIndex = -1;
		private Rectangle lastCloseRect = Rectangle.Empty; // Tracks the last "X" area

		private void TabControl1_MouseMove(object? sender, MouseEventArgs e)
		{
			int newHoveredIndex = -1;
			Rectangle newCloseRect = Rectangle.Empty;

			for (int i = 0; i < tabControlData.TabPages.Count; i++)
			{
				Rectangle tabRect = tabControlData.GetTabRect(i);
				Rectangle closeRect = new Rectangle(tabRect.Right - 38, tabRect.Top + 4, 36, 36);

				if (closeRect.Contains(e.Location))
				{
					newHoveredIndex = i;
					newCloseRect = closeRect;
					break;
				}
			}

			if (newHoveredIndex != hoveredTabIndex)
			{
				// Invalidate old and new areas to minimize redraw
				tabControlData.Invalidate(lastCloseRect);
				tabControlData.Invalidate(newCloseRect);

				// Update the tracked indices and rectangles
				hoveredTabIndex = newHoveredIndex;
				lastCloseRect = newCloseRect;
			}
		}

		// Event handler to close the tab when "X" is clicked
		private void TabControl1_MouseDown(object? sender, MouseEventArgs e)
		{
			for (int i = 0; i < tabControlData.TabPages.Count; i++)
			{
				Rectangle tabRect = tabControlData.GetTabRect(i);
				Rectangle closeRect = new Rectangle(tabRect.Right - 38, tabRect.Top + 4, 36, 36);

				if (closeRect.Contains(e.Location))
				{
					// Close the tab
					tabControlData.TabPages.RemoveAt(i);
					break;
				}
			}
		}

		private void InitializeCountdownTimer()
		{
			countdownTimer = new Timer();
			countdownTimer.Interval = 60000; // Update every minute
			countdownTimer.Tick += (s, e) => UpdateCountdown();
			countdownTimer.Start();
		}

		private void UpdateCountdown()
		{
			if (!dgvDataProject.Columns.Contains("DeadlineDate"))
			{
				// If the column doesn't exist, simply return to avoid errors
				return;
			}

			foreach (DataGridViewRow row in dgvDataProject.Rows)
			{
				if (row.Cells["DeadlineDate"].Value is DateTime deadlineDate)
				{
					TimeSpan timeRemaining = deadlineDate - DateTime.Now;

					string countdownText;
					if (timeRemaining.TotalSeconds <= 0)
					{
						countdownText = "Expired";
					}
					else if (timeRemaining.TotalDays >= 1)
					{
						countdownText = $"{timeRemaining.Days} days left";
					}
					else if (timeRemaining.TotalHours >= 1)
					{
						countdownText = $"{timeRemaining.Hours} hours left";
					}
					else
					{
						countdownText = $"{timeRemaining.Minutes} minutes left";
					}

					row.Cells["Countdown"].Value = countdownText;
				}
			}
		}

		public void LoadTaskEmployee(int employeeId)
		{
			foreach (TabPage tab in tabControlData.TabPages)
			{
				if (tab.Name == "taskTab")
				{
					tabControlData.TabPages.Remove(tab);
				}
			}

			TabPage newTab = new TabPage
			{
				Name = "taskTab",
				Text = "Task List                           "
			};

			// Create and configure a new DataGridView
			dgvDataProject.Dock = DockStyle.Fill;  // Make it fill the entire tab

			// Add the DataGridView to the new TabPage
			newTab.Controls.Add(dgvDataProject);

			// Add the new TabPage to the TabControl
			tabControlData.TabPages.Add(newTab);

			// Select the newly added tab
			tabControlData.SelectedTab = newTab;

			selectedName = "TaskSubmit";

			if (!dgvDataProject.Columns.Contains("Deadline"))
			{
				// Add Countdown column
				var countdownColumn = new DataGridViewTextBoxColumn
				{
					Name = "Deadline",
					HeaderText = "Deadline",
					DefaultCellStyle = new DataGridViewCellStyle { Format = @"dd\:hh\:mm\:ss" }
				};
				dgvDataProject.Columns.Insert(0, countdownColumn);
			}

			if (!dgvDataProject.Columns.Contains("Submit"))
			{
				// Add a new button column to the DataGridView
				DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
				editButtonColumn.Name = "Submit";
				editButtonColumn.HeaderText = "Action";
				editButtonColumn.Text = "Submit";
				editButtonColumn.UseColumnTextForButtonValue = true; // Show the same text for all buttons
				dgvDataProject.Columns.Insert(0, editButtonColumn);
			}

			dgvDataProject.DataSource = null;

			var uniqueEpisodeIdList = context.Tasks
				.Include(t => t.EpisodeMovie)
				.Where(t => t.ReceiverId == employeeId && t.Status.Name != "Not Start" && t.DeletedDate == null)
				.Select(t => new { EpisodeMovieName = t.EpisodeMovie.Name, t.EpisodeMovieId })  // Create an anonymous type
				.Distinct()  // Apply Distinct to get unique combinations of EpisodeMovieName and EpisodeMovieId
				.ToList();

			// Step 1: Extract the EpisodeMovieId values from uniqueEpisodeIdList
			var episodeMovieIds = new List<int>();

			foreach (var item in uniqueEpisodeIdList)
			{
				var episodeMovie = item as dynamic; // Use 'dynamic' if it's an anonymous type, or cast to the specific type
				episodeMovieIds.Add(episodeMovie.EpisodeMovieId);
			}

			// Step 2: Query to get tasks where EpisodeMovieId is in the episodeMovieIds list
			var data = context.Tasks
				.Include(t => t.Status)
				.Include(t => t.EpisodeMovie)
				.Include(t => t.Status)
				.AsNoTracking()
				.Where(t => episodeMovieIds.Contains(t.EpisodeMovieId) && t.Status.Name != "Not Start" && t.DeletedDate == null)
				.Select(t => new
				{
					TaskId = t.TaskId,
					Name = t.Name,
					Description = t.Description,
					//AssignedDate = t.AssignedDate,
					DeadlineDate = t.DeadlineDate,
					ReceiverId = t.ReceiverId,
					Status = t.Status.Name,
					Note = t.Note,
					ResourceLink = t.ResourceLink,
					SubmitLink = t.SubmitLink,
					EpisodeMovie = t.EpisodeMovie.Name,
					EpisodeMovieId = t.EpisodeMovieId
				})
				.ToList();

			dgvDataProject.DataSource = data;

			dgvDataProject.Columns["DeadlineDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
			dgvDataProject.Columns["TaskId"].Visible = false;
			dgvDataProject.Columns["EpisodeMovieId"].Visible = false;
			dgvDataProject.Columns["ReceiverId"].Visible = false;
			dgvDataProject.Columns["ResourceLink"].Visible = false;
			dgvDataProject.Columns["SubmitLink"].Visible = false;
			dgvDataProject.Columns["DeadlineDate"].HeaderText = "Deadline Date";
			dgvDataProject.Columns["EpisodeMovie"].HeaderText = "Episode Movie";

			if (!dgvDataProject.Columns.Contains("DownloadColumn"))
			{
				DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
				linkColumn.Name = "Resource Link";
				//linkColumn.HeaderText = "Download";
				linkColumn.DataPropertyName = "ResourceLink"; // This should match your property name in the data source
				linkColumn.LinkBehavior = LinkBehavior.AlwaysUnderline;
				dgvDataProject.Columns.Insert(1, linkColumn);

				DataGridViewLinkColumn linkColumn2 = new DataGridViewLinkColumn();
				linkColumn2.Name = "Submit Link";
				//linkColumn.HeaderText = "Download";
				linkColumn2.DataPropertyName = "SubmitLink"; // This should match your property name in the data source
				linkColumn2.LinkBehavior = LinkBehavior.AlwaysUnderline;

				// Add the column to the DataGridView
				dgvDataProject.Columns.Insert(2, linkColumn2);
			}
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			var account = context.Accounts
				.Include(a => a.Employee)
				.FirstOrDefault(a => a.AccountId == accountId);
			if (account != null)
			{
				tSSLabelAccountName.Text = account.Employee.FullName;

				typeTreeView = "Employee";
				LoadTreeView("Employee");
				if (account.RoleId == 1)
				{
					treeViewData.NodeMouseDoubleClick += treeViewData_NodeMouseDoubleClick;
					taskSubmitToolStripMenuItem.Visible = false;
					//LoadData("Task");
					InitializeCountdownTimer();

					this.Text = "Admin";
				}
				else
				{
					var permisson = context.Permissions.FirstOrDefault(p => p.RoleId == account.RoleId && p.TypeId == 1);

					projectToolStripMenuItem.Visible = false;
					movieToolStripMenuItem.Visible = false;
					episodeToolStripMenuItem.Visible = false;
					if (permisson != null && !permisson.Create)
						createNewTaskToolStripMenuItem.Visible = false;
					if (permisson != null && !permisson.Update)
						editTaskToolStripMenuItem.Visible = false;
					if (permisson != null && !permisson.Read)
						taskDataToolStripMenuItem.Visible = false;
					taskLogToolStripMenuItem.Visible = false;
					employeeToolStripMenuItem.Visible = false;
					settingToolStripMenuItem.Visible = false;
					InitializeTimer();
					LoadTaskEmployee(account.EmployeeId);

					this.Text = "Employee";
				}
			}
			else
			{
				MessageBox.Show("Not found Account");
				this.Close();
			}
		}

		private void InitializeTimer()
		{
			countdownTimer = new Timer();
			countdownTimer.Interval = 1000; // 1 second interval
			countdownTimer.Tick += CountdownTimer_Tick;
			countdownTimer.Start();
		}

		private void CountdownTimer_Tick(object? sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvDataProject.Rows)
			{
				var deadlineDateCell = row.Cells["DeadlineDate"];
				if (deadlineDateCell.Value is DateTime deadlineDate)
				{
					TimeSpan countdown = deadlineDate - DateTime.Now;
					if (countdown.TotalSeconds <= 0)
					{
						countdown = TimeSpan.Zero;
					}
					row.Cells["Deadline"].Value = countdown;
				}
			}
			dgvDataProject.Refresh(); // Refresh to update UI
		}

		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			formLogin.Close();
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to close this form?",
										  "Confirm Close",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Warning);

			// If the user selects "No", cancel the form close
			if (result == DialogResult.No)
			{
				e.Cancel = true;
			}
		}

		private void dgvData_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			DataGridView? dgvData = sender as DataGridView;

			if (dgvData != null)
			{
				if (e.RowIndex >= 0)
				{
					if (selectedName == "Project")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["ProjectId"].Value);

						editProjectToolStripMenuItem.Enabled = true;
						editMovieToolStripMenuItem.Enabled = false;
						editEpisodeToolStripMenuItem.Enabled = false;
						editTaskToolStripMenuItem.Enabled = false;
					}
					else if (selectedName == "Movie")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["CartoonMovieId"].Value);

						editProjectToolStripMenuItem.Enabled = false;
						editMovieToolStripMenuItem.Enabled = true;
						editEpisodeToolStripMenuItem.Enabled = false;
						editTaskToolStripMenuItem.Enabled = false;
					}
					else if (selectedName == "Episode")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["EpisodeMovieId"].Value);

						editProjectToolStripMenuItem.Enabled = false;
						editMovieToolStripMenuItem.Enabled = false;
						editEpisodeToolStripMenuItem.Enabled = true;
						editTaskToolStripMenuItem.Enabled = false;
					}
					else if (selectedName == "Task")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["TaskId"].Value);

						editProjectToolStripMenuItem.Enabled = false;
						editMovieToolStripMenuItem.Enabled = false;
						editEpisodeToolStripMenuItem.Enabled = false;
						editTaskToolStripMenuItem.Enabled = true;
					}
					else if (selectedName == "TaskSubmit")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["TaskId"].Value);

						var account = context.Accounts.FirstOrDefault(a => a.AccountId == accountId);

						var status = context.Statuses
							.FirstOrDefault(s => s.Name == dgvData.Rows[e.RowIndex].Cells["Status"].Value
							.ToString());

						if (status != null && account != null)
						{
							if (status.Name == "Passed" ||
							(dgvData.Rows[e.RowIndex].Cells["DeadlineDate"].Value != null &&
							Convert.ToDateTime(dgvData.Rows[e.RowIndex].Cells["DeadlineDate"].Value) < DateTime.Now) ||
							(dgvData.Rows[e.RowIndex].Cells["ReceiverId"].Value != null &&
							account.EmployeeId != Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["ReceiverId"].Value)))
							{
								taskSubmitToolStripMenuItem.Enabled = false;
							}
							else
							{
								taskSubmitToolStripMenuItem.Enabled = true;
							}
						}
					}
				}
			}
		}

		private void projectDetail()
		{
			if (formProjectDetail == null || formProjectDetail.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formProjectDetail = new FormProjectDetail(selectedId, this);
				formProjectDetail.Show();
			}
			else
			{
				formProjectDetail.UpdateData(selectedId);
				formProjectDetail.BringToFront();
			}
		}

		private void movieDetail()
		{
			if (formMovieDetail == null || formMovieDetail.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formMovieDetail = new FormMovieDetail(selectedId, this);
				formMovieDetail.Show();
			}
			else
			{
				formMovieDetail.UpdateData(selectedId);
				formMovieDetail.BringToFront();
			}
		}

		private void episodeDetail()
		{
			if (formEpisodeDetail == null || formEpisodeDetail.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formEpisodeDetail = new FormEpisodeDetail(selectedId, this);
				formEpisodeDetail.Show();
			}
			else
			{
				formEpisodeDetail.Close();
				formEpisodeDetail = new FormEpisodeDetail(selectedId, this);
				formEpisodeDetail.Show();
				//formEpisodeDetail.UpdateData(selectedId);
				//formEpisodeDetail.BringToFront();
			}
		}

		private void taskDetail()
		{
			if (formTaskDetail == null || formTaskDetail.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formTaskDetail = new FormTaskDetail(selectedId, this, 0, 0, 0, 0);
				formTaskDetail.Show();
			}
			else
			{
				formTaskDetail.UpdateData(selectedId);
				formTaskDetail.BringToFront();
			}
		}

		private void createNewProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			selectedId = 0;
			projectDetail();
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			projectDetail();
		}

		private void createNewMovieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			selectedId = 0;
			movieDetail();
		}

		private void editMovieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			movieDetail();
		}

		private void createNewEpisodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			selectedId = 0;
			episodeDetail();
		}

		private void editEpisodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			episodeDetail();
		}

		private void createNewTaskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			selectedId = 0;
			taskDetail();
		}

		private void editTaskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			taskDetail();
		}

		private void viewProjectTreeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			typeTreeView = "Project";
			LoadTreeView("Project");
		}

		private void viewEmployeeTreeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			typeTreeView = "Employee";
			LoadTreeView("Employee");
		}

		private void employeeDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formEmployee == null || formEmployee.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formEmployee = new FormEmployee(this);
				formEmployee.Show();
			}
			else
			{
				// If the form is already open, bring it to the front
				formEmployee.BringToFront();
			}
		}

		private void projectDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Check if a tab with the same name already exists
			foreach (TabPage tab in tabControlData.TabPages)
			{
				if (tab.Name == "projectTab")
				{
					// Tab already exists, so select it
					tabControlData.SelectedTab = tab;
					return; // Exit the method to avoid creating a new tab
				}
			}

			// Create a new TabPage
			TabPage newTab = new TabPage
			{
				Name = "projectTab",
				Text = "Project List                           "
			};

			// Create and configure a new DataGridView
			dgvDataProject.Dock = DockStyle.Fill;  // Make it fill the entire tab

			// Add the DataGridView to the new TabPage
			newTab.Controls.Add(dgvDataProject);

			// Add the new TabPage to the TabControl
			tabControlData.TabPages.Add(newTab);

			// Select the newly added tab
			tabControlData.SelectedTab = newTab;

			LoadData("Project", dgvDataProject);
		}

		private void movieDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Check if a tab with the same name already exists
			foreach (TabPage tab in tabControlData.TabPages)
			{
				if (tab.Name == "movieTab")
				{
					// Tab already exists, so select it
					tabControlData.SelectedTab = tab;
					return; // Exit the method to avoid creating a new tab
				}
			}

			// Create a new TabPage
			TabPage newTab = new TabPage
			{
				Name = "movieTab",
				Text = "Movie List                           "
			};

			// Create and configure a new DataGridView
			dgvDataMovie.Dock = DockStyle.Fill;  // Make it fill the entire tab

			// Add the DataGridView to the new TabPage
			newTab.Controls.Add(dgvDataMovie);

			// Add the new TabPage to the TabControl
			tabControlData.TabPages.Add(newTab);

			// Select the newly added tab
			tabControlData.SelectedTab = newTab;

			LoadData("Movie", dgvDataMovie);
		}

		private void episodeDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Check if a tab with the same name already exists
			foreach (TabPage tab in tabControlData.TabPages)
			{
				if (tab.Name == "episodeTab")
				{
					// Tab already exists, so select it
					tabControlData.SelectedTab = tab;
					return; // Exit the method to avoid creating a new tab
				}
			}

			// Create a new TabPage
			TabPage newTab = new TabPage
			{
				Name = "episodeTab",
				Text = "Episode List                           "
			};

			// Create and configure a new DataGridView
			dgvDataEpisode.Dock = DockStyle.Fill;  // Make it fill the entire tab

			// Add the DataGridView to the new TabPage
			newTab.Controls.Add(dgvDataEpisode);

			// Add the new TabPage to the TabControl
			tabControlData.TabPages.Add(newTab);

			// Select the newly added tab
			tabControlData.SelectedTab = newTab;

			LoadData("Episode", dgvDataEpisode);
		}

		private void taskDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var account = context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
			if (account != null)
			{
				// Check if a tab with the same name already exists
				foreach (TabPage tab in tabControlData.TabPages)
				{
					if (tab.Name == "taskTab")
					{
						// Tab already exists, so select it
						tabControlData.SelectedTab = tab;
						return; // Exit the method to avoid creating a new tab
					}
				}

				if (account.RoleId == 1)
				{
					// Create a new TabPage
					TabPage newTab = new TabPage
					{
						Name = "taskTab",
						Text = "Task List                           "
					};

					// Create and configure a new DataGridView
					dgvDataTask.Dock = DockStyle.Fill;  // Make it fill the entire tab

					// Add the DataGridView to the new TabPage
					newTab.Controls.Add(dgvDataTask);

					// Add the new TabPage to the TabControl
					tabControlData.TabPages.Add(newTab);

					// Select the newly added tab
					tabControlData.SelectedTab = newTab;
					LoadData("Task", dgvDataTask);
				}
				else
					LoadTaskEmployee(account.EmployeeId);
			}
			else
				MessageBox.Show("Error");
		}

		private void taskLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formHistoryLog == null || formHistoryLog.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formHistoryLog = new FormHistoryLog("Task", this);
				formHistoryLog.Show();
			}
			else
			{
				// If the form is already open, bring it to the front
				formHistoryLog.BringToFront();
			}
		}

		private void statusSettingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formStatusSetting == null || formStatusSetting.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formStatusSetting = new FormStatusSetting("Status");
				formStatusSetting.Show();
			}
			else
			{
				// If the form is already open, bring it to the front
				formStatusSetting.BringToFront();
			}
		}

		private void categorySettingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formCategorySetting == null || formCategorySetting.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formCategorySetting = new FormStatusSetting("Category");
				formCategorySetting.Show();
			}
			else
			{
				// If the form is already open, bring it to the front
				formCategorySetting.BringToFront();
			}
		}

		private void dgvData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
		{
			DataGridView? dgvData = sender as DataGridView;

			if (dgvData != null)
			{
				if (dgvData.Columns[e.ColumnIndex].Name == "ResourceLink")
				{
					string? resourceLink = dgvData.Rows[e.RowIndex].Cells["ResourceLink"].Value.ToString();
					if (!string.IsNullOrEmpty(resourceLink))
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
							saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								string destinationPath = saveFileDialog.FileName;

								string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
								if (projectRootPath != null)
								{
									string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Resources");
									string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
									string fullFilePath = Path.Combine(uploadsFolder, fileName);
									// Here you would implement the logic to download the file to the selected path
									// For example, using WebClient or HttpClient to download the file from resourceLink
									//using (var client = new WebClient())
									//{
									//	client.DownloadFile(fullFilePath, destinationPath);
									//}
									//MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

									DownloadFile(fullFilePath, destinationPath);
								}
							}
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "SubmitLink")
				{
					string? resourceLink = dgvData.Rows[e.RowIndex].Cells["SubmitLink"].Value.ToString();
					if (!string.IsNullOrEmpty(resourceLink))
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
							saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								string destinationPath = saveFileDialog.FileName;

								string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
								if (projectRootPath != null)
								{
									string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Results");
									string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
									string fullFilePath = Path.Combine(uploadsFolder, fileName);
									// Here you would implement the logic to download the file to the selected path
									// For example, using WebClient or HttpClient to download the file from resourceLink
									//using (var client = new WebClient())
									//{
									//	client.DownloadFile(fullFilePath, destinationPath);
									//}
									//MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

									DownloadFile(fullFilePath, destinationPath);
								}
							}
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "MovieLink")
				{
					string? resourceLink = dgvData.Rows[e.RowIndex].Cells["MovieLink"].Value.ToString();
					if (!string.IsNullOrEmpty(resourceLink))
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
							saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								string destinationPath = saveFileDialog.FileName;

								string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
								if (projectRootPath != null)
								{
									string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Movies");
									string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
									string fullFilePath = Path.Combine(uploadsFolder, fileName);

									// Here you would implement the logic to download the file to the selected path
									// For example, using WebClient or HttpClient to download the file from resourceLink
									//using (var client = new WebClient())
									//{
									//	client.DownloadFile(fullFilePath, destinationPath);
									//}
									//MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

									DownloadFile(fullFilePath, destinationPath);
								}
							}
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "Resource Link")
				{
					string? resourceLink = dgvData.Rows[e.RowIndex].Cells["ResourceLink"].Value.ToString();
					if (!string.IsNullOrEmpty(resourceLink))
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
							saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								string destinationPath = saveFileDialog.FileName;

								string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
								if (projectRootPath != null)
								{
									string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Resources");
									string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
									string fullFilePath = Path.Combine(uploadsFolder, fileName);
									// Here you would implement the logic to download the file to the selected path
									// For example, using WebClient or HttpClient to download the file from resourceLink

									//using (var client = new WebClient())
									//{
									//	client.DownloadFile(fullFilePath, destinationPath);
									//}
									////await DownloadFileAsync(fullFilePath, destinationPath);

									//MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

									DownloadFile(fullFilePath, destinationPath);
								}
							}
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "Submit Link")
				{
					string? resourceLink = dgvData.Rows[e.RowIndex].Cells["SubmitLink"].Value.ToString();
					if (!string.IsNullOrEmpty(resourceLink))
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
							saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								string destinationPath = saveFileDialog.FileName;

								string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
								if (projectRootPath != null)
								{
									string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Results");
									string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
									string fullFilePath = Path.Combine(uploadsFolder, fileName);
									// Here you would implement the logic to download the file to the selected path
									// For example, using WebClient or HttpClient to download the file from resourceLink
									//using (var client = new WebClient())
									//{
									//	client.DownloadFile(fullFilePath, destinationPath);
									//}
									//MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

									DownloadFile(fullFilePath, destinationPath);
								}
							}
						}
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "Edit")
				{
					if (selectedName == "Project")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["ProjectId"].Value);
						projectDetail();
					}
					else if (selectedName == "Movie")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["CartoonMovieId"].Value);
						movieDetail();
					}
					else if (selectedName == "Episode")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["EpisodeMovieId"].Value);
						episodeDetail();
					}
					else if (selectedName == "Task")
					{
						selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["TaskId"].Value);
						taskDetail();
					}
				}

				if (dgvData.Columns[e.ColumnIndex].Name == "Submit")
				{
					selectedId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["TaskId"].Value);
					taskSubmit();
				}
			}
		}

		private void tSSLabelAccountName_Click(object sender, EventArgs e)
		{
			var account = context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
			if (account != null && account.RoleId != 1)
			{
				if (formProfile == null || formProfile.IsDisposed)
				{
					formProfile = new FormProfile(account.EmployeeId, "Employee", null);
					formProfile.Show();
				}
				else
				{
					// If the form is already open, bring it to the front
					formProfile.BringToFront();
				}
			}

		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void taskSubmitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			taskSubmit();
		}

		private void taskSubmit()
		{
			if (formSubmit == null || formSubmit.IsDisposed)
			{
				// If the form does not exist or was closed, create a new instance
				formSubmit = new FormSubmit(selectedId, this);
				formSubmit.Show();
			}
			else
			{
				formSubmit.Close();
				formSubmit = new FormSubmit(selectedId, this);
				formSubmit.Show();
			}
		}

		private void treeViewData_NodeMouseDoubleClick(object? sender, TreeNodeMouseClickEventArgs e)
		{
			// Check if the double-clicked node is a task
			if (e.Node.Tag != null && (e.Node.Tag?.ToString()?.StartsWith("Task") == true))
			{
				// Retrieve the taskId from the Tag property
				//selectedId = Int32.Parse(e.Node.Tag.ToString().Split(':')[1]);

				if (e.Node.Tag is string tag && tag.Contains(":"))
				{
					string[] parts = tag.Split(':');
					if (parts.Length > 1 && int.TryParse(parts[1], out int parsedId))
					{
						selectedId = parsedId;
					}
					// Open the task detail form and pass the taskId
					taskDetail();
				}
			}
			else if (e.Node.Tag != null && (e.Node.Tag?.ToString()?.StartsWith("Link") == true))
			{
				//string resourceLink = e.Node.Tag.ToString().Split(':')[1];

				if (e.Node.Tag is string tag && tag.Contains(":"))
				{
					string[] parts = tag.Split(':');
					if (parts.Length > 1)
					{
						string resourceLink = parts[1];
						// Use resourceLink safely here

						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.FileName = Path.GetFileName(resourceLink); // Default file name
							saveFileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								string destinationPath = saveFileDialog.FileName;

								string? projectRootPath = Directory.GetParent(Application.StartupPath)?.Parent?.Parent?.Parent?.FullName;
								if (projectRootPath != null)
								{
									string uploadsFolder = Path.Combine(projectRootPath, "Uploads", "Results");
									string fileName = Path.GetFileName(resourceLink); // Get the file name from resourceLink
									string fullFilePath = Path.Combine(uploadsFolder, fileName);
									// Here you would implement the logic to download the file to the selected path
									// For example, using WebClient or HttpClient to download the file from resourceLink
									//using (var client = new WebClient())
									//{
									//	client.DownloadFile(fullFilePath, destinationPath);
									//}
									//MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

									DownloadFile(fullFilePath, destinationPath);
								}
							}
						}
					}
				}
			}
		}

		private void DownloadFile(string fullFilePath, string destinationPath)
		{
			try
			{
				using (var client = new WebClient())
				{
					// Download the data into a byte array
					byte[] data = client.DownloadData(fullFilePath);

					// Check if the data is empty
					if (data == null || data.Length == 0)
					{
						MessageBox.Show("The downloaded data is empty.", "Download Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					else
					{
						// Save the data to the destination path
						File.WriteAllBytes(destinationPath, data);
						MessageBox.Show("File downloaded successfully.", "Download Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch (WebException)
			{
				string fileName = Path.GetFileName(fullFilePath);

				// Handle web-related exceptions sucfileNameh as 404 Not Found or connection issues
				MessageBox.Show($"Failed to download the file: {fileName} not found", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				// Handle any other exceptions
				MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void toolStripButtonCreate_Click(object sender, EventArgs e)
		{
			selectedId = 0;
			taskDetail();
		}

		private void toolStripButtonEdit_Click(object sender, EventArgs e)
		{

		}

		private void dgvData_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
		{
			DataGridView? dgvData = sender as DataGridView;

			if (dgvData != null) 
			{
				string columnName = dgvData.Columns[e.ColumnIndex].Name;

				if (columnName == "Countdown")
					columnName = "DeadlineDate";

				if (sortColumn == columnName)
				{
					// If the same column is clicked again, toggle the sort order
					sortOrder = (sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
				}
				else
				{
					// If a new column is clicked, default to ascending order
					sortOrder = SortOrder.Ascending;
					sortColumn = columnName;
				}

				if (selectedTab == "projectTab")
				{
					LoadData("Project", dgvData);
				}
				else if (selectedTab == "movieTab")
				{
					LoadData("Movie", dgvData);
				}
				else if (selectedTab == "episodeTab")
				{
					LoadData("Episode", dgvData);
				}
				else if (selectedTab == "taskTab")
				{
					LoadData("Task", dgvData);
				}
			}
		}

		private void otherSettingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formManagement == null || formManagement.IsDisposed)
			{
				formManagement = new FormManagement();
				formManagement.Show();
			}
			else
			{
				// If the form is already open, bring it to the front
				formManagement.BringToFront();
			}
		}

		private void tabControlData_SelectedIndexChanged(object sender, EventArgs e)
		{
			HandleTabSelection();
		}

		private void tabControlData_ControlAdded(object sender, ControlEventArgs e)
		{
			if (tabControlData.TabPages.Count == 1)  // Only trigger if this is the first tab
			{
				HandleTabSelection();
			}
		}

		private void HandleTabSelection()
		{
			if (tabControlData.SelectedTab != null)
			{
				// Get the currently selected tab
				selectedTab = tabControlData.SelectedTab.Name;
			}
		}
	}
}
