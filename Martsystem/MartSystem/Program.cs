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

            Application.Run(new Quantity_Type());   





=======
            Application.Run(new Stock());
>>>>>>> f363185e1235f91b2b7b03ab4501bc58a44e8428
        }
    }
}
