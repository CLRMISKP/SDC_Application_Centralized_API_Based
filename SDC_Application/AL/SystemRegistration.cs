using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.DL;
using SDC_Application.BL;
using SDC_Application.Classess;
using System.Net.NetworkInformation;
using System.Net.Sockets;
namespace SDC_Application.AL
{
    public partial class frmSystemRegistration : Form
    {
        Database ojbdb = new Database();
        UserMangement usm = new UserMangement();
        APIClient client = new APIClient();
        public int TehsilIdSelected = -1;
        public frmSystemRegistration()
        {
            InitializeComponent();
        }

        private void SystemRegistration_Load(object sender, EventArgs e)
        {
            string spWithParam = "Proc_Entry_DistrictsAll ";//+ Login + "', '" + ver + "', '" + Password + "'," + tehsilId;
            DataTable districts = client.GetDistrictList(UsersManagments.userToken); //ojbdb.filldatatable_from_storedProcedure(spWithParam);
            if (districts != null)
            {
                this.cmdDistrict.DataSource = districts;
                cmdDistrict.DisplayMember = "DistrictnameUrdu";
                cmdDistrict.ValueMember = "DistrictId";
            }
            macList.DataSource = getmacs();
            macList.Text = getmac_default();
            ipList.DataSource = GetAllLocalIPv4(NetworkInterfaceType.Ethernet);
            txtMachineName.Text = System.Environment.MachineName;
            cboCounter.SelectedIndex = -1;

        }

        public String[] getmacs()
        {

            String[] aaa =
                        (
                            from nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                            // where nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up
                            select nic.GetPhysicalAddress().ToString()
                        ).ToArray();

            //foreach(String str in aaa) Console.WriteLine(str);
            return aaa;

        }
        public String getmac_default()
        {

            String aaa =
                        (
                            from nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                            where nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up
                            select nic.GetPhysicalAddress().ToString()
                        ).FirstOrDefault();

            //  foreach (String str in aaa) Console.WriteLine(str);
            return aaa;

        }

        public static string[] GetAllLocalIPv4(NetworkInterfaceType _type)
        {
            List<string> ipAddrList = new List<string>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddrList.Add(ip.Address.ToString());
                        }
                    }
                }
            }
            return ipAddrList.ToArray();
        }
        private void cmdDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string distirctid = "";
            distirctid = cmdDistrict.SelectedValue.ToString();

            int selectedIndex = cmdDistrict.SelectedIndex;


            if (cmdDistrict.SelectedValue.GetType() != typeof(System.Int32)) return;
            System.Int32 selectedValue = (System.Int32)cmdDistrict.SelectedValue;
            if (distirctid != "")
            {
                string spWithParam = "Proc_Entry_Tehsils  " + selectedValue.ToString();//+ Login + "', '" + ver + "', '" + Password + "'," + tehsilId;
                DataTable tehsils = client.GetTehsilList(selectedValue.ToString(), UsersManagments.userToken);
                this.cmbTehsil.DataSource = tehsils;
                if(tehsils!= null)
                {
                    cmbTehsil.DisplayMember = "TehsilNameUrdu";
                    cmbTehsil.ValueMember = "TehsilId";
                }
               
            }
        }

        private void cmbTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbTehsil.SelectedValue.GetType() != typeof(System.Int32)) return;
            //System.Int32 selectedValue = (System.Int32)cmbTehsil.SelectedValue;
            ////if (cmbTehsil != "")
            //{
            //    //MessageBox.Show(selectedValue.ToString());
            //    TehsilIdSelected = selectedValue;
            //}
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            //Database objDb = new Database();
            //ojbdb.ExecStoredProcedure(            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "" || txtPass.Text.Trim()=="")
            {
                MessageBox.Show("User Name & Password must entered", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          try
            {
                string login = txtUser.Text.Trim();
                string password = txtPass.Text.Trim();
                string encPass = Crypto.getEncryptedCode(txtPass.Text.Trim());
                DataTable UserInfo = new DataTable();
                string SpWithParam = "CLRMIS_getAdminUserInfo '" + txtUser.Text + "','" + encPass+"'";
                UserInfo = ojbdb.GetUserInfoForMachineReg(SpWithParam); //usm.GetUserInfo(txtUser.Text, encPass);
              String error ="";
              int retVal = 0;
              //UserInfo = usm.GetUserInfo2(txtUser.Text, encPass,out error, out retVal);
              if(UserInfo!=null)
                { 
                if (UserInfo.Rows.Count > 0)
                {
                    
                    int v;
                    if (Int32.TryParse(UserInfo.Rows[0]["TehsilId"].ToString(), out v))
                    {
                        if (v == -1)
                        {
                            cmbTehsil.Enabled = true;
                            cmdDistrict.Enabled = true;
                            cmdDistrict.Focus();
                        }
                        else
                        {   
                            UsersManagments._Tehsilid = v;
                            cmdDistrict.SelectedValue = UserInfo.Rows[0]["DistrictId"].ToString();
                                cmdDistrict_SelectionChangeCommitted(sender, e);
                                //cmbTehsil.SelectedValue = UserInfo.Rows[0]["TehsilId"].ToString();
                                cmbTehsil.Enabled = true;
                                cmdDistrict.Enabled = false;
                                cboCounter.Focus();
                        }
                    }
                   

                    btnAdd.Enabled = true;
                 


                  
                }
                }
            }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

//            macList.Items.Cast<String>().Select(s=> )

            String mac = string.Join("," ,  macList.Items.Cast<String>().Select(p=> p.ToString() ));
            String ip = string.Join(",", ipList.Items.Cast<String>().Select(p => p.ToString()));
            if (cboCounter.SelectedItem == null)
            {
                MessageBox.Show("Kindly select the counter");
                this.cboCounter.Focus();
                return;
            }
            String s = "CLRMIS_SystemRegistrationLog_ins '" + txtMachineName.Text.ToString() + "','" + mac + "','" + ip + "','" + txtUser.Text.ToString() + "','" + cmbTehsil.SelectedValue.ToString() + "','" + cboCounter.SelectedItem.ToString() + "'";
            ojbdb.ExecInsertUpdateStoredProcedure(s);
            MessageBox.Show("Registered Successfuly");
            if (UsersManagments._Tehsilid==0)
            {
                UsersManagments._Tehsilid=  (Int32) (cmbTehsil.SelectedValue);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cmdDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string distirctid = "";
            distirctid = cmdDistrict.SelectedValue.ToString();

            int selectedIndex = cmdDistrict.SelectedIndex;


            
            if (distirctid != "")
            {
                string spWithParam = "Proc_Entry_Tehsils  " + distirctid;//+ Login + "', '" + ver + "', '" + Password + "'," + tehsilId;
                DataTable tehsils = client.GetTehsilList(distirctid, UsersManagments.userToken);
                this.cmbTehsil.DataSource = tehsils;
                if (tehsils != null)
                {
                    cmbTehsil.DisplayMember = "TehsilNameUrdu";
                    cmbTehsil.ValueMember = "TehsilId";
                }
            }
        }

        private void cmbTehsil_SelectionChangeCommitted(object sender, EventArgs e)
        {

            TehsilIdSelected =int.Parse(cmbTehsil.SelectedValue.ToString()) ;
            
        }
    }
}
