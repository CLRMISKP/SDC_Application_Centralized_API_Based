using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.AL;
using System.Configuration;


namespace SDC_Application
{
    public partial class frmMain : Form
    {
        
        public static string getDateFormateString(){
            return "dd MMM yyyy hh:mm:ss tt";
        }

        public static string getShortDateFormateString()
        {
            return "dd MMM yyyy";
        }

        #region Class Variables
       // public int Check { get; set; }
        public int MozaIDforRep { get; set; }
        public string roleid { get; set; }
        public static int cameraindex = -1;
        //public string tokenmenu { get; set; }
        //public string bookingmenu { get; set; }
        
        List<NavigationMenu> navmenus = new List<NavigationMenu>();
        //List<Proc_Get_UserRoles_Result> userRole = new List<Proc_Get_UserRoles_Result>();
        DataTable UserRole = new DataTable();
        //List<Proc_Get_UserRoles_Result> userRolesSelected = new List<Proc_Get_UserRoles_Result>();
        DataTable UserObject = new DataTable();
        //List<Proc_Get_Admin_RolesDetail_Result> UserObjects = new List<Proc_Get_Admin_RolesDetail_Result>();
       // SDCReports chk = new SDCReports();    
        DL.Database db = new DL.Database();
        ArrayList list = new ArrayList();
       

        #endregion

        #region Default constructor

        public frmMain()
        {
            InitializeComponent();
            this.Text = "سروس ڈیلیوری سنٹر سسٹم   " + "( Vesion " + UsersManagments._Ver + " )";
        }

        #endregion

        #region Method for checking already opened forms/windows
         
        private bool IsFrmOpen(string formName)
        {
            bool isOpen = false;
            foreach (Form form in this.MdiChildren)
            {
                
                if (form.Name == formName)
                {
                    form.Activate();
                    isOpen = true;
                }

            }
            return isOpen;
        }

        #endregion

        #region Menu Items Click Events
        /// <summary>
        /// calls isopen() method for checking of already open forms, if it returns false a new form of Allaqajat is opened 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuIlaqaJaat_Click(object sender , EventArgs e)
        {
            bool isopen = IsFrmOpen("frmRecipt");
            if ( !isopen )
            {
                UsersManagments.check = 3;
                frmRecipt rcp = new frmRecipt();
                rcp.MdiParent = this;
                rcp.WindowState = this.WindowState;
                rcp.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Receipt Form'");
            }
        }
        /// <summary>
        /// calls isopen() method for checking of already open Shajra forms, if it returns false a new form of for Shajra entry is opened 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAfraadRegister_Click(object sender , EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmVoucher");

