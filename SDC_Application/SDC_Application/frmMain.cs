﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.AL;
using System.Configuration;


namespace SDC_Application
{
    public partial class frmMain : Form
    {

        #region Class Variables
        // public int Check { get; set; }
        public int MozaIDforRep { get; set; }
        public string roleid { get; set; }
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
            DialogResult res= MessageBox.Show("Are You Sure to Close the DLRR Application", "Confirm to Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                e.Cancel = false;
                db.UserLogout("", UsersManagments._Tehsilid.ToString(), UsersManagments.UserToken);
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
            
            checkForAdmin();
            loadUserRoles();
            CheckMenus();
            GetNavigationMenuRights();
            if (UsersManagments.UserName.Contains("Admin"))
            {
                mnucreateUsers.Visible = true;
            }
            else
            {
                mnucreateUsers.Visible = false;
            }
            //UsersManagments._Tehsilid = u;// Convert.ToInt32( ConfigurationSettings.AppSettings["Tehsil"]);
            BL.AreaProfile af=new BL.AreaProfile();
            DataTable dt = af.GetDistTehsilNames(UsersManagments._Tehsilid.ToString());//ConfigurationSettings.AppSettings["Tehsil"]);
            string DistNameUrdu="";
            string DistNameEng="";
            string TehsilNameUrdu="";
            string TehsilNameEng="";
            foreach(DataRow r in dt.Rows)
            {
                DistNameEng = r["DistrictNameEng"].ToString();
                DistNameUrdu=r["DistrictnameUrdu"].ToString();
                TehsilNameEng=r["TehsilNameEng"].ToString();
                TehsilNameUrdu=r["TehsilNameUrdu"].ToString();
            }
            this.lblSDCTitle.Text = "   مرکز ترسیل سہولیات -   "+TehsilNameUrdu +" | Service Delivery Center -  Tehsil  " +TehsilNameEng+" - District - "+DistNameEng ;

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
            
            
           role=db.filldatatable_from_storedProcedure("Proc_Get_AdminUserRoleId "+UsersManagments.UserId.ToString());
            foreach(DataRow row in role.Rows)
            {
                roleid = row["RoleId"].ToString();
            }
            if (roleid != null)
            {
                roledetail = db.filldatatable_from_storedProcedure("Proc_Get_Admin_RolesDetail_SDC " + roleid.ToString());
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
            this.mnucreateUsers.Visible = isMenuVisible("frmUserManagement");
            this.mnucreaTRoles.Visible = isMenuVisible("UserRoleDefination");
            this.ToolStripMenuCorrection.Visible = isMenuVisible("frmMisalMain");
            this.mnuKhataLock.Visible = isMenuVisible("frmKhattaLocking");
            this.mnuMalkanSearchandMerging.Visible = isMenuVisible("frmMalkanSearchingMerging");
            this.mnuInsertLoginDetails.Visible = isMenuVisible("frmUserLogs");
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
                if (menuName == objects)
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
            bool isOpen = IsFrmOpen("frmNaqalIntiqal");
             if (!isOpen)
             {
                 frmNaqalIntiqal s = new frmNaqalIntiqal();
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

        private void creaTRolesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void mnuTafseelKhatas_Click(object sender, EventArgs e)
        {
            bool isOpen = IsFrmOpen("frmKhattaSearchByPerson");
            if (!isOpen)
            {
                frmKhattaSearchByPerson KhattaSearch = new frmKhattaSearchByPerson();
                //  frmUserManagement
                try
                {
                    //RoleDep.MdiParent = this;
                    // KhattaSearch.WindowState = this.WindowState;
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
                obj.ShowDialog();
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

                frmRevenueDashboard obj = new frmRevenueDashboard();
                obj.MdiParent = this;
                obj.WindowState = this.WindowState;
                obj.Show();
            }
        }

        private void toolStripPicIndexing_Click(object sender, EventArgs e)
        {
            frmPictureIndexMain m = new frmPictureIndexMain();
            m.MdiParent = this;
            m.ThesilId = 15;
            m.Show();
        }

        private void فردToolStripMenuItem_Click(object sender, EventArgs e)
            {
            frmFard fard = new frmFard();
            fard.MdiParent = this;
            fard.Show();
            }

        private void mnuKhassraGardawri_Click(object sender, EventArgs e)
        {
            frmKhassraGardawri fard = new frmKhassraGardawri();
            fard.MdiParent = this;
            fard.Show();
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
    }
}
