using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmKhanakashtMushteryanReport : Form
    {
        #region Class Variables
        AutoComplete objauto = new AutoComplete();
        Misal misalBl = new Misal();
        BL.frmToken objBusiness = new BL.frmToken();
        #endregion
        public frmKhanakashtMushteryanReport()
        {
            InitializeComponent();
        }

        private void frmKhanakashtMushteryanReport_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }

        #region Get Khatajat by Moza

        private void GetKhatajatByMoza(string MozaId)
        {
            objauto.FillCombo("proc_Get_Moza_KhataJat_for_Intiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId, cmbKhataNos, "KhataNo", "RegisterHqDKhataId");
        }

        #endregion

        #region Combobox Mouza Selection Change commited

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string mozaid=cmbMouza.SelectedValue.ToString();
            this.GetKhatajatByMoza(mozaid);
        }
        		 
	    #endregion

          #region Combobox Khata Nos Selection Change commited

        private void cmbKhataNos_SelectionChangeCommitted(object sender, EventArgs e)
        {
             string KhataId=cmbKhataNos.SelectedValue.ToString();
            string MouzaId=cmbMouza.SelectedValue.ToString();
            if(KhataId!="0")
            {
                btnViewReport.Enabled=true;
            }
            else
            {
                btnViewReport.Enabled=false;
            }

        }

        #endregion

        #region MyRegion

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try 
	            {	
        
		             frmSDCReportingMain obj = new frmSDCReportingMain();
                     if (chkAllByMoza.Checked)
                     {
                         UsersManagments.check = 10;
                     }
                     else
                     {
                         UsersManagments.check = 8;
                     }
                        obj.MozaId = cmbMouza.SelectedValue.ToString();
                        obj.KhataId = cmbKhataNos.SelectedValue.ToString();                
                        obj.Show();
	            }
	            catch (Exception ex)
	            {
		
		            MessageBox.Show(ex.Message);
	            }
        }
        		 
	    #endregion
    }
}
