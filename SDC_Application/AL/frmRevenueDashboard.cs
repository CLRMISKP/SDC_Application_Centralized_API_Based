using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDC_Application.AL
{
    public partial class frmRevenueDashboard : Form
    {
        public frmRevenueDashboard()
        {
            InitializeComponent();
        }

        private void frmRevenueDashboard_Load(object sender, EventArgs e)
        {
            //BL.UserMangement
            //BL.Users;
            refreshDashBoard();
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Elapsed += (sender1, eventarg) =>
             {
                 String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
                 if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

                 refreshDashBoard();
             };

            timer.Enabled = true;
        }

        void refreshDashBoard()
        {
            try
            {

            BL.Persons person = new BL.Persons();
            
            DataTable dt = person.getDashBoard(Classess.UsersManagments.UserId);
            if(dt!=null && dt.Rows.Count != 0)
            {
                lblDBMutationReadyForAttestation.BeginInvoke((MethodInvoker)delegate ()
                 {
                    lblDBMutationReadyForAttestation.Text =  dt.Rows[0].Field<int>("MutationForAttestation").ToString();
                 });
                 lblDBMutationAttested.BeginInvoke((MethodInvoker)delegate ()
                  {
                    lblDBMutationAttested.Text = dt.Rows[0].Field<int>("MutationAttested").ToString();
                  });

                 lblDBMutationInDE.BeginInvoke((MethodInvoker)delegate ()
                  {
                     lblDBMutationInDE.Text =  dt.Rows[0].Field<int>("MutationInDataEntery").ToString();
                  });

                 lblDBMutationAttestationUnimplemented.BeginInvoke((MethodInvoker)delegate ()
                  {
                     lblDBMutationAttestationUnimplemented.Text =  dt.Rows[0].Field<int>("MutationAttestedNotImplemented").ToString();
                  });

                 lblDBElFrdBdrForAttestation.BeginInvoke((MethodInvoker)delegate ()
                  {
                     lblDBElFrdBdrForAttestation.Text = dt.Rows[0].Field<int>("FardBadarForAttestation").ToString();
                  });

                 lblDBElFrBdrAttested.BeginInvoke((MethodInvoker)delegate ()
                  {
                   lblDBElFrBdrAttested.Text = dt.Rows[0].Field<int>("FardBadarAttested").ToString();
                  });

                 lblDBElFrdBdrInDE.BeginInvoke((MethodInvoker)delegate ()
                  {
                    lblDBElFrdBdrInDE.Text = dt.Rows[0].Field<int>("FardBadarInDataEntery").ToString();
                  });
  
 
               

            }

            }
            catch (Exception ex)
            {

               //
            }
        }

        private void txtDBAttestationUnimplemented_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshDashBoard();
        }
    }
}
