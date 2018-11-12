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

        public CreateInvoice(DataTable dtInvoiceData)
        {
            InitializeComponent();
            btnSave.Width = flowLayoutPanel1.Width;
            this.dtInvoiceData = dtInvoiceData;
        }

        public CreateInvoice(DataRow dataRowInvoice)
        {
            InitializeComponent();
            this.dataRowInvoice = dataRowInvoice;
            btnDelete.Visible= txtDate.Visible = true;
            btnSave.Width = btnDelete.Width;
            txtInvoiceID.Text = dataRowInvoice["Invoice ID"] + "";

            txtDate.Text = dataRowInvoice["Date Created"] + "";

            double n = double.Parse(dataRowInvoice["Dollars"] + "");
            txtRecieveEng.Text = n.ToString("#,##0.00");

            n = double.Parse(dataRowInvoice["Riel"] + "");
            txtRecieveKh.Text = n.ToString("#,##0");

            n = double.Parse(dataRowInvoice["rate"] + "");
            txtRate.Text = n.ToString("#,##0");


            n = double.Parse(txtGrandEng.Text);
            n *= double.Parse(txtRate.Text, System.Globalization.NumberStyles.AllowThousands);

            txtGrandKh.Text = n.ToString("#,##0");

            txtReceive_LostFocus(txtRecieveEng, null);




            sql = "select ProName,qtyType,i.qty,UnitPrice,p.proId from InvoiceDetail i join Product p on i.ProID=p.ProID;";

            dataCon.Con.Open();
            SqlDataReader dataReader = dataCon.ExecuteQry(sql);
            
            while (dataReader.Read())
            {
                dgvInvoiceDetail.Rows.Add(dataReader.GetString(0), dataReader.GetString(1), "+",Convert.ToDouble(dataReader.GetValue(2)), "-",Convert.ToDouble(dataReader.GetValue(3)), "0", "x", dataReader.GetString(4));
            }

            dataCon.Con.Close();

        }


        

        DataRow dataRowInvoice;
        DataTable dtProduct = new DataTable();
        string sql;
        double total,subtotal,oldSubTotal, recieve, qtyForEndEdit;
        int id;
        DataTable dtInvoiceData;


        private void CreateInvoice_Load(object sender, EventArgs e)
        {
            if (dataRowInvoice == null)
            {
                dataCon.getRate();
                txtRate.Text = dataCon.rate.ToString("#,##0");

                dataCon.Con.Open();
                sql = "newGetAutoID 'invid','_','invoice';";
                SqlDataReader dataReader = dataCon.ExecuteQry(sql);
                dataReader.Read();
                id = dataReader.GetInt32(0);
                txtInvoiceID.Text = id.ToString("Inv_000");
                dataCon.Con.Close();
            }
           
            sql = "select Barcode,proname,qty,QtyType,UnitPrice,proID from product;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql,dataCon.Con);

            dataAdapter.Fill(dtProduct);



            dgvInvoiceDetail.Width = panel10.Width - panel2.Width;

            for(int i = 0; i < dtProduct.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem(dtProduct.Rows[i]["proname"] + "", dtProduct.Rows[i]["Barcode"] + "");
                cbProduct.Items.Add(item);
            }
            txtBarcode.Focus();

           

            txtRecieveEng.LostFocus += new EventHandler(txtReceive_LostFocus);
            txtRecieveKh.LostFocus += new EventHandler(txtReceive_LostFocus);

            if (dataRowInvoice != null)
            {
                foreach(DataGridViewRow temp in dgvInvoiceDetail.Rows)
                {
                    DataRow[] dataRow = dtProduct.Select("proID='" + temp.Cells["proID"].Value + "'");

                    if (dataRow.Length == 1)
                        dataRow[0]["qty"] = double.Parse(dataRow[0]["qty"] + "") + double.Parse(temp.Cells["qty"].Value + "");

                }
            }
        }



        private void dgvInvoiceDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getQty(e);
        }


        void removeRowFromDGV(int rowIndex)
        {
            total -= double.Parse(dgvInvoiceDetail.Rows[rowIndex].Cells["ColSubTotal"].Value + "");
            dgvInvoiceDetail.Rows.RemoveAt(rowIndex);
            ShowGrandTotalAndChange();
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

            ShowGrandTotalAndChange();
        }
       
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
            ShowGrandTotalAndChange();
        }

        
        void ShowGrandTotalAndChange()
        {
            txtGrandEng.Text = total.ToString("#,##0.00");

            double totalKh = total * int.Parse(txtRate.Text,System.Globalization.NumberStyles.AllowThousands);
            roundKhMoney(ref totalKh);
            txtGrandKh.Text = totalKh.ToString("#,##0");

            showChange();
        }


        void roundKhMoney(ref double khMoney)
        {
            double m = khMoney;

            if (m % 100 < 50)
            {
                khMoney = Math.Abs(khMoney) - (khMoney % 100);
            }
            else
            {
                khMoney = Math.Abs(khMoney) - (khMoney % 100)+100;
            }

            if (m < 0)
                khMoney *= -1;
            
        }

        void showChange()
        {
            double change = recieve - total;

            double changeKh = change * int.Parse(txtRate.Text, System.Globalization.NumberStyles.AllowThousands);
            roundKhMoney(ref changeKh);

            if (changeKh == 0)
            {
                change = 0;
                recieve = total;
            }


            txtChangeEng.Text = change.ToString("#,##0.00");

            txtChangeKh.Text = changeKh.ToString("#,##0");


        }



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
                if (temp.Name.EndsWith ("Eng"))
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
            if ("0123456789\b".IndexOf(e.KeyChar) == -1)
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
                 .Where(r => r.Cells["ProID"].Value.ToString().Equals(dr[0]["proID"]))
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
                    ShowGrandTotalAndChange();
                    
                    return;
                }


                dgvInvoiceDetail.Rows.Add(dr[0]["ProName"], dr[0]["QtyType"], "+",1,"-",dr[0]["UnitPrice"],"0","x",dr[0]["proID"]);

                int lastIndexInDgv = dgvInvoiceDetail.RowCount - 1;

                getSubTotalAndGrandTotal(lastIndexInDgv, double.Parse(dgvInvoiceDetail.Rows[lastIndexInDgv].Cells["Qty"].Value+""));

                dgvInvoiceDetail.Rows[lastIndexInDgv].Cells["ColSubTotal"].Value = subtotal + "";

                ShowGrandTotalAndChange();
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



        private void txtReceive_LostFocus(object sender, EventArgs e)
        {
            double recieveKh=0, recieveEng=0;
            try
            {
                 recieveKh = double.Parse(txtRecieveKh.Text);
                if (recieveKh % 100 != 0)
                    throw new FormatException();
            }
            catch (FormatException)
            {
               
                txtRecieveKh.Text = "0";
            }

            try
            {
                recieveEng = double.Parse(txtRecieveEng.Text);
            }
            catch (FormatException)
            {
                txtRecieveEng.Text = "0.00";
            }



            recieve = Math.Round(recieveKh / int.Parse(txtRate.Text,System.Globalization.NumberStyles.AllowThousands),2) + recieveEng;

            TextBox txt = (TextBox)sender;

            double amountInTxt = double.Parse(txt.Text);

            if (txt.Name.EndsWith("Eng"))
                txt.Text = amountInTxt.ToString("#,##0.00");
            else
                txt.Text = amountInTxt.ToString("#,##0");


            showChange();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            dgvInvoiceDetail.Rows.Clear();
            total = 0;
            ShowGrandTotalAndChange();
        }

        private void CreateInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void cbProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txtGrandEng_TextChanged(object sender, EventArgs e)
        {
            
        }

        double FormatStringToNumber(String number)
        {
            string[] n = number.Split(',');

            string result="";
            foreach (string temp in n)
                result += temp+"";

            return double.Parse(result);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> qtyProductToRemove = new Dictionary<string, double>();

            if (recieve >= total && total > 0)
            {
                //comment this line when done testing
                    UserLoginDetail.empID = "Emp_001";
                    UserLoginDetail.fName = "Vut";
                    UserLoginDetail.lName = "Pov";
                //

                DateTime now = DateTime.Now;
                double recieveKh = FormatStringToNumber(txtRecieveKh.Text);
                double recieveEng = FormatStringToNumber(txtRecieveEng.Text);

                if (dataRowInvoice == null)
                {
                    sql = "insert into invoice values('" + txtInvoiceID.Text + "','" + now + "'," + total + "," + dataCon.rate + "," + recieveEng + "," + recieveKh + ",'" + UserLoginDetail.empID + "');";
                }
                else
                {
                    sql += "delete from invoiceDetail where invID='" + txtInvoiceID.Text + "';";
                }

                
                sql += "insert into invoiceDetail(invID,ProID,qty,SubTotal) values";

                foreach (DataGridViewRow temp in dgvInvoiceDetail.Rows)
                {
                    sql += "('"+txtInvoiceID.Text+"','"+temp.Cells["proID"].Value+"',"+temp.Cells["Qty"].Value+","+temp.Cells["ColSubtotal"].Value +"),";

                    qtyProductToRemove.Add(temp.Cells["ProID"].Value +"", Convert.ToDouble(temp.Cells["Qty"].Value));
                }

                sql = sql.Substring(0, sql.Length - 1) + ";";

                bool error = false;
                dataCon.ExecuteActionQry(sql, ref error);

                if (!error)
                {
                    foreach(DataRow temp in dtProduct.Rows)
                    {
                        if (qtyProductToRemove.ContainsKey(temp["proID"] + ""))
                        {
                            temp["qty"] = (double)temp["qty"] - qtyProductToRemove[temp["proID"]+""];
                        }
                    }

                    MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dtInvoiceData != null)
                    {
                        dtInvoiceData.Rows.Add(txtInvoiceID.Text, now, txtGrandEng.Text, dataCon.rate, recieveEng, recieveKh, UserLoginDetail.fName + " " + UserLoginDetail.lName);
                    }
                    else
                    {
                        dataRowInvoice["Total"] = txtGrandEng.Text;
                        dataRowInvoice["Dollars"] = recieveEng;
                        dataRowInvoice["Riel"] = recieveKh;
                        this.Close();
                        return;
                    }

                    btnClean_Click(null, null);
                    
                    total =
                        oldSubTotal =
                        recieve =
                        subtotal = 0;

                    txtGrandEng.Text = 
                        txtRecieveEng.Text=
                        txtChangeEng.Text= "0.00";

                    txtGrandKh.Text =
                        txtRecieveKh.Text =
                        txtChangeKh.Text = "0";

                    id++;
                    txtInvoiceID.Text = id.ToString("Inv_000");

                    
                }
            }
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {

        }



    }
}
