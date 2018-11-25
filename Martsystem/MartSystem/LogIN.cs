using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace MartSystem
{
    public partial class LogIN : Form
    {
        public LogIN()
        {
            InitializeComponent();
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool select = false;
        private void bunifuCustomLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            select = true;
        }

        private void bunifuCustomLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (select == true)
                this.Location = e.Location;
        }

        private void bunifuCustomLabel1_MouseLeave(object sender, EventArgs e)
        {
            select = false;
        }
       BunifuThinButton2  btn;
        private void btnLogIn_MouseHover(object sender, EventArgs e)
        {
            btn = (BunifuThinButton2)sender;
            btn.Font = new Font(btnLogIn.Font.FontFamily, 18);
        }

        private void btnLogIn_MouseLeave(object sender, EventArgs e)
        {
            btn = (BunifuThinButton2)sender;
            btn.Font = new Font(btnLogIn.Font.FontFamily, 12);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            foreach(DataRow Dr in dt.Rows)
            {
                //MessageBox.Show(Dr["UserAcc"].ToString());
                //MessageBox.Show(Dr["Pwd"].ToString());
                if ((txtuserName.Text.ToLower() ==Dr["UserAcc"].ToString().ToLower()&&txtpass.Text.ToLower()==Dr["Pwd"].ToString().ToLower()))
                    {
                    if (Convert.ToBoolean(Dr["Active"]) == true){
                        MessageBox.Show("Welcome "+Dr["Lname"]+" "+Dr["Fname"]);
                        Dom_SqlClass.empID = Dr["EmpID"].ToString();
                        Dom_SqlClass.fName = Dr["Fname"].ToString();
                        Dom_SqlClass.lName = Dr["Lname"].ToString();
                        Dom_SqlClass.position = Dr["Position"].ToString();
                        new Import().ShowDialog();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Your Account is Deactive !");
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password or User Name !");
                    break;
                }
            }
        }
        DataTable dt;
        private void LogIN_Load(object sender, EventArgs e)
        {
            dt = Dom_SqlClass.retriveData("Employee join UserAcc on Employee.EmpID=UserAcc.EmpID", "", new string[] {"*"});


        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            txtpass.ForeColor = Color.Green;
        }

        private void txtpass_MouseUp(object sender, MouseEventArgs e)
        {
            txtpass.ForeColor = Color.Black;
        }

        private void txtpass_MouseEnter(object sender, EventArgs e)
        {
           // txtpass_MouseClick(null, null);
        }

        private void txtpass_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
