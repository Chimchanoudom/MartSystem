using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MartSystem
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            dataCon.Con.Close();
            datasupplier.DataSource = DgvDataSource;
        }

        string fileLocation = "";//file Path of Image
        Boolean isFormLoading = true;
        DataTable DgvDataSource=new DataTable() ;
        String ID;
        int BigRowIndex = -1;
        List<string> eIDfromDB;


        DateTime convertDateFromString(string DateInString)
        {   char splitter = (DateInString.Contains("-")) ? '-':'/';
            string[] stDob = (DateInString).Split(splitter);
            DateTime dob = new DateTime(int.Parse(stDob[0]), int.Parse(stDob[1]), int.Parse(stDob[2]), 0, 0, 0);
            return dob;
        }

        void AutoID()
        {
            ID = (int.Parse(ID.Substring(ID.Length - 1)) + 1).ToString();
            ID = ID.Length == 2 ? "Emp_0" + ID : "Emp_00" + ID;
        }
        void Clear()
        {
            //fghff
            dTHireDate.Value =dTBirthDate.Value= DateTime.Now;
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            txtSalary.Text = "";
            txtTimeShift.Text = "";
            txtUserName.Text = "";
            lblID.Text = ID;
            ImageBox.Image = Properties.Resources.employee;
            if (!isFormLoading && BigRowIndex != -1)
            {
                try
                {
                    datasupplier.Rows[BigRowIndex].Height = new DataGridViewRow().Height;
                    BigRowIndex = -1;
                }
                catch (Exception){ BigRowIndex = -1; }
            }
            datasupplier.ClearSelection();
            
        }



        private void Employee_Load(object sender, EventArgs e)
        {
            DefaultColorBtnAdd=btnAdd.BackColor;
            DefaultColorBtnEdit=btnEdit.BackColor;
            DefaultColorBtnDelete=btnDelete.BackColor;

            
            dom_Design.GenerateColumHeader(new string[] { "ID", "Hire Date", "FName", "LName","Gender", "Date of birth","Address","Phone","Basic Salary","Position","Time Shift","Active","UserName","Password", "Image" }, 15, datasupplier,DgvDataSource);
            //DataGridViewColumn dgvImg = new DataGridViewImageColumn();
            //dgvImg.Name = "Image";
            //dgvImg.HeaderText="Image";
            //datasupplier.Columns.Add(dgvImg);
            datasupplier.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd";
            datasupplier.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
            datasupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12,FontStyle.Bold);

            //Disable this after completely finished coding
            UserLoginDetail.position = "admin";
            //

            string sqlCmd = "";
            SqlDataReader dr;
            try
            {
                dataCon.Con.Open();
                if (UserLoginDetail.position == "admin")
                    sqlCmd = @"SELECT Employee.EmpID,format(HiredDate,'yyyy/MM/dd') AS HiredDate, FName,
                            LName,Gender,format(DOB,'yyyy/MM/dd') AS DOB,Address,Phone,BasicSalary,Position,TimeShift,
                            Active,UserAcc,Pwd,Image
                            FROM Employee LEFT JOIN UserAcc ON Employee.EmpID=UserAcc.EmpID;";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Unable to Connect to Database!");
            }
            dr = dataCon.ExecuteQry(sqlCmd);
            eIDfromDB = new List<string>();
            while (dr.Read())
            {
                object[] newRow = {dr["EmpID"], dr["HiredDate"], dr["FName"], dr["LName"], dr["Gender"], dr["DOB"],
                        dr["Address"], dr["Phone"], dr["BasicSalary"], dr["Position"], dr["TimeShift"], dr["Active"], dr["UserAcc"], dr["Pwd"],(dr["Image"])!=null?dr["Image"]:""};
                DgvDataSource.Rows.Add(newRow);
                //getImageFromBinary((byte[])dr[14])
                eIDfromDB.Add(dr["EmpID"].ToString());
            }
            dr.Close();
            dataCon.Con.Close();

            //dom_Design.ColumnName(datasupplier, 5, new string[] { "ID", "SupName", "Tel", "Email", "Address" });
            ID = "Emp_" + EmpClass.GetData.getIdFromDB();
            Clear();
            isFormLoading = false;
            datasupplier_SelectionChanged(null, null);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter=new OpenFileDialog().Filter= "Images (*.jpg)|*.jpg|Images (*.png)|*.png";        
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fileLocation = fd.FileName;
                ImageBox.Image = Image.FromFile(fileLocation);               
            }
            else
            {
                if (datasupplier.SelectedRows.Count < 1)
                {
                    fileLocation = "";
                    ImageBox.Image = MartSystem.Properties.Resources.employee;
                }
            }
        }

        private void datasupplier_SelectionChanged(object sender, EventArgs e)
        {
            btnBrowse.Enabled = !(datasupplier.SelectedRows.Count > 1);
            btnEdit.Enabled = btnDelete.Enabled = (datasupplier.SelectedRows.Count > 0&&datasupplier.RowCount>0);
            btnAdd.Enabled = !btnEdit.Enabled;
            if (datasupplier.SelectedRows.Count > 0)
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

                    lblID.Text = dataRow.Cells[0].Value.ToString();
                    txtTimeShift.Text = txtTimeShift.Text!=null?dataRow.Cells["Time Shift"].Value.ToString():"";
                    txtFirstName.Text= dataRow.Cells["FName"].Value.ToString();
                    txtLastName.Text= dataRow.Cells["LName"].Value.ToString();
                    rndMale.Checked = !(rndFemale.Checked = (dataRow.Cells["Gender"].ToString().ToLower() == "female"));
                    dTBirthDate.Value = convertDateFromString(dataRow.Cells["Date of birth"].Value + "");
                    dTHireDate.Value= convertDateFromString(dataRow.Cells["Hire Date"].Value + "");
                    txtPhoneNumber.Text= dataRow.Cells["Phone"].Value.ToString();
                    txtAddress.Text= dataRow.Cells["Address"].Value.ToString();

                    fileLocation = dataRow.Cells["Image"].Value.ToString();
                    ImageBox.Image =(fileLocation!= string.Empty) ?Image.FromFile( dataRow.Cells["Image"].Value.ToString()) : MartSystem.Properties.Resources.employee;
                    cbxPosition.SelectedItem= dataRow.Cells["Position"].Value.ToString();
                    txtSalary.Text= dataRow.Cells["Basic Salary"].Value.ToString();
                    CheckActive.Checked = Convert.ToBoolean(dataRow.Cells["Active"].Value.ToString());
                    txtUserName.Text= dataRow.Cells["UserName"].Value.ToString();
                    txtPassword.Text= dataRow.Cells["Password"].Value.ToString();
                }
                else
                {
                    btnEdit.Enabled = false;
                    if (!isFormLoading && BigRowIndex != -1)
                    {
                        datasupplier.Rows[BigRowIndex].Height = new DataGridViewRow().Height;
                        BigRowIndex = -1;
                        ImageBox.Image = MartSystem.Properties.Resources.employee;
                    }
                }
            }
            else
            {
                lblID.Text = ID;
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
            btnAdd_Click(sender, null);
            datasupplier.Rows.RemoveAt(index);
            datasupplier.Sort(datasupplier.SortedColumn!=null? datasupplier.SortedColumn: datasupplier.Columns[0], ListSortDirection.Ascending);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            while (datasupplier.SelectedRows.Count > 0)
            {
                int index = datasupplier.SelectedRows[0].Index;
                if(datasupplier.Rows[index].Cells["Position"].Value.ToString()== "Admin")
                {
                    int countAdmin = 1;
                    for (int i = datasupplier.RowCount - 1; i >= 0; i--)
                    {
                        if (i == index)
                            continue;
                        else
                            if (datasupplier.Rows[i].Cells["Position"].Value.ToString() == "Admin")
                                countAdmin++;
                    }
                    if(countAdmin>1)
                        datasupplier.Rows.RemoveAt(index);
                    else
                    {
                        MessageBox.Show("There must be at least one Admin in the list!");
                        if (datasupplier.SelectedRows.Count > 1)
                            continue;
                        else
                            break;
                    }
                }              
                datasupplier.Rows.RemoveAt(index);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> idLeftInDB = new List<string>();
            foreach(DataGridViewRow rows in datasupplier.Rows)
            {
                string id = rows.Cells[0].Value.ToString();
                string tablename = "Employee";
                idLeftInDB.Add(id);
                string empid = rows.Cells["ID"].Value.ToString();
                string fname = rows.Cells["FName"].Value.ToString();
                string lname = rows.Cells["LName"].Value.ToString();
                string gender = rows.Cells["Gender"].Value.ToString();
                string dob = rows.Cells["Date of birth"].Value.ToString();
                string address = rows.Cells["Address"].Value.ToString();
                string tel = rows.Cells["Phone"].Value.ToString();
                string img = rows.Cells["Image"].Value.ToString();
                string basicSalary = rows.Cells["Basic Salary"].Value.ToString();
                string role = rows.Cells["Position"].Value.ToString();
                string time = rows.Cells["Time Shift"].Value.ToString();
                string active = rows.Cells["Active"].Value.ToString();
                string date = rows.Cells["Hire Date"].Value.ToString();

                string username = rows.Cells["UserName"].Value.ToString();
                string code = rows.Cells["Password"].Value.ToString();

<<<<<<< HEAD
                //dataCon.exActionQuery.deleteDataFromDB(tablename, "WHERE EmpID='" + id + "';");
                string sqlCmd = "";
                bool error = false;
                if (!eIDfromDB.Contains(id))
                {
                    sqlCmd = "INSERT INTO Employee VALUES('" + empid + "','" + fname + "','" + lname + "','" + gender + "','" + dob + "','" + address + "','" + tel + "','" + img + "','" + basicSalary + "','" + role + "','" + time + "','" + active + "','" + date + "');";
                    dataCon.ExecuteActionQry(sqlCmd, ref error);
                    if (error)
                    {
                        error = false;
                        MessageBox.Show("Insertion Failed!");
                    }
                }
                else
                {
                    sqlCmd = @"UPDATE Employee SET EmpID ='" + id + "', Fname ='" + fname + "', Lname ='" + lname + "', Gender ='" + gender + "', DOB ='" + dob + "', Address ='" + address + "', Phone ='" + tel + "', Image ='" + img + "', BasicSalary ='" + basicSalary + "', Position ='" + role + "', TimeShift ='" + time + "', Active ='" + active + "', HiredDate ='" + date + "' WHERE EmpID ='" + id + "';";
                    dataCon.ExecuteActionQry(sqlCmd, ref error);
                    if (error)
                    {
                        error = false;
                        MessageBox.Show("Update Failed!");
                    }
                }
                dataCon.exActionQuery.deleteDataFromDB("UserAcc", "WHERE EmpID='" + id + "';");
=======
                dataCon.exActionQuery.deleteDataFromDB(tablename, "WHERE EmpID='" + id + "';");
                string sqlCmd = "INSERT INTO Employee VALUES('" + empid + "','" + fname + "','" + lname + "','" + gender + "','" + dob + "','" + address + "','" + tel + "','" + img + "','" + basicSalary + "','" + role + "','" + time + "','" + active + "','" + date + "');";
                bool error = false;
                dataCon.ExecuteActionQry(sqlCmd, ref error);
                if (error)
                {
                    error = false;
                    return;
                }
>>>>>>> 0e412cd12951f9bbb6678a01a17b42f82c5891da
                sqlCmd = "INSERT INTO UserAcc VALUES('" + empid + "','" + username + "','" + code + "');";
                dataCon.ExecuteActionQry(sqlCmd, ref error);
                if (error)
                {
                    error = false;
<<<<<<< HEAD
                    MessageBox.Show("Insertion Failed!");
                }
            }

            getIDLeftInDB();
=======
                    return;
                }
            }

