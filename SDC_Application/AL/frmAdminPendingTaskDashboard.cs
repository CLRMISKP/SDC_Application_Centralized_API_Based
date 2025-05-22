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
using SDC_Application.LanguageManager;
using System.Globalization;

namespace SDC_Application.AL
{
    public partial class frmAdminPendingTaskDashboard : Form
    {
        RhzSDC rhz = new RhzSDC();
        DataTable dtRHZ_ChangeList_Summary = new DataTable();
        DataTable dtRHZ_ChangeList_details = new DataTable();
        DataView dvRHZ_ChangeList_details;
        Intiqal Iq = new Intiqal();
        DataTable dtMouzas = new DataTable();
        AutoComplete auto = new AutoComplete();
        Khatoonies khatooni = new Khatoonies();
        DataTable dtkj= new DataTable();
        Misal misal=new Misal();
        DataView dvPendingIntiqal = new DataView();
        DataView dvPendingIntiqalAllPend = new DataView();
        DataTable dtKhewatFareeqain = new DataTable();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        DataView view;
        DataView viewMF;
        LanguageConverter lang = new LanguageConverter();
        DataTable dtIntiqalListForAdminOps = new DataTable();
        DataTable TokenList = new DataTable();
        DataTable dtFbList = new DataTable();
        public string intiqalTypeId { get; set; }

        public frmAdminPendingTaskDashboard()
        {
            InitializeComponent();
        }

        private void frmAdminPendingTaskDashboard_Load(object sender, EventArgs e)
        {
            dtRHZ_ChangeList_Summary = rhz.GetRHZChangeSummary();
            if (dtRHZ_ChangeList_Summary != null)
            {
                if (dtRHZ_ChangeList_Summary.Rows.Count > 0)
                {
                    dgTasksSummary.DataSource = dtRHZ_ChangeList_Summary;
                    fillDgTaskSummary();
                }
            }
        }
        private void fillDgTaskSummary()
        {
            if (dtRHZ_ChangeList_Summary.Rows.Count > 0)
            {
                dgTasksSummary.Columns["TotalChangeRequets"].HeaderText="تمام ٹاسک";
                dgTasksSummary.Columns["Implemented"].HeaderText="عمل شدہ";
                dgTasksSummary.Columns["Pending"].HeaderText="زیر تجویز";
                dgTasksSummary.Columns["MozaNameUrdu"].HeaderText="موضع";
                dgTasksSummary.Columns["MozaId"].Visible=false;
            }
        }

