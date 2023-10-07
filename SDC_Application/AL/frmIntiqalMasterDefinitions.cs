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
using SDC_Application.LanguageManager;


namespace SDC_Application.AL
{
    public partial class frmIntiqalMasterDefinitions : Form
    {
        MasterDefinition MasDef = new MasterDefinition();
        Taxes tax = new Taxes();
        Intiqal inti = new Intiqal();


        frmToken objtoken = new frmToken();
        MasterDefinition Master = new MasterDefinition();
        datagrid_controls datacontrols = new datagrid_controls();
        AutoComplete auto = new AutoComplete();
        LanguageConverter lang = new LanguageConverter();

        public string TehsilId = "19"; //{ get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public frmIntiqalMasterDefinitions()
        {
            InitializeComponent();
        }

        private void frmIntiqalMasterDefinitions_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            txtTaxID.Text = "-1";
            FillComboByCatagorylist();
            FillGridByTaxlist();
            FillgridBycatagorieslist();
            FillgridByTaxNotifications();
            FillcomboboxBySDCunitList();
            //FillgridByTaxNotificatDetails();
            FillcomboboxBytaxesList();
            FillcomboboxByTaxNotifications();
            txtTaxNotificationDetailIdHide.Text = "-1";
          //  TehsilId = (UsersManagments._Tehsilid != null && UsersManagments._Tehsilid > 0) ? UsersManagments._Tehsilid.ToString() : "NULL";
            UserId = (UsersManagments.UserId != null && UsersManagments.UserId > 0) ? UsersManagments.UserId.ToString() : "NULL";
            UserName = (UsersManagments.UserName != null) ? UsersManagments.UserName.ToString() : "NULL";

