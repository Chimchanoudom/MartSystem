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
    public partial class CreateExpense : Form
    {
        public CreateExpense()
        {
            InitializeComponent();
        }



        public CreateExpense(DataTable dtExpenseData)
        {
            InitializeComponent();
            this.dtExpenseData = dtExpenseData;
        }

        public CreateExpense(DataRow dataRow)
        {
            InitializeComponent();
            this.dataRow = dataRow;
        }


        string sql;
        int id;
        
        DataTable dtExpenseData;
        DataRow dataRow;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                if (txtAmount.Text == "" || txtDescription.Text == "")
                    return;

                double amount = double.Parse(txtAmount.Text);


                dgvExpenseDetail.Rows.Add(txtDescription.Text,amount.ToString("#,##0.00"));
                getTotal();

                txtDescription.Text =
                    txtAmount.Text = "";
            }
            dgvExpenseDetail.ClearSelection();

        }

        double total;

        void getTotal()
        {
            total += double.Parse(txtAmount.Text);
            txtTotal.Text = total.ToString("#,##0.00");
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("0123456789\b.".IndexOf(e.KeyChar) == -1||(e.KeyChar == '.' && txtAmount.Text.Contains(".")))
            {
                e.KeyChar = '\0';
            }
        }



        private void dgvExpenseDetail_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvExpenseDetail.SelectedRows.Count == 1;

            btnDelete.Enabled = dgvExpenseDetail.SelectedRows.Count > 0;

            btnAdd.Text=dgvExpenseDetail.SelectedRows.Count > 0 ? "Cancel":"Add";


            if (dgvExpenseDetail.SelectedRows.Count == 1)
            {
                int selectedIndex = dgvExpenseDetail.SelectedRows[0].Index;
                txtDescription.Text = dgvExpenseDetail.Rows[selectedIndex].Cells["Description"].Value + "";
                txtAmount.Text= dgvExpenseDetail.Rows[selectedIndex].Cells["Amount"].Value + "";

            }
            else
            {
                txtDescription.Text =
                    txtAmount.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvExpenseDetail.SelectedRows[0].Index;
            double oldAmount =double.Parse(dgvExpenseDetail.Rows[selectedRowIndex].Cells["Amount"].Value + "");

            total -= oldAmount;

            dgvExpenseDetail.Rows[selectedRowIndex].Cells["Description"].Value = txtDescription.Text;
            dgvExpenseDetail.Rows[selectedRowIndex].Cells["Amount"].Value = string.Format("{0:N}", txtAmount.Text);

           

            getTotal();
            txtDescription.Text =
                   txtAmount.Text = "";

            dgvExpenseDetail.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow temp in dgvExpenseDetail.SelectedRows)
            {
                total -= double.Parse(temp.Cells["Amount"].Value + "");
                dgvExpenseDetail.Rows.Remove(temp);
            }

            txtTotal.Text = total.ToString("#,##0.00");
            dgvExpenseDetail.ClearSelection();
        }

        bool error;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvExpenseDetail.Rows.Count > 0)
            {
                if (dataRow!=null)
                {
                    sql = "delete from expenseDetail where expenseid='" + lbExpenseID.Text + "'";

                    sql += "update expense set Total=" + txtTotal.Text + " where expenseID='" + lbExpenseID.Text + "'";


                    insertDataIntoExpenseDetail();
                    Close();

                    return;
                }


                DateTime now = DateTime.Now;
                sql = "insert into Expense values('"+lbExpenseID.Text+"','"+now+"',"+total+")";

               
                insertDataIntoExpenseDetail();
                total = 0;
            }
            else
            {
                MessageBox.Show("Please input atleast a row", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void insertDataIntoExpenseDetail()
        {
            sql += "insert into ExpenseDetail values";
            for (int i = 0; i < dgvExpenseDetail.Rows.Count; i++)
            {
                sql += "('" + lbExpenseID.Text + "','" + dgvExpenseDetail.Rows[i].Cells["Description"].Value + "'," + dgvExpenseDetail.Rows[i].Cells["Amount"].Value + "),";
            }

            sql = sql.Substring(0, sql.Length - 1) + ";";

            dataCon.ExecuteActionQry(sql, ref error);

            if (!error)
            {
                MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (dataRow==null)
                {
                    DateTime now = DateTime.Now;
                    dtExpenseData.Rows.Add(lbExpenseID.Text, now, txtTotal.Text);
                }
                else
                {
                    dataRow["Total"] = txtTotal.Text+"";
                }
                dgvExpenseDetail.Rows.Clear();

                txtDescription.Text =
               txtAmount.Text = "";
                txtTotal.Text = "0.00";

                lbExpenseID.Text = (id + 1).ToString("Exp_000");

            }
        }

        private void CreateExpense_Load(object sender, EventArgs e)
        {

            dgvExpenseDetail.Columns["Amount"].DefaultCellStyle.Format = "#,##0.00";
            dgvExpenseDetail.ClearSelection();
            if (dataRow != null)
            {
                lbExpenseID.Text = dataRow["Expense ID"] + "";

                sql = "select Desciption,amount from ExpenseDetail where expenseID='" + lbExpenseID.Text + "'";
                dataCon.Con.Open();
                SqlDataReader dataReader = dataCon.ExecuteQry(sql);
                while (dataReader.Read())
                {
                    double subTotal = double.Parse(dataReader.GetValue(1) + "");
                    dgvExpenseDetail.Rows.Add(dataReader.GetString(0),subTotal);
                    total += subTotal;
                    txtTotal.Text = subTotal.ToString("#,##0.00");
                }
                dataCon.Con.Close();

                return;
            }
                

            getInvoiceID();

            
        }

        void getInvoiceID()
        {
            sql = "newGetAutoID 'Expenseid','_','expense';";

            dataCon.Con.Open();
            SqlDataReader dataReader = dataCon.ExecuteQry(sql);

            dataReader.Read();
            id = dataReader.GetInt32(0);
            lbExpenseID.Text = id.ToString("Exp_000");

            dataCon.Con.Close();
        }
    }
}
