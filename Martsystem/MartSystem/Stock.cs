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
            string sql = "select stockid 'Stock ID', ProName 'Product Name',importDate 'Import Date',s.Qty 'Quantity',id.UnitPrice 'Unit Price',ExpiredDate 'Expire Date' from stock s join Product p on s.ProID=p.ProID join Import i on s.ImportID=i.ImportID join ImportDetail id on (id.ImportID=s.ImportID and id.ProID=s.ProID);";

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
            else if (rndImportDate.Checked) filter = "[Import Date]=";
            else if (rndExpiredDate.Checked) filter = "[Expire Date]=";

            DateTime date = new DateTime(dtDate.Value.Year, dtDate.Value.Month, dtDate.Value.Day, 0, 0,0);

            if (rndImportDate.Checked || rndExpiredDate.Checked) filter += "'" + date + "'";
            else if (rndProductName.Checked) filter += "'" + txtSearch.Text + "'";



            dtStock.DefaultView.RowFilter = filter;
        }

        private void rndProductName_CheckedChanged(object sender, EventArgs e)
        {
            dtDate.Visible = !rndProductName.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtStock.DefaultView.RowFilter = string.Empty;
        }
    }
}