            auto.FillCombo("Proc_Get_Intiqal_TypeCategory_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() , cmbIntiqalTypeCat, "IntaIntiqalTypeCategory", "IntiqalTypeCategoryId");
            auto.FillCombo("Proc_Get_Intiqal_PlotTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() , txtUrduPlot, "PlotType_Urdu", "PlotTypeId");
            auto.FillCombo("Proc_Get_SDC_PaymentTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() , cboPaymentType, "PaymentType_Urdu", "PaymentTypeId");
            Call_grdIntiqalType();  //Call for filling Intiqal Types list from DB
            Call_grdDucomentList(); //Call for filling Ducoments list from DB
            Call_grdPlotType_Constructions();     //PlotType Filling contruction from DB
            Call_TypeofPlots();    // //PlotType Filling from DB
        }
        //--------------------------------------------------------------------Intiqal Types
        #region Save IntiqalType s.afzal
        private void btnIntiqalTypeSaved_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbIntiqalTypeCat.SelectedIndex != 0 && txtIntiqalTypeNameUrdu.Text.Trim() != "")
                {
                    string TypeId = txthidenIntiqalTypeid.Text.ToString();

                    string TypeName = txtIntiqalTypeNameUrdu.Text.Trim().ToString();
                    string InitiqalCatagory = this.cmbIntiqalTypeCat.SelectedValue.ToString();
                    string dt = Master.SaveIntiqalTypes(TypeId,TehsilId, TypeName, InitiqalCatagory, UserId, UserName, UserId, UserName);
                    txthidenIntiqalTypeid.Text = dt;
                    Call_grdIntiqalType();
                }
                else
                {
                    MessageBox.Show("انتقال کا انتخاب کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtIntiqalTypeNameUrdu.Text == "")
                    {
                        txtIntiqalTypeNameUrdu.Focus();
                    }
                    if (cmbIntiqalTypeCat.SelectedIndex == 0)
                    {
                        cmbIntiqalTypeCat.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region IntiqalType GirdSetting S.afzal
       
        public void Call_grdIntiqalType()
        {
            DataTable dtt = new DataTable();
            dtt = Master.GetIntiqalTypesList();
            DataTable outputTable = dtt.Clone();
            
            for (int i = dtt.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(dtt.Rows[i]);
            }
            grdIntiqalType.DataSource = outputTable;

            grdIntiqalType.Columns["chk"].DisplayIndex = 0;
            grdIntiqalType.Columns["IntaIntiqalTypeCategory"].DisplayIndex = 1;
            grdIntiqalType.Columns["IntiqalType"].DisplayIndex = 2;
            grdIntiqalType.Columns["insertdate"].DisplayIndex = 3;
            grdIntiqalType.Columns["Delete"].DisplayIndex = 4;

            grdIntiqalType.Columns["IntaIntiqalTypeCategory"].HeaderText = "انتقال کی قسم";
            grdIntiqalType.Columns["IntiqalType"].HeaderText = "انتقال ";
            grdIntiqalType.Columns["insertdate"].HeaderText = "تاریخ";

            grdIntiqalType.Columns["IntiqalTypeId"].Visible = false;
            grdIntiqalType.Columns["Delete"].Visible = false;
            grdIntiqalType.Columns["TehsilId"].Visible = false;
            grdIntiqalType.Columns["IntiqalTypeCategoryId"].Visible = false;
            grdIntiqalType.Columns["UpdateDate"].Visible = false;

            datacontrols.gridControls(grdIntiqalType);
            datacontrols.colorrbackgrid(grdIntiqalType);
        }
        #endregion
        #region Inteqal GRid Events Clicks
        private void grdIntiqalType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView g = sender as DataGridView;
                if (e.ColumnIndex == this.grdIntiqalType.CurrentRow.Cells["chk"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (grdIntiqalType.SelectedRows.Count > 0)
                        {

                            if (row.Selected)
                            {

                                row.Cells["chk"].Value = 1;
                                cmbIntiqalTypeCat.Text = grdIntiqalType.CurrentRow.Cells["IntaIntiqalTypeCategory"].Value.ToString();
                                txtIntiqalTypeNameUrdu.Text = grdIntiqalType.CurrentRow.Cells["IntiqalType"].Value.ToString();
                                txthidenIntiqalTypeid.Text = grdIntiqalType.CurrentRow.Cells["IntiqalTypeId"].Value.ToString();


                            }
                            else
                            {
                                row.Cells["chk"].Value = 0;

                            }
                        }
                    }
                }
                if (e.ColumnIndex == grdIntiqalType.CurrentRow.Cells["Delete"].ColumnIndex)
                {
                    try
                    {
                        if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string Intiqaltypeid = grdIntiqalType.CurrentRow.Cells["IntiqalTypeId"].Value.ToString();
                            Master.WEB_SP_DELETE_IntiqalType(Intiqaltypeid);
                            Call_grdIntiqalType();
                            btnNewToken_Click(sender, e);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        #endregion
        #region Clear Intiqal Type
        private void btnNewToken_Click(object sender, EventArgs e)
        {
            txtIntiqalTypeNameUrdu.Text = "";
            cmbIntiqalTypeCat.SelectedIndex = 0;
            txthidenIntiqalTypeid.Text = "-1";
            if (txtIntiqalTypeNameUrdu.Text == "")
            {
                objtoken.errorChar.SetError(txtIntiqalTypeNameUrdu, "");
                objtoken.errorNumeric.SetError(txtIntiqalTypeNameUrdu, "");
            }
        }
        #endregion
        #region Keypress for IntiqalType

        private void txtIntiqalTypeNameUrdu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtIntiqalTypeNameUrdu, objtoken.errorChar, objtoken.errorNumeric, check);

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

            char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                btnIntiqalTypeSaved_Click(sender, e);
                           }
        }


        private void txtIntiqalTypeNameUrdu_Leave(object sender, EventArgs e)
        {
            if (txtIntiqalTypeNameUrdu.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtIntiqalTypeNameUrdu, "Ok");
            }
            if (txtIntiqalTypeNameUrdu.Text == string.Empty)
            {
                objtoken.errorChar.SetError(txtIntiqalTypeNameUrdu, "Error");
            }
            else
            {
                objtoken.errorChar.SetError(txtIntiqalTypeNameUrdu, "Error");
            }
        }
        #endregion
        //-------------------------------------------------------------- Plot Counstructoin Types
        #region Grid Plot Counstructoin Settings
        public void Call_grdPlotType_Constructions()
        {
            DataTable plotTable = new DataTable();
            plotTable = this.Master.GetIntiqalPlotConstructionTypesList();
            DataTable outputTable = plotTable.Clone();

            for (int i = plotTable.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(plotTable.Rows[i]);
            }
            grdPlotType.DataSource = outputTable;
            grdPlotType.Columns["PlotConstructionTypeId"].Visible = false;
            grdPlotType.Columns["UpdateDate"].Visible = false;
            grdPlotType.Columns["DeletePlot"].Visible = false;
            grdPlotType.Columns["plottypeid"].Visible = false;

            grdPlotType.Columns["chkPlot"].DisplayIndex = 0;
            grdPlotType.Columns["PlotConstructionType_Urdu"].DisplayIndex = 1;
            grdPlotType.Columns["PlotConstructionType_Eng"].DisplayIndex = 2;
            grdPlotType.Columns["DeletePlot"].DisplayIndex = 4;
            grdPlotType.Columns["InsertDate"].DisplayIndex = 3;



            grdPlotType.Columns["PlotConstructionType_Urdu"].HeaderText = "نام اردو";
            grdPlotType.Columns["PlotConstructionType_Eng"].HeaderText = "نام انگریزی";
            grdPlotType.Columns["InsertDate"].HeaderText = "تاریخ";

            datacontrols.gridControls(grdPlotType);
            datacontrols.colorrbackgrid(grdPlotType);
        }
        #endregion
        #region Grid Plot Counstructoin ClickEvents
        private void grdPlotType_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridView g = sender as DataGridView;
                if (e.ColumnIndex == this.grdPlotType.CurrentRow.Cells["chkPlot"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (grdPlotType.SelectedRows.Count > 0)
                        {

                            if (row.Selected)
                            {

                                row.Cells["chkPlot"].Value = 1;
                                this.txtEngPlot.Text = grdPlotType.CurrentRow.Cells["PlotConstructionType_Eng"].Value.ToString();
                                this.txtUrdPlot.Text = grdPlotType.CurrentRow.Cells["PlotConstructionType_Urdu"].Value.ToString();
                                this.txtHiddenPlotConsId.Text = grdPlotType.CurrentRow.Cells["PlotConstructionTypeId"].Value.ToString();


                            }
                            else
                            {
                                row.Cells["chkPlot"].Value = 0;

                            }
                        }
                    }
                }
                if (e.ColumnIndex == grdPlotType.CurrentRow.Cells["DeletePlot"].ColumnIndex)
                {
                    try
                    {
                        if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string PlotConstructionTypeId = this.grdPlotType.CurrentRow.Cells["PlotConstructionTypeId"].Value.ToString();
                            Master.DELETEPlotConstructionType(PlotConstructionTypeId);
                            Call_grdPlotType_Constructions();
                            btnPlotClear_Click(sender, e);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        #endregion
        #region Save Plot Constructoin Counstructoin Types
        private void btnPlotSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUrduPlot.Text.Trim() != "" && txtEngPlot.Text.Trim() != "")
                {
                    string ConstructionTypeId = this.txtHiddenPlotConsId.Text.ToString();

                    string ConstructionTypeNameUrdu = this.txtUrdPlot.Text.ToString();
                    string PlotTypeId = this.txtUrduPlot.SelectedValue.ToString();
                    string ConstructionTypeNameEng = this.txtEngPlot.Text.Trim().ToString();
                    string dt = Master.SaveIntiqalPlotConstructionTypes(ConstructionTypeId, UsersManagments._Tehsilid.ToString(), PlotTypeId,ConstructionTypeNameUrdu, ConstructionTypeNameEng, UserId, UserName, UserId, UserName);
                    this.txtHiddenPlotConsId.Text = dt;
                    Call_grdPlotType_Constructions();
                }
                else
                {
                    MessageBox.Show("تعمیر نام اردو/انگریزی داخل کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtUrdPlot.Text == "")
                    {
                        txtUrdPlot.Focus();
                        objtoken.errorChar.SetError(txtUrdPlot, "Blank");
                    }
                    if (txtEngPlot.Text == "")
                    {
                        txtEngPlot.Focus();

                        objtoken.errorChar.SetError(txtEngPlot, "Blank");
                    }
                    if (txtUrdPlot.Text == "" && txtEngPlot.Text == "")
                    {
                        txtUrdPlot.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Keypress Events Plot contructionType
        private void txtUrdPlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtUrdPlot, objtoken.errorChar, objtoken.errorNumeric, check);
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

        private void txtEngPlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int check = 1;
            //Validations.errorprovider(e, txtEngPlot, objtoken.errorChar, objtoken.errorNumeric, check);
            //char c = e.KeyChar;
            //if (c == e.KeyChar)
            //{
            //    btnPlotSave_Click(sender, e);
            //}
        }
        #endregion
        #region Clear Plot Construction Type
        private void btnPlotClear_Click(object sender, EventArgs e)
        {
            this.txtEngPlot.Text = "";
            this.txtUrdPlot.Text = "";
            this.txtHiddenPlotConsId.Text = "-1";
            if (txtEngPlot.Text == "")
            {
                objtoken.errorChar.SetError(txtEngPlot, "");
                objtoken.errorNumeric.SetError(txtEngPlot, "");
            }
            if (txtUrdPlot.Text == "")
            {
                objtoken.errorChar.SetError(txtUrdPlot, "");
                objtoken.errorNumeric.SetError(txtUrdPlot, "");
            }
        }
        #endregion
        //------------------------------------------------------------------ Ducoments
        #region Keypress events for Documents list
        private void txtDocUrdu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtDocUrdu, objtoken.errorChar, objtoken.errorNumeric, check);
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

        private void txtDocEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtDocEng, objtoken.errorChar, objtoken.errorNumeric, check);
            char c = e.KeyChar;
            if (c == (char)13)
            {
                btnDocSave_Click(sender, e);
            }

            
        }



        private void txtDocUrdu_Leave(object sender, EventArgs e)
        {
            if (txtDocUrdu.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtDocUrdu, "Ok");
            }
            if (txtDocUrdu.Text == string.Empty)
            {
                objtoken.errorChar.SetError(txtDocUrdu, "Error");
            }
            else
            {
                objtoken.errorChar.SetError(txtDocUrdu, "Error");
            }
        }

