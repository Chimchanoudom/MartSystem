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
    public partial class ExpenseData : Form
    {
        public ExpenseData()
        {
            InitializeComponent();
        }

        DataTable dtExpense = new DataTable();
        string sql;
        private void ExpenseData_Load(object sender, EventArgs e)
        {
            sql = "select ExpenseId as 'Expense ID', DateCreate as 'Date Created',total as 'Total' from expense";

            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sql,dataCon.Con);

            dataAdaptor.Fill(dtExpense);
            dgvExpenseData.DataSource=dtExpense;

            dgvExpenseData.Columns["Date Created"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvExpenseData.Columns["Total"].DefaultCellStyle.Format = "#,##0.00";

            dgvExpenseData.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }



        private void rndDateCreated_CheckedChanged(object sender, EventArgs e)
        {
            dtDate.Visible = rndDateCreated.Checked;
        }

        private void dgvExpenseData_SelectionChanged(object sender, EventArgs e)
        {
            editToolStripMenuItem.Visible = dgvExpenseData.SelectedRows.Count == 1;
            deleteToolStripMenuItem.Visible= dgvExpenseData.SelectedRows.Count >= 1;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvExpenseData.SelectedRows[0].Index;
            string id = dgvExpenseData.Rows[selectedRowIndex].Cells["Expense ID"].Value + "";

            DataGridViewRowCollection expenseDataRow = dgvExpenseData.Rows;

            CreateExpense createExpense = new CreateExpense(id, selectedRowIndex,expenseDataRow);
            createExpense.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete selected row(s)?","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                sql = "delete from expense where expenseID in(";

                for(int i = 0; i < dgvExpenseData.SelectedRows.Count; i++)
                {
                    int selectedRowIndex = dgvExpenseData.SelectedRows[i].Index;
                    sql +="'" +dgvExpenseData.Rows[selectedRowIndex].Cells["Expense ID"].Value + "',";
                }

                sql = sql.Substring(0,sql.Length - 1) + ");";

                bool error = false;
                dataCon.ExecuteActionQry(sql, ref error);
                if (!error)
                {
                    foreach(DataGridViewRow temp in dgvExpenseData.SelectedRows)
                    {
                        dgvExpenseData.Rows.Remove(temp);
                    }
                    MessageBox.Show("Deleted successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection expenseDataRow = dgvExpenseData.Rows;
            
            CreateExpense createExpense = new CreateExpense(dgvExpenseData, expenseDataRow);
            createExpense.ShowDialog();


        }
    }
}
