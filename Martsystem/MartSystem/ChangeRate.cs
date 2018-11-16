using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
    public partial class ChangeRate : Form
    {
        public ChangeRate()
        {
            InitializeComponent();
        }

        private void ChangeRate_Load(object sender, EventArgs e)
        {
            

            //delete this when done testing
                dataCon.getRate();
            //

            txtRate.Text = dataCon.rate+"";
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(txtRate.Text);
            if (amount % 100 != 0)
            {
                MessageBox.Show("Invalid amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (StreamWriter sw = new StreamWriter("Rate.avi"))
            {
                sw.WriteLine(txtRate.Text);
            };

            MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
