using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.BL;
using SDC_Application.DL;
using System.Collections;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmGainTax : Form
    {
        TaqseemNewKhataJatMin taq = new TaqseemNewKhataJatMin();
        //public string Personid
        //{ 
        //    get; 
        //    set; 
        //}
        public frmGainTax()
        {
            InitializeComponent();
        }

        private void frmGainTax_Load(object sender, EventArgs e)
        {
            try
            {
                String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
                if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

                DataTable dt = new DataTable();
                dt = taq.Proc_Get_Gaintax(UsersManagments.Personid.ToString());
                grdgaintax.DataSource = dt;
                if (grdgaintax.Rows.Count > 0)
                {
                    label1.Text = "Gaint Tax";
                    label1.ForeColor = Color.Red;
                }
                else
                {
                    label1.Text = "No Gain Tax";
                    label1.ForeColor = Color.Black;
                }
                grdgaintax.Columns["PersonId"].Visible = false;
                grdgaintax.Columns["IntiqalId"].Visible = false;
                grdgaintax.Columns["KhewatGroupId"].Visible = false;
                grdgaintax.Columns["RegisterHqDKhataId"].Visible = false;
                grdgaintax.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                grdgaintax.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                grdgaintax.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
                grdgaintax.Columns["AmaldaramadStatus"].HeaderText = "عمل دارامد";
                grdgaintax.Columns["AmalDaramadDate"].HeaderText = "عمل دارامد تاریخ";
                grdgaintax.Columns["Buyer_Kanal"].HeaderText = "کنال";
                grdgaintax.Columns["Buyer_Marla"].HeaderText = "مرلہ";
                grdgaintax.Columns["Buyer_Sarsai"].HeaderText = "سرسایی";
                grdgaintax.Columns["Buyer_Feet"].HeaderText = "فٹ";

            }
            catch (Exception ex)
            { 
            }
        }
    }
}
