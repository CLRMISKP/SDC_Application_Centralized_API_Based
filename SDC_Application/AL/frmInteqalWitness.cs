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
    public partial class frmInteqalWitness : Form
    {
        Persons pers = new Persons();
        LanguageConverter lang = new LanguageConverter();
        BL.frmToken objbusines = new BL.frmToken();
        public string IntiqalId { get; set; }
        public bool Attested { get; set; }
        public bool Amaldaramad { get; set; }
        public string MozaID { get; set; }
        Intiqal intiqal = new Intiqal();

        Persons Pr = new Persons();

        public frmInteqalWitness()
        {
            InitializeComponent();
        }
        private void frmInteqalWitness_Load(object sender, EventArgs e)
        {
            FillIntiqalWitnessGrid();
            AcceptButton = btnSaveWitness;
            btnReset_Click(sender, e);
           
            if (this.Attested || this.Amaldaramad)
            {
                btnSaveWitness.Enabled = false;
                btnDelWitness.Enabled = false;
                btnNewWitness.Enabled = false;
            }
        }

        #region GridView Fill Methods

        public void FillIntiqalWitnessGrid()
        {
            DataTable dt = new DataTable();
            dt = pers.GetIntiqalWitnessList(this.IntiqalId);
            GridWitnessDetails.DataSource = dt;
            if (dt != null)
            {
                GridWitnessDetails.Columns["personid"].Visible = false;
                GridWitnessDetails.Columns["IntiqalWitnessId"].Visible = false;
                GridWitnessDetails.Columns["IntiqalId"].Visible = false;
                GridWitnessDetails.Columns["PersonName"].Visible = false;
                GridWitnessDetails.Columns["Fathername"].Visible = false;
                GridWitnessDetails.Columns["Relation"].Visible = false;
                GridWitnessDetails.Columns["WitnessTypeId"].Visible = false;
                GridWitnessDetails.Columns["CompleteName"].HeaderText = "مکمل نام ";
                GridWitnessDetails.Columns["status"].HeaderText = "حیثیت ";
                GridWitnessDetails.Columns["cnic"].HeaderText = "شناختی کارڈنمبر ";
                GridWitnessDetails.Columns["Address"].HeaderText = "پتہ";
                GridWitnessDetails.Columns["Relation"].HeaderText = "رشتہ";
                GridWitnessDetails.Columns["Gender"].HeaderText = "جنس";
                GridWitnessDetails.Columns["CompleteName"].DisplayIndex = 1;
                GridWitnessDetails.Columns["status"].DisplayIndex = 2;
                GridWitnessDetails.Columns["Gender"].DisplayIndex = 3;
                GridWitnessDetails.Columns["cnic"].DisplayIndex = 4;
                GridWitnessDetails.Columns["Relation"].DisplayIndex = 5;
                GridWitnessDetails.Columns["Address"].DisplayIndex = 6;
            }

        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtWitnessFatherName.Text.Trim() != string.Empty && txtWittnessPersonName.Text.Trim() != string.Empty && txtWitnessCNIC.Text.Trim() != string.Empty)
            {
                string R_CNIC = Pr.CheckCNICWitness(txtWitnessCNIC.Text.Replace("-",""));
                if (R_CNIC == "-1")
                {
                    MessageBox.Show("  شناختی کارڈ نمبر" + txtWitnessCNIC.Text.Replace("-", "") + " مزید گواہی نہیں دے سکتا۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_PersonDetail_By_NIC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtWitnessCNIC.Text + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.txtPersonId.Text = dt.Rows[0]["PersonId"].ToString();
                    }
                }
                string WitnessId = txtWitnessId.Text.ToString();
                string IntiqalId = this.IntiqalId;
                string WitnessPersonId = txtWitnessPersonId.Text.ToString();
                string usrId = UsersManagments.UserId.ToString();
                string UsrName = UsersManagments.UserName.ToString();
                string PersonId = txtPersonId.Text.ToString();
                string PersonName = txtWittnessPersonName.Text.ToString();
                string FatherName = txtWitnessFatherName.Text.ToString();
                string CNIC = txtWitnessCNIC.Text.ToString();
                string Adress = txtWitnessAddress.Text;
                string MozaId = this.MozaID;
                string Gender;
                string WitnessTypeId;
                if (chkWitnessMale.Checked)
                {
                    Gender = chkWitnessMale.Text.ToString();
                }
                else
                {
                    Gender = chkWitnessFemale.Text.ToString();
                }

                if (rbWitness.Checked)
                {
                    WitnessTypeId = "3";
                }
                else if (rbBuyer.Checked)
                {
                    WitnessTypeId = "4";
                }
                else
                {
                    WitnessTypeId = "5";
                }

              
                string LastId = pers.SaveInteqalWitness(WitnessId, IntiqalId, WitnessPersonId, usrId, UsrName, usrId, UsrName, PersonId, PersonName, FatherName, CNIC, Gender, MozaId, Adress,WitnessTypeId);
                txtWitnessId.Text = LastId;
                btnSaveWitness.Enabled = false;
                //MessageBox.Show("گواہ کا اندراج ہوگیا ہے");
                FillIntiqalWitnessGrid();
                btnNewWitness.Enabled = true;
                btnReset_Click(sender, e);
            }
            else
            { MessageBox.Show("نام,والدیت اور شناختی کارڈ کا اندراج کریں","",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPersonId.Text = "-1";
            txtWitnessId.Text = "-1";
            txtWitnessPersonId.Text = "-1";
            btnSaveWitness.Enabled = true;
            btnDelWitness.Enabled = false;
            txtWittnessPersonName.Clear();
            txtWitnessFatherName.Clear();
            txtWitnessCNIC.Clear();
            chkWitnessMale.Checked = true;
            txtWitnessAddress.Clear();
            txtWittnessPersonName.Focus();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
            if (txtWitnessCNIC.TextLength > 16)
            {
                e.Handled = true;
            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAdress_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                intiqal.DeleteIntiqalWitness(txtWitnessId.Text);
                FillIntiqalWitnessGrid();
                btnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridWitnessDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {if(e.RowIndex!=-1)
        {

            try
            {
                DataGridView g = sender as DataGridView;
                if (e.ColumnIndex == GridWitnessDetails.CurrentRow.Cells["colChooseWitness"].ColumnIndex)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (GridWitnessDetails.SelectedRows.Count > 0)
                        {
                            if (this.Attested || this.Amaldaramad)
                            {
                                btnSaveWitness.Enabled = false;
                                btnDelWitness.Enabled = false;
                            }
                            else
                            {
                                btnSaveWitness.Enabled = true;
                                btnDelWitness.Enabled = true;
                            }
                            
                            if (row.Selected)
                            {
                                row.Cells["colChooseWitness"].Value = 1;
                                txtWitnessId.Text = row.Cells["IntiqalWitnessId"].Value.ToString();
                                txtPersonId.Text = row.Cells["personid"].Value.ToString();
                                txtWittnessPersonName.Text = row.Cells["PersonName"].Value.ToString();
                                txtWitnessFatherName.Text = row.Cells["Fathername"].Value.ToString();
                                txtWitnessCNIC.Text = row.Cells["cnic"].Value.ToString();
                                string gender = row.Cells["Gender"].Value.ToString();
                                if (gender == "مرد")
                                { chkWitnessMale.Checked = true; }
                                else { chkWitnessFemale.Checked = true; }
                                txtWitnessAddress.Text = row.Cells["Address"].Value.ToString();
                                string type = row.Cells["WitnesstypeId"].Value.ToString();
                                if (type == "4")
                                    rbBuyer.Checked = true;
                                else if (type == "5")
                                    rbSeller.Checked = true;
                                else
                                    rbWitness.Checked = true;

                            }
                            else
                            {
                                row.Cells["colChooseWitness"].Value = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
            }
        }}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtWitnessFatherName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWitnessCNIC_Leave(object sender, EventArgs e)
        {
            if (txtWitnessCNIC.TextLength == 13)
            {
                txtWitnessCNIC.Text=txtWitnessCNIC.Text.Insert(5, "-");
                txtWitnessCNIC.Text=txtWitnessCNIC.Text.Insert(13, "-");
            }
            else
            {
                MessageBox.Show("شناختی کارڈ نمبر غلط ہیں- دوبارہ درج کریں", "Invalid CNIC Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWitnessCNIC.Focus();
            }
           
        }

        private void btnSearchByNIC_Click(object sender, EventArgs e)
        {
            DataTable dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_PersonDetail_By_NIC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtWitnessCNIC.Text + "'");
            if (dt != null)
            {
               
                foreach (DataRow dr in dt.Rows)
                {
                    txtWittnessPersonName.Text = dr["PersonName"].ToString();
                    txtWitnessFatherName.Text = dr["Fathername"].ToString();
                    txtWitnessAddress.Text = dr["Address"].ToString();
                    this.txtPersonId.Text = dr["PersonId"].ToString();

                    }

                }
            
        }

      

    }
}
