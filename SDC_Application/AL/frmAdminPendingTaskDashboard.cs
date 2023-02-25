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
                }
                else
                {
                    btnImplementTask.Enabled = false;
                    btnPrintProposedChanges.Enabled = false;
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
                if (dtPendingMutations.Rows.Count > 0)
                {
                    dgPendingMutations.DataSource = dtPendingMutations;
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
                dgPendingMutations.Columns["MozaId"].Visible = false;
            }
        }

        private void dgPendingMutations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIntiqalId.Text=dgPendingMutations.SelectedRows[0].Cells["IntiqalId"].Value.ToString();
                txtMozaId.Text = dgPendingMutations.SelectedRows[0].Cells["MozaId"].Value.ToString();
                if (txtIntiqalId.Text.Length > 5 && txtMozaId.Text.Length>4)
                {
                    btnImplementMutation.Enabled = true;
                }
                else
                    btnImplementMutation.Enabled = false;

                foreach (DataGridViewRow row in dgPendingMutations.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["ColSelIntiqal"].Value = true;
                    }
                    else
                        row.Cells["ColSelIntiqal"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImplementMutation_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("کیا آپ انتخاب کردہ انتقال پر عمل درامد کرنا چاہتے ہے؟", "عمل درامد کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    this.btnImplementMutation.Enabled = false;
                    //MessageBox.Show("Yes");
                    //check whether seller and buyer raqba and hissa are same

                    string BS_AreaHissa = Iq.GetIntiqalSellerBuyerAreaCheck(txtIntiqalId.Text);
                    if (BS_AreaHissa != "-1")
                    {
                        MessageBox.Show(BS_AreaHissa, "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        if (Iq.CheckMalikRemainingHissaCheck(txtIntiqalId.Text) == "1")
                        {
                            DataTable dtIntiqalaAmal = Iq.IntiqalAmalDaramad(txtMozaId.Text, txtIntiqalId.Text);
                            if (dtIntiqalaAmal.Rows.Count > 0)
                            {
                                if (dtIntiqalaAmal.Rows[0][0].ToString().Length > 5)
                                {
                                    MessageBox.Show("عمل درامد ہو گیا");
                                    btnImplementMutation.Enabled = false;
                                    btnShowAllPendingMutations_Click(sender, e);
                                    //this.SetAmalDaramadStatus(this.AmalDaramad);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("بایع / دہندہ کے محفوظ شدہ حصہ و رقبہ اور اصل ملکییتی حصہ و رقبہ برابر نہیں ہے۔", "ناقابل عمل درامد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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

    }
}
