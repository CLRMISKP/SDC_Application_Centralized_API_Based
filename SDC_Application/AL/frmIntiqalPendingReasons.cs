using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmIntiqalPendingReasons : Form
    {
        #region Class Varialbes

        Intiqal client = new Intiqal();
        LanguageManager.LanguageConverter Lang = new LanguageManager.LanguageConverter();
        public string IntiqalId { get; set; }
        public string PersonId { get; set; }

        #endregion
        public frmIntiqalPendingReasons()
        {
            InitializeComponent();
        }

        private void frmIntiqalPendingReasons_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            DataTable Reasons = new DataTable();
            Reasons = client.GetIntiqalPendingReason();
            if (Reasons != null)
            {
                DataRow Reason = Reasons.NewRow();
                Reason["IntiqalPendingreason_Urdu"] = "انتخاب واجہ التواء";
                Reason["Intiqalpendingreasonid"] = 0;
                Reasons.Rows.InsertAt(Reason, 0);
                this.cboIntiqalPendingReasons.DataSource = Reasons;
                this.cboIntiqalPendingReasons.DisplayMember = "IntiqalPendingreason_Urdu";
                this.cboIntiqalPendingReasons.ValueMember = "Intiqalpendingreasonid";
                this.cboIntiqalPendingReasons.SelectedValue = 0;
            }
        }

        private void btnSaveIntiqalPendingStatus_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32( this.cboIntiqalPendingReasons.SelectedValue )!= 0)
            {
                client.setIntiqalPendingReason(this.IntiqalId, true, cboIntiqalPendingReasons.SelectedValue.ToString(), UsersManagments.UserId.ToString(),txtPendingRemarks.Text.Trim());
                this.Close();
            }
        }

        private void txtPendingRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar((Keys.Back)))
            {

            }
            else
            {
                e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            }
        }
    }
}
