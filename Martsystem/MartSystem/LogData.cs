using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
    public partial class LogData : Form
    {
        public LogData()
        {
            InitializeComponent();
        }

        public LogData(string formTitle,string sql)
        {
            InitializeComponent();
            Text = formTitle;
            this.sql = sql;
        }

        string sql;
        private void LogData_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, dataCon.Con);
            DataTable dtLog = new DataTable();
            dataAdapter.Fill(dtLog);

            dgvLogData.DataSource = dtLog;

            dgvLogData.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
        }
    }
}
