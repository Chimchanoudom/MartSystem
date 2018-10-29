using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
<<<<<<< HEAD
<<<<<<< HEAD
        DataTable  DT2=new DataTable() ;
        DataSet DT1;
=======
=======
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6


        Boolean isFormLoading = true;
        DataTable DT1=new DataTable(), DT2=new DataTable() ;
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
        String ID;
        int BigRowIndex = -1;


        DateTime convertDateFromString(string DateInString)
        {   char splitter = (DateInString.Contains("-")) ? '-':'/';
            string[] stDob = (DateInString).Split(splitter);
            DateTime dob = new DateTime(int.Parse(stDob[0]), int.Parse(stDob[1]), int.Parse(stDob[2]), 0, 0, 0);
            return dob;
        }

        void AutoID()
        {
            ID ="Emp_"+ EmpClass.GetData.getIdFromDB();
        }
        void Clear()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            DateHireDate.Value =dTPickerBirthDate.Value= DateTime.Now;
=======
            //fghff
            dTHireDate.Value =dTBirthDate.Value= DateTime.Now;
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
=======
            //fghff
            dTHireDate.Value =dTBirthDate.Value= DateTime.Now;
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            txtSalary.Text = "";
            txtTimeShift.Text = "";
            txtUserName.Text = "";
            lblID.Text = ID;
<<<<<<< HEAD
<<<<<<< HEAD
            pcPhoto.Image = Properties.Resources.employee;            
            dataEmp.ClearSelection();
=======
=======
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
            ImageBox.Image = Properties.Resources.employee;
            if (!isFormLoading && BigRowIndex != -1)
            {
                datasupplier.Rows[BigRowIndex].Height = new DataGridViewRow().Height;
                BigRowIndex = -1;
            }
            datasupplier.ClearSelection();
            
<<<<<<< HEAD
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
=======
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
        }



        private void Employee_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            DT1 = Dom_SqlClass.retriveDataMultiTable(@"SELECT e.EmpID,e.HiredDate,e.Fname,e.Lname,e.Gender,e.DOB,e.Address,e.Phone,e.BasicSalary,e.Position,e.TimeShift,e.Active,u.EmpID,u.UserAcc,u.Pwd FROM Employee e join UserAcc u on e.EmpID=u.EmpID;");
            dataEmp.DataSource = DT1.Tables[0];
            dom_Design.GenerateColumHeader(new string[] { "ID", "Hire Date", "First Name", "Last Name","Gender", "Date of birth","Address","Phone","Basic Salary","Position","Time Shift","Active","User Name","Password" }, 14, dataEmp);
            dataEmp.Columns[1].DefaultCellStyle.Format = "dd-MM-yyyy";
            dataEmp.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
=======
            DefaultColorBtnAdd=btnAdd.BackColor;
            DefaultColorBtnEdit=btnEdit.BackColor;
            DefaultColorBtnDelete=btnDelete.BackColor;

            datasupplier.ColumnCount = 14;
            dom_Design.GenerateColumHeader(new string[] { "ID", "Hire Date", "First Name", "Last Name","Gender", "Date of birth","Address","Phone","Basic Salary","Position","Time Shift","Active","User Name","Password" }, datasupplier.ColumnCount, datasupplier);
            DataGridViewColumn dgvImg = new DataGridViewImageColumn();
            dgvImg.Name = "Image";
            dgvImg.HeaderText="Image";
            datasupplier.Columns.Add(dgvImg);
            datasupplier.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd";
            datasupplier.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
            datasupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12,FontStyle.Bold);

=======
            DefaultColorBtnAdd=btnAdd.BackColor;
            DefaultColorBtnEdit=btnEdit.BackColor;
            DefaultColorBtnDelete=btnDelete.BackColor;

            datasupplier.ColumnCount = 14;
            dom_Design.GenerateColumHeader(new string[] { "ID", "Hire Date", "First Name", "Last Name","Gender", "Date of birth","Address","Phone","Basic Salary","Position","Time Shift","Active","User Name","Password" }, datasupplier.ColumnCount, datasupplier);
            DataGridViewColumn dgvImg = new DataGridViewImageColumn();
            dgvImg.Name = "Image";
            dgvImg.HeaderText="Image";
            datasupplier.Columns.Add(dgvImg);
            datasupplier.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd";
            datasupplier.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
            datasupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12,FontStyle.Bold);

