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
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }
        private Dictionary<String, String> DataProName = new Dictionary<string, string>();
        private Dictionary<String, String> DataSupName = new Dictionary<string, string>();
        private DataTable DTProduct,DTSupllier,DTAllData;
        private String ID;

        private void ReadDatafromDataTable(ComboBox cm,DataTable DT,Dictionary<string,string> Data)
        {
             foreach ( DataRow DR in DT.Rows)
            {
                Data.Add(DR[0].ToString(), DR[1].ToString());
               // MessageBox.Show(DR[0].ToString()+","+ DR[1].ToString());
            }
            foreach (String item in Data.Keys)
            {
                cm.Items.Add(Data[item]);
            }
        }
        private void AutoID()
        {
            ID = dom_Design.GenerateID(ID, "I00_",4);
            LblID.Text = ID;
        }

        private void Clear()
        {
            cmProductName.SelectedIndex = -1;
            Quallity.Value = 0;
            txtPrice.Text = "";
            txtSubTotal.Text = "";
            dateImport.Value = DateTime.Now;
            cmSupllierName.SelectedIndex = -1;
            txtTotal.Text = ""; 
        }
        private String GetKey(Dictionary<String, String> Data,String item)
        {
            String Key = "";
            foreach (KeyValuePair<String, String>items in Data)
            {
                if (items.Value==item)
                {
                    Key= items.Key;
                }
            }
            return Key;
        }
        private void Import_Load(object sender, EventArgs e)
        {
            DTProduct = Dom_SqlClass.retriveDataMultiTable(@"Select p.ProID,p.ProName from Product p;");
            ReadDatafromDataTable(cmProductName, DTProduct, DataProName);
            DTSupllier = Dom_SqlClass.retriveDataMultiTable(@"Select s.SupID,s.SupName from Supplier s;");
            ReadDatafromDataTable(cmSupllierName, DTSupllier, DataSupName);
            txtEmpl.Text = UserLoginDetail.fName + " " + UserLoginDetail.lName;
            DTAllData = Dom_SqlClass.retriveDataMultiTable(@"Select i.ImportID as 'Import ID',i.ImportDate as 'Import Date',CONCAT(e.Fname,e.Lname) as 'Employee Name',s.SupName as 'Suppllier Name', p.ProName as 'Product Name',id.Qty as 'Quality',id.UnitPrice,id.SubTotal,i.Total from Import i join ImportDetail id on i.ImportID=id.ImportID join Supplier s on i.SupID=s.SupID join Employee e on i.ImportID=e.EmpID join Product p on id.ProID=p.ProID;");
            dataImport.DataSource = DTAllData;
            ID=Dom_SqlClass.GetIDFromDB("ImportID", "_", "Import");
            ID = dom_Design.GenerateID(ID, "I00_");
            LblID.Text = ID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataImport.SelectedRows.Count == 0)
            {
                if (cmProductName.SelectedIndex != -1 && Quallity.Value != 0 && txtPrice.Text != "" && dateImport.Value > DateTime.Now && cmSupllierName.SelectedIndex != -1 && txtSubTotal.Text != "" && txtTotal.Text != "")
                {

                }
                else
                {
                    MessageBox.Show("Please! input Data to all Box!");
                }
            }
            else
            {
                DialogResult dir = MessageBox.Show("Do you want to cancell this selection ?", "selection will be cancell", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                {
                    Clear();
                    dataImport.ClearSelection();
                }
            }
            //MessageBox.Show(GetKey(DataProName, cmProductName.SelectedItem.ToString()));
        }

    }
}
