using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
    public partial class category : Form
    {
        public category()
        {
            InitializeComponent();
        }
        DataTable dt;
        int ID;
        bool update = false;
        void AutoID()
        {
            ID += 1;
        }
        void Clear()
        {
            txtCatName.Text = "";
            lblID.Text = ID.ToString();
            dataCat.ClearSelection();
        }
        private void category_Load(object sender, EventArgs e)
        {
            dt = Dom_SqlClass.retriveData("Category", "", new string[] { "*" });
            dataCat.DataSource = dt;
            dom_Design.GenerateColumHeader(new string[] { "ID", "Category Name" }, 2, dataCat);
            ID = Dom_SqlClass.GetIDFromDB("CatID", "Category");
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataCat.SelectedRows.Count == 0)
            {
                if (txtCatName.Text != "")
                {
                    dt.Rows.Add(new object[] { lblID.Text, txtCatName.Text });
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
                    dataCat.ClearSelection();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataCat.SelectedRows.Count == 1)
            {
                int index = dataCat.SelectedRows[0].Index;
                dt.Rows[index].SetField("CatID", lblID.Text);
                dt.Rows[index].SetField("CatName", txtCatName.Text);
                Clear();
                update = true;

            }
            else
            {
                MessageBox.Show("Please Select one data in List to Edit");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataCat.SelectedRows.Count > 0)
            {
                DialogResult dir = MessageBox.Show("Do you want to delete " + dataCat.SelectedRows.Count + " Rows?", "Your Data will be delete", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                {
                    while (dataCat.SelectedRows.Count > 0)
                    {
                        int index = dataCat.SelectedRows[0].Index;
                        dataCat.Rows.RemoveAt(index);
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (update == true)
            {
                Dom_SqlClass.UpdateDate(dt);
                update = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Search by Category Name or Category ID")
            {
                String Search = "";
                int i = 0;
                bool s = int.TryParse(txtSearch.Text, out i);
                if (s == true)
                    Search = "CatID=" + txtSearch.Text;
                else
                    Search = "CatName=" + "'" + txtSearch.Text.ToLower() + "'";
                dt.DefaultView.RowFilter = Search;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Empty;
            txtSearch.Text = "Search by Category Name or Category ID";
            Clear();
        }

        private void txtCatName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataCat_SelectionChanged(object sender, EventArgs e)
        {
            if (dataCat.SelectedRows.Count == 1)
            {
                int index = dataCat.SelectedRows[0].Index;
                lblID.Text = dataCat.Rows[index].Cells[0].Value.ToString();
                txtCatName.Text = dataCat.Rows[index].Cells[1].Value.ToString(); ;
            }
        }

        private void category_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (update == true)
            {
                DialogResult dir = MessageBox.Show("Do you wnat to save all your data?", "Your Data doesn't saved ! ", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                    Dom_SqlClass.UpdateDate(dt);
            }
        }
    }
}
