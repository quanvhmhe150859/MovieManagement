using CartoonMovieManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartoonMovieManagement
{
    public partial class FormHistoryLog : Form
    {
        CartoonProductManagementContext context = new CartoonProductManagementContext();

        public FormHistoryLog()
        {
            InitializeComponent();
        }

        private void FormHistoryLog_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            var data = context.TaskHistoryLogs.ToList();
            dataGridView1.DataSource = data;

            dataGridView1.Columns["Task"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
