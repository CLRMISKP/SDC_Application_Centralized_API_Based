using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmNaqalIntiqal : Form
    {

        #region Class Variables and Properties

        BL.frmToken objbusines = new BL.frmToken();

        public string TokenNo { get; set; }

        public string TokenId { get; set; }

        public string MozaId { get; set; }

        public string Intiqalid { get; set; }

        List<Person> IntiqalSellers = new List<Person>();
        List<Person> IntiqalBuyers = new List<Person>();

        DataTable IntiqalList = new System.Data.DataTable();

        public byte[] ReceivedImage { get; set; }
        public string ImageType { get; set; }

        string ToSaveFileTo = "";

        #endregion

        public frmNaqalIntiqal()
        {
            InitializeComponent();
        }

        private void frmNaqalIntiqal_Load(object sender, EventArgs e)
        {

        }

        #region Load Token Details


        private void btnLoadToken_Click(object sender, EventArgs e)
        {
            try
            {
                frmTokenPopulate Populate = new frmTokenPopulate();
                Populate.ServiceTypeId = GetServiceTypeIdByServiceName("Inteqal");
                Populate.FormClosed -= new FormClosedEventHandler(Populate_FormClosed);

                Populate.FormClosed += new FormClosedEventHandler(Populate_FormClosed);
                Populate.InteqalMain = true;
                Populate.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        void Populate_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmTokenPopulate Populate = sender as frmTokenPopulate;
                this.TokenId = Populate.TokenID;
                txtTokenNo.Text = Populate.TokenNo;
                this.MozaId = (Populate.Mouzaid != null && Populate.Mouzaid != "") ? Populate.Mouzaid : "0";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Get ServiceTypeId by Service Name

        private string GetServiceTypeIdByServiceName(string ServiceNameEng)
        {
            string ServiceTypeId = "0";
            DataTable dtServiceTypes = new DataTable();
            dtServiceTypes = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_ServiceTypes_ByServiceTypeName '" + ServiceNameEng + "'");
            if (dtServiceTypes != null)
            {
                if (dtServiceTypes.Rows.Count > 0)
                    ServiceTypeId = dtServiceTypes.Rows[0][0].ToString();
            }
            return ServiceTypeId;
        }

        #endregion

        #region Search Intiqal Sellers


        private void btnSearchSeller_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text.Trim().Length > 0)
            {
                frmSearchPerson Sp = new frmSearchPerson();
                Sp.MozaId = this.MozaId;
                Sp.FormClosed -= new FormClosedEventHandler(Sp_FormClosed);
                Sp.FormClosed += new FormClosedEventHandler(Sp_FormClosed);
                Sp.ShowDialog();

            }
            else
            {
                MessageBox.Show("تلاش کرنے سے پہلے ٹوکن لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Sp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson ap = sender as frmSearchPerson;
            Person p = new Person();
            p.PersonId = ap.PersonId.ToString();
            IntiqalSellers.Add(p);
            this.txtSellerName.Text += this.txtSellerName.Text.Length > 2 ? "," + ap.PersonName : ap.PersonName;

        }

        #endregion

        #region Search Intiqal Buyers

        private void btnSearchBuyers_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text.Trim().Length > 0)
            {
                frmSearchPerson Buyer = new frmSearchPerson();
                Buyer.MozaId = this.MozaId;
                Buyer.FormClosed -= new FormClosedEventHandler(Buyer_FormClosed);
                Buyer.FormClosed += new FormClosedEventHandler(Buyer_FormClosed);
                Buyer.ShowDialog();
            }
            else
            {
                MessageBox.Show("تلاش کرنے سے پہلے ٹوکن لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Buyer_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPerson ap = sender as frmSearchPerson;
            Person p = new Person();
            p.PersonId = ap.PersonId.ToString();
            IntiqalBuyers.Add(p);
            this.txtbuyerName.Text += this.txtbuyerName.Text.Length > 2 ? "," + ap.PersonName : ap.PersonName;
        }

        #endregion

        #region List Searched Intiqals

        private void btnListIntiqals_Click(object sender, EventArgs e)
        {
            if (this.MozaId != "")
            {
                string Sellers1 = "0";
                string Sellers2 = "0";
                string Sellers3 = "0";
                string Buyers1 = "0";
                string Buyers2 = "0";
                string Buyers3 = "0";

                Sellers1 = IntiqalSellers.Count > 0 ? IntiqalSellers[0].PersonId : "0";
                Sellers2 = IntiqalSellers.Count > 1 ? IntiqalSellers[1].PersonId : "0";
                Sellers3 = IntiqalSellers.Count > 2 ? IntiqalSellers[2].PersonId : "0";

                Buyers1 = IntiqalBuyers.Count > 0 ? IntiqalBuyers[0].PersonId : "0";
                Buyers2 = IntiqalBuyers.Count > 1 ? IntiqalBuyers[1].PersonId : "0";
                Buyers3 = IntiqalBuyers.Count > 2 ? IntiqalBuyers[2].PersonId : "0";


                string IntiqalNo = txtIntiqalNo.Text.Trim() != "" ? txtIntiqalNo.Text.Trim() : "0";
                IntiqalList = this.objbusines.filldatatable_from_storedProcedure("proc_Get_Intiqal_List_For_Naqal '" + IntiqalNo + "', '" + Sellers1 + "','" + Sellers2 + "','" + Sellers3 + "','" + Buyers1 + "','" + Buyers2 + "','" + Buyers3 + "','" + this.MozaId + "'");
                if (IntiqalList != null)
                {
                    this.GridWitnessDetails.DataSource = IntiqalList;
                    if (IntiqalList != null)
                    {

                        GridWitnessDetails.Columns["IntiqalId"].Visible = false;

                        GridWitnessDetails.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                        GridWitnessDetails.Columns["IntiqalAndrajDate"].HeaderText = "تاریخ اندراج انتقال";
                        GridWitnessDetails.Columns["IntiqalAmaldramadDate"].HeaderText = "تاریخ انتقال عملدرامد";
                        GridWitnessDetails.Columns["AmalDaramadStatus"].HeaderText = "کیفیت";
                        GridWitnessDetails.Columns["IntiqalPendingRemakrs"].HeaderText = "ریمارکس";
                    }




                }
            }
            else
            {
                MessageBox.Show("تلاش کرنے سے پہلے ٹوکن لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void GridWitnessDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //byte[] file=new byte[];
            if (e.ColumnIndex == 0)
            {
                GridWitnessDetails.CurrentRow.Cells[e.ColumnIndex].Value = !(bool)(GridWitnessDetails.CurrentRow.Cells[e.ColumnIndex].Value != null ? GridWitnessDetails.CurrentRow.Cells[e.ColumnIndex].Value : false);
                string IntId = GridWitnessDetails.CurrentRow.Cells["IntiqalId"].Value != null ? GridWitnessDetails.CurrentRow.Cells["IntiqalId"].Value.ToString() : "0";
                DataTable IntiqaDocImage = this.objbusines.filldatatable_from_storedProcedure("proc_Get_Intiqal_DocImage_For_Naqal '" + IntId + "'");
                
                if (IntiqaDocImage != null)
                {
                    foreach (DataRow dr in IntiqaDocImage.Rows)
                    {
                        try
                        {
                            // In case of Image File
                            MemoryStream ms = new MemoryStream((byte[])dr["IntiqalDocImage"]);
                            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                            //System.Drawing.Image imagee = (System.Drawing.Image);
                            this.ReceivedImage =(byte[])dr["IntiqalDocImage"];
                            this.ImageType = "Image";
                            pbIntiqalnaqalDoc.Image = returnImage;


                        }
                        catch (Exception ex)
                        {

                            byte[] fileData = (byte[])dr["IntiqalDocImage"];
                            this.ReceivedImage = fileData;
                            this.ImageType = "pdf";
                           
                            pbIntiqalnaqalDoc.Image = Resource1.pdf2;
                        }
                        //byte[] file= (byte[])GridWitnessDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        //Stream strm = new MemoryStream(file);

                        //using (FileStream fstream = new FileStream("sample.jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite))

                        //{

                        //    fstream.Write(file, 0, file.Length);
                        //    Process Proc = new Process();
                        //    Proc.StartInfo.FileName = "sample.jpg";
                        //    Proc.Start();


                        //}
                    }

                }
            }

        }

        private void pbIntiqalnaqalDoc_DoubleClick(object sender, EventArgs e)
        {
            if (ImageType == "pdf")
            {
                ToSaveFileTo = "IntImgDoc";
                try
                {
                    int Fileno = 0;
                    while (File.Exists(ToSaveFileTo+".pdf"))
                    {
                        ToSaveFileTo = ToSaveFileTo + Fileno.ToString();
                        Fileno++;
                    }
                        ToSaveFileTo = ToSaveFileTo + ".pdf";
                        using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                        {

                            using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                            {

                                bw.Write(this.ReceivedImage);

                                bw.Close();

                            }
                        }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               // Process.Start(ToSaveFileTo);
                Process p = new Process();
                p.StartInfo.FileName = ToSaveFileTo;
                p.EnableRaisingEvents = true;
                p.Exited += new EventHandler(p_Exited);
                //Process.Start(ToSaveFileTo);
                p.Start();
            }
            if (ImageType == "Image")
            {
                ToSaveFileTo = "IntImgDoc.jpeg";
                using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                {

                    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                    {

                        bw.Write(this.ReceivedImage);

                        bw.Close();

                    }
                }
                Process.Start(ToSaveFileTo);
            }
        }

        void p_Exited(object sender, EventArgs e)
        {
            try
            {
                File.Delete(ToSaveFileTo);
                //MessageBox.Show(ToSaveFileTo + " Deleted");
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void pbIntiqalnaqalDoc_Click(object sender, EventArgs e)
        {

        }
    }
}
