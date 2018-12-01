using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.Lib;
using Bunifu.Framework.UI;

namespace MartSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
      
            Tdate.Start();
            lblName.Text = UserLoginDetail.fName +" "+ UserLoginDetail.lName;
            label2.Dock = DockStyle.Left;
            lblposition.Text = UserLoginDetail.position;
            lblposition.Dock = DockStyle.Left;
            lblposition.Visible = true;
        }
       
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Application.Restart();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnstay_Click_1(object sender, EventArgs e)
        {
            dom_Design.dropdown(pnStay, 48, 3);
            //btnstay.Normalcolor = Color.Green;
            //ClickChang(btnstay.Name);
        }

        private void btnbook_Click_1(object sender, EventArgs e)
        {
            //dom_Design.dropdown(pnBook, 48, 3);
            //btnbook.Normalcolor = Color.Green;
            //ClickChang(btnbook.Name);\
            Employee Emp = new Employee();
            Emp.Show();
        }

    
        private void btncheckin_Click(object sender, EventArgs e)
        {
            CreateInvoice CI = new CreateInvoice();
            CI.ShowDialog();
        }

        private void btncheckINData_Click(object sender, EventArgs e)
        {
            InvoiceData ID= new InvoiceData();
            ID.ShowDialog();
        }

        private void btncheckoutNote_Click(object sender, EventArgs e)
        {
            //dom_Design.dropdown(pncheckout, 48, 3);
            //btncheckoutNote.Normalcolor = Color.Green;
            //ClickChang(btncheckoutNote.Name);
            supplyer Sp = new supplyer();
            Sp.Show();
        }


        private void btnRoom_Click_2(object sender, EventArgs e)
        {
            dom_Design.dropdown(pnRoom, 48, 6);
            //btnRoom.Normalcolor = Color.Green;
            //ClickChang(btnRoom.Name);
        }

        private void btnCheckRoom_Click_2(object sender, EventArgs e)
        {
            Stock st = new Stock();
            st.ShowDialog();
        }

        private void btnAddRoom_Click_2(object sender, EventArgs e)
        {
            ImportData ip = new ImportData();
            ip.ShowDialog();
        }

        private void btnRoomPrice_Click_2(object sender, EventArgs e)
        {
            Product p= new Product();
            p.ShowDialog();
        }
        private void btnExpenAndIncome_Click_2(object sender, EventArgs e)
        {
            new ExpenseData().ShowDialog();
            //btnExpenAndIncome.Normalcolor= Color.Green;
            //ClickChang(btnExpenAndIncome.Name);
        }

        private void btnAllReport_Click(object sender, EventArgs e)
        {
            dom_Design.dropdown(pnReport,48,3);
        }

        private void btnPlayAndStop_Click(object sender, EventArgs e)
        {
            new ChangeUserSetting("").ShowDialog();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            dom_Design.dropdown(pnSetting,48,3);
        }

        private void Tdate_Tick(object sender, EventArgs e)
        {
            LBLTime.Text = DateTime.Now.ToLongDateString()+"\n"+DateTime.Now.ToShortTimeString();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            new Brand().ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            new category().ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            new Quantity_Type().ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