>>>>>>> 0e412cd12951f9bbb6678a01a17b42f82c5891da
            foreach(string oldIdinDb in eIDfromDB)
            {
                if (!idLeftInDB.Contains(oldIdinDb))
                {
                    dataCon.exActionQuery.deleteDataFromDB("Employee", "WHERE EmpID='" + oldIdinDb + "';");
                }
            }
            MessageBox.Show("Saved!");
        }
<<<<<<< HEAD
        
        void getIDLeftInDB()
        {
            eIDfromDB = new List<string>();
            try
            {
                dataCon.Con.Open();
                string sqlCmd = "SELECT EmpID FROM Employee;";
                SqlDataReader dr = dataCon.ExecuteQry(sqlCmd);
                while (dr.Read())
                {
                    eIDfromDB.Add(dr.GetString(0));
                }
                dr.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                dataCon.Con.Close();
            }
        }
=======
>>>>>>> 0e412cd12951f9bbb6678a01a17b42f82c5891da

        private void ImageBox_Paint(object sender, PaintEventArgs e)
        {
            if (ImageBox.Image == MartSystem.Properties.Resources.employee)
                fileLocation = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //"ID", "Hire Date", "FName", "LName","Gender", "Date of birth","Address","Phone","Basic Salary","Position","Time Shift","Active","UserName","Password", "Image"
            if (txtSearch.Text != "")
            {
                string filter = (rndSearchFname.Checked ? "FName='" + txtSearch.Text + "'" : rndSearchLname.Checked ? "LName='" + txtSearch.Text + "'" : rndSearchID.Checked ? "ID='" + txtSearch.Text + "'" : rndSearchPosition.Checked ? "Position='" + txtSearch.Text + "'" : rndSearchTelephone.Checked ? "Phone='" + txtSearch.Text + "'" : rndSearchUsername.Checked ? "UserName='" + txtSearch.Text + "'" : "");
                DgvDataSource.DefaultView.RowFilter = filter;
            }
            else
            {
                MessageBox.Show("Please Enter any text to search!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DgvDataSource.DefaultView.RowFilter = string.Empty;
            txtSearch.Text = String.Empty;
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

                DgvDataSource.Rows.Add(new object[] {
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
                        fileLocation
                    });
                if(((Button)sender).Name=="btnAdd")
                    AutoID();
                Clear();
            }
            else
            {
                MessageBox.Show("Please fill in all the required information!");
            }
        }
    }
}
