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
    public partial class QuantityImportType : Form
    {
     
        public QuantityImportType()
        {
            InitializeComponent();
        }

        DataTable DT;
        Dictionary<String, int> Data = new Dictionary<string, int>();
        private void ReadDatafromDataTable(ComboBox cm, DataTable DT, Dictionary<string, int> Data)
        {
            foreach (DataRow DR in DT.Rows)
            {
                Data.Add(DR[0].ToString(), int.Parse(DR[1].ToString()));
                // MessageBox.Show(DR[0].ToString()+","+ DR[1].ToString());
            }
            foreach (String item in Data.Keys)
            {
                cm.Items.Add(item);
            }
        }
        private void QuantityImportType_Load(object sender, EventArgs e)
        {
            DT = Dom_SqlClass.retriveData("Quantity", "where 1=1", new string[] { "*" });
            ReadDatafromDataTable(comboBox1, DT, Data);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dom_Design.QTY==0)
            {
                dom_Design.QTY = Convert.ToInt32(numericUpDown2.Value.ToString());
            }
            else
            {
                dom_Design.QTY=dom_Design.QTY+ Convert.ToInt32(numericUpDown2.Value.ToString());
            }
            
            this.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

                if (dom_Design.NumberOnly(e) != true)
                {
                    if (e.KeyChar == 13)
                    {
                    if (comboBox1.SelectedIndex != -1)
                    {
                        numericUpDown2.Value = int.Parse(textBox1.Text) * Data[comboBox1.SelectedItem.ToString()];

                        //MessageBox.Show(numericUpDown2.Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Please Select Quantity in top box !");
                    }

                }
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
