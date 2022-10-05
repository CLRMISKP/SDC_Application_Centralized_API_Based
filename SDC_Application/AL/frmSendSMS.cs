using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmSendSMS : Form
    {
        //SMS sms=new SMS();   
        public frmSendSMS()
        {
            InitializeComponent();
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
            try
            {

            //Set message text which you want to send 
            String messageText = txtMesage.Text;

            //Provide msisdn list to whom you want to send messages for multiple set value as 92345XXXXXXX,92345XXXXXXX 
            String to = "92345XXXXXXX";

            //Set mask value if you want to send from specific mask          
            String mask = "DC MARDAN";

            //Please provide correct username and password here of your account 
            String userName = "923451001296";
            String password = "SdcMrd@123456789"; // SdcMrd@1 for Web Portal
            SMS obj = new SMS(userName, password);
            String sessionId = obj.getSessionId();
            String messageIds = "";
            foreach (ListViewItem item in lvContactList.Items)
            {
                if (sessionId != null)
                {
                     messageIds = obj.sendQuickMessage(sessionId, messageText, item.Text, mask);
                }
            }
            if (messageIds.Contains("Error"))
            {
                MessageBox.Show("Unable to Send SMS.. Error Code=" + messageIds);
            }
                else
            {
                MessageBox.Show("SMS Sent to the listed receipients...");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Button Select Contacts for Messages

        private void btnSelectContact_Click(object sender, EventArgs e)
        {
            try
            {
                frmTokenPopulate frmtokenload = new frmTokenPopulate();
                frmtokenload.FormClosed -= new FormClosedEventHandler(frmtokenload_FormClosed);
                frmtokenload.FormClosed += new FormClosedEventHandler(frmtokenload_FormClosed);
                frmtokenload.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void frmtokenload_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTokenPopulate frmtoken = sender as frmTokenPopulate;
             ListViewItem item=new ListViewItem();
            item.Text=frmtoken.VisitorContactNo;
            lvContactList.Items.Add(item);
        }

        #endregion

        #region Clear Contact List

        private void btnClearNumbers_Click(object sender, EventArgs e)
        {
            lvContactList.Clear();
        }

        #endregion

    }
}