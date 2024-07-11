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
        public string intiqalTypeId { get; set; }

        public frmAdminPendingTaskDashboard()
        {
            InitializeComponent();
        }

        private void frmAdminPendingTaskDashboard_Load(object sender, EventArgs e)
        {
            dtRHZ_ChangeList_Summary = rhz.GetRHZChangeSummary();
            if (dtRHZ_ChangeList_Summary.Rows.Count > 0)
            {
                dgTasksSummary.DataSource = dtRHZ_ChangeList_Summary;
                fillDgTaskSummary();
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

        private void btnShowAllPendingTasks_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAllPendingTasks= rhz.GetRHZChangePendingAllMouzas();
                if (dtAllPendingTasks.Rows.Count > 0)
                {
                    dgAllPendingTasks.DataSource = dtAllPendingTasks;
                    fillDgAllPendingTasks();
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
                dvPendingIntiqal = dtPendingMutations.AsDataView();
                if (dtPendingMutations.Rows.Count > 0)
                {
                    dgPendingMutations.DataSource = dvPendingIntiqal;
                    fillDgPendingMutations();
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
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - انتخاب کرِیں - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cbKhattajatAll.DataSource = dtkj;
                cbKhattajatAll.DisplayMember = "KhataNo";
                cbKhattajatAll.ValueMember = "RegisterHqDKhataId";
                cbKhattajatAll.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            auto.FillCombo("Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cbokhataNo.SelectedValue.ToString(), cboKhatoonies, "KhatooniNo", "KhatooniId");
            
        }

        private void cboKhatoonies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboKhatoonies.SelectedValue.ToString() != "0")
            {
                DataTable KhatooniDetail = khatooni.GetKhatooniDetailbyKhatooniId(cboKhatoonies.SelectedValue.ToString());
                foreach (DataRow row in KhatooniDetail.Rows)
                {
                        chkBeahShoda.Checked =Convert.ToBoolean( row["BeahShud"]);
                    txtKhatooniHissa.Text = row["KhatooniHissa"].ToString().Length>0?row["KhatooniHissa"].ToString():"0";
                    txtKhatooniKanal.Text = row["KhatooniKanal"].ToString().Length>0?row["KhatooniKanal"].ToString():"0";
                    txtKhatooniMarla.Text = row["KhatooniMarla"].ToString().Length>0?row["KhatooniMarla"].ToString():"0";
                    txtKhatooniSarsai.Text = row["KhatooniSarsai"].ToString().Length>0? row["KhatooniSarsai"].ToString():"0";
                    txtKhatooniFeet.Text = row["KhatooniFeet"].ToString().Length>0?row["KhatooniFeet"].ToString():"0";
                }
            }
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
                dvPendingIntiqalAllPend = dtPendingMutations.AsDataView();
                if (dtPendingMutations.Rows.Count > 0)
                {
                    dgPendingMutationsAll.DataSource = dvPendingIntiqalAllPend;// dtPendingMutations;
                    fillDgPendingMutationsAll();
                }
                else
                    dgPendingMutationsAll.DataSource = null;
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
            dvPendingIntiqal.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
            dgPendingMutations.DataSource = dvPendingIntiqal;
            fillDgPendingMutations();
        }

        private void txtSearchIntiqalAllPending_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchIntiqalAllPending.Text.ToString();
            dvPendingIntiqalAllPend.RowFilter = "IntiqalNo LIKE '%" + filter + "%'";
            dgPendingMutationsAll.DataSource = dvPendingIntiqalAllPend;// dtPendingMutations;
                    fillDgPendingMutationsAll();
        }
    }
}
