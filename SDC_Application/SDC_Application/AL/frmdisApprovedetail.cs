using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
namespace SDC_Application.AL
{
    public partial class frmdisApprovedetail : Form
    {
        #region Class variables

        public string TokenId { get; set; }

        DocumentApproval da = new DocumentApproval();

        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();

        #endregion
        public frmdisApprovedetail()
        {
            InitializeComponent();
        }

        #region Button Save Click Event



        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string Token_CurrentStatus = "نامنظور";
                string Token_CurrentStatus_Reason = txtDisAppReason.Text.Trim();
                da.UpdateDocumentApprovalStatus(this.TokenId, Token_CurrentStatus, Token_CurrentStatus_Reason);
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private void txtDisAppReason_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmdisApprovedetail_Load(object sender, EventArgs e)
        {
            tooltip_for_disapprove();
        }

        private void frmdisApprovedetail_Load_1(object sender, EventArgs e)
        {

        }

        private void frmdisApprovedetail_KeyPress(object sender, KeyPressEventArgs e)
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
        public void tooltip_for_disapprove()
        {
            toolTipDisaprove.SetToolTip(txtDisAppReason,"وجہ نامنظوری");
            toolTipDisaprove.SetToolTip(btnsave,"مخفوظ کریں");
        }
    }
}
