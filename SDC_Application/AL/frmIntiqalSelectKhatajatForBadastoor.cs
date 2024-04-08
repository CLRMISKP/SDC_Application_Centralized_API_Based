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
    public partial class frmIntiqalSelectKhatajatForBadastoor : Form
    {
        public DataTable dtKhatajat { get; set; }
        public string BadastoorKhata { get; set; }
        public string BadastoorKhataId { get; set; }
        private BL.Intiqal intiqal = new BL.Intiqal();
        public string IntiqalId { get; set; }
        public string MozaId { get; set; }
        public frmIntiqalSelectKhatajatForBadastoor()
        {
            InitializeComponent();
        }

        private void frmIntiqalSelectKhatajatForBadastoor_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in dtKhatajat.Rows)
            {
                
                clbKhatajat.Items.Add(row["KhataNo"]);
                lblBadastoorKhata.Text = BadastoorKhata;
            }
        }

        private void btnBadastoorMalikan_Click(object sender, EventArgs e)
        {
            if(this.BadastoorKhataId!=null && this.IntiqalId!=null &&  this.MozaId!=null)
            {
            if (this.BadastoorKhataId.Length > 5 && clbKhatajat.CheckedItems.Count > 0)
            {
                string KhataList = "";
                for (int i = 0; i < this.clbKhatajat.Items.Count; i++)
                {
                    if (clbKhatajat.GetItemChecked(i))
                    {
                        foreach (DataRow row in dtKhatajat.Rows)
                        {
                            if (row["KhataNo"].ToString() == clbKhatajat.Items[i].ToString())
                                KhataList = KhataList + row["IntiqalKhataId"].ToString() + ",";
                        }

                    }
                }
                KhataList = KhataList.TrimEnd(',');
                if (KhataList.Length > 5)
                {
                    intiqal.SaveIntiqalKhataMalkanBadastoorKhata(IntiqalId, MozaId, KhataList, BadastoorKhataId);
                    this.Close();
                }
                else
                    MessageBox.Show("کھاتہ جات کا انتخاب کریں");
                
            }
            }
        }
    }
}
