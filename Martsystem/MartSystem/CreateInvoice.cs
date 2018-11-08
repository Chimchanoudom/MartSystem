﻿using System;
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
            dataCon.getRate();

            txtRate.Text = dataCon.rate.ToString("#,##0");
            sql = "select Barcode,proname,qty,QtyType,UnitPrice from product;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql,dataCon.Con);

            dataAdapter.Fill(dtProduct);



            //dgvInvoiceDetail.Rows.Add("Coca", "Can", "+", "3", "-", 0.5.ToString("#,##0.00"), 1.5003424.ToString("#,##0.00"), "x");

            //dgvInvoiceDetail.Rows.Add("Coca", "Can", "+", "3", "-", 0.5.ToString("#,##0.00"), 1.5003424.ToString("#,##0.00"), "x");

            dgvInvoiceDetail.Width = panel10.Width - panel2.Width;

            for(int i = 0; i < dtProduct.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem(dtProduct.Rows[i]["proname"] + "", dtProduct.Rows[i]["Barcode"] + "");
                cbProduct.Items.Add(item);
            }
            txtBarcode.Focus();
        }

        private void dgvInvoiceDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getQty(e);
        }


        void removeRowFromDGV(int rowIndex)
        {
            total -= double.Parse(dgvInvoiceDetail.Rows[rowIndex].Cells["ColSubTotal"].Value + "");
            dgvInvoiceDetail.Rows.RemoveAt(rowIndex);
            showGrandTotal();
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
                    removeRowFromDGV(e.RowIndex);
                    return;
                case 3:
                    break;
                default:
                    return;
            }

            string proName = dgvInvoiceDetail.Rows[e.RowIndex].Cells[0].Value + "";
            DataRow[] dr = dtProduct.Select("proName='" + proName+"'");


            double qty = double.Parse(dgvInvoiceDetail.Rows[e.RowIndex].Cells[3].Value + "");
            

            if (qty== 1&&qtyToAdd==-1)
            {
                removeRowFromDGV(e.RowIndex);
                return;
            }
            else if ((double)dr[0][2] == qty&&qtyToAdd==1)
                return;

            qty += qtyToAdd;

            dgvInvoiceDetail.Rows[e.RowIndex].Cells[3].Value = qty;
            getSubTotalAndGrandTotal(e.RowIndex, qty);

            showGrandTotal();
        }
        double subtotal;
        void getSubTotalAndGrandTotal(int rowIndex ,double qty)
        {
            total -=double.Parse(dgvInvoiceDetail.Rows[rowIndex].Cells[6].Value + "");

            subtotal = double.Parse(dgvInvoiceDetail.Rows[rowIndex].Cells[5].Value + "") * qty;

            total += subtotal;
            dgvInvoiceDetail.Rows[rowIndex].Cells[6].Value = subtotal.ToString("#,##0.00");

        }

        private void dgvInvoiceDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int rowIndex = dgvInvoiceDetail.Rows.Count - 1;
            getSubTotalAndGrandTotal(rowIndex,double.Parse(dgvInvoiceDetail.Rows[rowIndex].Cells["Qty"].Value+""));
            showGrandTotal();
        }

        double oldSubTotal;
        void showGrandTotal()
        {
            double totalKh = total * dataCon.rate;
            txtGrandEng.Text = total.ToString("#,##0.00");
            txtGrandKh.Text = totalKh.ToString("#,##0");
        }

        double qtyForEndEdit;
       
        private void dgvInvoiceDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            qtyForEndEdit = double.Parse(dgvInvoiceDetail.Rows[e.RowIndex].Cells[3].Value + "");
            oldSubTotal = double.Parse(dgvInvoiceDetail.Rows[e.RowIndex].Cells[6].Value + "");
        }

        private void lbRecieve_Click(object sender, EventArgs e)
        {
            Control c = (Label)sender;
            if (c.Text == "$")
            {
                c.Text = "៛";
                SetVisibleTextBox(c.Parent);
            }
            else
            {
                c.Text = "$";
                SetVisibleTextBox(c.Parent);
            }
                
        }

        void SetVisibleTextBox(Control panel)
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
            if ("0123456789\b.".IndexOf(e.KeyChar) == -1)
            {
                e.KeyChar = '\0';
            }
        }


        private void watermarked_Textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataRow[] dr = dtProduct.Select("Barcode='" + txtBarcode.Text + "'");

            if (dr.Length == 1)
            {
                txtBarcode.Text = "";

                DataGridViewRow drInDGV = dgvInvoiceDetail.Rows
                .Cast<DataGridViewRow>()
                 .Where(r => r.Cells["ProName"].Value.ToString().Equals(dr[0]["ProName"]))
                .FirstOrDefault();

               
                if (drInDGV != null)
                {
                    double qtyOfDr =(double)dr[0]["Qty"];

                    double oldQty = double.Parse(drInDGV.Cells["Qty"].Value + "");

                    

                    dgvInvoiceDetail.Rows[drInDGV.Index].Cells["Qty"].Value =double.Parse( dgvInvoiceDetail.Rows[drInDGV.Index].Cells["Qty"].Value+"")+1;

                    double newQty = double.Parse(dgvInvoiceDetail.Rows[drInDGV.Index].Cells["Qty"].Value+"");

                    if (qtyOfDr < newQty)
                    {
                        dgvInvoiceDetail.Rows[drInDGV.Index].Cells["Qty"].Value = oldQty;
                        newQty = oldQty;
                    }

                    getSubTotalAndGrandTotal(drInDGV.Index,newQty);
                    showGrandTotal();
                    
                    return;
                }

                dgvInvoiceDetail.Rows.Add(dr[0]["ProName"], dr[0]["QtyType"], "+",1,"-",dr[0]["UnitPrice"],"0","x");

                int lastIndexInDgv = dgvInvoiceDetail.RowCount - 1;

                getSubTotalAndGrandTotal(lastIndexInDgv, double.Parse(dgvInvoiceDetail.Rows[lastIndexInDgv].Cells["Qty"].Value+""));

                dgvInvoiceDetail.Rows[lastIndexInDgv].Cells["ColSubTotal"].Value = subtotal + "";

                showGrandTotal();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvInvoiceDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double qty=double.Parse(dgvInvoiceDetail.Rows[e.RowIndex].Cells[3].Value + "");

                DataRow[] dr = dtProduct.Select("proname='" + dgvInvoiceDetail.Rows[e.RowIndex].Cells["ProName"].Value+"'");

                if(qty>(double)dr[0]["Qty"])
                    throw new FormatException();
            }
            catch (FormatException)
            {
                dgvInvoiceDetail.Rows[e.RowIndex].Cells["Qty"].Value = qtyForEndEdit+"";
            }
        }

        private void txtRecieveEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtRecieveEng.Text.Contains(".") && e.KeyChar == '.')
                e.KeyChar = '\0';
            
            if ("1234567890\b.".IndexOf(e.KeyChar) == -1)
                e.KeyChar = '\0';

            
        }

        private void txtRecieveKh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("1234567890\b".IndexOf(e.KeyChar) == -1)
                e.KeyChar = '\0';
        }

        private void txtRecieveKh_Leave(object sender, EventArgs e)
        {
            try
            {
                int recieveKh = int.Parse(txtRecieveKh.Text, System.Globalization.NumberStyles.AllowThousands);
                if (recieveKh % 100 != 0)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                txtRecieveKh.Undo();
            }

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            int valueBefore = Int32.Parse(txtRecieveKh.Text, System.Globalization.NumberStyles.AllowThousands);
            txtRecieveKh.Text = String.Format(culture, "{0:N0}", valueBefore);


        }


        private void txtRecieveEng_Leave(object sender, EventArgs e)
        {
            double recieveEng = double.Parse(txtRecieveEng.Text);
            txtRecieveEng.Text = recieveEng.ToString("#,##0.00");
           

        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedIndex != -1)
            {
                string barcode = (cbProduct.SelectedItem as ComboboxItem).Value;
                txtBarcode.Text = barcode;
                cbProduct.SelectedIndex = -1;
                watermarked_Textbox1_KeyPress(null, null);
            }
        }
    }
}
