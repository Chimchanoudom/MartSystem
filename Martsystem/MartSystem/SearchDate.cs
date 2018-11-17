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
    public partial class SearchDate : Form
    {
        public SearchDate()
        {
            InitializeComponent();
        }

        public SearchDate(object txtSearchDate)
        {
            InitializeComponent();
            this.txtSearchDate = txtSearchDate;
        }

        object txtSearchDate;
        private void btnOK_Click(object sender, EventArgs e)
        {

            TextBox txt = (TextBox)txtSearchDate;
            txt.Text  = dtpFrom.Text + " - " + dtpTo.Text;

            DialogResult = DialogResult.Yes;
        }
    }
}
