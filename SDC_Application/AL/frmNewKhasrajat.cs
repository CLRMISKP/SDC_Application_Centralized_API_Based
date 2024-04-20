using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmNewKhasrajat : Form
    {
        
        Intiqal inteq = new Intiqal();
        DataTable dt = new DataTable();
        DataTable malikanSel = new DataTable();
        DataTable MozaFamilies = new DataTable();
        DataTable FamilyPersons = new DataTable();
        UserMangement currentUsers = new UserMangement();
        TaqseemNewKhataJatMin taqseem = new TaqseemNewKhataJatMin();
        public string RegisterhaqkhataId { get; set; }
        public string IntiqalId { get; set; }
        public string KhataId { get; set; }
        public string khatoniid { get; set; 
       // var items = checkedListBox1.Items;
        }
        public bool byKhata { get; set; }
        
        public frmNewKhasrajat()
        {
            InitializeComponent();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.grdKhasrajat.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["chk"].Value = !(Boolean)(row.Cells["chk"].Value != null ? row.Cells["chk"].Value : false);
                }
            }
        }

        private void chkkhasrajat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in this.grdKhasrajat.Rows)
                {
                    if (chkkhasrajat.Checked == true)
                    {
                        //row.Cells["chk"].Value = !(Boolean)(row.Cells["chk"].Value != null ? row.Cells["chk"].Value : false);
                        row.Cells["chk"].Value = true;
                    }
                    else
                    {
                        row.Cells["chk"].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show();
            }
        }

        private void frmNewKhasrajat_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            if(byKhata)
            {
                dt = taqseem.Proc_Get_KhassraJatByKhataId(RegisterhaqkhataId);
            }
            else
            {
                dt = taqseem.Proc_Get_KhassraJatByIntiqalId(IntiqalId);
            }
           grdKhasrajat.DataSource = dt;
           grdKhasrajat.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
           grdKhasrajat.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
           grdKhasrajat.Columns["RegisterHqDKhataId"].Visible = false; 
           grdKhasrajat.Columns["KhassraId"].Visible=false;    
           grdKhasrajat.Columns["KhassraDetailId"].Visible=false;   
           grdKhasrajat.Columns["KhatooniNo"].Visible=true;
           grdKhasrajat.Columns["KhatooniId"].Visible = false;    
           grdKhasrajat.Columns["AreaTypeId"].Visible=false;         
           grdKhasrajat.Columns["AreaType"].Visible=false;        
           grdKhasrajat.Columns["Khassra_Area"].Visible=false;

           this.FormBorderStyle = FormBorderStyle.FixedDialog;           
           this.MaximizeBox = false;           
           this.MinimizeBox = false;           
           this.StartPosition = FormStartPosition.CenterScreen; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtKhasraNo.Text = "";
                foreach (DataGridViewRow row in this.grdKhasrajat.Rows)
                {
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        if (row.Cells["KhassraNo"].Value == checkedListBox1.Items[i])
                        {
                            string khasraid = row.Cells["KhassraId"].Value.ToString();
                            string khatooniid = row.Cells["KhatooniId"].Value.ToString();
                            string lastid = taqseem.WEB_SP_INSERT_KhassraRegister_Intiqal_Taqseem(khasraid, khatoniid, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                        }
                    }
                }
                MessageBox.Show("خسرہ جات محفوظ ہوگیے", "خسرہ جات", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           
        }

        private void grdKhasrajat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    bool allow = true;
                    bool check_status = Convert.ToBoolean(grdKhasrajat.CurrentRow.Cells["chk"].Value);
                    if (check_status == false)
                    {
                        grdKhasrajat.CurrentRow.Cells["chk"].Value = true;
                        bool update_status = Convert.ToBoolean(grdKhasrajat.CurrentRow.Cells["chk"].Value);
                        if (update_status == true)
                        {
                            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                            {
                                if (checkedListBox1.Items[0] == grdKhasrajat.CurrentRow.Cells["KhassraNo"].Value)
                                {
                                    allow = false;
                                }
                                else
                                {
                                    allow = true;
                                }
                            }
                        if(allow)
                          {
                         checkedListBox1.Items.Add(grdKhasrajat.CurrentRow.Cells["KhassraNo"].Value.ToString(), true);
                          }
                          }
                    }
                    else
                    {
                    grdKhasrajat.CurrentRow.Cells["chk"].Value = false;                        
                    }

                    if(Convert.ToBoolean(this.grdKhasrajat.CurrentRow.Cells["chk"].Value)==false)
                    {
                        for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.Items[i] == grdKhasrajat.CurrentRow.Cells["KhassraNo"].Value)
                            {
                                checkedListBox1.Items.RemoveAt(i);
                            }

                        } 
                    }
                    
                }
               
            }
            catch (Exception ex)
            { 
            }
        }

        

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if (e.NewValue == CheckState.Unchecked)
            //{
            //   // MessageBox.Show("new");
            //    e.NewValue = CheckState.Unchecked;
            //}
        }

        private void txtKhasraNo_TextChanged(object sender, EventArgs e)
        {
            string No = this.txtKhasraNo.Text;
            this.fillgrid_byfilter("KhassraNo like '%" + No + "%'");
        }

        public void fillgrid_byfilter(string Condition)
        {
            if (dt != null)
            {
                DataView v = new DataView(dt);
                v.RowFilter = Condition;
                this.grdKhasrajat.DataSource = v;
            }

        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            CheckedListBox clb = (CheckedListBox)sender;
            
            int index = clb.SelectedIndex;

           if (index != -1 && clb.GetItemCheckState(index) == CheckState.Unchecked)
            {
                clb.Items.RemoveAt(index);
            }

        }

        private void txtKhatooniNo_TextChanged(object sender, EventArgs e)
        {
            string No = this.txtKhatooniNo.Text;
            this.fillgrid_byfilter("KhatooniNo like '%" + No + "%'");
        }
        
        
    }
}