        private void dgTasksSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string MozaId = "0";
                if (dgTasksSummary.Rows.Count > 0)
                {
                    MozaId = dgTasksSummary.SelectedRows[0].Cells["MozaId"].Value.ToString();
                    dtRHZ_ChangeList_details = rhz.GetRHZChangeDetailsByMoza(MozaId);
                    if (dtRHZ_ChangeList_details != null)
                    {
                        dvRHZ_ChangeList_details = new DataView(dtRHZ_ChangeList_details);
                        dvRHZ_ChangeList_details.RowFilter = "ImplementedBY =0";
                        dgTaskDetails.DataSource = dvRHZ_ChangeList_details; //dgKhataEditColSel
                        fillDgTaskDetails();
                        foreach (DataGridViewRow row in dgTasksSummary.Rows)
                        {
                            if (row.Selected)
                            {
                                row.Cells["dgKhataEditColSel"].Value = true;
                            }
                            else
                                row.Cells["dgKhataEditColSel"].Value = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillDgTaskDetails()
        {
            //if (dgTaskDetails.Rows.Count > 0)
            //{
                dgTaskDetails.Columns["SrNo"].HeaderText = "ٹاسک نمبر";
                dgTaskDetails.Columns["ChangeDetails"].HeaderText = "تفصیل ترمیم";
                dgTaskDetails.Columns["InsertLoginName"].HeaderText = "اندراج کنندہ";
                dgTaskDetails.Columns["InsertDate"].HeaderText = "بتاریخ";
                dgTaskDetails.Columns["RHZ_ChangeId"].Visible = false;
                dgTaskDetails.Columns["ImplementedBy"].Visible = false;
            //}
        }

        private void rbPending_CheckedChanged(object sender, EventArgs e)
        {
            if (dtRHZ_ChangeList_details != null)
            {
                if (dtRHZ_ChangeList_details.Rows.Count > 0)
                {
                    if (rbPending.Checked)
                    {
                        dvRHZ_ChangeList_details = new DataView(dtRHZ_ChangeList_details);
                        dvRHZ_ChangeList_details.RowFilter = "ImplementedBY =0";
                        dgTaskDetails.DataSource = dvRHZ_ChangeList_details;
                        fillDgTaskDetails();
                    }
                    else if (rbCompleted.Checked)
                    {
                        dvRHZ_ChangeList_details = new DataView(dtRHZ_ChangeList_details);
                        dvRHZ_ChangeList_details.RowFilter = "ImplementedBY <>0";
                        dgTaskDetails.DataSource = dvRHZ_ChangeList_details;
                        fillDgTaskDetails();
                    }
                    else if (rbAllTasks.Checked)
                    {
                        dvRHZ_ChangeList_details = new DataView(dtRHZ_ChangeList_details);
                        dgTaskDetails.DataSource = dvRHZ_ChangeList_details;
                        fillDgTaskDetails();
                    }
                }
            }
        }

        private void btnShowAllPendingTasks_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAllPendingTasks= rhz.GetRHZChangePendingAllMouzas();
                if (dtAllPendingTasks != null)
                {
                    if (dtAllPendingTasks.Rows.Count > 0)
                    {
                        dgAllPendingTasks.DataSource = dtAllPendingTasks;
                        fillDgAllPendingTasks();
                    }
                    else
                        dgAllPendingTasks.DataSource = null;
                }
                else
                    dgAllPendingTasks.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillDgAllPendingTasks()
        {
            if (dgAllPendingTasks.Rows.Count > 0)
            {
                dgAllPendingTasks.Columns["MozaNameUrdu"].HeaderText = "موضع";
                dgAllPendingTasks.Columns["SrNo"].HeaderText = "ٹاسک نمبر";
                dgAllPendingTasks.Columns["ChangeDetails"].HeaderText = "تفصیل ترمیم";
                dgAllPendingTasks.Columns["InsertLoginName"].HeaderText = "اندراج کنندہ";
                dgAllPendingTasks.Columns["InsertDate"].HeaderText = "بتاریخ";
                dgAllPendingTasks.Columns["RHZ_ChangeId"].Visible = false;
                dgAllPendingTasks.Columns["MozaId"].Visible = false;
            }
        }

        private void dgAllPendingTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtRHZ_ChangeId.Text=dgAllPendingTasks.SelectedRows[0].Cells["RHZ_ChangeId"].Value.ToString();
                txtMozaIdAllPendingTask.Text = dgAllPendingTasks.SelectedRows[0].Cells["MozaId"].Value.ToString();
                if (txtRHZ_ChangeId.Text.Length > 5)
                {
                    btnImplementTask.Enabled = true;
                    btnPrintProposedChanges.Enabled = true;
                    btnFinishTask.Enabled = true;
                }
                else
                {
                    btnImplementTask.Enabled = false;
                    btnPrintProposedChanges.Enabled = false;
                    btnFinishTask.Enabled = false;
                }

                foreach (DataGridViewRow row in dgAllPendingTasks.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["ColSelAllPendingTask"].Value = true;
                    }
                    else
                        row.Cells["ColSelAllPendingTask"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImplementTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("آپ فرد انتخاب کردہ ترامیم پر عملدرامد کرنا چاہتے ہے؟", "عمل کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (txtRHZ_ChangeId.Text.Trim().Length > 5)
                    {
                        string retVal=rhz.RHZ_ChangeImplementation(txtRHZ_ChangeId.Text);
                        if (retVal.Length > 5)
                        {
                            MessageBox.Show("انتخاب کردہ ریکارڈ پر عمل درامد ہو چکا ہے۔");
                            btnShowAllPendingTasks_Click(sender, e);
                            btnImplementTask.Enabled = false;
                        }
                        
                    }
                    else
                        MessageBox.Show("عملدارمد کرنے کیلئے پہلے ریکارڈ کا انتخاب کریں", "ناقابل عمل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAllPendingMutations_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPendingMutations = rhz.GetIntiqalPendingMissingAll();
                if (dtPendingMutations != null)
                {
                    dvPendingIntiqal = dtPendingMutations.AsDataView();
                    if (dtPendingMutations.Rows.Count > 0)
                    {
                        dgPendingMutations.DataSource = dvPendingIntiqal;
                        fillDgPendingMutations();
                    }
                    else
                        dgPendingMutations.DataSource = null;
                }
                else
                    dgPendingMutations.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillDgPendingMutations()
        {
            if (dgPendingMutations.Rows.Count > 0)
            {
                dgPendingMutations.Columns["MozaNameUrdu"].HeaderText = "موضع";
                dgPendingMutations.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                //dgPendingMutations.Columns["ChangeDetails"].HeaderText = "تفصیل ترمیم";
                dgPendingMutations.Columns["InsertLoginName"].HeaderText = "اندراج کنندہ";
                dgPendingMutations.Columns["InsertDate"].HeaderText = "بتاریخ";
                dgPendingMutations.Columns["IntiqalId"].Visible = false;
                dgPendingMutations.Columns["MozaId"].Visible = false; //IntiqalTypeId
                //dgPendingMutations.Columns["IntiqalTypeId"].Visible = false;
            }
        }
        private void fillDgPendingMutationsAll()
        {
            if (dgPendingMutationsAll.Rows.Count > 0)
            {
                dgPendingMutationsAll.Columns["MozaNameUrdu"].HeaderText = "موضع";
                dgPendingMutationsAll.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                //dgPendingMutations.Columns["ChangeDetails"].HeaderText = "تفصیل ترمیم";
                dgPendingMutationsAll.Columns["InsertLoginName"].HeaderText = "اندراج کنندہ";
                dgPendingMutationsAll.Columns["InsertDate"].HeaderText = "بتاریخ";
                dgPendingMutationsAll.Columns["IntiqalId"].Visible = false;
                dgPendingMutationsAll.Columns["MozaId"].Visible = false; //IntiqalTypeId
                //dgPendingMutations.Columns["IntiqalTypeId"].Visible = false;
            }
        }

        private void dgPendingMutations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIntiqalId.Text=dgPendingMutations.SelectedRows[0].Cells["IntiqalId"].Value.ToString();
                txtMozaId.Text = dgPendingMutations.SelectedRows[0].Cells["MozaId"].Value.ToString();
                //this.intiqalTypeId = dgPendingMutations.SelectedRows[0].Cells["IntiqalTypeId"].Value.ToString();
                if (txtIntiqalId.Text.Length > 5 && txtMozaId.Text.Length > 4)
                {
                    btnImplementMutation.Enabled = true;
                    btnPrintMutation.Enabled = true;
                }
                else
                {
                    btnImplementMutation.Enabled = false;
                    btnPrintMutation.Enabled = false;
                }

                foreach (DataGridViewRow row in dgPendingMutations.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["ColSelIntiqal"].Value = true;
                    }
                    else
                        row.Cells["ColSelIntiqal"].Value = false;
                }
                btnCancelMutation.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImplementMutation_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("کیا آپ انتخاب کردہ انتقال  عمل درامد کیلئے فعال کرنا چاہتے ہے؟", "عمل درامد فعال کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    this.btnImplementMutation.Enabled = false;
                    string retVal= Iq.IntiqalEnableDisable(txtIntiqalId.Text, "enableAmal", "", "");
                    if (retVal == "1")
                    {
                        MessageBox.Show("انتقال عمل درامد فعال ہو گیا");
                        btnImplementMutation.Enabled = false;
                        btnShowAllPendingMutations_Click(sender, e);
                    }
                        //check whether seller and buyer raqba and hissa are same

                    //string BS_AreaHissa = Iq.GetIntiqalSellerBuyerAreaCheck(txtIntiqalId.Text);
                    //if (BS_AreaHissa != "-1")
                    //{
                    //    MessageBox.Show(BS_AreaHissa, "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    //else
                    //{
                    //    if (Iq.CheckMalikRemainingHissaCheck(txtIntiqalId.Text) == "1")
                    //    {
                    //        DataTable dtIntiqalaAmal = Iq.IntiqalAmalDaramad(txtMozaId.Text, txtIntiqalId.Text,UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    //        if (dtIntiqalaAmal.Rows.Count > 0)
                    //        {
                    //            if (dtIntiqalaAmal.Rows[0][0].ToString().Length > 5)
                    //            {
                    //                MessageBox.Show("عمل درامد ہو گیا");
                    //                btnImplementMutation.Enabled = false;
                    //                btnShowAllPendingMutations_Click(sender, e);
                    //                //this.SetAmalDaramadStatus(this.AmalDaramad);
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("بایع / دہندہ کے محفوظ شدہ حصہ و رقبہ اور اصل ملکییتی حصہ و رقبہ برابر نہیں ہے۔", "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void btnPrintProposedChanges_Click(object sender, EventArgs e)
        {
            if (txtRHZ_ChangeId.Text.Trim().Length > 5)
            {
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 44;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.FbID = txtRHZ_ChangeId.Text;
                obj.MozaId = txtMozaIdAllPendingTask.Text;
                obj.ShowDialog();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {

                case 3:
                    {
                        if (cmbMouza.DataSource == null)
                        {
                            auto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
                        }
                        break;
                    }
                case 0:
                    {
                        break;
                    }
            }

        }

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {

           // auto.FillCombo("Proc_Self_Get_Moza_Register_KhataJat_All  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cmbMouza.SelectedValue.ToString() + "," + "0", cbKhattajatAll, "KhataNo", "RegisterHqDKhataId");
            Fill_Khata_DropDown();
            auto.FillCombo("Proc_Get_Moza_Register_KhataJat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cmbMouza.SelectedValue.ToString() + "," + "0", cbokhataNo, "KhataNo", "RegisterHqDKhataId");
        }
        public void Fill_Khata_DropDown()
        {
            try
            {

                dtkj = misal.GetAllKhatajatByMoza(Convert.ToInt32(cmbMouza.SelectedValue.ToString()));
                if (dtkj != null)
                {
                    DataRow inteqKj = dtkj.NewRow();
                    inteqKj["RegisterHqDKhataId"] = "0";
                    inteqKj["KhataNo"] = " - انتخاب کرِیں - ";
                    dtkj.Rows.InsertAt(inteqKj, 0);
                    cbKhattajatAll.DataSource = dtkj;
                    cbKhattajatAll.DisplayMember = "KhataNo";
                    cbKhattajatAll.ValueMember = "RegisterHqDKhataId";
                    cbKhattajatAll.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            auto.FillCombo("Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cbokhataNo.SelectedValue.ToString(), cboKhatoonies, "KhatooniNo", "KhatooniId");

            try
            {
                this.dtKhewatFareeqain = khatas.Proc_Self_Get_KhewatFareeqeinByKhataId(cbokhataNo.SelectedValue.ToString());
                this.dgKhewatFareeqainAll.DataSource = null;
                if (dtKhewatFareeqain != null)
                {
                    this.dgKhewatFareeqainAll.DataSource = dtKhewatFareeqain;
                    view = new DataView(dtKhewatFareeqain);
                    this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboKhatoonies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboKhatoonies.SelectedValue.ToString() != "0")
            {
                DataTable KhatooniDetail = khatooni.GetKhatooniDetailbyKhatooniId(cboKhatoonies.SelectedValue.ToString());
                if (KhatooniDetail != null)
                {
                    foreach (DataRow row in KhatooniDetail.Rows)
                    {
                        chkBeahShoda.Checked = Convert.ToBoolean(row["BeahShud"]);
                        txtKhatooniHissa.Text = row["KhatooniHissa"].ToString().Length > 0 ? row["KhatooniHissa"].ToString() : "0";
                        txtKhatooniKanal.Text = row["KhatooniKanal"].ToString().Length > 0 ? row["KhatooniKanal"].ToString() : "0";
                        txtKhatooniMarla.Text = row["KhatooniMarla"].ToString().Length > 0 ? row["KhatooniMarla"].ToString() : "0";
                        txtKhatooniSarsai.Text = row["KhatooniSarsai"].ToString().Length > 0 ? row["KhatooniSarsai"].ToString() : "0";
                        txtKhatooniFeet.Text = row["KhatooniFeet"].ToString().Length > 0 ? row["KhatooniFeet"].ToString() : "0";
                    }
                }
            }
            this.GetKhatooniMushteryan(cboKhatoonies.SelectedValue.ToString());
        }

        private void chkBeahShoda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBeahShoda.Checked)
            {
                if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ کھتونی کا حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string Status = khatooni.UpdateKhatooniStatus(cboKhatoonies.SelectedValue.ToString(), "1");
                        MessageBox.Show("حیثیت تبدیل ہو چکا ہے۔");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ کھتونی کا حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        string Status = khatooni.UpdateKhatooniStatus(cboKhatoonies.SelectedValue.ToString(), "0");
                        MessageBox.Show("حیثیت تبدیل ہو چکا ہے۔");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void cbKhattajatAll_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataRow row in dtkj.Rows)
            {
                if (cbokhataNo.SelectedValue != null)
                {
                    if ((row["RegisterHqDKhataId"].ToString() == cbKhattajatAll.SelectedValue.ToString()) && cbKhattajatAll.SelectedValue.ToString() != "0")
                    {
                        rbCurrentKhata.Checked = row["KhataNo"].ToString().Contains("سابقہ") ? false : true;
                        rbPreviousKhata.Checked = row["KhataNo"].ToString().Contains("سابقہ") ? true : false;
                    }
                }
            }
        }

        private void rbCurrentKhata_Click(object sender, EventArgs e)
        {
             if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ کھاتے کا حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
            if (rbCurrentKhata.Checked)
            {
               string status= rhz.UpdateKhataRecStatus(cbKhattajatAll.SelectedValue.ToString(), rbCurrentKhata.Checked ? "1" : "0");
               MessageBox.Show("انتخاب کردہ کھاتے کا حیثیت تبدیل ہو چکا ہے۔");
            }
            else if (rbPreviousKhata.Checked)
            {
                string status = rhz.UpdateKhataRecStatus(cbKhattajatAll.SelectedValue.ToString(), rbCurrentKhata.Checked ? "1" : "0");
                MessageBox.Show("انتخاب کردہ کھاتے کا حیثیت تبدیل ہو چکا ہے۔");
            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }

        private void btnFinishTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ ترامیم کو ختم کرنا چاہتے ہے؟", "ختم کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        if (txtRHZ_ChangeId.Text.Trim().Length > 5)
                        {
                            string retVal = rhz.RHZ_ChangeRequest_Cancel(txtRHZ_ChangeId.Text);
                            if (retVal.Length > 5)
                            {
                                MessageBox.Show("انتخاب کردہ ریکارڈ ختم ہو چکا ہے۔");
                                btnShowAllPendingTasks_Click(sender, e);
                                btnImplementTask.Enabled = false;
                            }

                        }
                        else
                            MessageBox.Show("ختم کرنے کیلئے پہلے ریکارڈ کا انتخاب کریں", "ناقابل ختم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelMutation_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("کیا آپ انتخاب کردہ انتقال کینسل/ ہائیڈ کرنا چاہتے ہے؟", "کینسل / ہائیڈ کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    this.btnCancelMutation.Enabled = false;
                    string retVal = Iq.IntiqalEnableDisable(txtIntiqalId.Text, "cancel", "", "");
                    if (retVal == "1")
                    {
                        MessageBox.Show("انتقال کینسل / ہائیڈ ہو گیا");
                        btnImplementMutation.Enabled = false;
                        btnShowAllPendingMutations_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void btnPrintMutation_Click(object sender, EventArgs e)
        {
            frmIntiqalReport rpt = new frmIntiqalReport();
            rpt.ShowDialog();
            //frmSDCReportingMain TokenReport = new frmSDCReportingMain();
            //TokenReport.IntiqalId = txtIntiqalId.Text;
            //TokenReport.userId = UsersManagments.UserId.ToString();
            //if (this.intiqalTypeId == "37")
            //    UsersManagments.check = 18;
            //else if (this.intiqalTypeId == "15")
            //    UsersManagments.check = 19;
            //else
            //    UsersManagments.check = 4;
            ////else if (radKhanaKasht.Checked)
            ////    UsersManagments.check = 16;
            ////else if (radkhanakashtmalkiat.Checked)
            ////    UsersManagments.check = 17;
            ////else if (radkhanakashtToMalkiat.Checked)
            ////    UsersManagments.check = 45;
            ////else if (radKhanaMalkiat.Checked)
            ////    UsersManagments.check = 4;
            //TokenReport.ShowDialog();     
        }

        private void btnLoadAllPendingMut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPendingMutations = rhz.GetIntiqalPendingAll();
                if (dtPendingMutations != null)
                {
                    dvPendingIntiqalAllPend = dtPendingMutations.AsDataView();
                    if (dtPendingMutations.Rows.Count > 0)
                    {
                        dgPendingMutationsAll.DataSource = dvPendingIntiqalAllPend;// dtPendingMutations;
                        fillDgPendingMutationsAll();
                    }
                    else
                        dgPendingMutationsAll.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgPendingMutationsAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIntiqalIdAllMut.Text = dgPendingMutationsAll.SelectedRows[0].Cells["IntiqalId"].Value.ToString();
                txtMozaIdAll.Text = dgPendingMutationsAll.SelectedRows[0].Cells["MozaId"].Value.ToString();
                //this.intiqalTypeId = dgPendingMutations.SelectedRows[0].Cells["IntiqalTypeId"].Value.ToString();
                if (txtIntiqalIdAllMut.Text.Length > 5 && txtMozaIdAll.Text.Length > 4)
                {
                    btnCancelAllMut.Enabled = true;
                    btnPrintAllMut.Enabled = true;
                }
                else
                {
                    btnCancelAllMut.Enabled = false;
                    btnPrintAllMut.Enabled = false;
                }

                foreach (DataGridViewRow row in dgPendingMutationsAll.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["ColSelIntiqalAll"].Value = true;
                    }
                    else
                        row.Cells["ColSelIntiqalAll"].Value = false;
                }
                //btnCancelMutation.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrintAllMut_Click(object sender, EventArgs e)
        {
            frmIntiqalReport rpt = new frmIntiqalReport();
            rpt.ShowDialog();
        }

        private void btnCancelAllMut_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("کیا آپ انتخاب کردہ انتقال کینسل/ ہائیڈ کرنا چاہتے ہے؟", "کینسل / ہائیڈ کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    this.btnCancelMutation.Enabled = false;
                    string retVal = Iq.IntiqalEnableDisable(txtIntiqalId.Text, "cancel", "", "");
                    if (retVal == "1")
                    {
                        MessageBox.Show("انتقال کینسل / ہائیڈ ہو گیا");
                        btnImplementMutation.Enabled = false;
                        btnShowAllPendingMutations_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void txtSearchIntiqal_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchIntiqal.Text.ToString();
            if (dvPendingIntiqal != null)
            {
                dvPendingIntiqal.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
                dgPendingMutations.DataSource = dvPendingIntiqal;
                fillDgPendingMutations();
            }
        }

        private void txtSearchIntiqalAllPending_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchIntiqalAllPending.Text.ToString();
            if (dvPendingIntiqalAllPend != null)
            {
                dvPendingIntiqalAllPend.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
                dgPendingMutationsAll.DataSource = dvPendingIntiqalAllPend;// dtPendingMutations;
                fillDgPendingMutationsAll();
            }
        }
        #region Fill Gridview Malkan by Khata

        private void PopulateGridViewKhewatMalkanAll(DataGridView g, Boolean All)
        {
            try
            {

                g.Columns["FardAreaPart"].HeaderText = "حصہ";
                g.Columns["Khewat_Area"].HeaderText = "رقبہ";
                g.Columns["PersonName"].HeaderText = "نام مالک";
                g.Columns["CNIC"].HeaderText = "شناختی /پاسپورٹ نمبر";
                g.Columns["KhewatType"].HeaderText = "قسم مالک";
                g.Columns["FardPart_Bata"].Visible = false;
                g.Columns["seqno"].HeaderText = "نمبر شمار";
                g.Columns["KhewatGroupFareeqId"].Visible = false;
                g.Columns["KhewatGroupId"].Visible = false;
                g.Columns["PersonId"].Visible = false;
                g.Columns["KhewatTypeId"].Visible = false;
                g.Columns["RecStatus"].HeaderText = "حالت";
                g.Columns["PersonName"].DisplayIndex = 2;
                g.Columns["KhewatType"].DisplayIndex = 3;
                g.Columns["seqno"].DisplayIndex = 1;
                if (!g.Columns.Contains("ColCnicUpdate"))
                {
                    DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                    col.Name = "ColCnicUpdate";
                    g.Columns.Add(col);
                    g.Columns["ColCnicUpdate"].HeaderText = "اندراج شناختی کارڈ";

                }
                g.Columns["ColCnicUpdate"].DisplayIndex = g.Columns.Count - 1;

                foreach (DataGridViewRow row in g.Rows)
                {
                    if (row.Cells["CNIC"].Value.ToString().Length > 5)
                    {

                    }
                    else
                    {
                        row.Cells["ColCnicUpdate"].Value = "اندراج شناختی کارڈ";
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        private void dgKhewatFareeqainAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (dgKhewatFareeqainAll.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells[0].Value = 1;
                            txtKhewatGroupFareeqId.Text = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                            if (row.Cells["RecStatus"].Value.ToString() == "موجودہ")
                                rbKhewatMalikCurrent.Checked = true;
                            else
                                rbKhewatMalikPrevious.Checked = true;
                        }
                        else
                        {
                            row.Cells[0].Value = 0;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbKhewatMalikCurrent_Click(object sender, EventArgs e)
        {
            if (txtKhewatGroupFareeqId.Text.Length > 5)
            {
                ChangeKhewatMalikStatus();
                cbokhataNo_SelectionChangeCommitted(sender, e);
            }
        }

        private void rbKhewatMalikPrevious_Click(object sender, EventArgs e)
        {
            if (txtKhewatGroupFareeqId.Text.Length > 5)
            {
                ChangeKhewatMalikStatus();
                cbokhataNo_SelectionChangeCommitted(sender, e);
            }
        }
        private void ChangeKhewatMalikStatus()
        {
            if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ مالک کی حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (rbKhewatMalikCurrent.Checked)
                    {
                        string status = rhz.UpdateKhewatMalikRecStatus(txtKhewatGroupFareeqId.Text, rbKhewatMalikCurrent.Checked ? "1" : "0");
                        MessageBox.Show("انتخاب کردہ مالک کی حیثیت تبدیل ہو چکا ہے۔");
                    }
                    else if (rbKhewatMalikPrevious.Checked)
                    {
                        string status = rhz.UpdateKhewatMalikRecStatus(txtKhewatGroupFareeqId.Text, rbKhewatMalikCurrent.Checked ? "1" : "0");
                        MessageBox.Show("انتخاب کردہ مالک کی حیثیت تبدیل ہو چکا ہے۔");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void GetKhatooniMushteryan(string KhatooniId)
        {
            try
            {
                //DataTable mushteryanCUrrent = khatooni.Get_MushtriFareeqein_By_KhatooniId(KhatooniId);
                DataTable mushteryanCUrrent = khatooni.Get_MushtriFareeqein_By_Khatooni_All_Status(KhatooniId);
                if (mushteryanCUrrent != null)
                {
                    dgMushteriFareeqainAll.DataSource = mushteryanCUrrent;
                    viewMF = new DataView(mushteryanCUrrent);
                    PopulateGrid(dgMushteriFareeqainAll);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region MushterFareeqain Gridview Population
        private void PopulateGrid(DataGridView g)
        {
            try
            {
                if (g.DataSource != null)
                {
                    g.Columns["FardAreaPart"].HeaderText = "حصہ";
                    g.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                    g.Columns["CompleteName"].HeaderText = "نام مالک";
                    g.Columns["KhewatType"].HeaderText = "قسم مالک";
                    g.Columns["FardPart_Bata"].Visible = false;
                    g.Columns["seqno"].HeaderText = "نمبر شمار";
                    g.Columns["MushtriFareeqId"].Visible = false;
                    g.Columns["KhatooniId"].Visible = false;
                    g.Columns["PersonId"].Visible = false;
                    g.Columns["KhewatTypeId"].Visible = false;
                    g.Columns["RecStatus"].HeaderText = "حالت";
                    g.Columns["CompleteName"].DisplayIndex = 2;
                    g.Columns["KhewatType"].DisplayIndex = 3;
                    g.Columns["seqno"].DisplayIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void dgMushteriFareeqainAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (g.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells[0].Value = 1;
                            txtMushteriFareeqId.Text = row.Cells["MushtriFareeqId"].Value.ToString();
                            if (row.Cells["RecStatus"].Value.ToString() == "موجودہ")
                                rbKhatooniMalikCurrent.Checked = true;
                            else
                                rbKhatooniMalikPrevious.Checked = true;


                        }
                        else
                        {
                            row.Cells[0].Value = 0;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbKhatooniMalikCurrent_Click(object sender, EventArgs e)
        {
            if (txtMushteriFareeqId.Text.Length > 5)
            {
                ChangeKhatooniMalikStatus();
                cboKhatoonies_SelectionChangeCommitted(sender, e);
            }
        }

        private void rbKhatooniMalikPrevious_Click(object sender, EventArgs e)
        {
            if (txtMushteriFareeqId.Text.Length > 5)
            {
                ChangeKhatooniMalikStatus();
                cboKhatoonies_SelectionChangeCommitted(sender, e);
            }
        }
        private void ChangeKhatooniMalikStatus()
        {
            if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ مالک کی حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    if (rbKhatooniMalikCurrent.Checked)
                    {
                        string status = rhz.UpdateKhatooniMalikRecStatus(txtMushteriFareeqId.Text, rbKhatooniMalikCurrent.Checked ? "1" : "0");
                        MessageBox.Show("انتخاب کردہ مالک کی حیثیت تبدیل ہو چکا ہے۔");
                    }
                    else if (rbKhatooniMalikPrevious.Checked)
                    {
                        string status = rhz.UpdateKhatooniMalikRecStatus(txtMushteriFareeqId.Text, rbKhatooniMalikCurrent.Checked ? "1" : "0");
                        MessageBox.Show("انتخاب کردہ مالک کی حیثیت تبدیل ہو چکا ہے۔");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtSearchKhanakasht_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchKhanakasht.Text.ToString();
            if (viewMF != null)
            {
                viewMF.RowFilter = "CompleteName LIKE '%" + filter + "%'";
                this.dgMushteriFareeqainAll.DataSource = viewMF;
                this.PopulateGridViewMushteryanAll();
            }
        }
        #region Fill Gridview Mushteryan by Khata

        private void PopulateGridViewMushteryanAll()
        {
            if (dgMushteriFareeqainAll != null)
            {
                dgMushteriFareeqainAll.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgMushteriFareeqainAll.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                dgMushteriFareeqainAll.Columns["CompleteName"].HeaderText = "نام مالک";
                dgMushteriFareeqainAll.Columns["KhewatType"].HeaderText = "قسم مالک";
                dgMushteriFareeqainAll.Columns["FardPart_Bata"].Visible = false;
                dgMushteriFareeqainAll.Columns["seqno"].HeaderText = "نمبر شمار";
                dgMushteriFareeqainAll.Columns["MushtriFareeqId"].Visible = false;
                dgMushteriFareeqainAll.Columns["KhatooniId"].Visible = false;
                dgMushteriFareeqainAll.Columns["PersonId"].Visible = false;
                dgMushteriFareeqainAll.Columns["KhewatTypeId"].Visible = false;
                dgMushteriFareeqainAll.Columns["RecStatus"].HeaderText = "حالت";
                dgMushteriFareeqainAll.Columns["CompleteName"].DisplayIndex = 2;
                dgMushteriFareeqainAll.Columns["KhewatType"].DisplayIndex = 3;
                dgMushteriFareeqainAll.Columns["seqno"].DisplayIndex = 1;
            }
        }

        #endregion

        private void txtSearchCurrentKhewatFareeqain_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchCurrentKhewatFareeqain.Text.ToString();
            if (view != null)
            {
                view.RowFilter = "PersonName LIKE '%" + filter + "%'";
                dgKhewatFareeqainAll.DataSource = view;
                this.PopulateGridViewKhewatMalkanAll(dgKhewatFareeqainAll, false);
            }
        }

        private void txtSearchCurrentKhewatFareeqain_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void btnLoadMouza_Click(object sender, EventArgs e)
        {
            try
            {
                auto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + UsersManagments.SubSdcId.ToString(), cmbMouzaAdminOps, "MozaNameUrdu", "MozaId");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadIntiqal_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMouzaAdminOps.DataSource!=null)
                {
                    dtIntiqalListForAdminOps = null;
                    dtIntiqalListForAdminOps = Iq.GetIntiqalListByMoza(cmbMouzaAdminOps.SelectedValue.ToString());
                    if (dtIntiqalListForAdminOps != null)
                    {
                        cmbIntiqalAdminOps.DataSource = dtIntiqalListForAdminOps;
                        cmbIntiqalAdminOps.ValueMember = "IntiqalId";
                        cmbIntiqalAdminOps.DisplayMember = "IntiqalNo";
                    }
                }
                else
                    dtIntiqalListForAdminOps = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadFardbadar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMouzaAdminOps.SelectedValue.ToString().Length > 2)
                {
                    dtFbList = null;
                    dtFbList = Iq.GetFardbadarList(cmbMouzaAdminOps.SelectedValue.ToString());
                    if (dtFbList != null)
                    {
                        cmbFardBadarAdminOps.DataSource = dtFbList;
                        cmbFardBadarAdminOps.ValueMember = "FB_Id";
                        cmbFardBadarAdminOps.DisplayMember = "FB_DocumentNo";
                    }
                }
                else
                    dtIntiqalListForAdminOps = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpAdminOps_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                TokenList = Iq.GetTokenListByDate(dtpAdminOps.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), UsersManagments.SubSdcId.ToString());
                if (TokenList != null)
                {
                    DataRow Token = TokenList.NewRow();
                    Token["TokenId"] = "0";
                    Token["TokenNo"] = " - ٹوکن نمبر - ";
                    TokenList.Rows.InsertAt(Token, 0);
                    cmbTokenAdminOps.DataSource = TokenList;
                    cmbTokenAdminOps.DisplayMember = "TokenNo";
                    cmbTokenAdminOps.ValueMember = "TokenId";
                    cmbTokenAdminOps.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbIntiqalAdminOps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkAmalshuda.Checked = false;
            chkAttested.Checked = false;
            chkOperatorConfirm.Checked = false;
            chkCancelled.Checked = false;
            chkPending.Checked = false;
            if (dtIntiqalListForAdminOps != null)
            {
                foreach (DataRow row in dtIntiqalListForAdminOps.Rows)
                {
                    if (row["IntiqalId"].ToString() == cmbIntiqalAdminOps.SelectedValue.ToString())
                    {
                        chkAmalshuda.Checked = Convert.ToBoolean(row["AmalShoda"].ToString());
                        chkAttested.Checked = Convert.ToBoolean(row["Attested"].ToString());
                        chkOperatorConfirm.Checked = Convert.ToBoolean(row["Confirmed"].ToString());
                        chkCancelled.Checked = Convert.ToBoolean(row["Cancelled"].ToString());
                        chkPending.Checked = Convert.ToBoolean(row["IntiqalPending"].ToString());
                    }
                }
            }
        }

        private void cmbTokenAdminOps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkFardConfirm.Checked = false;
            chkChalan.Checked = false;
            chkReceipt.Checked = false;
            if (TokenList != null)
            {
                foreach (DataRow row in TokenList.Rows)
                {
                    if (row["TokenId"].ToString() == cmbTokenAdminOps.SelectedValue.ToString() && cmbTokenAdminOps.SelectedValue.ToString() != "0")
                    {
                        chkFardConfirm.Checked = Convert.ToBoolean(row["isConfirmed"].ToString());
                        chkChalan.Checked = Convert.ToBoolean(row["PvStatus"].ToString());
                        chkReceipt.Checked = Convert.ToBoolean(row["RvStatus"].ToString());
                    }
                }
            }
        }

        private void cmbFardBadarAdminOps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkfbFinal.Checked = false;
            chkFbAmalShoda.Checked = false;
            if (dtFbList != null)
            {
                foreach (DataRow row in dtFbList.Rows)
                {
                    if (row["FB_Id"].ToString() == cmbFardBadarAdminOps.SelectedValue.ToString() && cmbFardBadarAdminOps.SelectedValue.ToString() != "0")
                    {
                        chkFbAmalShoda.Checked = Convert.ToBoolean(row["AmaldaramadStatus"].ToString());
                        chkfbFinal.Checked = Convert.ToBoolean(row["ConfirmationStatus"].ToString());
                        rbEFB.Checked = Convert.ToBoolean(row["isEFB"].ToString()); //isManualFb
                        rbMFB.Checked = Convert.ToBoolean(row["isManualFb"].ToString());
                    }
                }
            }
        }

        private string UpdateIntiqalOperations()
        {
            string lastId = "0";
            if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ انتقال کی حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    lastId = Iq.UpdateIntiqalAdminOps(cmbIntiqalAdminOps.SelectedValue.ToString(), chkAttested.Checked ? "1" : "0", chkAmalshuda.Checked ? "1" : "0", chkOperatorConfirm.Checked ? "1" : "0", chkPending.Checked ? "1" : "0", chkCancelled.Checked ? "1" : "0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return lastId;
        }
        private string UpdateFardatsOperations()
        {
            string lastId = "0";
            if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ فرد کی حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    lastId = Iq.UpdateFardatsAdminOps(cmbTokenAdminOps.SelectedValue.ToString(), chkFardConfirm.Checked ? "1" : "0", chkChalan.Checked ? "1" : "0", chkReceipt.Checked ? "1" : "0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return lastId;
        }
        private string UpdateFardBadratsOperations()
        {
            string lastId = "0";
            if (DialogResult.Yes == MessageBox.Show("آپ انتخاب کردہ فرد بدر کی حیثیت تبدیل کرنا چاہتے ہیں ؟", " تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    lastId = Iq.UpdateFardBadratsAdminOps(cmbFardBadarAdminOps.SelectedValue.ToString(), chkfbFinal.Checked ? "1" : "0", chkFbAmalShoda.Checked ? "1" : "0", rbEFB.Checked ? "1" : "0", rbMFB.Checked ? "1" : "0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return lastId;
        }

        private void chkOperatorConfirm_Click(object sender, EventArgs e)
        {
            string retVal = UpdateIntiqalOperations();
            if (retVal != "0" && retVal!=null)
               MessageBox.Show("انتقال  فائنل سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkAttested_Click(object sender, EventArgs e)
        {
            string retVal = UpdateIntiqalOperations();
            if (retVal != "0" && retVal != null)
               MessageBox.Show("انتقال  تصدیق شدہ سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkAmalshuda_Click(object sender, EventArgs e)
        {
            string retVal = UpdateIntiqalOperations();
            if (retVal != "0" && retVal != null)
             MessageBox.Show("انتقال  عمل شدہ سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkPending_Click(object sender, EventArgs e)
        {
            string retVal = UpdateIntiqalOperations();
            if (retVal != "0" && retVal != null)
             MessageBox.Show("انتقال  زیر التوا سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkCancelled_Click(object sender, EventArgs e)
        {
            string retVal = UpdateIntiqalOperations();
            if (retVal != "0" && retVal != null)
           MessageBox.Show("انتقال  خارج سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkFardConfirm_Click(object sender, EventArgs e)
        {
            string retVal = UpdateFardatsOperations();
            if (retVal != "0" && retVal != null)
            MessageBox.Show("فرد آپریٹر کنفرم سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkChalan_Click(object sender, EventArgs e)
        {
            string retVal = UpdateFardatsOperations();
            if (retVal != "0" && retVal != null)
           MessageBox.Show("فرد چالان سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkReceipt_Click(object sender, EventArgs e)
        {
            string retVal = UpdateFardatsOperations();
            if (retVal != "0" && retVal != null)
             MessageBox.Show("فرد رسید سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkfbFinal_Click(object sender, EventArgs e)
        {
            string retVal = UpdateFardBadratsOperations();
            if (retVal != "0" && retVal != null)
             MessageBox.Show("فرد بدر فائنل سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void chkFbAmalShoda_Click(object sender, EventArgs e)
        {
            string retVal = UpdateFardBadratsOperations();
            if (retVal != "0" && retVal != null)
              MessageBox.Show("فردبدر عمل شدہ سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }

        private void rbEFB_Click(object sender, EventArgs e)
        {
            string retVal = UpdateFardBadratsOperations();
            if (retVal != "0" && retVal != null)
                            MessageBox.Show("فردبدر ای فرد بدر سٹیٹس آپڈیٹ ہو گیا ہے۔");
           else
                    MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
         }

        private void rbMFB_Click(object sender, EventArgs e)
        {
            string retVal = UpdateFardBadratsOperations();
            if (retVal != "0" && retVal != null)
                MessageBox.Show(" دستی فرد بدر سٹیٹس آپڈیٹ ہو گیا ہے۔");
            else
                MessageBox.Show(" مطلوبہ عمل مکمل نہیں ہو سکا۔");
        }
    }
}
