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
    public partial class frmNewKhatooniAdd : Form
    {
        public string IntiqalId { get; set; }
        Intiqal inteq = new Intiqal();
        DataTable dt = new DataTable();
        DataTable malikanSel = new DataTable();
        DataTable MozaFamilies = new DataTable();
        DataTable FamilyPersons = new DataTable();
        UserMangement currentUsers = new UserMangement();
        TaqseemNewKhataJatMin taqseem = new TaqseemNewKhataJatMin();
        //LanguageConverter Lang = new LanguageConverter();
        public bool btn { get; set; }
        public string RegisterHaqKhataID { get; set; }
        public string MinKhataId { get; set; }
        public string KhatoniId { get; set; }
        public bool byKhta { get; set; }
        public frmNewKhatooniAdd()
        {
            InitializeComponent();
        }

        private void frmNewKhatooniAdd_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            try
            {
                if (byKhta)
                {
                    dt = taqseem.Proc_Get_Khatoonis(RegisterHaqKhataID);
                    this.grdKhatooni.DataSource = dt;
                    grdKhatooni.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                    grdKhatooni.Columns["KhatooniId"].Visible = false;
                    grdKhatooni.Columns["RegisterHqDKhataId"].Visible = false;
                    grdKhatooni.Columns["KhatooniKashtkaranFullDetail_New"].Visible = false;
                    grdKhatooni.Columns["KhatooniLagan"].Visible = false;
                    grdKhatooni.Columns["Wasail_e_Abpashi"].Visible = false;
                }
                else
                {
                    dt = taqseem.Proc_Get_Khatoonis_Intiqal_Taqseem_by_IntiqalId(IntiqalId);
                    this.grdKhatooni.DataSource = dt;
                    grdKhatooni.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                    grdKhatooni.Columns["KhatooniId"].Visible = false;
                    grdKhatooni.Columns["RegisterHqDKhataId"].Visible = false;
                    grdKhatooni.Columns["KhatooniKashtkaranFullDetail_New"].Visible = false;
                    grdKhatooni.Columns["KhatooniLagan"].Visible = false;
                    grdKhatooni.Columns["Wasail_e_Abpashi"].Visible = false;
                }
                
            }
            catch (Exception ex)
            { 
            }

        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.grdKhatooni.Rows)
            {
                if (!row.IsNewRow)
                {
                 row.Cells["chk"].Value = !(Boolean)(row.Cells["chk"].Value != null ? row.Cells["chk"].Value : false);
                }
                         }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.grdKhatooni.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["chk"].Value) == true)
                    {
                        string KhatooniId = "-1";
                        string KhatooniNo = row.Cells["KhatooniNo"].Value.ToString();
                        string KhatooniKashtkaranFullDetail_New = row.Cells["KhatooniKashtkaranFullDetail_New"].Value.ToString(); ; ;
                        string Wasail_e_Abpashi = row.Cells["Wasail_e_Abpashi"].Value.ToString();
                        string KhatooniLagan = row.Cells["KhatooniLagan"].Value.ToString();
                        string khatoniid = this.taqseem.WEB_SP_INSERT_KhatooniRegister(KhatooniId, KhatooniNo, KhatooniKashtkaranFullDetail_New, MinKhataId, Wasail_e_Abpashi, KhatooniLagan, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                    }
                }
                MessageBox.Show("کھتونی محفوظ ہوگیے", "کھتونی", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        
        }
    }