        private void txtDocEng_Leave(object sender, EventArgs e)
        {
            if (txtDocEng.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtDocEng, "Ok");
            }
            if (txtIntiqalTypeNameUrdu.Text == string.Empty)
            {
                objtoken.errorChar.SetError(txtDocEng, "Error");
            }
            else
            {
                objtoken.errorChar.SetError(txtDocEng, "Error");
            }
        }
        #endregion
        #region Save Documents
        private void btnDocSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocUrdu.Text.Trim() != "" && txtDocEng.Text.Trim() != "")
                {

                    string UrduName = txtDocUrdu.Text.Trim();
                    string EnglishName = txtDocEng.Text.Trim();
                    string docid = txthiddendocid.Text;
                    string last = Master.SaveIntiqalDocumentsList(docid, TehsilId, UrduName, EnglishName, UserId, UserName, UserId, UserName);

                    if (last != null)
                    {
                        txthiddendocid.Text = last;
                        Call_grdDucomentList();
                    }
                }
                else
                {
                    MessageBox.Show("اردو/انگریزی نام داخل کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtDocUrdu.Text == "")
                    {
                        txtDocUrdu.Focus();
                        objtoken.errorChar.SetError(txtDocUrdu, "Error");
                    }
                    if (txtDocEng.Text == "")
                    {
                        txtDocEng.Focus();
                        objtoken.errorChar.SetError(txtDocEng, "Error");
                    }
                    if (txtDocUrdu.Text == "" && txtDocEng.Text == "")
                    {
                        txtDocUrdu.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Grid Ducoments Setting
        public void Call_grdDucomentList()
        {
            DataTable docTable = new DataTable();
            docTable = this.Master.GetIntiqalDocumentsList();
            DataTable outputTable = docTable.Clone();

            for (int i = docTable.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(docTable.Rows[i]);
            }
            grdDocments.DataSource = outputTable;
            grdDocments.Columns["IntiqalDocId"].Visible = false;
            grdDocments.Columns["UpdateDate"].Visible = false;
            grdDocments.Columns["DeleteDoc"].Visible = false;

            grdDocments.Columns["chkdoc"].DisplayIndex = 0;
            grdDocments.Columns["IntiqalDocName_Urdu"].DisplayIndex = 1;
            grdDocments.Columns["IntiqalDocName_Eng"].DisplayIndex = 2;
            grdDocments.Columns["insertdate"].DisplayIndex = 3;
            grdDocments.Columns["DeleteDoc"].DisplayIndex = 4;

            grdDocments.Columns["IntiqalDocName_Urdu"].HeaderText = "نام";
            grdDocments.Columns["IntiqalDocName_Eng"].HeaderText = "انگریزی نام";
            grdDocments.Columns["insertdate"].HeaderText = "تاریخ";

            datacontrols.gridControls(grdDocments);
            datacontrols.colorrbackgrid(grdDocments);
        }
        #endregion
        #region grdDocments Click Events for Ducoments
        private void grdDocments_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridView g = sender as DataGridView;
                if (e.ColumnIndex == this.grdDocments.CurrentRow.Cells["chkDoc"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (grdDocments.SelectedRows.Count > 0)
                        {

                            if (row.Selected)
                            {

                                row.Cells["chkDoc"].Value = 1;
                                this.txtDocEng.Text = grdDocments.CurrentRow.Cells["IntiqalDocName_Eng"].Value.ToString();
                                this.txtDocUrdu.Text = grdDocments.CurrentRow.Cells["IntiqalDocName_Urdu"].Value.ToString();
                                this.txthiddendocid.Text = grdDocments.CurrentRow.Cells["IntiqalDocId"].Value.ToString();


                            }
                            else
                            {
                                row.Cells["chkdoc"].Value = 0;

                            }
                        }
                    }
                }
                if (e.ColumnIndex == grdDocments.CurrentRow.Cells["DeleteDoc"].ColumnIndex)
                {
                    try
                    {
                        if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string IntiqalDocId = this.grdDocments.CurrentRow.Cells["IntiqalDocId"].Value.ToString();
                            Master.WEB_SP_DELETE_DocmentID(IntiqalDocId);
                            Call_grdDucomentList();
                            btnClearDoc_Click(sender, e);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        #endregion
        #region Clear Documents
        private void btnClearDoc_Click(object sender, EventArgs e)
        {
            this.txtDocUrdu.Text = "";
            this.txtDocEng.Text = "";
            this.txthiddendocid.Text = "-1";
            if (txtDocUrdu.Text == "")
            {
                objtoken.errorChar.SetError(txtDocUrdu, "");
                objtoken.errorNumeric.SetError(txtDocUrdu, "");
            }
            if (txtDocEng.Text == "")
            {
                objtoken.errorChar.SetError(txtDocEng, "");
                objtoken.errorNumeric.SetError(txtDocEng, "");
            }
        }
        #endregion
        #region Leave Texts Documents
        private void txtDocUrdu_Leave_1(object sender, EventArgs e)
        {
            if (txtDocUrdu.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtDocUrdu, "OK");
            }
            if (this.txtDocEng.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtDocEng, "OK");
            }

        }
        private void txtEngPlot_Leave(object sender, EventArgs e)
        {
            if (this.txtUrdPlot.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtUrdPlot, "OK");
            }
            if (this.txtEngPlot.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtEngPlot, "OK");
            }
        }
        #endregion


        //---------------------------------------------------------------------- Plot Types
        #region Grid Plot Type Setting
        public void Call_TypeofPlots()
        {
            DataTable plotTable = new DataTable();
            plotTable = this.Master.GetIntiqalPlotTypesList();
            DataTable outputTable = plotTable.Clone();

            for (int i = plotTable.Rows.Count - 1; i >= 0; i--)
            {
                outputTable.ImportRow(plotTable.Rows[i]);
            }
            this.grdPlot_Type.DataSource = outputTable;
            grdPlot_Type.Columns["PlotTypeId"].Visible = false;
            grdPlot_Type.Columns["UpdateDate"].Visible = false;
            grdPlot_Type.Columns["DeleteTypePlot"].Visible = false;


            grdPlot_Type.Columns["chkPlotType"].DisplayIndex = 0;
            grdPlot_Type.Columns["PlotType_Urdu"].DisplayIndex = 1;
            grdPlot_Type.Columns["PlotType_Eng"].DisplayIndex = 2;
            grdPlot_Type.Columns["PlotType_Eng"].Width = 280;
            grdPlot_Type.Columns["DeleteTypePlot"].DisplayIndex = 4;
            grdPlot_Type.Columns["insertdate"].DisplayIndex = 3;

            grdPlot_Type.Columns["PlotType_Urdu"].HeaderText = "قسم(اردو)";
            grdPlot_Type.Columns["PlotType_Eng"].HeaderText = "قسم(انگریزی)";
            grdPlot_Type.Columns["insertdate"].HeaderText = "تاریخ";

            datacontrols.gridControls(grdPlot_Type);
            datacontrols.colorrbackgrid(grdPlot_Type);
        }
        #endregion
        #region PlotType GridClicks events
        private void grdPlot_Type_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView g = sender as DataGridView;
                if (e.ColumnIndex == this.grdPlot_Type.CurrentRow.Cells["chkPlotType"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (grdPlot_Type.SelectedRows.Count > 0)
                        {

                            if (row.Selected)
                            {

                                row.Cells["chkPlotType"].Value = 1;
                                this.txtPlotType_Urdu.Text = grdPlot_Type.CurrentRow.Cells["PlotType_Urdu"].Value.ToString();
                                this.txtPlotType_Eng.Text = grdPlot_Type.CurrentRow.Cells["PlotType_Eng"].Value.ToString();
                                this.txtHiddenPlot_type.Text = grdPlot_Type.CurrentRow.Cells["PlotTypeId"].Value.ToString();


                            }
                            else
                            {
                                row.Cells["chkPlotType"].Value = 0;

                            }
                        }
                    }
                }
                if (e.ColumnIndex == grdPlot_Type.CurrentRow.Cells["DeleteTypePlot"].ColumnIndex)
                {
                    try
                    {
                        if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string PlotTypeId = this.grdPlot_Type.CurrentRow.Cells["PlotTypeId"].Value.ToString();
                            Master.DELETE_PlotType(PlotTypeId);
                            Call_TypeofPlots();
                            clear_Plot_Type();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        #endregion
        #region Save Plot Type
        private void btnSave_PlotType_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPlotType_Urdu.Text.Trim() != "" && this.txtPlotType_Eng.Text.Trim() != "")
                {

                    string UrduName = txtPlotType_Urdu.Text.Trim();
                    string EnglishName = txtPlotType_Eng.Text.Trim();
                    string plotid = this.txtHiddenPlot_type.Text;
                    string last = Master.SaveIntiqalPlotTypes(plotid, TehsilId, UrduName, EnglishName,  UserId, UserName, UserId, UserName);

                    if (last != null)
                    {
                        this.txtHiddenPlot_type.Text = last;
                        Call_TypeofPlots();
                    }
                }
                else
                {
                    MessageBox.Show("اردو/انگریزی نام داخل کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtPlotType_Urdu.Text.Trim() == "")
                    {
                        txtPlotType_Urdu.Focus();
                        objtoken.errorChar.SetError(txtPlotType_Urdu, "Error");
                    }
                    if (txtPlotType_Eng.Text.Trim() == "")
                    {
                        txtPlotType_Eng.Focus();
                        objtoken.errorChar.SetError(txtPlotType_Eng, "Error");
                    }
                    if (txtPlotType_Urdu.Text == "" && txtPlotType_Eng.Text == "")
                    {
                        txtPlotType_Urdu.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Keypress Events of Plot Types
        private void txtPlotType_Eng_Leave(object sender, EventArgs e)
        {
            if (txtPlotType_Eng.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtPlotType_Eng, "OK");
            }
            if (this.txtPlotType_Urdu.TextLength > 0)
            {
                objtoken.errorNumeric.SetError(txtPlotType_Urdu, "OK");
            }

        }

        private void txtPlotType_Urdu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtPlotType_Urdu, objtoken.errorChar, objtoken.errorNumeric, check);
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

        private void txtPlotType_Eng_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtPlotType_Eng, objtoken.errorChar, objtoken.errorNumeric, check);
            char c = e.KeyChar;
            if (c == (char)13)
            { 
                btnSave_PlotType_Click(sender,e);
            }
        }
        #endregion
        #region Clear Plot Types
        private void btn_Clear_Plot_Click(object sender, EventArgs e)
        {
            clear_Plot_Type();
        }
        public void clear_Plot_Type()
        {
            this.txtPlotType_Eng.Text = "";
            this.txtPlotType_Urdu.Text = "";
            this.txtHiddenPlot_type.Text = "-1";
            if (txtPlotType_Eng.Text == "")
            {
                objtoken.errorChar.SetError(txtPlotType_Eng, "");
                objtoken.errorNumeric.SetError(txtPlotType_Eng, "");
            }
            if (txtPlotType_Urdu.Text == "")
            {
                objtoken.errorChar.SetError(txtPlotType_Urdu, "");
                objtoken.errorNumeric.SetError(txtPlotType_Urdu, "");
            }
        }
        #endregion



        private void MasterTabControl_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= grdDocments.Rows.Count - 1; i++)
            {
                DataGridViewRow row = grdDocments.Rows[i];
                row.Height = 30;
            }
            for (int ki = 0; ki <= this.grdPlot_Type.Rows.Count - 1; ki++)
            {
                DataGridViewRow row = grdPlot_Type.Rows[ki];
                row.Height = 30;
            }
            for (int j = 0; j <= this.grdPlotType.Rows.Count - 1; j++)
            {
                DataGridViewRow row = grdPlotType.Rows[j];
                row.Height = 30;
            }

        }



        #region Page Tax list Methods and Events
        public void FillGridByTaxlist()
        {
            DataTable dt = new DataTable();
            dt = tax.GetIntiqalTaxlist();
            gridTaxlist.DataSource = dt;
            gridTaxlist.Columns["TaxName_Urdu"].HeaderText = "ٹیکس نام (اردو)";
            gridTaxlist.Columns["TaxName_Eng"].HeaderText = "ٹیکس نام (انگریزی)";
            gridTaxlist.Columns["TaxCategoryName_Urdu"].HeaderText = "ٹیکس قسم";
            gridTaxlist.Columns["insertdate"].Visible = false;
            gridTaxlist.Columns["UpdateDate"].Visible = false;
            gridTaxlist.Columns["TaxCategoryId"].Visible = false;


        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //string userId = (UsersManagments.UserId != null && UsersManagments.UserId > 0) ? UsersManagments.UserId.ToString() : "NULL";
                //string Username = (UsersManagments.UserName != null && UsersManagments.UserName != "") ? UsersManagments.UserName.ToString() : "NULL";
                string TaxeId = txtTaxID.Text;
                // string TehsilId=
                string TaxCategoryId = cboCcatagoriID.SelectedValue.ToString();
                string TaxName_Urdu = txtTaxNameUrdu.Text;
                string Taxname_English = txtTaxNameEng.Text;
                // string TehsilId = "19";
                if (txtTaxNameEng.Text.Trim() != "" && txtTaxNameUrdu.Text.Trim() != "")
                {

                    string s = MasDef.SaveIntiqalTaxesList(TaxeId, UsersManagments._Tehsilid.ToString(), TaxCategoryId, TaxName_Urdu, Taxname_English, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                    FillGridByTaxlist();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTaxNameEng.Text = "";
            txtTaxNameUrdu.Text = "";
            cboCcatagoriID.SelectedValue = 0;
            txtTaxID.Text = "-1";
        }

        public void FillComboByCatagorylist()
        {
            DataTable dt = new DataTable();
            dt = MasDef.GetntiqalTaxCategoriesList();
            DataRow TypeRow = dt.NewRow();
            TypeRow["TaxeCategoryId"] = "0";
            TypeRow["TaxCategoryName_Urdu"] = " - ٹیکس قسم  - ";
            dt.Rows.InsertAt(TypeRow, 0);


            cboCcatagoriID.DataSource = dt;
            cboCcatagoriID.DisplayMember = dt.Columns["TaxCategoryName_Urdu"].ToString();
            cboCcatagoriID.ValueMember = dt.Columns["TaxeCategoryId"].ToString();
            cboCcatagoriID.SelectedValue = 0;

        }
        private void txtTaxNameUrdu_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Page Tax Catagory list methods and Events
        public void FillgridBycatagorieslist()
        {
            DataTable dt = new DataTable();
            dt = MasDef.GetntiqalTaxCategoriesList();
            gridcatagorieslist.DataSource = dt;
            gridcatagorieslist.Columns["TaxeCategoryId"].Visible = false;
            gridcatagorieslist.Columns["TaxCategoryName_Urdu"].HeaderText = "ٹیکس قسم (اردو)";
            gridcatagorieslist.Columns["TaxCategoryName_Eng"].HeaderText = "ٹیکس قسم (انگریزی)";
            gridcatagorieslist.Columns["insertdate"].Visible = false;
            gridcatagorieslist.Columns["UpdateDate"].Visible = false;

        }

        private void txtTaxcatagoriesNameUrdu_KeyPress(object sender, KeyPressEventArgs e)
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


        private void btnTaxcatagSave_Click(object sender, EventArgs e)
        {
            try
            {

            
            //string Tehsilid = UsersManagments._Tehsilid.ToString();
            //string userId = (UsersManagments.UserId != null && UsersManagments.UserId > 0) ? UsersManagments.UserId.ToString() : "NULL";
            //string Username = (UsersManagments.UserName != null && UsersManagments.UserName != "") ? UsersManagments.UserName.ToString() : "NULL";
           // string TaxcatagoryID = txtTaxCatagoriesID.Text;
            string TaxcatagoryNameUrdu = txtTaxcatagoriesNameUrdu.Text;
            string TaxcatagoryNameEng = txtTaxcatagoriesnameEnglish.Text;
            string TaxcatagoryId = txtTaxCatagoriesID.Text;

            string lastid = MasDef.SaveIntiqalTaxCategories(TaxcatagoryId, TehsilId, TaxcatagoryNameUrdu, TaxcatagoryNameEng, UserId, UserName, UserId, UserName);
            FillgridBycatagorieslist();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewTaxcatag_Click(object sender, EventArgs e)
        {
            txtTaxcatagoriesNameUrdu.Clear();
            txtTaxcatagoriesnameEnglish.Clear();
            txtTaxCatagoriesID.Text = "-1";
        }
        #endregion

        #region  Page Tax Notification Methods and Events



        private void btnSaveTaxNotif_Click(object sender, EventArgs e)
        {
            try
            {

           
            bool TaxNotificatActive;
            if (chkTaxNotificationActive.Checked)
            {
                TaxNotificatActive = true;
            }
            else
            {

                TaxNotificatActive = false;
            }       
            string TaxNotificatDate = dtpTaxNotifdate.Value.ToString("dd MMM yyyy");
            string TaxNotificatExpDate = dtpTaxNotifExpirdate.Value.ToString("dd MMM yyyy");
            string TaxNotificatActiveDate = dtpTaxNotifActivedate.Value.ToString("dd MMM yyyy");
            string TaxNotificatNo = txtTaxNotificationNo.Text;
            string TaxNotificatRemarks = txtTaxNotificationRemarks.Text;
            string TaxNotificatID = txtTaxNotificationidhide.Text;
            string lastid = MasDef.SaveIntiqalTaxNotifications(TaxNotificatID, TaxNotificatNo, TehsilId, TaxNotificatDate, TaxNotificatActiveDate, TaxNotificatExpDate, TaxNotificatRemarks, TaxNotificatActive.ToString(), UserId, UserName, UserId, UserName);
            FillgridByTaxNotifications();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void FillgridByTaxNotifications()
        {
            DataTable dt = new DataTable();
            dt = tax.GetIntiqalTaxNotification();
            gridTaxNotifications.DataSource = dt;
            gridTaxNotifications.Columns["TaxNotificationId"].Visible = false;
            gridTaxNotifications.Columns["TaxNotificationNo"].HeaderText = "ٹیکس نوٹیفکیشن نمبر";
            gridTaxNotifications.Columns["TehsilId"].Visible = false;
            gridTaxNotifications.Columns["TaxNotificationDate"].HeaderText = "ٹیکس نوٹیفکیشن تاریخ";
            gridTaxNotifications.Columns["TaxNotificationActiveDate"].HeaderText = "ٹیکس نوٹیفکیشن فعال تاریخ";
            gridTaxNotifications.Columns["TaxNotificationExpiryDate"].HeaderText = "ٹیکس نوٹیفکیشن آخری تاریخ";
            gridTaxNotifications.Columns["TaxNotificationActive"].HeaderText = "ٹیکس نوٹیفکیشن فعال";
            gridTaxNotifications.Columns["TaxNotificationRemarks"].HeaderText = "ٹیکس نوٹیفکیشن ریمارکس";

        }

        #endregion



        #region Page Tax notification Details Methods and events

        public void FillcomboboxBySDCunitList()
        {
            DataTable dt = new DataTable();
            dt = MasDef.GetSDCServiceCostUnitsList();
            DataRow TypeRow = dt.NewRow();
            TypeRow["SDCUnitId"] = "0";
            TypeRow["SDCUnitName_Urdu"] = " -  انتخاب کریں - ";
            dt.Rows.InsertAt(TypeRow, 0);

            cboSDCunitId.DataSource = dt;

            cboSDCunitId.DisplayMember = dt.Columns["SDCUnitName_Urdu"].ToString();
            cboSDCunitId.ValueMember = dt.Columns["SDCUnitId"].ToString();
            cboSDCunitId.SelectedValue = 0;


        }
        public void FillcomboboxByTaxNotifications()
        {
            DataTable dt = new DataTable();
            dt = tax.GetIntiqalTaxNotification();
            DataRow TypeRow = dt.NewRow();
            TypeRow["TaxNotificationId"] = "0";
            TypeRow["TaxNotificationNo"] = " -  انتخاب کریں - ";
            dt.Rows.InsertAt(TypeRow, 0);

            cboTaxNotifications.DataSource = dt;

            cboTaxNotifications.DisplayMember = dt.Columns["TaxNotificationNo"].ToString();
            cboTaxNotifications.ValueMember = dt.Columns["TaxNotificationId"].ToString();
            cboTaxNotifications.SelectedValue = 0;


        }
        public void FillcomboboxBytaxesList()
        {
            DataTable dt = new DataTable();
            dt = tax.GetIntiqalTaxlist();
            DataRow TypeRow = dt.NewRow();
            TypeRow["TaxeId"] = "0";
            TypeRow["TaxName_Urdu"] = " -  انتخاب کریں - ";
            dt.Rows.InsertAt(TypeRow, 0);

            cboTaxlist.DataSource = dt;

            cboTaxlist.DisplayMember = dt.Columns["TaxName_Urdu"].ToString();
            cboTaxlist.ValueMember = dt.Columns["TaxeId"].ToString();
            cboTaxlist.SelectedValue = 0;


        }
        public void FillgridByTaxNotificatDetails(string NotificationId)
        {
            //string Tehsilid = "19";
            DataTable dt = new DataTable();
            dt = tax.GetIntiqalTaxNotificationDetailsForNotificationUpdation(NotificationId);
            gridTaxNotificcatDetails.DataSource = dt;
            gridTaxNotificcatDetails.Columns["TaxNotificationId"].Visible = false;
            gridTaxNotificcatDetails.Columns["TaxNotificationNo"].HeaderText = "ٹیکس نوٹیفکیشن نمبر";
            gridTaxNotificcatDetails.Columns["TehsilId"].Visible = false;
            gridTaxNotificcatDetails.Columns["TaxNotificationDetailId"].Visible = false;
            gridTaxNotificcatDetails.Columns["TaxRate"].HeaderText = "ٹیکس ریٹ";
            gridTaxNotificcatDetails.Columns["TaxId"].Visible = false;
            gridTaxNotificcatDetails.Columns["TaxName_Urdu"].HeaderText = "ٹیکس نام (اردو)";
            gridTaxNotificcatDetails.Columns["SDCUnitId"].Visible = false;
            gridTaxNotificcatDetails.Columns["SDCUnitName_Urdu"].HeaderText = "اکائی نام";
            gridTaxNotificcatDetails.Columns["Paymenttypeid"].Visible = false;
            gridTaxNotificcatDetails.Columns["paymenttype_Urdu"].Visible = false;

        }

        private void gridTaxNotificcatDetails_SelectionChanged(object sender, EventArgs e)
        {
          
                foreach (DataGridViewRow row in gridTaxNotificcatDetails.Rows)
                {
                    if (row.Selected)
                    {
                        row.Cells["chk4"].Value = 1;
                        txtTaxNotificationDetailIdHide.Text = row.Cells["TaxNotificationDetailId"].Value.ToString();
                        // txtTaxDetailNotfRemarks.Text = row.Cells[""].Value.ToString();
                        txtTaxRate.Text = row.Cells["TaxRate"].Value.ToString();
                        //cboTaxlist.SelectedValue = row.Cells["TaxeId"].Value.ToString();
                        //cboSDCunitId.SelectedValue = row.Cells["SDCUnitId"].Value.ToString();
                        //cboTaxNotifications.SelectedValue = row.Cells["TaxNotificationId"].Value.ToString();


                    }
                    else
                    {
                        row.Cells["chk4"].Value = 0;
                    }

                }
           
        }
        private void btnSaveTaxNotifDetails_Click(object sender, EventArgs e)
        {
            try
            {
              
            string userId = (UsersManagments.UserId != null && UsersManagments.UserId > 0) ? UsersManagments.UserId.ToString() : "NULL";
            string Username = (UsersManagments.UserName != null && UsersManagments.UserName != "") ? UsersManagments.UserName.ToString() : "NULL";
            string TaxNotifDetailID = txtTaxNotificationDetailIdHide.Text;
            string TaxRate = txtTaxRate.Text;
            string TaxDetailRemarks = "";// txtTaxDetailNotfRemarks.Text;
            string TaxId = cboTaxlist.SelectedValue.ToString();
            string SDCUnitId = cboSDCunitId.SelectedValue.ToString();
            string TaxNotifId = cboTaxNotifications.SelectedValue.ToString();
            string SeqNo = Convert.ToString(gridTaxNotificcatDetails.Rows.Count + 1);
            string lastid = MasDef.SaveIntiqalTaxNotificationDetail(TaxNotifDetailID, TaxNotifId, SeqNo, TaxId,cboPaymentType.SelectedValue.ToString(), SDCUnitId,cboTaxRateType.Text, TaxRate, TaxDetailRemarks, userId, Username);
            FillgridByTaxNotificatDetails(TaxNotifId);
            this.btnNewTaxNotifdetail_Click(sender, e);
            MessageBox.Show("ٹیکس محفوظ ہو گیا۔");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnNewTaxNotifdetail_Click(object sender, EventArgs e)
        {
            txtTaxNotificationDetailIdHide.Text = "-1";
            //cboTaxNotifications.SelectedValue = 0;
            cboTaxlist.SelectedValue = 0;
            cboSDCunitId.SelectedValue = 0;
            txtTaxRate.Clear();
            cboPaymentType.SelectedValue = "-1";
            //txtTaxDetailNotfRemarks.Clear();
        }
        #endregion

        private void gridTaxlist_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridTaxlist.Rows)
            {

                if (row.Selected)
                {
                    row.Cells["chk1"].Value = 1;
                    txtTaxNameEng.Text = row.Cells["TaxName_Eng"].Value.ToString();
                    txtTaxNameUrdu.Text = row.Cells["TaxName_Urdu"].Value.ToString();
                    cboCcatagoriID.SelectedValue = row.Cells["TaxCategoryId"].Value.ToString();
                    txtTaxID.Text = row.Cells["TaxeId"].Value.ToString();

                }
                else
                {
                    row.Cells["chk1"].Value = 0;
                }
            }
        }

        private void gridcatagorieslist_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridcatagorieslist.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["chk2"].Value = 1;
                    txtTaxCatagoriesID.Text = row.Cells["TaxeCategoryId"].Value.ToString();
                    txtTaxcatagoriesnameEnglish.Text = row.Cells["TaxCategoryName_Eng"].Value.ToString();
                    txtTaxcatagoriesNameUrdu.Text = row.Cells["TaxCategoryName_Urdu"].Value.ToString();


                }
                else
                {

                    row.Cells["chk2"].Value = 0;
                }



            }
        }

        private void gridTaxNotifications_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridTaxNotifications.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["chk3"].Value = 1;
                    txtTaxNotificationidhide.Text = row.Cells["TaxNotificationId"].Value.ToString();
                    txtTaxNotificationNo.Text = row.Cells["TaxNotificationNo"].Value.ToString();
                    txtTaxNotificationRemarks.Text = row.Cells["TaxNotificationRemarks"].Value.ToString();
                    //dtpTaxNotifActivedate.Value = Convert.ToDateTime(row.Cells["TaxNotificationActiveDate"].Value.ToString());
                    DateTime taxNotifActiveDate = (DateTime)row.Cells["TaxNotificationActiveDate"].Value;
                    dtpTaxNotifActivedate.Value = taxNotifActiveDate;


                    dtpTaxNotifdate.Value = Convert.ToDateTime(row.Cells["TaxNotificationDate"].Value);
                    if (!row.Cells["TaxNotificationExpiryDate"].Value.ToString().Equals(string.Empty))
                    {
                        dtpTaxNotifExpirdate.Value = Convert.ToDateTime(row.Cells["TaxNotificationExpiryDate"].Value);
                    }
                    else
                    {
                        dtpTaxNotifExpirdate.Value = DateTime.Now;

                    }
                    //chkTaxNotificationActive.Checked = Convert.ToBoolean(row.Cells["TaxNotificationActive"].Value);

                }
                else
                {
                    row.Cells["chk3"].Value = 0;
                }
            }



















        }

        private void txtTaxNotificationRemarks_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnNewTaxNotif_Click(object sender, EventArgs e)
        {
            txtTaxNotificationidhide.Text = "-1";
            txtTaxNotificationNo.Clear();
            txtTaxNotificationRemarks.Clear();
            dtpTaxNotifActivedate.Value = DateTime.Now;
            dtpTaxNotifdate.Value = DateTime.Now;
            dtpTaxNotifExpirdate.Value = DateTime.Now;
        }

        private void txtTaxDetailNotfRemarks_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboCcatagoriID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                this.btnSave_Click(sender, e);
            }
        }

        private void txtTaxcatagoriesnameEnglish_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtTaxcatagoriesnameEnglish, objtoken.errorChar, objtoken.errorNumeric, check);
            char c = e.KeyChar;
            if(c==(char)13)
            {
                btnTaxcatagSave_Click(sender, e);
        }
        }

        private void dtpTaxNotifActivedate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSaveTaxNotif_Click(sender, e);
            }
        }

        private void cboSDCunitId_KeyPress(object sender, KeyPressEventArgs e)
        {
           // char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                btnSaveTaxNotifDetails_Click(sender, e);
            }
        }

        private void txtTaxNameEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 1;
            Validations.errorprovider(e, txtTaxNameEng, objtoken.errorChar, objtoken.errorNumeric, check);
        }

        private void MasterTabControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtTaxNotificationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int check = 2;
            Validations.errorprovider(e, txtTaxNotificationNo, objtoken.errorChar, objtoken.errorNumeric, check);
        }

        private void txtTaxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;


                          }
        }

        #region Dropdwon Tax Notifcation Selection Change Event

        private void cboTaxNotifications_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.FillgridByTaxNotificatDetails(cboTaxNotifications.SelectedValue.ToString());
        }

        #endregion
    }
}
