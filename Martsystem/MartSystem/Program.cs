using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (new LogIN().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }

<<<<<<< HEAD
=======
            Application.Run(new Product());

>>>>>>> c813f281d5a6f805a6e98d39da34b004e6add3ac
        }
    }
}
