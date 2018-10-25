using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MartSystem;


namespace MartSystem
{
    public partial class supplyer : Form
    {
        public supplyer()
        {
            InitializeComponent();
        }
        DataTable dt;
        String ID;
        bool update = false;
        void AutoID()
        {
            ID = dom_Design.GenerateID(ID.Substring(5), "SP00_");
        }
        void Clear()
        {
            
            txtPhoneNumber.Text = "";
            txtSupplierName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            lblID.Text = ID;
            datasupplier.ClearSelection();
        }
        private void supplyer_Load(object sender, EventArgs e)
        {
            dt = Dom_SqlClass.retriveData("Supplier", "", new string[] { "*"});
            datasupplier.DataSource = dt;
            dom_Design.GenerateColumHeader(new string[] { "ID", "Supplier Name", "Phone", "Email", "Address" }, 5, datasupplier);
            dom_Design.ColumnName(datasupplier, 5, new string[] {"ID","SupName","Tel","Email","Address" });
            ID=Dom_SqlClass.GetIDFromDB("SupID", "_", "Supplier");
            ID=dom_Design.GenerateID(ID, "SP00_");
            Clear();
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            dom_Design.CharaterOnly(e);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            dom_Design.NumberOnly(e);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (datasupplier.SelectedRows.Count == 0)
            {
                if (txtAddress.Text != "" && txtEmail.Text != "" && txtSupplierName.Text != "" && txtPhoneNumber.Text != "")
                {
                  dt.Rows.Add(new object[] { lblID.Text, txtSupplierName.Text, txtPhoneNumber.Text, txtEmail.Text, txtAddress.Text });
                    AutoID();
                    Clear();
                    update = true;
                }
                else
                {
                    MessageBox.Show("Please! input values in all of box!");
                }
            }
            else
            {
                DialogResult dir = MessageBox.Show("Do you want to cancell this selection ?", "selection will be cancell", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                {
                    Clear();
                    datasupplier.ClearSelection();
                }
            }

        }

        private void datasupplier_SelectionChanged(object sender, EventArgs e)
        {
            if (datasupplier.SelectedRows.Count == 1)
            {
                int index = datasupplier.SelectedRows[0].Index;
                lblID.Text = datasupplier.Rows[index].Cells[0].Value.ToString();
                txtSupplierName.Text = datasupplier.Rows[index].Cells[1].Value.ToString(); ;
                txtPhoneNumber.Text = datasupplier.Rows[index].Cells[2].Value.ToString(); ;
                txtEmail.Text = datasupplier.Rows[index].Cells[3].Value.ToString(); ;
                txtAddress.Text = datasupplier.Rows[index].Cells[4].Value.ToString(); ;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (datasupplier.SelectedRows.Count == 1)
            {
                int index = datasupplier.SelectedRows[0].Index;
                dt.Rows[index].SetField("SupID", lblID.Text);
                dt.Rows[index].SetField("SupName", txtSupplierName.Text);
                dt.Rows[index].SetField("phone", txtPhoneNumber.Text);
                dt.Rows[index].SetField("Email", txtEmail.Text);
                dt.Rows[index].SetField("Address", txtAddress.Text);
                Clear();
                update = true;

            }
            else
            {
                MessageBox.Show("Please Select one data in List to Edit");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (datasupplier.SelectedRows.Count > 0)
            {
                DialogResult dir = MessageBox.Show("Do you want to delete "+datasupplier.SelectedRows.Count+ " Rows?", "Your Data will be delete", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                {
                    while (datasupplier.SelectedRows.Count > 0)
                    {
                        int index = datasupplier.SelectedRows[0].Index;
                        datasupplier.Rows.RemoveAt(index);
                    }
                    Clear();
                    update = true;
                }
            }
            else
            {
                MessageBox.Show("Please Select any data in List to Edit");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (update == true)
            {
                Dom_SqlClass.UpdateDate(dt);
                update = false;
            }

        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.ForeColor = Color.Black;
            txtSearch.Font = new Font("Century Gothic", 12);
            txtSearch.Text = "";
        }

        private void txtSearch_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearch.Focused == false)
            {
                txtSearch.ForeColor = Color.Gray;
                txtSearch.Font = new Font("Century Gothic", 9);
                txtSearch.Text = "Search by Supplier Name and Telephone";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Search by Supplier Name or Telephone")
            {
                String Search = "";
                int i = 0;
                bool s = int.TryParse(txtSearch.Text, out i);
                if (s == true)
                    Search = "Phone=" + txtSearch.Text ;
                else
                    Search = "SupName=" +"'"+ txtSearch.Text.ToLower()+"'";
                dt.DefaultView.RowFilter = Search;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Empty;
            txtSearch_MouseLeave(null, null);
            Clear();
        }

        private void supplyer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (update == true)
            {
                DialogResult dir = MessageBox.Show("Do you wnat to save all your data?", "Your Data doesn't saved ! ", MessageBoxButtons.YesNo);
                if(dir==DialogResult.Yes)
                Dom_SqlClass.UpdateDate(dt);
            }
        }
    }
}
