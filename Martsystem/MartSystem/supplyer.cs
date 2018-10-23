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
        private void supplyer_Load(object sender, EventArgs e)
        {
            dt = Dom_SqlClass.retriveData("Supplier", "where 1=1", new string[] { "*"});
            datasupplier.DataSource = dt;
            dom_Design.GenerateColumHeader(new string[] { "ID", "Supplier Name", "Phone", "Email", "Address" }, 5, datasupplier);

        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            dom_Design.CharaterOnly(e);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            dom_Design.NumberOnly(e);
        }
    }
}
