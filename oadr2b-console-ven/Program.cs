using System;
using System.Collections.Generic;
using System.Linq;
//using System.Windows.Forms;

namespace oadr2b_ven
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Check
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);

#if (!DEBUG)
    //Remove Forms?
//            frmSplash splash = new frmSplash();

//            DialogResult result = splash.ShowDialog();

//            if (result != System.Windows.Forms.DialogResult.OK)
//                return;
#endif
//            Application.Run(new frmMain());

            Application.Run(new consoleMain());

        }
    }
}


