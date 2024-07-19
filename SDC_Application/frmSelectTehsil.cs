using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.DL;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SDC_Application
{
    public partial class frmSelectTehsil : Form
    {
        Database ojbdb = new Database();
        public int TehsilIdSelected  = -1;
        public frmSelectTehsil()
        {
            InitializeComponent();
        }

        private void frmSelectTehsil_Load(object sender, EventArgs e)
        {
            //DataTable districts = ojbdb.fillDataTable(
               string spWithParam = "Proc_Entry_DistrictsAll ";//+ Login + "', '" + ver + "', '" + Password + "'," + tehsilId;
               DataTable districts = ojbdb.filldatatable_from_storedProcedure(spWithParam);
               this.cmdDistrict.DataSource = districts;
               cmdDistrict.DisplayMember = "DistrictnameUrdu";
               cmdDistrict.ValueMember = "DistrictId";
   
              
        }

        private void cmdDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string distirctid = "";
            distirctid = cmdDistrict.SelectedValue.ToString();

            int selectedIndex = cmdDistrict.SelectedIndex;


            if(cmdDistrict.SelectedValue.GetType() != typeof(System.Int32))return;
            System.Int32 selectedValue = (System.Int32)cmdDistrict.SelectedValue;
            if (distirctid != "")
            {
                string spWithParam = "Proc_Entry_Tehsils  " + selectedValue.ToString();//+ Login + "', '" + ver + "', '" + Password + "'," + tehsilId;
                DataTable tehsils = ojbdb.filldatatable_from_storedProcedure(spWithParam);
                this.cmbTehsil.DataSource = tehsils;

                cmbTehsil.DisplayMember = "TehsilNameUrdu";
                cmbTehsil.ValueMember = "TehsilId";
            }
        }

        private void cmbTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTehsil.SelectedValue.GetType() != typeof(System.Int32)) return;
            System.Int32 selectedValue = (System.Int32)cmbTehsil.SelectedValue;
            //if (cmbTehsil != "")
            {
                //MessageBox.Show(selectedValue.ToString());
                TehsilIdSelected = selectedValue;
            }
        }

      

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        public String[] getmacs()
        {
            String[] aaa =
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    let macAddress = nic.GetPhysicalAddress().ToString()
                    where !macAddress.StartsWith("00090F") && !macAddress.StartsWith("005056")
                    select macAddress
                ).ToArray();

            // Optionally print each MAC address (commented out)
            // foreach(String str in aaa) Console.WriteLine(str);

            // Return the array of MAC addresses
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

        private void ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
