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



<<<<<<< HEAD
            //Application.Run(new ExpenseData());

            Application.Run(new Import());   
=======
            Application.Run(new ExpenseData());
>>>>>>> 3639f6321998c9af95dff69e7005574577a50ad0


        }
    }
}
