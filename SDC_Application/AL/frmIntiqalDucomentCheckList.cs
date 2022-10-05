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
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmIntiqalDucomentCheckList : Form
    {
        #region Varibales
        datagrid_controls datagridcontrols = new datagrid_controls();
        Intiqal intiq = new Intiqal();
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        Intiqal Iq = new Intiqal();
        DataTable dt_GetfromDocRequired = new DataTable();

        public string IntiqalId
        {
            get;
            set;
        }
        #endregion
        public frmIntiqalDucomentCheckList()
        {
            InitializeComponent();

        }
        #region ToolTip


        public void ToolTip()
        {
            toolTip1.SetToolTip(btnSave, "محفوظ کریں");
        }
        #endregion
        #region Load form
        private void frmIntiqalDucomentCheckList_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            ToolTip();

            if (IntiqalId != "-1")
            {
                try
                {
                    FillGridDocuments();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                CallRequireDocuments();
                invsiable();
            }
            else
            {
                MessageBox.Show("انتقال لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }




        }
        #endregion
        #region Document list grid setting
        public void FillGridDocuments()
        {

            dt = intiq.GetIntiqalDocumentsList();
            gdrDucoments.DataSource = dt;
            for (int i = 0; i <= gdrDucoments.Rows.Count - 1; i++)
            {
                gdrDucoments.Rows[i].Cells["increment"].Value = "-1";
                gdrDucoments.Rows[i].Cells["Seq"].Value = i + 1;
            }
            gdrDucoments.Columns["IntiqalDocName_Urdu"].HeaderText = "دستاویز انتقال";
            gdrDucoments.Columns["IntiqalDocName_Urdu"].DisplayIndex = 2;
            gdrDucoments.Columns["Seq"].DisplayIndex = 1;
            gdrDucoments.Columns["IntiqalDocId"].Visible = false;
            gdrDucoments.Columns["increment"].Visible = false;
            datagridcontrols.gridControls(gdrDucoments);
            datagridcontrols.colorrbackgrid(gdrDucoments);



        }
        #endregion
        #region Save ducoments
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            string IntiqalDocRecId;
            string SeqNo;
            for (int i = 0; i <= gdrDucoments.Rows.Count - 1; i++)
            {
                int b = Convert.ToInt32(gdrDucoments.Rows[i].Cells["CheckList"].Value);
                if (b == 1)
                {


                    IntiqalDocRecId = gdrDucoments.Rows[i].Cells["increment"].Value.ToString();
                    SeqNo = gdrDucoments.Rows[i].Cells["Seq"].Value.ToString();
                    string DocNameUrdu = gdrDucoments.Rows[i].Cells["IntiqalDocName_Urdu"].Value.ToString();
                    string IntiqalDocId = gdrDucoments.Rows[i].Cells["IntiqalDocId"].Value.ToString();

                    try
                    {
                        if (this.grdDucomentsUpdate.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in grdDucomentsUpdate.Rows)
                            {
                                // MessageBox.Show(row.Cells["IntiqalDocId"].Value + "--" + gdrDucoments.Rows[i].Cells["IntiqalDocId"].Value);
                                if (row.Cells["IntiqalDocId"].Value.ToString() == gdrDucoments.Rows[i].Cells["IntiqalDocId"].Value.ToString())
                                {
                                    isExists = true;
                                    gdrDucoments.CurrentCell = null;
                                    gdrDucoments.Rows[i].Visible = false;
                                    break;
                                }
                            }

                        }

                        if (!isExists)
                        {
                            string s = intiq.SaveIntiqalDocumentsRequired(IntiqalDocRecId, IntiqalId, SeqNo.ToString(), IntiqalDocId, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                            gdrDucoments.CurrentCell = null;
                            gdrDucoments.Rows[i].Visible = false;
                            invsiable();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

            for (int k = 0; k <= gdrDucoments.Rows.Count - 1; k++)
            {
                gdrDucoments.Rows[k].Cells["CheckList"].Value = 0;
            }
            CallRequireDocuments();
            chkAddDoc.Checked = false;
        }
        #endregion
        #region Retrive Saved Required Ducomts
        public void CallRequireDocuments()
        {
            grdDucomentsUpdate.Rows.Clear();
            try
            {
                dt_GetfromDocRequired = Iq.GetIntiqalDocuments_RequiredforScanning(IntiqalId);
                if (dt_GetfromDocRequired != null)
                {


                    for (int rowss = 0; rowss <= dt_GetfromDocRequired.Rows.Count - 1; rowss++)
                    {
                        grdDucomentsUpdate.Rows.Add();
                    }
                    int count = 0;
                    foreach (DataRow row in dt_GetfromDocRequired.Rows)
                    {

                        this.grdDucomentsUpdate.Rows[count].Cells["Doc"].Value = row["IntiqalDocName_Urdu"];
                        this.grdDucomentsUpdate.Rows[count].Cells["IntiqalDocId"].Value = row["IntiqalDocId"];
                        this.grdDucomentsUpdate.Rows[count].Cells["SeqNo"].Value = row["SeqNo"];
                        count++;

                    }
                }
                this.grdDucomentsUpdate.Columns["IntiqalDocId"].Visible = false;
                this.datagridcontrols.gridControls(grdDucomentsUpdate);
                datagridcontrols.colorrbackgrid(grdDucomentsUpdate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region ducoment list checked true false on click
        private void gdrDucoments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int b = Convert.ToInt32(gdrDucoments.CurrentRow.Cells["CheckList"].Value);

            if (b == 1)
            {
                gdrDucoments.CurrentRow.Cells["CheckList"].Value = 0;
            }
            else
            {
                gdrDucoments.CurrentRow.Cells["CheckList"].Value = 1; ;
            }
        }
        #endregion
        #region delete ducoments
        private void grdDucomentsUpdate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == this.grdDucomentsUpdate.CurrentRow.Cells["DeleteDucoment"].ColumnIndex)
                {
                    if (Convert.ToInt32(this.grdDucomentsUpdate.CurrentRow.Cells["DeleteDucoment"].Value) == 1)
                    {
                        this.grdDucomentsUpdate.CurrentRow.Cells["DeleteDucoment"].Value = 0;
                    }
                    else
                    {
                        this.grdDucomentsUpdate.CurrentRow.Cells["DeleteDucoment"].Value = 1;
                    }
                }
            }
        }
        #endregion
        #region Delete doc
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridView g = sender as DataGridView;


            if (grdDucomentsUpdate.Rows.Count > 0)
            {

                try
                {
                    for (int i = 0; i < grdDucomentsUpdate.Rows.Count; i++)
                    {
                        int rowvalue = Convert.ToInt32(grdDucomentsUpdate.Rows[i].Cells["DeleteDucoment"].Value);
                        //MessageBox.Show(""+rowvalue);
                        if (rowvalue == 1)
                        {

                            string intiqaldocid = grdDucomentsUpdate.Rows[i].Cells["IntiqalDocId"].Value.ToString();
                            string SeqNo = grdDucomentsUpdate.Rows[i].Cells["SeqNo"].Value.ToString();
                            if (Iq.DeltefromRequiredDucoments(intiqaldocid, IntiqalId, SeqNo) != null)
                            {

                                for (int ii = 0; ii < gdrDucoments.Rows.Count; ii++)
                                {
                                    if (grdDucomentsUpdate.Rows[i].Cells["IntiqalDocId"].Value.ToString() == gdrDucoments.Rows[ii].Cells["IntiqalDocId"].Value.ToString())
                                    {
                                        if (gdrDucoments.Rows[ii].Visible == false)
                                        {

                                            gdrDucoments.Rows[ii].Visible = true;
                                        }
                                        else
                                        {
                                        }
                                    }


                                }


                            }
                        }
                    }
                    chkDelDoc.Checked = false;
                    CallRequireDocuments();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public void invsiable()
        {

            if (grdDucomentsUpdate.Rows.Count > 0)
            {
                for (int i = 0; i < grdDucomentsUpdate.Rows.Count; i++)
                {

                    for (int ii = 0; ii < gdrDucoments.Rows.Count; ii++)
                    {
                        if (grdDucomentsUpdate.Rows[i].Cells["IntiqalDocId"].Value.ToString() == gdrDucoments.Rows[ii].Cells["IntiqalDocId"].Value.ToString())
                        {
                            gdrDucoments.Rows[ii].Selected = true;
                            gdrDucoments.CurrentCell = null;
                           gdrDucoments.Rows[ii].Visible = false;
                            //{

                            //    gdrDucoments.Rows[ii].Visible = true;
                            //}
                            //else
                            //{
                            //    gdrDucoments.Rows[ii].Visible = false;
                            //}
                        }
                    }

                }
            }
        }
        #endregion
        #region Check all Documents
        private void chkAddDoc_Click(object sender, EventArgs e)
        {
            if (this.gdrDucoments.Rows.Count > 0)
            {
                if (this.chkAddDoc.Checked)
                {
                    foreach (DataGridViewRow row in gdrDucoments.Rows)
                    {

                        row.Cells["CheckList"].Value = 1;

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in gdrDucoments.Rows)
                    {

                        row.Cells["CheckList"].Value = 0;

                    }
                }
            }
           // chkAddDoc.Checked = false;
        }
        #endregion

        #region Checked Dell all Documents
        private void chkDelDoc_Click(object sender, EventArgs e)
        {
            if (this.grdDucomentsUpdate.Rows.Count > 0)
            {
                if (this.chkDelDoc.Checked)
                {
                    foreach (DataGridViewRow row in grdDucomentsUpdate.Rows)
                    {

                        row.Cells["DeleteDucoment"].Value = 1;

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in grdDucomentsUpdate.Rows)
                    {

                        row.Cells["DeleteDucoment"].Value = 0;

                    }
                }
            }
            //chkDelDoc.Checked = false;
        }
        #endregion
    }
}
