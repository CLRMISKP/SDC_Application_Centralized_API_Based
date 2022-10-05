using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using SDC_Application.Classess;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
using Microsoft.Reporting.WinForms;
using System.Net;
using System.Collections;
using System.Drawing.Imaging;
using SDC_Application.DL;
using LandInfo.ControlsLib;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SDC_Application.AL
{
    public partial class frmStayOrderDocs : Form
    {


        #region Class Varialbes

        public string TokenId { get; set; }
        datagrid_controls objdatagrid = new datagrid_controls();
        ArrayList list = new ArrayList();
        Intiqal Iq = new Intiqal();
        public byte[] ReceivedImage { get; set; }
        string ToSaveFileTo = "";
        BL.frmToken objbusines = new BL.frmToken();


        #endregion
        public frmStayOrderDocs()
        {
            InitializeComponent();
        }


        #region GetImages from Database
        public void GetCancelFardImages(string KhataId)
        {
            try
            {
                //((DataGridViewImageColumn)this.grdScanedDocStatus.Columns["PictureLoad"]).DefaultCellStyle.NullValue = null;
                DataTable RetriveImages = new DataTable();

                RetriveImages = Iq.GetCancelFardIamges(TokenId);
                
                if (RetriveImages != null)
                {


                    dgvLockKhata.Rows.Clear();
                    list.Clear();
                    int Total_Records = RetriveImages.Rows.Count;
                    for (int i = 0; i <= Total_Records - 1; i++)
                    {
                        dgvLockKhata.Rows.Add();
                        dgvLockKhata.Rows[i].Height = 70;

                    }
                    int count = 0;
                    foreach (DataRow row in RetriveImages.Rows)
                    {


                        byte[] doc = (byte[])row["Picture"];
                        try
                        {
                            MemoryStream stream = new MemoryStream(doc);
                            Image RetrunImgae = Image.FromStream(stream);
                            list.Add(RetrunImgae);
                            RetrunImgae = ResizeImages.ResizeImage(RetrunImgae, RetrunImgae.Width, RetrunImgae.Height, false);
                            this.dgvLockKhata.Rows[count].Cells["Picture"].Value = RetrunImgae;


                        }
                        catch (Exception ex)
                        {

                            list.Add(doc);
                            Image RetrunImgae = ResizeImages.ResizeImage(Resource1.pdf2, Resource1.pdf2.Width, Resource1.pdf2.Height, false);
                            this.dgvLockKhata.Rows[count].Cells["Picture"].Value = RetrunImgae;
                        }
                        this.dgvLockKhata.Rows[count].Cells["PageNos"].Value = row["PageNos"];
                        this.dgvLockKhata.Rows[count].Cells["SNo"].Value = row["SNo"];
                       
                        this.dgvLockKhata.Rows[count].Cells["InsertDate"].Value = row["InsertDate"];
                       
                        this.dgvLockKhata.Rows[count].Cells["GetImageId"].Value = row["ImageId"];

                        count++;
                    }

                    //grdScanedDocStatus_Formats();
                }
                else
                {
                    // btnNewDoc.Enabled = false;
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        private void frmStayOrderDocs_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            GetCancelFardImages(TokenId);
        }

        private void dgvLockKhata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;

            if (e.RowIndex != -1)
            {





                if (e.ColumnIndex == this.dgvLockKhata.CurrentRow.Cells["Picture"].ColumnIndex)
                {
                    string ImageId = dgvLockKhata.CurrentRow.Cells["GetImageId"].Value.ToString();
                    ToSaveFileTo = "IntImgDoc";
                    DataTable dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_CancelFard_ImagesByImageId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + ImageId + "'");
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            byte[] fileData = (byte[])dr["Image"];
                            this.ReceivedImage = fileData;
                        }
                    }
                    try
                    {

                        int Fileno = 0;
                        while (File.Exists(ToSaveFileTo + ".pdf"))
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
                    Process p = new Process();
                    p.StartInfo.FileName = ToSaveFileTo;
                    p.EnableRaisingEvents = true;
                    p.Exited += new EventHandler(p_Exited);
                    //Process.Start(ToSaveFileTo);
                    p.Start();

                    //frmKhataPictureViewerFunction(docid);

                }
            }
        }

        void p_Exited(object sender, EventArgs e)
        {
            string fName = "IntImgDoc";
            try
            {
                File.Delete(ToSaveFileTo);
                int count = 0;
                while (File.Exists(fName + ".pdf"))
                {
                    File.Delete(fName + ".pdf");
                    fName = fName + count.ToString();
                    count++;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
       
    }
}
