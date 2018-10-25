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
    public partial class Brand : Form
    {
        public Brand()
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
            txtBarndName.Text = "";
            lblID.Text = ID.ToString();
            dataBrand.ClearSelection();
        }
        private void branch_Load(object sender, EventArgs e)
        {
            dt = Dom_SqlClass.retriveData("Brand", "", new string[] { "*" });
            dataBrand.DataSource = dt;
            dom_Design.GenerateColumHeader(new string[] { "ID", "Brand Name" }, 2, dataBrand);
            ID = Dom_SqlClass.GetIDFromDB("BrandID", "Brand");
            Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataBrand.SelectedRows.Count == 0)
            {
                if (txtBarndName.Text != "")
                {
                    dt.Rows.Add(new object[] { lblID.Text, txtBarndName.Text });
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
                    dataBrand.ClearSelection();
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataBrand.SelectedRows.Count == 1)
            {
                int index = dataBrand.SelectedRows[0].Index;
                dt.Rows[index].SetField("BrandID", lblID.Text);
                dt.Rows[index].SetField("BrandName", txtBarndName.Text);
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
            if (dataBrand.SelectedRows.Count > 0)
            {
                DialogResult dir = MessageBox.Show("Do you want to delete " + dataBrand.SelectedRows.Count + " Rows?", "Your Data will be delete", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                {
                    while (dataBrand.SelectedRows.Count > 0)
                    {
                        int index = dataBrand.SelectedRows[0].Index;
                        dataBrand.Rows.RemoveAt(index);
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != " Search by Brand Name or Band ID")
            {
                String Search = "";
                int i = 0;
                bool s = int.TryParse(txtSearch.Text, out i);
                if (s == true)
                    Search = "BrandID=" + txtSearch.Text;
                else
                    Search = "CatName=" + "'" + txtSearch.Text.ToLower() + "'";
                dt.DefaultView.RowFilter = Search;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Empty;
            txtSearch.Text = "Search by Brand Name or Band ID";
            Clear();
        }

        private void branch_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (update == true)
            {
                DialogResult dir = MessageBox.Show("Do you wnat to save all your data?", "Your Data doesn't saved ! ", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                    Dom_SqlClass.UpdateDate(dt);
            }
        }

        private void dataBrand_SelectionChanged(object sender, EventArgs e)
        {
            if (dataBrand.SelectedRows.Count == 1)
            {
                int index = dataBrand.SelectedRows[0].Index;
                lblID.Text = dataBrand.Rows[index].Cells[0].Value.ToString();
                txtBarndName.Text = dataBrand.Rows[index].Cells[1].Value.ToString(); 
            }
        }
    }
}
