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
    }
}
