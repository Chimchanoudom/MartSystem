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
    public partial class ChangeUserSetting : Form
    {


        public ChangeUserSetting(string behaviour)
        {
            InitializeComponent();
            this.behaviour = behaviour;
        }

        string behaviour;

        private void ChangeRate_Load(object sender, EventArgs e)
        {
            //delete this when done testing
            dataCon.getRateAndDaysAlmostExp();
            //

            switch (behaviour)
            {
                case "rate":
                    txtRate.Text = dataCon.rate + "";
                    lbValue.Text = "Rate:";
                    Text = "Change Rate";
                    break;
                case "days":
                    txtRate.Text = dataCon.daysAlmostExp + "";
                    lbValue.Text = "Days:";
                    Text = "Change Days";
                    break;
            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            
            double amount = double.Parse(txtRate.Text);

            switch (behaviour)
            {
                case "rate":
                    if (amount % 100 != 0)
                    {
                        MessageBox.Show("Invalid amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    using (StreamWriter sw = new StreamWriter("Rate.avi"))
                    {
                        sw.WriteLine(txtRate.Text);
                    };
                    break;

                case "days":
                    using (StreamWriter sw = new StreamWriter("DaysAlmostExp.avi.avi"))
                    {
                        sw.WriteLine(txtRate.Text);
                    };
                    break;
            }

            MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
