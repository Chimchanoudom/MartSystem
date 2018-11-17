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
    public partial class InvoiceData : Form
    {
        public InvoiceData()
        {
            InitializeComponent();
        }

        DataTable dtInvoiceData = new DataTable();
        string sql;

        private void InvoiceData_Load(object sender, EventArgs e)
        {
           
            sql = "select InvID 'Invoice ID',DateCreated 'Date Created',total 'Total',rate 'Rate',recieveEng 'Dollars',recieveKh 'Riel',CONCAT(fname,' ',Lname) 'Employee' from Invoice i left join Employee e on i.EmpID=e.EmpID;";
            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sql,dataCon.Con);

            dataAdaptor.Fill(dtInvoiceData);

            dgvInvoiceData.DataSource = dtInvoiceData;

            dgvInvoiceData.Columns["Date Created"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss tt";
            dgvInvoiceData.Columns["Total"].DefaultCellStyle.Format=
                dgvInvoiceData.Columns["Dollars"].DefaultCellStyle.Format
                = "#,##0.00";

            dgvInvoiceData.Columns["Rate"].DefaultCellStyle.Format =
                dgvInvoiceData.Columns["Riel"].DefaultCellStyle.Format
                = "#,##0";

            dgvInvoiceData.ClearSelection();
        }

        private void dgvInvoiceData_SelectionChanged(object sender, EventArgs e)
        {
            logToolStripMenuItem.Visible= editToolStripMenuItem.Visible = dgvInvoiceData.SelectedRows.Count == 1;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateInvoice createInvoice = new CreateInvoice(dtInvoiceData);
            createInvoice.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvInvoiceData.SelectedRows[0].Index;
            DataRow selectedRow = dtInvoiceData.Rows[selectedRowIndex];

            CreateInvoice createInvoice = new CreateInvoice(selectedRow);
            createInvoice.ShowDialog();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvInvoiceData.SelectedRows[0].Index;
            string id = dgvInvoiceData.Rows[selectedRowIndex].Cells["Invoice ID"].Value + "";
            sql = "select InvLogID 'Invoice Log ID',editdate 'Edit Date',CONCAT(fname,' ',Lname) 'Edit by' from InvoiceLog i join Employee e on i.EditBy=e.EmpID where invID='"+id+"';";

            LogData invoiceLog = new LogData("Log for Invoice " + id,sql);

            invoiceLog.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "";
            if (rndID.Checked)
                filter = "[Invoice ID]=";

            else if (rndDateCreated.Checked) filter = "[Date Created]";

            if (!rndDateCreated.Checked)
            {
                filter += "'" + txtSearch.Text + "'";
            }
            else
            {
                string[] st = txtSearch.Text.Split('-');
                filter += ">='" + st[0] + "' AND [Date Created] <= '" + st[1] + "'";
            }

            dtInvoiceData.DefaultView.RowFilter = filter;
        }



        private void rndDateCreated_Click(object sender, EventArgs e)
        {
           
            SearchDate searchDate = new SearchDate(txtSearch);
            searchDate.ShowDialog();

            if (searchDate.DialogResult != DialogResult.Yes)
                rndID.Checked = true;

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtInvoiceData.DefaultView.RowFilter = string.Empty;
        }
    }
}
