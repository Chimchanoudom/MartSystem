using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem.Custom_Controls
{
    public partial class NumberTextBox : TextBox
    {
        public NumberTextBox()
        {
            InitializeComponent();
        }
        public bool FloatNumber { get; set; }

        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string characterAllow = "0123456789\b";

            if (FloatNumber) characterAllow += ".";


            if (characterAllow.IndexOf(e.KeyChar) == -1)
                e.KeyChar = '\0';

            if (FloatNumber)
                if (Text.Contains(".") && e.KeyChar == '.')
                    e.KeyChar = '\0';
        }
    }
}
