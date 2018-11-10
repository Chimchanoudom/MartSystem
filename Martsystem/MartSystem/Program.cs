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
            Application.Run(new ExpenseData());
=======
            Application.Run(new Import());   
>>>>>>> bbaaae2e24a49249bb31aaf76d7ac6c23520e756

        }
    }
}
