using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.BL;
using SDC_Application.DL;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmSearchPersonInAllMouzas : Form
    {



        Intiqal intt = new Intiqal();
        DataTable dt = new DataTable();
        LanguageConverter lang = new LanguageConverter();
        public string mozaid { get; set; }
        public frmSearchPersonInAllMouzas()
        {
            InitializeComponent();
        }

        private void frmSearchinAfradRegister_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            grid("0","0");
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen; 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

            char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                btnsearch_Click(sender, e);
               
            }
            
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string personname = this.txtPersonName.Text.Trim();
            string fatherName = this.txtFatherName.Text.Trim();
            grid(fatherName,personname);

        }

        public void grid(string FatherName,string name)
        {
            dt = intt.GetSearchedPersonListforAllMouzas(name, FatherName);
            this.dataGridView1.DataSource = dt;
            if (dt != null)
            {
                // string personname = this.textBox1.Text.ToString();
                // dt = intt.Proc_Get_Searched_Afrad_With_Family_Head("0", "");
                // this.dataGridView1.DataSource = dt;
                this.dataGridView1.Columns["CompleteName"].HeaderText = "نام";
                this.dataGridView1.Columns["CNIC"].HeaderText = "شناختی کارڈ نمبر";
                this.dataGridView1.Columns["Sakna"].HeaderText = "سکنہ ";
                this.dataGridView1.Columns["Address"].HeaderText = "مکمل پتہ";
                this.dataGridView1.Columns["MozaNameUrdu"].HeaderText = "موضع ";
                this.dataGridView1.Columns["PersonId"].Visible = false;
            }
        }
    }
}
