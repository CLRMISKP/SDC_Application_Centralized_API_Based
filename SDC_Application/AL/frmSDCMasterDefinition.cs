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
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmSDCMasterDefinition : Form
    {

        AutoComplete objauto = new AutoComplete();
        LanguageConverter lang = new LanguageConverter();

        public frmSDCMasterDefinition()
        {
            InitializeComponent();
        }
        MasterDefinition mstDef = new MasterDefinition();

        #region Form Load Event

        private void frmSDCMasterDefinition_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;


            txtTokenPurpooseId.Text = "-1";
            btnSaveTokPurpose.Enabled = false;
            btnDelTokPurpose.Enabled = false;
            FillTokenPurposeGrid();
           //-----------------------------------------

            txtPaymentTypeId.Text = "-1";
            btnSavePaymentType.Enabled = false;
            btnDelPaymentType.Enabled = false;
            FillPaymentTypeGrid();
            //-----------------------------------------

            txtServiceTypeId.Text = "-1";
            btnSaveServiceType.Enabled = false;
            btnDelServiceType.Enabled = false;
            FillServiceTypeGrid();

            //-----------------------------------------

            txtSrvCostUnitId.Text = "-1";
            btnSaveSrvCostUnit.Enabled = false;
            btnDelSrvCostUnit.Enabled = false;
            FillServiceCostUnitGrid();
            //-----------------------------------------
            txtServiceNameId.Text = "-1";
            btnSaveService.Enabled = false;
            btnDelService.Enabled = false;
            FillServicesGrid();
            objauto.FillCombo("Proc_Get_ServiceTypes_All " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",", cboServiceType, "ServiceTypeName_Urdu", "ServiceTypeId");

            //-----------------------------------------
            txtSrvCostNotId.Text = "-1";
            btnSaveCostNotification.Enabled = false;
            btnDelCostNotification.Enabled = false;
            FillServicesCostNotGrid();
            objauto.FillCombo("Proc_Get_SDC_Services_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",", cboNotSrvName, "SDCServiceName_Urdu", "SDCServiceId");
            objauto.FillCombo("Proc_Get_ServiceTypes_All " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",", cboNotSrvType, "ServiceTypeName_Urdu", "ServiceTypeId");
            objauto.FillCombo("Proc_Get_SDC_ServiceCostUnits_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",", cboNotSrvCostUnit, "SDCUnitName_Urdu", "SDCUnitId");
        }
        #endregion

        #region Key Press Event for Language


        public void LanguageCheckUrdu(object sender, KeyPressEventArgs e)
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

        public void CheckNumericField(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }

        }

        #endregion

        #region Code for Tab Token Purpose

        #region Record Insertion members

        private void SaveTokenPurpose()
        {

            if (txtTokenPurposeUrdu.Text != "" && txtTokenPurposeEng.Text != "")
            {
                try
                {
                    string TokenPurposeId = txtTokenPurpooseId.Text.ToString();
                    string TokenPurposeUrdu = txtTokenPurposeUrdu.Text.ToString();
                    string TokenPurposeEng = txtTokenPurposeEng.Text.ToString();
                    string tehsilId = UsersManagments._Tehsilid.ToString();
                    string UsrId = UsersManagments.UserId.ToString();
                    string UsrName = UsersManagments.UserName.ToString();
                    string LastId = mstDef.SaveSDCTokenPurpose(TokenPurposeId, TokenPurposeUrdu, TokenPurposeEng, tehsilId, UsrId, UsrName, UsrId, UsrName);
                    txtTokenPurpooseId.Text = LastId;
                    MessageBox.Show("ٹوکن مقصد کا اندراج ہوگیاہے۔");
                    btnNewSrvCostUnit.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ٹوکن مقصد(اردو) اور  ٹوکن مقصد(انگریزی) درج کیجیے۔");
            }
        }

        #endregion

        #region Button Click Event Members

        private void btnSaveTokPurpose_Click(object sender, EventArgs e)
        {
            SaveTokenPurpose();
            FillTokenPurposeGrid();
        }

        private void btnNewTokPurpose_Click(object sender, EventArgs e)
        {
            txtTokenPurpooseId.Text = "-1";
            btnSaveTokPurpose.Enabled = true;
            btnDelTokPurpose.Enabled = false;
            txtTokenPurposeEng.Clear();
            txtTokenPurposeUrdu.Clear();
            txtTokenPurposeUrdu.Focus();
        }

        #endregion

        #region GridView Fill Methods

        public void FillTokenPurposeGrid()
        {
            DataTable dt = new DataTable();
            dt = mstDef.GetSDCTokenPurposeList();
            grdTokenPurpose.DataSource = dt;
            grdTokenPurpose.Columns["TokenPurposeId"].Visible = false;
            grdTokenPurpose.Columns["TokenPurpose_Urdu"].HeaderText = "ٹوکن مقصد اردو ";
            grdTokenPurpose.Columns["TokenPurpose_Eng"].HeaderText = "ٹوکن مقصد انگریزی ";
            grdTokenPurpose.Columns["insertdate"].HeaderText = "تاریخ ٹوکن اندراج";
            grdTokenPurpose.Columns["UpdateDate"].HeaderText = "تاریخ ٹوکن تبدیلی";
        }

        #endregion

        #region Gridview Click Events

        private void grdTokenPurpose_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdTokenPurpose.CurrentRow.Cells["checkListNew"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdTokenPurpose.SelectedRows.Count > 0)
                    {
                        btnDelTokPurpose.Enabled = true;
                        btnSaveTokPurpose.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["checkListNew"].Value = 1;
                            txtTokenPurpooseId.Text = row.Cells["TokenPurposeId"].Value.ToString();
                            txtTokenPurposeUrdu.Text = row.Cells["TokenPurpose_Urdu"].Value.ToString();
                            txtTokenPurposeEng.Text = row.Cells["TokenPurpose_Eng"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["checkListNew"].Value = 0;
                        }
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Code for Tab Payment Type

        #region Record Insertion members

        private void SavePaymentType()
        {

            if (txtPaymentTypeUrdu.Text != "" && txtPaymentTypeEng.Text != "")
            {
                try
                {
                    string PaymentTypeId = txtPaymentTypeId.Text.ToString();
                    string PaymentTypeUrdu = txtPaymentTypeUrdu.Text.ToString();
                    string PaymentTypeEng = txtPaymentTypeEng.Text.ToString();
                    string tehsilId = UsersManagments._Tehsilid.ToString();
                    string UsrId = UsersManagments.UserId.ToString();
                    string UsrName = UsersManagments.UserName.ToString();
                    string LastId = mstDef.SaveSDCPaymentTypes(PaymentTypeId, PaymentTypeUrdu, PaymentTypeEng, tehsilId, UsrId, UsrName, UsrId, UsrName);
                    txtPaymentTypeId.Text = LastId;
                    MessageBox.Show("ادائیگی قسم کا اندراج ہوگیاہے۔");
                    btnNewPaymentType.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ادائیگی قسم(اردو) اور  ادائیگی قسم(انگریزی) درج کیجیے۔");
            }
        }

        #endregion

        #region GridView Fill Methods

        public void FillPaymentTypeGrid()
        {
            try
    			{
            DataTable dt = new DataTable();
            dt = mstDef.GetSDCPaymentTypesList();
            grdPaymentType.DataSource = dt;
            grdPaymentType.Columns["PaymentTypeId"].Visible = false;
            grdPaymentType.Columns["PaymentType_Urdu"].HeaderText = "ادائیگی قسم اردو ";
            grdPaymentType.Columns["PaymentType_Eng"].HeaderText = "ادائیگی قسم انگریزی ";
            grdPaymentType.Columns["insertdate"].HeaderText = "تاریخ ادائیگی قسم اندراج";
            grdPaymentType.Columns["UpdateDate"].HeaderText = "تاریخ ادائیگی قسم تبدیلی";
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion    

        #region Button Click Event Members

        private void btnNewPaymentType_Click(object sender, EventArgs e)
        {
            txtPaymentTypeId.Text = "-1";
            btnSavePaymentType.Enabled = true;
            btnDelPaymentType.Enabled = false;
            txtPaymentTypeUrdu.Clear();
            txtPaymentTypeEng.Clear();
            txtPaymentTypeUrdu.Focus();

        }
        private void btnSavePaymentType_Click(object sender, EventArgs e)
        {
            SavePaymentType();
            FillPaymentTypeGrid();
        }
        #endregion

        #region Gridview Click Events

        private void grdPaymentType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdPaymentType.CurrentRow.Cells["colChoosePaymentType"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdPaymentType.SelectedRows.Count > 0)
                    {
                        btnDelPaymentType.Enabled = true;
                        btnSavePaymentType.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChoosePaymentType"].Value = 1;
                            txtPaymentTypeId.Text = row.Cells["PaymentTypeId"].Value.ToString();
                            txtPaymentTypeUrdu.Text = row.Cells["PaymentType_Urdu"].Value.ToString();
                            txtPaymentTypeEng.Text = row.Cells["PaymentType_Eng"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChoosePaymentType"].Value = 0;
                        }
                    }
                }
            }
            }
 			catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
        }
        #endregion

        #endregion

        #region Code for Tab Service Type

        #region Record Insertion members

        private void SaveServiceType()
        {

            if (txtServiceTypeUrdu.Text != "" && txtServiceTypeEng.Text != "")
            {
                try
                {
                    string ServiceTypeId = txtServiceTypeId.Text.ToString();
                    string ServiceTypeUrdu = txtServiceTypeUrdu.Text.ToString();
                    string ServiceTypeEng = txtServiceTypeEng.Text.ToString();
                    string tehsilId = UsersManagments._Tehsilid.ToString();
                    string UsrId = UsersManagments.UserId.ToString();
                    string UsrName = UsersManagments.UserName.ToString();
                    string LastId = mstDef.SaveSDCServiceTypes(ServiceTypeId, tehsilId, ServiceTypeUrdu, ServiceTypeEng, UsrId, UsrName, UsrId, UsrName);
                    txtServiceTypeId.Text = LastId;
                    MessageBox.Show(" قسم سہولت کا اندراج ہوگیاہے۔");
                    btnNewServiceType.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("قسم سہولت (اردو) اور  قسم سہولت (انگریزی) درج کیجیے۔");
            }
        }

        #endregion

        #region Load Grid Members

        public void FillServiceTypeGrid()
        {
            try
    			{
            DataTable dt = new DataTable();
            dt = mstDef.GetSDCServiceTypesList();
            grdServiceType.DataSource = dt;
            grdServiceType.Columns["ServiceTypeId"].Visible = false;
            grdServiceType.Columns["TehsilId"].Visible = false;
            grdServiceType.Columns["ServiceTypeName_Urdu"].HeaderText = "سہولت قسم اردو ";
            grdServiceType.Columns["ServiceTypeName_Eng"].HeaderText = "سہولت قسم انگریزی ";
            grdServiceType.Columns["insertdate"].HeaderText = "تاریخ سہولت قسم اندراج";
            grdServiceType.Columns["UpdateDate"].HeaderText = "تاریخ سہولت قسم تبدیلی";
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Click Event Members

        private void btnNewServiceType_Click(object sender, EventArgs e)
        {
            txtServiceTypeId.Text = "-1";
            btnSaveServiceType.Enabled = true;
            btnDelServiceType.Enabled = false;
            txtServiceTypeUrdu.Clear();
            txtServiceTypeEng.Clear();
            txtServiceTypeUrdu.Focus();

        }
        private void btnSaveServiceType_Click(object sender, EventArgs e)
        {
            SaveServiceType();
            FillServiceTypeGrid();
        }

        #endregion

        #region GridView Fill Methods

        private void grdServiceType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{

            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdServiceType.CurrentRow.Cells["colChooseSrvType"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdServiceType.SelectedRows.Count > 0)
                    {
                        btnDelServiceType.Enabled = true;
                        btnSaveServiceType.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChooseSrvType"].Value = 1;
                            txtServiceTypeId.Text = row.Cells["ServiceTypeId"].Value.ToString();
                            txtServiceTypeUrdu.Text = row.Cells["ServiceTypeName_Urdu"].Value.ToString();
                            txtServiceTypeEng.Text = row.Cells["ServiceTypeName_Eng"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseSrvType"].Value = 0;
                        }
                    }
                }
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

        #region Code for Tab Service Cost Unit

        #region Record Insertion members

        private void SaveServiceCostUnit()
        {

            if (txtSrvCostUnitUrdu.Text != "" && txtSrvCostUnitEng.Text != "")
            {
                try
                {
                    string SrvCostUnitId = txtSrvCostUnitId.Text.ToString();
                    string SrvCostUnitUrdu = txtSrvCostUnitUrdu.Text.ToString();
                    string SrvCostUnitEng = txtSrvCostUnitEng.Text.ToString();
                    string tehsilId = UsersManagments._Tehsilid.ToString();
                    string UsrId = UsersManagments.UserId.ToString();
                    string UsrName = UsersManagments.UserName.ToString();
                    string LastId = mstDef.SaveSDCServiceCostUnits(SrvCostUnitId, tehsilId, SrvCostUnitUrdu, SrvCostUnitEng, UsrId, UsrName, UsrId, UsrName);
                    txtSrvCostUnitId.Text = LastId;
                    MessageBox.Show(" قیمت کی اکائی کا اندراج ہوگیاہے۔");
                    btnSaveSrvCostUnit.Enabled = true;
                    btnDelSrvCostUnit.Enabled = true;
                    btnNewSrvCostUnit.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("قیمت کی اکائی (اردو) اور  قیمت کی اکائی (انگریزی) درج کیجیے۔");
            }
        }

        #endregion

        #region Load Grid Members

        public void FillServiceCostUnitGrid()
        {
            try
            {
            DataTable dt = new DataTable();
            dt = mstDef.GetSDCServiceCostUnitsList();
            grdSrvCostUnit.DataSource = dt;
            grdSrvCostUnit.Columns["SDCUnitId"].Visible = false;
            grdSrvCostUnit.Columns["TehsilId"].Visible = false;
            grdSrvCostUnit.Columns["SDCUnitName_Urdu"].HeaderText = "قیمت کی اکائی اردو ";
            grdSrvCostUnit.Columns["SDCUnitName_Eng"].HeaderText = "قیمت کی اکائی انگریزی ";
            grdSrvCostUnit.Columns["insertdate"].HeaderText = "تاریخ قیمت کی اکائی اندراج";
            grdSrvCostUnit.Columns["UpdateDate"].HeaderText = "تاریخ قیمت کی اکائی تبدیلی";
            }
 			catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Click Event Members

        private void btnNewSrvCostUnit_Click(object sender, EventArgs e)
        {
            txtSrvCostUnitId.Text = "-1";
            btnSaveSrvCostUnit.Enabled = true;
            btnDelSrvCostUnit.Enabled = false;
            txtSrvCostUnitUrdu.Clear();
            txtSrvCostUnitEng.Clear();
            txtSrvCostUnitUrdu.Focus();
        }

        private void btnSaveSrvCostUnit_Click(object sender, EventArgs e)
        {
            SaveServiceCostUnit();
            FillServiceCostUnitGrid();
        }

        #endregion

        #region GridView Fill Methods

        private void grdSrvCostUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdSrvCostUnit.CurrentRow.Cells["colChooseSrvCostUnit"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdSrvCostUnit.SelectedRows.Count > 0)
                    {
                        btnDelSrvCostUnit.Enabled = true;
                        btnSaveSrvCostUnit.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChooseSrvCostUnit"].Value = 1;
                            txtSrvCostUnitId.Text = row.Cells["SDCUnitId"].Value.ToString();
                            txtSrvCostUnitUrdu.Text = row.Cells["SDCUnitName_Urdu"].Value.ToString();
                            txtSrvCostUnitEng.Text = row.Cells["SDCUnitName_Eng"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseSrvCostUnit"].Value = 0;
                        }
                    }
                }
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #endregion

        #region Code for Tab Services

        #region Record Insertion members

        private void SaveServices()
        {

            if (txtServiceNameUrdu.Text != "" && txtServiceNameEng.Text != "")
            {
                if (cboServiceType.SelectedIndex > 0)
                {
                    try
                    {
                        string ServiceNameId = txtServiceNameId.Text.ToString();
                        string ServiceNameUrdu = txtServiceNameUrdu.Text.ToString();
                        string ServiceNameEng = txtServiceNameEng.Text.ToString();
                        string ServiceTypeId = cboServiceType.SelectedValue.ToString();
                        string tehsilId = UsersManagments._Tehsilid.ToString();
                        string UsrId = UsersManagments.UserId.ToString();
                        string UsrName = UsersManagments.UserName.ToString();
                        string LastId = mstDef.SaveSDCServices(ServiceNameId, tehsilId, ServiceNameUrdu, ServiceNameEng, ServiceTypeId, UsrId, UsrName, UsrId, UsrName);
                        txtServiceNameId.Text = LastId;
                        MessageBox.Show(" سہولت کا اندراج ہوگیاہے۔");
                        btnSaveService.Enabled = true;
                        btnDelService.Enabled = true;
                        btnNewService.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {

                    MessageBox.Show("قسم سہولت چنئیے۔");
                }
            }
            else
            {

                MessageBox.Show("سہولت کا نام (اردو) اور  سہولت کا نام (انگریزی) درج کیجیے۔");
            }
        }

        #endregion

        #region Load Grid Members

        public void FillServicesGrid()
        {
            try
            {
            DataTable dt = new DataTable();
            dt = mstDef.GetSDCServicesList();
            grdServices.DataSource = dt;
            grdServices.Columns["SDCServiceId"].Visible = false;
            grdServices.Columns["TehsilId"].Visible = false;
            grdServices.Columns["ServiceTypeId"].Visible = false;
            grdServices.Columns["SDCServiceName_Urdu"].HeaderText = "سہولت کا نام اردو ";
            grdServices.Columns["SDCServiceName_Eng"].HeaderText = "سہولت کا نام انگریزی ";
            grdServices.Columns["ServiceTypeName_Urdu"].HeaderText = "قسم سہولت ";
            grdServices.Columns["insertdate"].HeaderText = "تاریخ سہولت اندراج";
            grdServices.Columns["UpdateDate"].HeaderText = "تاریخ سہولت تبدیلی";
            }
 			catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Click Event Members

        private void btnNewService_Click(object sender, EventArgs e)
        {
            txtServiceNameId.Text = "-1";
            btnSaveService.Enabled = true;
            btnDelService.Enabled = false;
            txtServiceNameUrdu.Clear();
            txtServiceNameEng.Clear();
            txtServiceNameUrdu.Focus();
            cboServiceType.SelectedIndex = 0;
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            SaveServices();
            FillServicesGrid();
        }

        #endregion

        #region GridView Fill Methods

        private void grdServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdServices.CurrentRow.Cells["colChooseSDCService"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdServices.SelectedRows.Count > 0)
                    {
                        btnDelSrvCostUnit.Enabled = true;
                        btnSaveSrvCostUnit.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChooseSDCService"].Value = 1;
                            txtServiceNameId.Text = row.Cells["SDCServiceId"].Value.ToString();
                            txtServiceNameUrdu.Text = row.Cells["SDCServiceName_Urdu"].Value.ToString();
                            txtServiceNameEng.Text = row.Cells["SDCServiceName_Eng"].Value.ToString();
                            cboServiceType.Text = row.Cells["ServiceTypeName_Urdu"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseSDCService"].Value = 0;
                        }
                    }
                }
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion

        #region Code for Tab Services Cost Notificaitons

        #region Record Insertion members

        private void SaveServicesCostNot()
        {

            if (cboNotSrvName.SelectedIndex > 0 || cboNotSrvType.SelectedIndex > 0)
            {
                if (cboNotSrvCostUnit.SelectedIndex > 0 || txtSrvCostPerUnit.Text != "")
                {
                    try
                    {
                        string ServiceCostNotId = txtSrvCostNotId.Text.ToString();
                        string ServiceId = cboNotSrvName.SelectedValue.ToString();
                        string ServiceCostUnitId = cboNotSrvCostUnit.SelectedValue.ToString();
                        string ServiceCostPerUnit = txtSrvCostPerUnit.Text.ToString();
                        string ServiceTypeId = cboNotSrvType.SelectedValue.ToString();
                        string tehsilId = UsersManagments._Tehsilid.ToString();
                        string UsrId = UsersManagments.UserId.ToString();
                        string UsrName = UsersManagments.UserName.ToString();
                        string LastId = mstDef.SaveSDCServiceCostNotifications(ServiceCostNotId, tehsilId, ServiceId, ServiceTypeId, ServiceCostUnitId, ServiceCostPerUnit, UsrId, UsrName, UsrId, UsrName);
                        txtSrvCostNotId.Text = LastId;
                        MessageBox.Show(" قیمت نوٹیفکیشین کا اندراج ہوگیاہے۔");
                        btnSaveCostNotification.Enabled = true;
                        btnDelCostNotification.Enabled = true;
                        btnNewCostNotification.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {

                    MessageBox.Show("قیمت کی اکائی چنئیے اورقیمت فی اکائی کا اندراج کیجئے۔");
                }
            }
            else
            {

                MessageBox.Show("سہولت کا نام اور سہولت کی قسیم چنئیے۔");
            }
        }

        #endregion

        #region Load Grid Members

        public void FillServicesCostNotGrid()
        {
            try
            {
            DataTable dt = new DataTable();
            dt = mstDef.GetSDCServiceCostNotificationsList();
            grdCostNotification.DataSource = dt;
            grdCostNotification.Columns["ServiceNotificationId"].Visible = false;
            grdCostNotification.Columns["TehsilId"].Visible = false;
            grdCostNotification.Columns["ServiceId"].Visible = false;
            grdCostNotification.Columns["ServiceTypeId"].Visible = false;
            grdCostNotification.Columns["ServiceCostUnitId"].Visible = false;
            grdCostNotification.Columns["SDCServiceName_Urdu"].HeaderText = "سہولت کا نام ";
            grdCostNotification.Columns["ServiceTypeName_Urdu"].HeaderText = "قسم سہولت ";   
            grdCostNotification.Columns["SDCUnitName_Urdu"].HeaderText = "قیمت کی اکائی ";
            grdCostNotification.Columns["ServiceCostPerUnit"].HeaderText = "قیمت فی سہولت ";
            grdCostNotification.Columns["insertdate"].HeaderText = "تاریخ سہولت اندراج";
            grdCostNotification.Columns["UpdateDate"].HeaderText = "تاریخ سہولت تبدیلی";
            }
 			catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Click Event Members

        private void btnNewCostNotification_Click(object sender, EventArgs e)
        {
            txtSrvCostNotId.Text = "-1";
            btnSaveCostNotification.Enabled = true;
            btnDelCostNotification.Enabled = false;
            txtSrvCostPerUnit.Clear();
            cboNotSrvName.SelectedIndex = 0;
            cboNotSrvType.SelectedIndex = 0;
            cboNotSrvCostUnit.SelectedIndex = 0;
        }

        private void btnSaveCostNotification_Click(object sender, EventArgs e)
        {
            SaveServicesCostNot();
            FillServicesCostNotGrid();
        }
        #endregion

        #region GridView Fill Methods

        private void grdCostNotification_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdCostNotification.CurrentRow.Cells["colChooseCostNot"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdCostNotification.SelectedRows.Count > 0)
                    {
                        btnDelCostNotification.Enabled = true;
                        btnSaveCostNotification.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChooseCostNot"].Value = 1;
                            txtSrvCostNotId.Text = row.Cells["ServiceNotificationId"].Value.ToString();
                            txtSrvCostPerUnit.Text = row.Cells["ServiceCostPerUnit"].Value.ToString();
                            cboNotSrvName.Text = row.Cells["SDCServiceName_Urdu"].Value.ToString();
                            cboNotSrvType.Text = row.Cells["ServiceTypeName_Urdu"].Value.ToString();
                            cboNotSrvCostUnit.Text = row.Cells["SDCUnitName_Urdu"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseCostNot"].Value = 0;
                        }
                    }
                }
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnDelTokPurpose_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