>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
            //Disable this after completely finished coding
            UserLoginDetail.position = "admin";
            //

            try
            {
                dataCon.Con.Open();
                string sqlCmd = "";
                if (UserLoginDetail.position == "admin")
                    sqlCmd = @"SELECT Employee.EmpID,format(HiredDate,'yyyy/MM/dd') AS HiredDate, FName,
                            LName,Gender,format(DOB,'yyyy/MM/dd') AS DOB,Address,Phone,BasicSalary,Position,TimeShift,
                            Active,UserAcc,Pwd,Image
                            FROM Employee JOIN UserAcc ON Employee.EmpID=UserAcc.EmpID;";
                SqlDataReader dr = dataCon.ExecuteQry(sqlCmd);
                while (dr.Read())
                {
                    datasupplier.Rows.Add(dr["EmpID"], dr["HiredDate"], dr["FName"], dr["LName"], dr["Gender"], dr["DOB"],
                        dr["Address"], dr["Phone"], dr["BasicSalary"], dr["Position"], dr["TimeShift"], dr["Active"], dr["UserAcc"], dr["Pwd"],dr["Image"]);
                }
                dr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Connect to Database!");
            }
            finally
            {
                dataCon.Con.Close();
            }
            
<<<<<<< HEAD
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
=======
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
            //dom_Design.ColumnName(datasupplier, 5, new string[] { "ID", "SupName", "Tel", "Email", "Address" });
            ID = "Emp_" + EmpClass.GetData.getIdFromDB();
            Clear();
            isFormLoading = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string fileLocation = "";
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter=new OpenFileDialog().Filter= "Images (*.jpg)|*.jpg|Images (*.png)|*.png";        
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fileLocation = fd.FileName;
                ImageBox.Image = Image.FromFile(fileLocation);
            }
            else
            {
                fileLocation = "";
                ImageBox.Image = MartSystem.Properties.Resources.employee;
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataEmp.SelectedRows.Count == 0)
=======
        private void datasupplier_SelectionChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled=!(btnEdit.Enabled = btnDelete.Enabled = (datasupplier.SelectedRows.Count > 0));
            if (datasupplier.SelectedRows.Count > 0)
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
=======
        private void datasupplier_SelectionChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled=!(btnEdit.Enabled = btnDelete.Enabled = (datasupplier.SelectedRows.Count > 0));
            if (datasupplier.SelectedRows.Count > 0)
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
            {
                if (datasupplier.SelectedRows.Count == 1)
                {
                    if (BigRowIndex != -1)
                        datasupplier.Rows[BigRowIndex].Height = new DataGridViewRow().Height;
                    datasupplier.SelectedRows[0].Height = new DataGridViewRow().Height + 50;
                    BigRowIndex = datasupplier.SelectedRows[0].Index;
                    btnEdit.Enabled = true;
                    //EditData
                    int index = datasupplier.SelectedRows[0].Index;
                    DataGridViewRow dataRow = datasupplier.Rows[index];
                    //"ID", "Hire Date", "First Name", "Last Name","Gender", "Date of birth","Address","Phone","Basic Salary","Position","Time Shift","Active","User Name","Password"
                    lblID.Text = dataRow.Cells[0].Value.ToString();
                    txtTimeShift.Text = txtTimeShift.Text!=null?dataRow.Cells["Time Shift"].Value.ToString():"";
                    txtFirstName.Text= dataRow.Cells["First Name"].Value.ToString();
                    txtLastName.Text= dataRow.Cells["Last Name"].Value.ToString();
                    rndMale.Checked = !(rndFemale.Checked = (dataRow.Cells["Gender"].ToString().ToLower() == "female"));
                    dTBirthDate.Value = convertDateFromString(dataRow.Cells["Date of birth"].Value + "");
                    dTHireDate.Value= convertDateFromString(dataRow.Cells["Hire Date"].Value + "");
                    txtPhoneNumber.Text= dataRow.Cells["Phone"].Value.ToString();
                    txtAddress.Text= dataRow.Cells["Address"].Value.ToString();
                    try
                    {
                        ImageBox.Image = (Image)dataRow.Cells["Image"].Value;
                    } catch (Exception){ImageBox.Image = MartSystem.Properties.Resources.employee;}
                    cbxPosition.SelectedItem= dataRow.Cells["Position"].Value.ToString();
                    txtSalary.Text= dataRow.Cells["Basic Salary"].Value.ToString();
                    CheckActive.Checked = Convert.ToBoolean(dataRow.Cells["Active"].Value.ToString());
                    txtUserName.Text= dataRow.Cells["User Name"].Value.ToString();
                    txtPassword.Text= dataRow.Cells["Password"].Value.ToString();
                }
                else
                {
                    btnEdit.Enabled = false;
                    if (!isFormLoading && BigRowIndex != -1)
                    {
                        datasupplier.Rows[BigRowIndex].Height = new DataGridViewRow().Height;
                        BigRowIndex = -1;
                    }
                }
            }
            else
            {
                if(!isFormLoading)
                    AutoID();
                Clear();
            }
            
        }

        Color DefaultColorBtnAdd;
        Color DefaultColorBtnEdit;
        Color DefaultColorBtnDelete;
        private void btnAdd_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled)
            {
                switch (btn.Name)
                {
                    case "btnAdd":
                        btn.BackColor = DefaultColorBtnAdd;
                        break;
                    case "btnEdit":
                        btn.BackColor = DefaultColorBtnEdit;
                        break;
                    default:
                        btn.BackColor = DefaultColorBtnDelete;
                        break;
                }
            }
            else
            {
                btn.BackColor = Color.Gray;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = datasupplier.SelectedRows[0].Index;
            btnAdd_Click(null, null);
            datasupplier.Rows.RemoveAt(index);
            datasupplier.Sort(datasupplier.SortedColumn!=null? datasupplier.SortedColumn: datasupplier.Columns[0], ListSortDirection.Ascending);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtAddress.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtPhoneNumber.Text != "" && txtSalary.Text != "" && txtTimeShift.Text != "" && cbxPosition.SelectedIndex != -1) && (dTHireDate.Value < DateTime.Now) && (dTBirthDate.Value != DateTime.Now && dTBirthDate.Value != dTHireDate.Value))
            {
                List<object> Data = new List<object>();
                if (cbxPosition.SelectedItem.ToString() == "Cleaner")
                {
                    txtUserName.Text = txtPassword.Text = "";
                }

<<<<<<< HEAD
<<<<<<< HEAD
                    dataEmp.Rows.Add(new object[] {
=======
                datasupplier.Rows.Add(new object[] {
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
=======
                datasupplier.Rows.Add(new object[] {
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
                        lblID.Text,
                        dTHireDate.Value.Date.ToString("yyyy/MM/dd"),
                        txtFirstName.Text,
                        txtLastName.Text,
                        rndMale.Checked==true?"Male":"Female",
                        dTBirthDate.Value.Date.ToString("yyyy/MM/dd"),
                        txtAddress.Text,
                        txtPhoneNumber.Text,
                        txtSalary.Text,
                        cbxPosition.SelectedItem.ToString(),
                        txtTimeShift.Text,
                        CheckActive.Checked,
                        txtUserName.Text,
                        txtPassword.Text,
                        ImageBox.Image
                    });
                AutoID();
                Clear();
            }
            else
            {
<<<<<<< HEAD
<<<<<<< HEAD
                DialogResult dir = MessageBox.Show("Do you want to cancell this selection ?", "selection will be cancell", MessageBoxButtons.YesNo);
                if (dir == DialogResult.Yes)
                {
                    Clear();
                    dataEmp.ClearSelection();
                }
=======
                MessageBox.Show("Please fill in all the required information!");
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
=======
                MessageBox.Show("Please fill in all the required information!");
>>>>>>> e9f1c4eae44fecce2d051cd1697aabf52d4d7ac6
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
