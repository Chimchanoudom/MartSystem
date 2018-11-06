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
    public partial class CreateInvoice : Form
    {
        public CreateInvoice()
        {
            InitializeComponent();
        }

        DataTable dtProduct = new DataTable();
        string sql;
        double total;
        private void CreateInvoice_Load(object sender, EventArgs e)
        {
            sql = "select Barcode,proname,qty,QtyType,UnitPrice from product;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql,dataCon.Con);

            dataAdapter.Fill(dtProduct);



            dgvInvoiceDetail.Rows.Add("Coca", "Can", "+", "3", "-", 0.5.ToString("#,##0.00"), 1.5003424.ToString("#,##0.00"), "x");

            
            
    }

        private void dgvInvoiceDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getQty(e);
        }

        void getQty(DataGridViewCellEventArgs e)
        {
            int qtyToAdd=0;

            switch (e.ColumnIndex)
            {
                case 2:
                    qtyToAdd = 1;
                    break;
                case 4:
                    qtyToAdd = -1;
                    break;
                case 7:
                    dgvInvoiceDetail.Rows.RemoveAt(e.RowIndex);
                    return;
                default:
                    return;
            }

            string proName = dgvInvoiceDetail.Rows[e.RowIndex].Cells[0].Value + "";
            DataRow[] dr = dtProduct.Select("proName='" + proName+"'");


            double qty = double.Parse(dgvInvoiceDetail.Rows[e.RowIndex].Cells[3].Value + "");
            

            if (qty== 1&&qtyToAdd==-1)
            {
                dgvInvoiceDetail.Rows.RemoveAt(e.RowIndex);
                return;
            }
            else if ((double)dr[0][2] == qty&&qtyToAdd==1)
                return;

            qty += qtyToAdd;

            getSubTotal(e, qty);
        }
        
        void getSubTotal(DataGridViewCellEventArgs e,double qty)
        {
            double subtotal;
            dgvInvoiceDetail.Rows[e.RowIndex].Cells[3].Value = qty;

            subtotal = double.Parse(dgvInvoiceDetail.Rows[e.RowIndex].Cells[5].Value + "") * qty;

            dgvInvoiceDetail.Rows[e.RowIndex].Cells[6].Value = subtotal.ToString("#,##0.00");

            getGrandTotal(e.RowIndex);
        }

        private void dgvInvoiceDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            getGrandTotal(dgvInvoiceDetail.Rows.Count - 1);
        }


        void getGrandTotal(int rowIndex)
        {
            total += double.Parse(dgvInvoiceDetail.Rows[rowIndex].Cells["SubTotal"].Value + "");
            double totalKh = total * 4000;
            txtGrandEng.Text = total.ToString("#,##0.00");
            txtGrandKh.Text = totalKh.ToString("#,##0");
        }

        double qtyForEndEdit = -1;
       
        private void dgvInvoiceDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            qtyForEndEdit = double.Parse(dgvInvoiceDetail.Rows[e.RowIndex].Cells[3].Value + "");
           
        }

        private void lbRecieve_Click(object sender, EventArgs e)
        {
            Control c = (Label)sender;
            if (c.Text == "$")
            {
                c.Text = "៛";
                SendTextBoxToBack(c.Parent);
            }
            else
            {
                c.Text = "$";
                SendTextBoxToBack(c.Parent);
            }
                
        }

        void SendTextBoxToBack(Control panel)
        {
            foreach (Control temp in panel.Controls.OfType<TextBox>())
            {
                string name = temp.Name;
                string suffix = name.Substring(name.Length - 3, 3);

                if (suffix == "Eng")
                {
                    temp.Visible = !temp.Visible;
                    break;
                }
                    
                    
            }
                
        }

        private void dgvInvoiceDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
        }

        private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b".IndexOf(e.KeyChar)==-1)
            {
                e.KeyChar = '\0';
            }
        }

        private void dgvInvoiceDetail_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            total -=double.Parse(e.Row.Cells["SubTotal"].Value + "");
        }
    }
}
