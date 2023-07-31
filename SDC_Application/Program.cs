using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SDC_Application.DL;
using SDC_Application.AL;

namespace SDC_Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Login ab = new Login();
            //// Classess.UsersManagments userdetails=new Classess.UsersManagments();
            // ab.ShowDialog();
            // if (Classess.UsersManagments.UserName != null)
            // {
            Application.EnableVisualStyles();


            //Application.Run(new frmIntiqal_TaxBankChallanTTx());
            //Application.Run(new FardMalikan_Report_TTx());

            DateTime test = DateTime.Now;
/*
            string s1 = test.ToString();
            string s2 = test.ToString("dd MMM yyyy hh:mm:ss tt");
            DateTime converTed = new DateTime(s2);
    */
            Application.Run(new Login());// MessageBox.Show("Null");
            //Application.Run(new frmMISC());

            //Application.Run(new mainWinForm());
           
            //
            //}
            //else
            //{

            //    //Application.Exit();
            //}

        }
    }
}
