using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmIntiqalOperatorNote : Form
    {
        #region Class Variables

        public string IntiqalId { get; set; }
        Intiqal intiqal = new Intiqal();
        LanguageConverter lang = new LanguageConverter();

        #endregion

        #region Default Converter

        public frmIntiqalOperatorNote()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event

        private void frmIntiqalOperatorNote_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Textbox Operator Note Key Press Event for Auto language Conversion
 
        private void txtOperatorNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }

        #endregion


        #region Button Save Click Event
 
        private void btnSave_Click(object sender, EventArgs e)
        {
            intiqal.SaveIntiqalOperatorNote(this.IntiqalId, txtOperatorNote.Text.Trim());
            this.Close();
        }

        #endregion
    }
}
