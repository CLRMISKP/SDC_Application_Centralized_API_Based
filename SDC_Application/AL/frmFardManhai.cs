using SDC_Application.BL;
using SDC_Application.Classess;
using SDC_Application.DL;
using SDC_Application.LanguageManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace SDC_Application.AL
{
    public partial class frmFardManhai : Form
    {
        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();

        Database db = new Database();
        DataTable dtkj = new DataTable();
        DataTable dtFrd = new DataTable();
        DataTable dtIntql = new DataTable();

        Misal misal = new Misal();

        long khewatGrpid;
        long personid;
        long khewatgrpfareeqid;
        long FardKhataRecId;
       
        


        public frmFardManhai()
        {
            InitializeComponent();
        }

        private void frmFardManhai_Load(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            dtFrd.Columns.Add("ٹوکن تاریخ");
            dtFrd.Columns.Add("ٹوکن نمبر");

            dtIntql.Columns.Add("تاریخ اندراج");
            dtIntql.Columns.Add("انتقال نمبر");
            
        }

        public void Fill_Khata_DropDown()
        {
               try
            {
            
                dtkj = misal.GetKhatajatByMoza(Convert.ToInt32(cmbMouza.SelectedValue.ToString()));
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cbokhataNo.DataSource = dtkj;
                cbokhataNo.DisplayMember = "KhataNo";
                cbokhataNo.ValueMember = "RegisterHqDKhataId";
                cbokhataNo.SelectedValue = 0;
            }
            catch (Exception ex)
           {
                MessageBox.Show(ex.Message);
           }
        }

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Fill_Khata_DropDown();
        }

        void serch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson p = sender as frmSearchPerson;
            
          
            if (p.IsForKhata)
            {
                this.txtPersonName.Text = p.PersonName;
                this.personid = p.PersonId;
             
            }
        }
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrWhiteSpace(cbokhataNo.SelectedValue.ToString()))
            {
                MessageBox.Show("تلاش کرنے سے پہلے کہاتے کا انتخاب کریں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmSearchPerson serch = new frmSearchPerson();
            serch.KhataId = cbokhataNo.SelectedValue.ToString();
           
            serch.IsForKhata = true;
            serch.FormClosed -= new FormClosedEventHandler(serch_FormClosed);
            serch.FormClosed += new FormClosedEventHandler(serch_FormClosed);
            serch.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qry;

            dtFrd.Clear();
            dtIntql.Clear();

            SqlDataReader rdr = null;
            
            qry = "select KhewatGroupId from KhewatShirakatGroups where RegisterHqDKhataId = " + cbokhataNo.SelectedValue;

            khewatGrpid = long.Parse( db.ExecInsertUpdateStoredProcedure(qry)); //Database.ExecuteQuery(qry);
            
            //if(rdr.Read()) 
            //    khewatGrpid = rdr.GetInt32(0);
            //rdr.Close();
            //khewatGrpid = khewatGrpid;

            qry = "select KhewatGroupFareeqId from KhewatGroupFareeqein where PersonId in (" + personid + ") and KhewatGroupId = " + khewatGrpid +
                      " and RecStatus = 1";

            //rdr = db.fillDataReader(qry);//Database.ExecuteQuery(qry);
            //if(rdr.Read())
            //    khewatgrpfareeqid = Convert.ToInt64(rdr.GetValue(0));
            //rdr.Close();
            khewatgrpfareeqid = long.Parse(db.ExecInsertUpdateStoredProcedure(qry));
            
            qry = "select FardKhataRecId from SDC_Fard_KhewatGroupFareeqain where KhewatGroupFareeqId in (" + khewatgrpfareeqid +
                ") and ISNULL(isTransactional,0)= 1";
            //rdr = db.fillDataReader(qry);//Database.ExecuteQuery(qry);
            //if(rdr.Read())
            //    FardKhataRecId = Convert.ToInt64(rdr.GetValue(0));
            //rdr.Close();
            FardKhataRecId = long.Parse(db.ExecInsertUpdateStoredProcedure(qry));
            
           qry = "select FardTokenId from SDC_FardKhattajat where FardKhataRecId in (" + FardKhataRecId + ")";
           //rdr = db.fillDataReader(qry);//Database.ExecuteQuery(qry);
           //ArrayList frdTokenIds = new ArrayList();
           // while (rdr.Read())
           // {
           //     frdTokenIds.Add(Convert.ToInt64(rdr.GetValue(0)));
           // }
           // rdr.Close();
            DataTable frdTokenIds=new DataTable();
            frdTokenIds = db.filldatatable_from_storedProcedure(qry);

            
            foreach (DataRow  t in frdTokenIds.Rows)
            {
                qry = "select TokenDate, TokenNo from SDC_Tokens where TokenId in (" + t[0].ToString() +")";

                DataTable dt = db.filldatatable_from_storedProcedure(qry);//Database.ExecuteQuery(qry);
               
              
                foreach(DataRow row in dt.Rows)
                {
                    DataRow dr = dtFrd.NewRow();
                    dr["ٹوکن تاریخ"] = Convert.ToDateTime(row[0]);
                    dr["ٹوکن نمبر"] = Convert.ToInt32(row[1]);
                    dtFrd.Rows.Add(dr);
                }
            }
           
            dgFardat.DataSource = dtFrd;

            
            qry = "select im.InsertDate,im.IntiqalNo from Intiqal_Sellers S " +
                  "inner join Intiqal_KhataJat IK on s.IntiqalKhataRecId = ik.IntiqalKhataRecId " +
                  "inner join Intiqal_Main IM on Ik.IntiqalId = IM.IntiqalId " +
                  "where S.KhewatGroupFareeqId in (" + khewatgrpfareeqid + ") " +
                  "and ISNULL(IM.IntiqalPending,0) = 0 and ISNULL(IM.AmalDaramadStatus,0)= 0 ";

            DataTable dtIntiqal = db.filldatatable_from_storedProcedure(qry);
            //rdr = db.fillDataReader(qry);//Database.ExecuteQuery(qry);
            foreach(DataRow row in dtIntiqal.Rows)
            {
                DataRow drI = dtIntql.NewRow();
                drI["تاریخ اندراج"] = Convert.ToDateTime(row[0]);
                drI["انتقال نمبر"] = Convert.ToString(row[1]);
                dtIntql.Rows.Add(drI);
            }
            //rdr.Close();
          
            dgIntiqals.DataSource = dtIntql;
        }

        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
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

    }
}
