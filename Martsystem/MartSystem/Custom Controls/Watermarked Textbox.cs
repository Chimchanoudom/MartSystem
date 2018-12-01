using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem.Custom_Contols
{
    public partial class Watermarked_Textbox : TextBox
    {
        public Watermarked_Textbox()
        {
            InitializeComponent();

        }

        string _watermarkedText;

       

        public string WatermarkedText
        {
            get { return _watermarkedText; }
            set {
                _watermarkedText = value;
                GetSetWatermark();
                    
             }
        }

        

        public bool FloatNumber { get; set; }

        private void GetSetWatermark()
        {
            if(Text==_watermarkedText || Text==String.Empty)
            {
                ForeColor = Color.Gray;
                Text = _watermarkedText;
            }
            else
            {
                ForeColor = Color.Black;
            }
        }



        private void Watermarked_Textbox_Enter(object sender, EventArgs e)
        {
            if (Text == _watermarkedText || Text == String.Empty)
            {
                Text = string.Empty;
                ForeColor = Color.Black;
            }
        }

        private void Watermarked_Textbox_Leave(object sender, EventArgs e)
        {
            GetSetWatermark();
        }

        private void Watermarked_Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
               
            
                
        }
    }
}
