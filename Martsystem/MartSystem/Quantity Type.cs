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
    public partial class Quantity_Type : Form
    {
        public Quantity_Type()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void Clear() {
            txtpacket.Text = "";
            txtType.Text = "";
           }
        private void Quantity_Type_Load(object sender, EventArgs e)
        {
            dt = Dom_SqlClass.retriveData("Quantity", "", new string[] { "*" });
            DataQty.DataSource = dt;
            dom_Design.GenerateColumHeader(new string[] { "Quantity Type", "Quantity in Package" }, 2, DataQty);
            DataQty.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DataQty.SelectedRows.Count == 0)
            {
                if (txtpacket.Text != ""&&txtType.Text!="")
                {
                    dt.Rows.Add(new object[] { txtType.Text, txtpacket.Text });
                    Clear();
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
                    DataQty.ClearSelection();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dom_SqlClass.UpdateDate(dt);
        }
    }
}
