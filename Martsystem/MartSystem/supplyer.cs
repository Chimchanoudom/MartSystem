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

        private void supplyer_Load(object sender, EventArgs e)
        {
            try
            {
                dataCon.Con.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception)
            {
                MessageBox.Show("Fails");
            }
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
