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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        DataTable DT1=new DataTable(), DT2=new DataTable() ;
        String ID;
        void AutoID()
        {
            ID = dom_Design.GenerateID(ID.Substring(6), "Emp00_");
        }
        void Clear()
        {
            DateHireDate.Value =dTPickerBirthDate.Value= DateTime.Now;
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            txtSalary.Text = "";
            txtTimeShift.Text = "";
            txtUserName.Text = "";
            lblID.Text = ID;
            pcPhoto.Image = Properties.Resources.employee;            
            datasupplier.ClearSelection();
        }



        private void Employee_Load(object sender, EventArgs e)
        {
            dom_Design.GenerateColumHeader(new string[] { "ID", "Hire Date", "First Name", "Last Name","Gender", "Date of birth","Address","Phone","Basic Salary","Position","Time Shift","Active","User Name","Password" }, 14, datasupplier);
            datasupplier.Columns[1].DefaultCellStyle.Format = "dd-MMMM-yyyy";
            datasupplier.Columns[4].DefaultCellStyle.Format = "dd-MMMM-yyyy";

            //dom_Design.ColumnName(datasupplier, 5, new string[] { "ID", "SupName", "Tel", "Email", "Address" });
            ID = Dom_SqlClass.GetIDFromDB("EmpID", "_", "Employee");
            ID = dom_Design.GenerateID(ID, "Emp00_");
            Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (datasupplier.SelectedRows.Count == 0)
            {
                if ((txtAddress.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtPhoneNumber.Text != "" && txtSalary.Text != "" && txtTimeShift.Text != "" && cbxPosition.SelectedIndex!=-1) && (DateHireDate.Value < DateTime.Now) && (dTPickerBirthDate.Value != DateTime.Now && dTPickerBirthDate.Value != DateHireDate.Value))
                {
                    List<object> Data = new List<object>();
                    if (cbxPosition.SelectedItem.ToString() == "Cleaner")
                    {

                    }

                    datasupplier.Rows.Add(new object[] {
                        lblID.Text,
                        DateHireDate.Value,
                        txtFirstName.Text,
                        txtLastName.Text,
                        rndMale.Checked==true?"Male":"Female",
                        dTPickerBirthDate.Value,
                        txtAddress.Text,
                        txtPhoneNumber.Text,
                        txtSalary.Text,
                        cbxPosition.SelectedItem.ToString(),
                        txtTimeShift.Text,
                        CheckActive.Checked,
                         txtUserName.Text,txtPassword.Text
                    });
                    AutoID();
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
                    datasupplier.ClearSelection();
                }
            }
        }
    }
}
