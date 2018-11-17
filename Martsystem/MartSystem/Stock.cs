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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }


        DataTable dtStock = new DataTable();

        private void Stock_Load(object sender, EventArgs e)
        {
            string sql = "select stockid 'Stock ID', ProName 'Product Name',importDate 'Import Date',s.Qty 'Quantity',s.UnitPrice 'Unit Price',ExpiredDate 'Expire Date' from stock s join Product p on s.ProID=p.ProID join Import i on s.ImportID=i.ImportID ;";

            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sql,dataCon.Con);

            dataAdaptor.Fill(dtStock);

            dgvStock.DataSource = dtStock;

            dgvStock.Columns["Import Date"].DefaultCellStyle.Format =
                dgvStock.Columns["Expire Date"].DefaultCellStyle.Format
                = "dd/MM/yyyy";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "";
            if (rndProductName.Checked) filter = "[Product Name]=";
            



            if (rndImportDate.Checked)
            {
                string[] st = txtSearch.Text.Split('-');
                filter = "[Import Date]>='" + st[0] + "' AND [Import Date] <= '" + st[1] + "'";
            }
            else if (rndProductName.Checked) filter += "'" + txtSearch.Text + "'";
            else if (rndExpiredDate.Checked)
            {
                string[] st = txtSearch.Text.Split('-');
                filter = "[Expire Date]>='" + st[0] + "' AND [Expire Date] <= '" + st[1] + "'";
            }



            dtStock.DefaultView.RowFilter = filter;
        }

        private void rndProductName_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtStock.DefaultView.RowFilter = string.Empty;
        }

        private void rndImportDate_Click(object sender, EventArgs e)
        {
            SearchDate searchDate = new SearchDate(txtSearch);
            searchDate.ShowDialog();

            if (searchDate.DialogResult != DialogResult.Yes)
                rndProductName.Checked = true;
        }
    }
}
