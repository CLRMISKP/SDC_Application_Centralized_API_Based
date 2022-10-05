
using System;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using System.Data;
using SDC_Application.BL;

namespace SDC_Application
{
    public partial class frmSearchPersonForNaqalIntiqal : Form
    {
        #region Class varialbes

       // ClientServiceClient client = new ClientServiceClient();
        LanguageConverter Lang = new LanguageConverter();
        Search Srch = new Search();
      
        #endregion

        #region Properties
        public string MozaId { get; set; }

        public string PersonName="";
        public string personId = "";
       
        #endregion

        #region Default Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public frmSearchPersonForNaqalIntiqal()
        {
            InitializeComponent();
            
        }
        #endregion

        

        #region Find Button Clicked
        /// <summary>
        /// filters the person list of moza for specied name and return all matching records by assigning 
   
        private void btnFind_Click(object sender, EventArgs e)
        {
            string PName = txtPersonaName.Text;
            string PCNIC = txtCNIC.Text;
            string PTyep="1";
            string MozaId = this.MozaId;
            DataTable dt = new DataTable();

                if (txtCNIC.Text.Trim().Length==0)
                {
                    dt = Srch.GetSearchAfradList(MozaId, PTyep, PName);
                }
                else
                {
                    dt = Srch.GetSearchAfradListByCNICSelf(MozaId, PTyep, PCNIC);
                }
            
                GridViewPersons.DataSource = dt;
                GridViewPersons.Columns["PersonFullName"].HeaderText = "نام افراد";
                GridViewPersons.Columns["CNIC"].HeaderText = "شناختی کارڈ نمبر";
                GridViewPersons.Columns["PersonId"].Visible = false;
   }
        #endregion


        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPersonaName.Clear();
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #region Tooltip


        public void Tooltip()
        {
            toolTip1.SetToolTip(btnAccept, "منتخب شدہ فرد کا اندراج کریں");
            toolTip1.SetToolTip(btnCancel, "   واپس جائیں");
            toolTip1.SetToolTip(btnFind, "نام لکھ کر تلاش کریں");
            toolTip1.SetToolTip(txtCNIC, "شناختی کارڈ نمبر سے تلاش کریں");
        
        }
        #endregion

        #region Form Closing Button Actions
        /// <summary>
        /// assign selected person id and name to concerned properties and closes this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.GridViewPersons.Rows.Count > 0)
            {



                for (int i = 0; i <= GridViewPersons.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(GridViewPersons.Rows[i].Cells["cbgrid"].Value) == 1)
                    {

                       
                            personId += ';' + GridViewPersons.Rows[i].Cells["PersonId"].Value.ToString();
                       
                        if (PersonName.Length == 0)
                        {
                            PersonName = GridViewPersons.Rows[i].Cells["PersonFullName"].Value.ToString();
                        }

                        else
                        {

                            PersonName += ',' + GridViewPersons.Rows[i].Cells["PersonFullName"].Value.ToString();
                        }

                    }
                }
               // MessageBox.Show(personId);
                this.Close();
            }
            else
                this.Close();
        }

        /// <summary>
        /// close this form without any search result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private void txtPersonaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCNIC.Clear();
            if (e.KeyChar == Convert.ToChar((Keys.Back)))
            {

            }
            else
            {
                e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            }
        }

        private void frmSearchPerson_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            this.txtPersonaName.Focus();
            Tooltip();
        }

        private void txtPersonaName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnFind;
        }
        private void GridViewPersons_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAccept_Click(sender, e);
        }

        private void btnAndarajAfrad_Click(object sender, EventArgs e)
        {
            AL.frmAfradRegister afr = new AL.frmAfradRegister();
           // frmMain M = new frmMain();

            afr.MozaId = this.MozaId.ToString();
            afr.ShowDialog();

           //afr.MdiParent = M;
           //afr.WindowState = this.WindowState;
           //afr.Show();
            
           
        }

        private void GridViewPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex != -1)
            {
                GridViewPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == GridViewPersons.CurrentRow.Cells["cbgrid"].ColumnIndex)
                {
                    int b = Convert.ToInt32(GridViewPersons.CurrentRow.Cells["cbgrid"].Value);

                    if (b == 1)
                    {
                        GridViewPersons.CurrentRow.Cells["cbgrid"].Value = 0;
                    }
                    else
                    {
                        GridViewPersons.CurrentRow.Cells["cbgrid"].Value = 1; ;
                    }
                }
           }
        }

      
 
    }
}
