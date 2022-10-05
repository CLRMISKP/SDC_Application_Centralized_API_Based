using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Configuration;
namespace SDC_Application.Classess
{
    class Validations
    {


        #region         Validation
        public static void errorprovider(KeyPressEventArgs e, TextBox txt, ErrorProvider errorProvider1, ErrorProvider errorProvider2, int check)
        {
            if (check == 1)
            {

                if (!Char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar !=8 && e.KeyChar != 13)
                {
                    e.Handled = true;
                    

                        errorProvider1.SetError(txt, "error");
                        errorProvider2.SetError(txt, "");

                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        errorProvider2.SetError(txt, "Correct");

                    }

                
            }
            if (check == 2)
            {

                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar!='-' && e.KeyChar != 13)
                {
                    e.Handled = true;
                   

                        errorProvider1.SetError(txt, "error");
                        errorProvider2.SetError(txt, "");

                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        errorProvider2.SetError(txt, "Correct");

                    }
                
                
               
            }
        }
        #endregion

        public static bool Validating(TextBox txt,TextBox txt2,TextBox txt3,TextBox txt4)
        {
            if (txt.Text != string.Empty && txt.Text.Length==15 && txt2.Text != string.Empty && txt3.Text != string.Empty && txt4.Text != string.Empty)
            {
                return true;
            }
            return false;
        }


        
    }
}