            if (!isOpen)
            {

                UsersManagments.check = 2;
                frmVoucher v = new frmVoucher();
                v.MdiParent = this;
                //personShajra.Text = "Window " + childFormNumber++;
                v.WindowState = this.WindowState;
                v.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Vouchar Form'");
            }
           
        }
        /// <summary>
        /// calls isopen() method for checking of already open RHZ forms, if it returns false a new form of RHZ entry is opened 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRegisterHaqdaranZameen_Click(object sender , EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmDocumentApproval");
            if ( !isOpen )
            {
                frmDocumentApproval da = new frmDocumentApproval();
                da.MdiParent = this;
                da.WindowState = this.WindowState;
                da.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Document Approval Form'");
            }
        }
       
       
       
        /// <summary>
        /// calls isopen() method for checking of already open Online GIS Map forms, if it return false a new form of Online GIS Map is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuonlineNaqshaMozaMasavi_Click(object sender , EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://gis.unhabitat.org.pk/dlrr");
            bool isOpen = IsFrmOpen("frmIntiqalMain");
            if (!isOpen)
            {
                UsersManagments.check = 4;
                frmIntiqalMain intiqal = new frmIntiqalMain();
                intiqal.MdiParent = this;
                intiqal.WindowState = this.WindowState;
                intiqal.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Intiqal Main Form'");
            }
        }
       
         ///<summary>
         ///Close the aplication
         ///</summary>
         ///<param name="sender"></param>
         ///<param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// calls isopen() method for checking of already open calculator forms, if it return false a new form of calculator is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCalculator_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmCalculatorcs");
            if (!isOpen)
            {
                frmCalculatorcs C = new frmCalculatorcs();
                C.Show();
            }
        }

        #endregion

        #region Form Close Event and User Promt
        /// <summary>
        /// Prompt user to click yes for application closing or click No for canceling the closing action of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res= MessageBox.Show("Are You Sure to Close the CLRMIS Application", "Confirm to Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                e.Cancel = false;
                string lastId=db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Login_Details " + UsersManagments.UserId + "," + UsersManagments._Tehsilid + ",'" + UsersManagments.UserName + "','undefined',"+ UsersManagments.LoginRecId); 
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Form Load Event
   /// <summary>
   /// Form Load Event
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            string clientProcessId = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = clientProcessId+this.Name + "|" + this.Text; DataGridViewHelper.addHelpterToAllFormGridViews(this);
            // UsersManagments._Tehsilid = Convert.ToInt32(ConfigurationSettings.AppSettings["Tehsil"]);
            BL.AreaProfile af = new BL.AreaProfile();
            DataTable dt = af.GetDistTehsilNames(UsersManagments._Tehsilid.ToString(), UsersManagments.SubSdcId.ToString());
            string DistNameUrdu = "";
            string DistNameEng = "";
            //string TehsilNameUrdu="";
            string TehsilNameEng = "";
            foreach (DataRow r in dt.Rows)
            {
                DistNameEng = r["DistrictNameEng"].ToString();
                DistNameUrdu = r["DistrictnameUrdu"].ToString();
                TehsilNameEng = r["TehsilNameEng"].ToString();
                UsersManagments.TehsilNameUrdu = r["TehsilNameUrdu"].ToString();

            }
            this.lblSDCTitle.Text = "   مرکز ترسیل سہولیات آراضی -   " + UsersManagments.TehsilNameUrdu + " | Service Delivery Center -  Tehsil  " + TehsilNameEng + " - District - " + DistNameEng;


            checkForAdmin();
            loadUserRoles();
            CheckMenus();
            GetNavigationMenuRights();

            //if (bookingmenu == "1")
            //{
            //    menuCovid19Booking.Visible = true;
            //}
            //else
            //{
            //    menuCovid19Booking.Visible = false;
            //}
            //if ((UsersManagments.UserName.Contains("Admin")) || (UsersManagments._RoleName.Contains("CAdmin")) || (UsersManagments._RoleName.Contains("Admin")) || (UsersManagments._RoleName.Contains("Administrator")))
            if (UsersManagments._IsAdmin )
            {
                mnucreateUsers.Visible = true;
                mnuSupervisorMain.Visible = true;
            }
            else
            {
                mnucreateUsers.Visible = false;
                mnuSupervisorMain.Visible = false;
            }
            if (DateTime.Now < new DateTime(2024, 09, 27))
            {
                frmAppUpdateListMessage appUp = new frmAppUpdateListMessage();
                appUp.ShowDialog();
            }
        }

        #endregion

        #region Check for Admin Role and control Admin Panel visibility
        /// <summary>
        /// Check user for thier role assigned to, and show application menu according to role
        /// </summary>
        private void checkForAdmin()
        {
            //if (CurrentUser.RoleName.ToLower() == "admin")
            //{
            //    mnuAdminMain.Visible = true;
            //    mnuReports.Visible = true;
            //}
            //else
            //{
            //    mnuAdminMain.Visible = false;
            //    mnuReports.Visible = false;
            //}
        }

        #endregion

        #region Menu Control
        private void loadUserRoles()
        {
            DataTable role = new DataTable();
            DataTable roledetail = new DataTable();

            //// =========== for showing token and booking menue to users
            //DataTable token = new DataTable();
            //token = db.filldatatable_from_storedProcedure("Covid19_proc_Self_Get_Token_Booking_YesNo " + UsersManagments.UserId.ToString());
            //foreach (DataRow row in token.Rows)
            //{
            //    tokenmenu = row["tokenmenu"].ToString();
            //    bookingmenu = row["bookingmenu"].ToString();
            //}
            
            ////======= end ==================================
            role = db.filldatatable_from_storedProcedure("Proc_Get_AdminUserRoleId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + UsersManagments.UserId.ToString());
            foreach(DataRow row in role.Rows)
            {
                roleid = row["RoleId"].ToString();
            }
            if (roleid != null)
            {
                roledetail = db.filldatatable_from_storedProcedure("Proc_Get_Admin_RolesDetail_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + roleid.ToString()); // --NOT_IMPLEMENTED_ TEHSIL ID NOT NEEDED
            }
            foreach (DataRow row in roledetail.Rows)
            {
                list.Add(row["ObjectActualName"].ToString());
            }
        }

        private void CheckMenus()
        {
           // bool mnu1 = false;
            this.mnuToken.Visible = isMenuVisible("frmToken");
            this.mnuChallan.Visible = isMenuVisible("frmVoucher");
            this.mnuReceipt.Visible = isMenuVisible("frmRecipt");
            this.mnuIntiqalMain.Visible = isMenuVisible("frmIntiqalMain");
            this.mnuVerificationByGirdawar.Visible = isMenuVisible("frmDocumentApproval");
            this.mnuVerificationByTehsilDar.Visible = isMenuVisible("frmDocumentApproval");
            this.mnuAfradRegister.Visible = isMenuVisible("frmAfradRegister");
            this.mnuMasterDefForms.Visible = isMenuVisible("frmSDCMasterDefinition");
            this.mnuAllaqajat.Visible = isMenuVisible("");
            //this.mnuMasterDefForms.Visible = isMenuVisible("");
           // this.mnuIntiqalDefForm.Visible = isMenuVisible("");
           this.mnuAmalDaramad.Visible = isMenuVisible("");
           bool cond = isMenuVisible("frmUserManagement");
           this.mnucreateUsers.Visible = cond; //isMenuVisible("frmUserManagement");
          // this.mnucreaTRoles.Visible = isMenuVisible("UserRoleDefination"); //UserRoleDefination
            this.ToolStripMenuCorrection.Visible = isMenuVisible("frmMisalMain");
            this.ToolStripMenuCorrection.Visible = isMenuVisible("frmFardBadar");
            this.mnuKhataLock.Visible = isMenuVisible("frmKhattaLocking");
            this.mnuMalkanSearchandMerging.Visible = isMenuVisible("frmMalkanSearchingMerging");
            //this.mnuInsertLoginDetails.Visible = isMenuVisible("frmUserLogs");\
            this.mnuSubDraFardatFee.Visible = isMenuVisible("DRA_FardFee_dem");
            this.mnuSubDraIntiqalatFee.Visible = isMenuVisible("DRA_IntiqalTax_dem");
            this.mnuSubDraIntiqalatParthFee.Visible = isMenuVisible("DRA_IntiqalParthFee_dem");
            this.mnuSubRTSfardat.Visible = isMenuVisible("RTS_Fard_Issueance_dem");
            this.mnuSubRTSIntiqalat.Visible = isMenuVisible("RTS_Mutation_Entry_dem");
            this.mnuSubIntiqalatAttested.Visible = isMenuVisible("IntiqalAttestationDateReport");
            this.mnuSubIntiqalatCancel.Visible = isMenuVisible("IntiqalKharijshudaDetailReport");
            this.mnuSubIntiqalatAttNotImp.Visible = isMenuVisible("IntiqalAttestedNotImplementedReport");
            this.mnuSubIntiqalatonRegistry.Visible = isMenuVisible("Registry_Intiqal_Detail_dem");
            this.mnuSubIntiqalatTehsildar.Visible = isMenuVisible("Intiqal_Tehsildar_Report_dem");
            this.mnuSubIntiqalatPendingRegistry.Visible = isMenuVisible("Registry_Intiqal_Pending_dem");
            this.mnuSubUnAttestedMutOPM.Visible = isMenuVisible("Mutation_UnAttested_dem");
            this.mnuCoBiometricNotAttested.Visible = isMenuVisible("IntiqalBoimetricCapturedNotAttestedReport");//mnuRHZreport
            this.mnuRHZreport.Visible = isMenuVisible("mnuRHZreport");//
            this.mnuRegEntryRptCo.Visible = isMenuVisible("mnuRegEntryRptCo");//
            this.mnuTaskNonAdmin.Visible = isMenuVisible("frmAdminPendingTaskDashboard");
            //this.mnuSubUnAttestedMutOPM.Visible = isMenuVisible("Mutation_UnAttested_dem"); IntiqalBoimetricCapturedNotAttestedReport
            this.mnuRhz_ChangeAdminDashboard.Visible = UsersManagments._IsAdmin;
            mnuReports.Visible = UsersManagments._IsAdmin;

        }
        private void GetNavigationMenuRights()
        {
            //foreach (var q in UserObjects)
            //{
            //    NavigationMenu m = new NavigationMenu();
            //    m.MenuName = q.ObjectActualName;
            //    m.isVisible = true;
            //    navmenus.Add(m);
            //}
            //for (int x=0;x < 4;x++)
            //{
            //    NavigationMenu m = new NavigationMenu();
            //    m.MenuName = "mnuIlaqaJaat";
            //    m.isVisible = false;
            //    navmenus.Add(m);
            //}
        }
        private bool isMenuVisible(string menuName)
        {
            bool result = false;
            foreach (string objects in list)
            {
                if (menuName.Trim() == objects.Trim())
                {
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
                              
            }
            return result;
        }
          
        #endregion

        #region Menu Items Click Events

        private void mnuAdminCreateUser_Click(object sender, EventArgs e)
        {
            
           
        }

        private void mnuAdminDelUser_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuFileIndexing_Click(object sender, EventArgs e)
        {
            //if (tokenmenu == "1")
            //{
                bool isopen = IsFrmOpen("frmToken");
                if (!isopen)
                {
                    UsersManagments.check = 1;
                    frmToken tk = new frmToken();
                    tk.MdiParent = this;
                    tk.WindowState = this.WindowState;
                    //tk.WindowState =
                    tk.Show();
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Token Form'");

                }
            //}
            //else
            //{
            //    bool isopen = IsFrmOpen("frmCovid19Token");
            //    if (!isopen)
            //    {
            //        UsersManagments.check = 1;
            //        frmCovid19Token tk = new frmCovid19Token();
            //        tk.MdiParent = this;
            //        tk.WindowState = this.WindowState;
            //        //tk.WindowState =
            //        tk.Show();
            //        string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Token Form'");

            //    }
            //}

          
        }

        private void mnuRHZAfraad_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmRptFard");
            if (!isopen)
            {
                //frmPictureIndexMain indexing = new frmPictureIndexMain();
                //indexing.MdiParent = this;
                //indexing.WindowState = this.WindowState;
                //indexing.Show();
            }
        }

        private void mnuAllaqajat_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmSupervisorAllaqajat");
            if (!isopen)
            {
                //frmSupervisorAllaqajat um = new frmSupervisorAllaqajat();
                //try
                //{

                //    um.MdiParent = this;
                //    um.WindowState = this.WindowState;
                //    um.Show();
                //}
                //catch (Exception ex)
                //{
                //    um.Dispose();
                //}


            }
        }

        private void mnuMasterDefForms_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmSDCMasterDefinition");
            if (!isopen)
            {
                frmSDCMasterDefinition um = new frmSDCMasterDefinition();
                try
                {

                    um.MdiParent = this;
                    um.WindowState = this.WindowState;
                    um.Show();
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Master Definition Form'");
                }
                catch (Exception ex)
                {
                    um.Dispose();
                }


            }
        }

        private void mnuUserRoles_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmRolesDefinition");
            if (!isopen)
            {
                //frmRolesDefinition roleDef = new frmRolesDefinition();
                //try
                //{

                //    roleDef.MdiParent = this;
                //    roleDef.WindowState = this.WindowState;
                //    roleDef.Show();
                //}
                //catch (Exception ex)
                //{
                //    roleDef.Dispose();
                //}


            }
        }

        private void mnuUserMngmnt_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmUserManagement");
            if (!isopen)
            {
                //frmUserManagement um = new frmUserManagement();
                //try
                //{

                //    um.MdiParent = this;
                //    um.WindowState = this.WindowState;
                //    um.Show();
                //}
                //catch (Exception ex)
                //{
                //    um.Dispose();
                //}


            }
        }

        private void mnuEditDelete_Click(object sender, EventArgs e)
        {

        }

        private void mnuFardBader_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmFardBadar");
            if (!isopen)
            {
                //frmFardBadarNew um = new frmFardBadarNew();
                //try
                //{

                //    um.MdiParent = this;
                //    um.WindowState = this.WindowState;
                //    um.Show();
                //}
                //catch (Exception ex)
                //{
                //    um.Dispose();
                //}


            }
        }

        private void mnuSetPath_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmSetPath");
            if (!isopen)
            {
                //frmSetPath um = new frmSetPath();
                //try
                //{


                //    um.ShowDialog();
                //}
                //catch (Exception ex)
                //{
                //    um.Dispose();
                //}


            }
        }

        private void mnuAmalDaramad_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmAmalDaramad");
            if (!isopen)
            {
                //frmAmalDaramad um = new frmAmalDaramad();
                //try
                //{


                //    um.MdiParent = this;
                //    um.WindowState = this.WindowState;
                //    um.Show();
                //}
                //catch (Exception ex)
                //{
                //    um.Dispose();
                //}


            }
        }

        private void mnuRegisterHaqdaranZameenAmalDaramad_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmHqdaranZameenKhatjatNewAmalDaramad");
            if (!isOpen)
            {
                //frmHqdaranZameenKhatjatNewAmalDaramad kh = new frmHqdaranZameenKhatjatNewAmalDaramad();
                //try
                //{
                //    kh.MdiParent = this;
                //    kh.WindowState = this.WindowState;
                //    kh.Show();
                //}
                //catch (Exception ex)
                //{
                //    kh.Dispose();
                //}
            }
        }

        #endregion

       


        private void mnuMutationStatistics_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmNaqalIntiqalSelf");
             if (!isOpen)
             {
                 frmNaqalIntiqalSelf s = new frmNaqalIntiqalSelf();
                 try
                 {
                     s.MdiParent = this;
                     s.WindowState = this.WindowState;
                     s.Show();
                     string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Naqal Intiqal Form'");
                 }
                 catch (Exception ex)
                 {
                     s.Dispose();
                 }

             }
        }

        private void mnuIntiqalDefForm_Click(object sender, EventArgs e)
        {
            
            bool isOpen = IsFrmOpen("frmIntiqalMasterDefinitions");
            if (!isOpen)
            {
                frmIntiqalMasterDefinitions imd = new frmIntiqalMasterDefinitions();
                try
                {
                    imd.MdiParent = this;
                    imd.WindowState = this.WindowState;
                    imd.Show();
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Intiqal Definitions Form'");
                }
                catch (Exception ex)
                {
                    imd.Dispose();
                }
            }
            
        }

        private void mnuAfradRegister_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmAfradRegister");
            if (!isOpen)
            {
                frmAfradRegister afr = new frmAfradRegister();
                try
                {
                    afr.MdiParent = this;
                    afr.WindowState = this.WindowState;
                    afr.Show();
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Shajra Nasab Form'");
                }
                catch (Exception ex)
                {
                    afr.Dispose();
                }
            }
           
        }

        private void createUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void creaTRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuTafseelKhatas_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmKhattaSearchByPerson");
            if (!isOpen)
            {
                frmKhattaSearchByPerson KhattaSearch = new frmKhattaSearchByPerson();
                //  frmUserManagement
                try
                {

                    KhattaSearch.MdiParent = this;
                    //personShajra.Text = "Window " + childFormNumber++;
                    KhattaSearch.WindowState = this.WindowState;
                    KhattaSearch.Show();
                  
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Khata, Khassra, Khatooni Searching Form'");
                }
                catch (Exception ex)
                {
                    KhattaSearch.Dispose();
                }
            }
   
        }

        private void mnuIntiqalTadiqDate_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmIntiqalTasdiqDate");
            if (!isOpen)
            {
                frmIntiqalTasdiqDate KhattaSearch = new frmIntiqalTasdiqDate();
                //  frmUserManagement
                try
                {
                    KhattaSearch.MdiParent = this;
                    KhattaSearch.WindowState = this.WindowState;
                    KhattaSearch.Show();
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Intiqal Tasdeeq Form'");
                }
                catch (Exception ex)
                {
                    KhattaSearch.Dispose();
                }
            }
        }

        private void ToolStripBankChalan_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmBankRecipt");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmBankRecipt obj = new frmBankRecipt();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Bank Receipt Form'");
            }
        }

        private void تفصیلاتبنکیسڈیسیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCBankreport");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCBankreport obj = new frmSDCBankreport();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'SDC Bank Deposit Form'");
            }
        }

        private void mnuIndrajMisal_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmMisalMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmMisalMain obj = new frmMisalMain();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Correction by Misal Form'");
            }
        }

        private void mnuKhataLock_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmKhattaLocking");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmKhattaLocking obj = new frmKhattaLocking();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Record Locking-Unlocking Form'");
            }
        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmUserChangePassword");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmUserChangePassword obj = new frmUserChangePassword();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'User Change Password Form'");
            }
        }

        private void mnuIntiqalFardReport_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check= 7;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuReportHaqooqMalkiatKhanakasht_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmKhanakashtMushteryanReport");

            if (!isOpen)
            {
                frmKhanakashtMushteryanReport obj = new frmKhanakashtMushteryanReport();
                obj.ShowDialog();
            }
        }

        private void mnuSeachPersonForAllMouzas_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSearchPersonInAllMouzas");

            if (!isOpen)
            {
                frmSearchPersonInAllMouzas obj = new frmSearchPersonInAllMouzas();
                obj.ShowDialog();
            }
        }

        private void mnuMalkiatDetailHistory_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmMalkiatHistoryDetails");

            if (!isOpen)
            {
                frmMalkiatHistoryDetails obj = new frmMalkiatHistoryDetails();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();

            }
        }

        private void mnuMalkanSearchandMerging_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmMalkanSearchingMerging");

            if (!isOpen)
            {
                frmMalkanSearchingMerging obj = new frmMalkanSearchingMerging();
                obj.ShowDialog();
            }
        }

        private void mnuSearchKhassra_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmKhassraSearch");

            if (!isOpen)
            {
                frmKhassraSearch obj = new frmKhassraSearch();
                obj.Show();
            }
        }

        private void mnuBayanSearch_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmKhanakashtBayanMushteryan");

            if (!isOpen)
            {
                frmKhanakashtBayanMushteryan obj = new frmKhanakashtBayanMushteryan();
                obj.Show();
            }
        }

        private void mnuRHZamaldaramad_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmRhzAmaladaramad");

            if (!isOpen)
            {
                
                frmRhzAmaladaramad obj = new frmRhzAmaladaramad();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuInsertLoginDetails_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmUserLogs");

            if (!isOpen)
            {

                frmUserLogs obj = new frmUserLogs();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuFardeBadar_Click(object sender, EventArgs e)
            {
            bool isOpen = IsFrmOpen("frmFardeBadar");

            if (!isOpen)
                {
                frmFardeBadar obj = new frmFardeBadar();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
                }
            }

        private void ڈیشبورڈToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        bool isOpen = IsFrmOpen("frmRevenueDashboard");

            if (!isOpen)
            {

                frmSubSdcs obj = new frmSubSdcs();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void toolStripPicIndexing_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmPictureIndexMain");

             if (!isOpen)
             {
                 frmPictureIndexMain m = new frmPictureIndexMain();
                 m.MdiParent = this;
                 m.ThesilId = 15;
                 m.Show();
             }
        }

        private void فردToolStripMenuItem_Click(object sender, EventArgs e)
            {
                bool isOpen = IsFrmOpen("frmFard");

              if (!isOpen)
              {
                  frmFard fard = new frmFard();
                  fard.MdiParent = this;
                  fard.Show();
              }
            }

        private void mnuKhassraGardawri_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmKhassraGardawri");

             if (!isOpen)
             {
                 frmKhassraGardawri fard = new frmKhassraGardawri();
                 fard.MdiParent = this;
                 fard.Show();
             }
        }

        private void mnuDocReceiving_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = IsFrmOpen("frmDocReceiving");

            if (!isOpen)
                {
                frmDocReceiving obj = new frmDocReceiving();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuKhassraValuation_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = IsFrmOpen("frmKhassraValuation");

                if (!isOpen)
                {
                    frmKhassraValuation obj = new frmKhassraValuation();
                    obj.MdiParent = this;
                    obj.WindowState = this.WindowState;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuTextMessage_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = IsFrmOpen("frmSendSMS");

                if (!isOpen)
                {
                    frmSendSMS obj = new frmSendSMS();
                    obj.MdiParent = this;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TSMIIntiqalReports_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmIntiqalReport");

            if (!isOpen)
            {

                frmIntiqalReport obj = new frmIntiqalReport();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void TSMDetailedFard_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmDetailedFard");

            if (!isOpen)
            {

                frmDetailedFard obj = new frmDetailedFard();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void TSMRegSearch_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmRegistrySearch");

            if (!isOpen)
            {

                frmRegistrySearch obj = new frmRegistrySearch();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

      
        private void TSMStayOrder_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = IsFrmOpen("frmStayOrder");

                if (!isOpen)
                {
                    frmStayOrder obj = new frmStayOrder();
                    obj.MdiParent = this;
                    obj.WindowState = this.WindowState;
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuCovid19Booking_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmCovid19Booking");
            if (!isopen)
            {
                UsersManagments.check = 1;
                frmCovid19Booking tk = new frmCovid19Booking();
                tk.MdiParent = this;
                tk.WindowState = this.WindowState;
                //tk.WindowState =
                tk.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Booking Form'");

            }
        }

        private void tsmBultROAttestation_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmBulkROAttestation");
            if (!isopen)
            {
                
                frmBulkROCancellation BROA = new frmBulkROCancellation(); ;
                BROA.MdiParent = this;
                BROA.WindowState = this.WindowState;

                BROA.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Bulk Attestatio Form'");

            }
        }

        private void TSMGardawarVerification_Click(object sender, EventArgs e)
        {
       

            bool isopen = IsFrmOpen("frmBulkGardawarVerification");
            if (!isopen)
            {
               
                frmBulkGardawarVerification BROA = new frmBulkGardawarVerification(); ;
                BROA.MdiParent = this;
                BROA.WindowState = this.WindowState;

                BROA.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Bulk Gardawar Verification'");

            }
        }

        private void ٹوکنرولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersTokenRole TR = new frmUsersTokenRole(); ;
            TR.MdiParent = this;
            TR.WindowState = this.WindowState;

            TR.Show();
            }

        private void mnuTafseelKhassras_Click(object sender, EventArgs e)
        {

        }

        private void mnuRHZzerekar_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmRhzZerejar");
            if (!isOpen)
            {

                frmRhzZerejar obj = new frmRhzZerejar();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuRhzSDCEditing_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmRhzSDCEditing");
            if (!isOpen)
            {

                frmRhzSDCEditing obj = new frmRhzSDCEditing();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuIntiqalManual_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmIntiqalMainForManual");
            if (!isOpen)
            {

                frmIntiqalMainForManual obj = new frmIntiqalMainForManual();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuRhz_ChangeAdminDashboard_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmAdminPendingTaskDashboard");
            if (!isOpen)
            {

                frmAdminPendingTaskDashboard obj = new frmAdminPendingTaskDashboard();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubYaksalaQismZameen_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 25;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubYaksalMakhloot_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 26;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubDrFardTaxes_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 27;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId= UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubDraIntiqalPartTaxes_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 28;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubDraIntiqalatTaxes_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 29;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubInitqalatTehsildar_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 30;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubIntiqalRegistryPending_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 31;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubRegistryIntiqalatDetails_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 32;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void MnuSubREgistryIntiqalatDaily_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 33;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void MnuSubRtsMutaions_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 34;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubRtsFardats_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 35;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuReportMutForFBR_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 38;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubAttestedMutaions_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 54;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubCancelledInital_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 41;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnSubAntiCurIntiqal_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 36;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubAntiCurFardat_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 37;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubInitqalEntryByOperator_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 42;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void ایمآئاسسیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmMISC");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmMISC obj = new frmMISC();
                //obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuMisalManualFb_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmFardeBadarManual");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmFardeBadarManual obj = new frmFardeBadarManual();
                //obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuQabzulWasool_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmQabzUlWassol");

            if (!isOpen)
            {

                frmQabzUlWassol obj = new frmQabzUlWassol();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubIntiqalatAttestedNotImplemented_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 43;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSearchFardat_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmFardManhai");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmFardManhai obj = new frmFardManhai();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuIntiqalatInKhata_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmIntiqalatInKhata");
            if (!isOpen)
            {

                frmIntiqalatInKhata intiqal = new frmIntiqalatInKhata();
                intiqal.MdiParent = this;
                intiqal.WindowState = this.WindowState;
                intiqal.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Intiqalat In Khata'");
            }
        }

        private void TSMFardatForSR_Click(object sender, EventArgs e)
        {
            bool isopen = IsFrmOpen("frmRegFardDispatch");
            if (!isopen)
            {
                UsersManagments.check = 1;
                frmRegFardDispatch tk = new frmRegFardDispatch();
                tk.MdiParent = this;
                tk.WindowState = this.WindowState;
                //tk.WindowState =
                tk.Show();
                string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Fardat For Sub Regisrar Form'");

            }
        }

        private void TSMShortFard_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmShortFard");

            if (!isOpen)
            {
                frmShortFard fard = new frmShortFard();
                fard.MdiParent = this;
                fard.WindowState = this.WindowState;
                fard.Show();
            }
        }

        private void mnuUserVisibility_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmShortFard");

            if (!isOpen)
            {
                frmUsersVisibility fard = new frmUsersVisibility();
                fard.MdiParent = this;
                fard.WindowState = this.WindowState;
                fard.Show();
            }
        }

        private void mnuOtherDistrictTehsilFard_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmTokenOtherTehsil");

            if (!isOpen)
            {
                frmTokenOtherTehsil fard = new frmTokenOtherTehsil();
                fard.MdiParent = this;
                fard.WindowState = this.WindowState;
                fard.Show();
            }
        }

        private void mnuSubBiometricCapturedNotAttestIntiqalat_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 48;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubStateLandReport_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 49;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuTutorial_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmVidTut obj = new frmVidTut();
                obj.Show();
            }
        }

        private void mnuSubNotAttestedMut_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 52;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubUnAttestedMutOPM_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 52;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubMutAttNotImpl_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 53;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuInconsistentRpt_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 55;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void fmrDowraSchedule_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmDowraSchedule");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmDowraSchedule obj = new frmDowraSchedule();
                obj.Show();
            }
        }

        private void mnuCoBiometricNotAttested_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 48;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuEnteredMutationsReport_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 33;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuDePendingMut_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 56;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuDePendingMutCo_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 56;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuAdminRptAttMutAudit_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 57;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuRhzRptAdmin_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("RHZ");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                RHZ obj = new RHZ();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuRHZreport_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("RHZ");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                RHZ obj = new RHZ();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
            
            
        }

        private void mnuFardBadarEntryRpt_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 58;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void MnuRegEntryRptsm_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 59;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuRegEntryRptCo_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 59;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuKhanakashtDetail_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuTaskNonAdmin_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmAdminPendingTaskDashboard");
            if (!isOpen)
            {

                frmAdminPendingTaskDashboard obj = new frmAdminPendingTaskDashboard();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuMutationSummaryRptForRevMeeting_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 63;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void MnuKhanakashtSummary_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 62;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuKhanakashtDetails_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 64;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuUserAccounts_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmUserManagement");
            if (!isOpen)
            {
                frmUserManagement usermanagment = new frmUserManagement();
                //  frmUserManagement
                try
                {
                    usermanagment.MdiParent = this;
                    usermanagment.WindowState = this.WindowState;
                    usermanagment.Show();
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Users Management Form'");
                }
                catch (Exception ex)
                {
                    usermanagment.Dispose();
                }
            }
        }

        private void mnuUserRoles_Click_1(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("UserRolDefination");
            if (!isOpen)
            {
                UserRolDefination RoleDep = new UserRolDefination();
                //  frmUserManagement
                try
                {
                    RoleDep.MdiParent = this;
                    RoleDep.WindowState = this.WindowState;
                    RoleDep.Show();
                    string ObjAccessId = db.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Access_Details " + UsersManagments.LoginRecId + "," + UsersManagments._Tehsilid.ToString() + ",'Users Roles Definition Form'");
                }
                catch (Exception ex)
                {
                    RoleDep.Dispose();
                }
            }
        }

        private void mnuUserVisibility2_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmUsersVisibility");

            if (!isOpen)
            {
                frmUsersVisibility fard = new frmUsersVisibility();
                fard.MdiParent = this;
                fard.WindowState = this.WindowState;
                fard.Show();
            }
        }

        private void mnuMachineAccessControl_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmUsersMachinesAccessControls");

            if (!isOpen)
            {
                frmUsersMachinesAccessControls fard = new frmUsersMachinesAccessControls();
                fard.TabIndex = 1;
                fard.MdiParent = this;
                fard.WindowState = this.WindowState;
                fard.Show();
            }
        }

        private void mnuUserAccessControl_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmUsersMachinesAccessControls");

            if (!isOpen)
            {
                frmUsersMachinesAccessControls fard = new frmUsersMachinesAccessControls();
                fard.TabIndex = 0;
                fard.MdiParent = this;
                fard.WindowState = this.WindowState;
                fard.Show();
            }
        }

        private void mnuAdminRptInconKhatasTehsilwise_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 65;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuInconKhataHissasFarq_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 66;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuFardbadarAll_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 58;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuFardbadarImp_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 67;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuFardbadarCancel_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 68;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuFardbadarPending_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 69;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuTokenandService_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 70;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuInitqalforDawra_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 71;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuRoznamchaROorders_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmRozanamchaRoInst obj = new frmRozanamchaRoInst();
                obj.Show();
            }
        }

        private void mnuDRAIntiqalFeeDetailRpt_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 72;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuLandOwnersWithAcre_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 73;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuEmpryFardBader_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 74;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuMissingMut_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmIntiqalMissingReport");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmIntiqalMissingReport obj = new frmIntiqalMissingReport();
                //UsersManagments.check = 74;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                //obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuMonthlyTaxMut_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 75;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuBayabHalfiAdmin_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 76;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuBayanHalfiIntiqalatNonAdmin_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 77;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuSubInitqalEntryByOperatorNonAdmin_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 42;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuFardBadarEntryRptNonAdmin_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 58;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuTokenandServiceNonAdmin_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 70;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void mnuQismZameen_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmSDCReportingMain");

            if (!isOpen)
            {

                //UsersManagments.check = 2;
                frmSDCReportingMain obj = new frmSDCReportingMain();
                UsersManagments.check = 78;
                obj.Tehsilid = UsersManagments._Tehsilid.ToString();
                obj.SubSdcId = UsersManagments.SubSdcId.ToString();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }
     
    }
}
