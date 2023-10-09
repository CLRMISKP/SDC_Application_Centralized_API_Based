using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Drawing2D;
using SDC_Application.Classess;
using LandInfo.ControlsLib;
using SDC_Application.DL;
using SDC_Application.BL;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Diagnostics;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmBankRecipt : Form
    {
        #region Varibles
        public string Dep_ID { get; set; }
        public byte[] ReceivedImage { get; set; }
        string filenameBank = null;
        string fileSDCReport = null;
        byte[] BankImage;
        byte[] SDCImage;
        BindingSource bs = new BindingSource();
        DataTable dt = new DataTable();
        BL.Bank_SDC_Data bankobj = new Bank_SDC_Data();
        datagrid_controls objdatagrid = new datagrid_controls();
        LanguageConverter lang = new LanguageConverter();
        string ToSaveFileTo = "0";
        #endregion
        public frmBankRecipt()
        {
            InitializeComponent();
        }

        #region  Load Pictures from PC

        private void btnPicture_Click(object sender, EventArgs e)
        {
            try 
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string tempFolder = System.IO.Path.GetTempPath();
                        filenameBank = dlg.FileName;
                       // MessageBox.Show(filename);                     
                        picBox.ImageLocation = filenameBank;
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.BankImage=getImgaeinByte(filenameBank);
                        
                       
                    }
                }
            }

            catch(Exception ex)
            {
            }
        }
        public byte[]  getImgaeinByte(string path)
        {
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var imgStream = GetImageStream(path);
                var image = iTextSharp.text.Image.GetInstance(imgStream);
                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                document.Add(image);
                document.Close();
                return ms.ToArray();
            }
        }
        private void btnsdcReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {   string tempFolder = System.IO.Path.GetTempPath();
                        fileSDCReport = dlg.FileName;                      
                        this.pictureBoxsdcReport.ImageLocation = fileSDCReport;
                        pictureBoxsdcReport.SizeMode = PictureBoxSizeMode.StretchImage;

                        this.SDCImage = getImgaeinByte(fileSDCReport);
                    }
                }
            }

            catch (Exception ex)
            {
            }
        }
        #endregion
        #region saveRecords
        private void btnChalanSave_Click(object sender, EventArgs e)
        {
            

          
           if(txtAmount.Text==string.Empty || txtRecipt.Text==string.Empty )
            {
               
                    MessageBox.Show("رسید نمبر،رقم کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         
            }
            else
            {
               // fileSDCReport == null ? DBNull.Value : fileSDCReport;
                int type = 0;
                if (btnfard.Checked == true)
                {
                    type = 19001;
                }
                else
                {
                    type = 19002;
                }
               string depositDate = this.dtarival.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
               string depostibankdate = this.strecipt.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
               string Recipt = txtRecipt.Text.ToString();
               string amount = txtAmount.Text.ToString();
               string dipositname = txtdepositor.Text.ToString();

               Dep_ID = bankobj.SaveBankSDCSlips(Dep_ID, UsersManagments._Tehsilid, depositDate, depostibankdate, Recipt, amount, dipositname, BankImage, SDCImage, UsersManagments.UserId, UsersManagments.UserName.ToString(), type, UsersManagments.UserId, UsersManagments.UserName.ToString());
               if (Dep_ID != null)
               {
                   MessageBox.Show("ریکارڈ محفوظ ہوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   PupulateGrid("Proc_Get_SDC_BankDeposit");
               }

            }
        }
        private Stream GetImageStream(string imagePath)
        {
            var ms = new MemoryStream();
            using (var img = Image.FromFile(imagePath))
            {
                var jpegCodec = ImageCodecInfo.GetImageEncoders()
                    .Where(x => x.MimeType == "image/jpeg")
                    .FirstOrDefault();

                var encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)20);

                int dpi = 175;
                var thumb = img.GetThumbnailImage((int)(11.692 * dpi), (int)(8.267 * dpi), null, IntPtr.Zero);
                thumb.Save(ms, jpegCodec, encoderParams);
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
        #endregion
        #region controls
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != '.')
            {
                e.Handled = true;

            }
        }

        private void txtRecipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar!='-')
            {
                e.Handled = true;

            }
        }

        private void txtdepositor_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion  


#region Load Main
private void frmBankRecipt_Load(object sender, EventArgs e)
{
    String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
    if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
   // DataGridViewHelper.addHelpterToAllFormGridViews(this);

    PupulateGrid("Proc_Get_SDC_BankDeposit");
    btnintiqal.Checked = true;
    Dep_ID = "-1";
}

private void chkgetAll_Click(object sender, EventArgs e)
{
    if (chkgetAll.Checked == true)
    {
        txtrecSearch.Text = "";
        txtDateSearch.Text = "";
        PupulateGrid("Proc_Get_SDC_BankDeposit_All");
    }
    else
    {
        txtrecSearch.Text = "";
        txtDateSearch.Text = "";
        PupulateGrid("Proc_Get_SDC_BankDeposit");
    }
}
public Image MStream(byte[] img)
{
    MemoryStream stream = new MemoryStream(img);

    return Image.FromStream(stream);

}
public void PupulateGrid(string getstatus)
{

    dt = bankobj.getBankRecords(getstatus);
    bs.DataSource = dt;
    grdBankData.DataSource = dt;
    grdBankData.Columns["DepositId"].Visible = false;
    grdBankData.Columns["TehsilId"].Visible = false;
    grdBankData.Columns["ServiceTypeId"].Visible = false;  
    
    grdBankData.Columns["BankRecieptNo"].DisplayIndex = 1;
    grdBankData.Columns["Amount"].DisplayIndex = 2;
    grdBankData.Columns["DepositedBy"].DisplayIndex = 3;
    grdBankData.Columns["DepositDate"].DisplayIndex = 4;
    grdBankData.Columns["DepositDateBank"].DisplayIndex = 5;
    grdBankData.Columns["Bank"].DisplayIndex = 6;
    grdBankData.Columns["sdc"].DisplayIndex = 7;
   
   
    grdBankData.Columns["Amount"].HeaderText = "رقم";
    grdBankData.Columns["BankRecieptNo"].HeaderText = "رسید نمبر";
    grdBankData.Columns["DepositDate"].HeaderText = " تاریخ";
    grdBankData.Columns["DepositDateBank"].HeaderText = " بتاریخ";
    grdBankData.Columns["DepositedBy"].HeaderText = "نام جمع کنندہ";
    objdatagrid.colorrbackgrid(grdBankData);
    objdatagrid.gridControls(grdBankData);
}
#endregion
#region ClearFields
private void btnNewToken_Click(object sender, EventArgs e)
{
    Dep_ID = "-1";
   BankImage=null;
   SDCImage=null;
   txtAmount.Text = "";
   txtRecipt.Text = "";
   txtdepositor.Text = "";
   //depositid = null;
   filenameBank = null;
   fileSDCReport = null;
   picBox.Image = null;
   pictureBoxsdcReport.Image = null;

}
#endregion

#region CreatePDffromDB
private void grdBankData_CellClick(object sender, DataGridViewCellEventArgs e)
{
    try
    {
        if (e.RowIndex > -1)
        {
            DataTable dtt = new DataTable();
            string depositidee = grdBankData.CurrentRow.Cells["DepositId"].Value.ToString();
            if (e.ColumnIndex == this.grdBankData.CurrentRow.Cells["Bank"].ColumnIndex)
            {
                dtt = bankobj.getBankRecords("Proc_Get_SDC_BankDeposit_ScanImages '" + depositidee + "'");
                foreach (DataRow dr in dtt.Rows)
                {

                    if (dr["ImgBankReciept"] == DBNull.Value)
                    {
                        MessageBox.Show("بنک کے رسید کا امیج نہی ملا", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        byte[] fileData = (byte[])dr["ImgBankReciept"];
                        this.ReceivedImage = fileData;
                        CreatePdf();
                    }
                }

            }
            if (e.ColumnIndex == this.grdBankData.CurrentRow.Cells["sdc"].ColumnIndex)
            {
                dtt = bankobj.getBankRecords("Proc_Get_SDC_BankDeposit_ScanImages '" + depositidee + "'");
                foreach (DataRow dr in dtt.Rows)
                {
                    if (dr["ImgSDCReport"] == DBNull.Value)
                    {
                        MessageBox.Show("ایس ڈی سی کے رپورٹ کاامیج نہی ملا", "", MessageBoxButtons.OK);
                    }
                    else
                    {
                        byte[] fileData = (byte[])dr["ImgSDCReport"];
                        this.ReceivedImage = fileData;
                        CreatePdf();
                    }
                }

            }
        }
    }
    catch (Exception ex)
    { }
}
        public void CreatePdf()
        {
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
        }
void p_Exited(object sender, EventArgs e)
{
    string fName = "BankSDCImage";
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
#endregion

private void txtrecSearch_TextChanged(object sender, EventArgs e)
{
    bs.Filter = string.Format("BankRecieptNo LIKE '%{0}%'", txtrecSearch.Text);
    objdatagrid.colorrbackgrid(grdBankData);
    objdatagrid.gridControls(grdBankData);
}

private void txtDateSearch_TextChanged(object sender, EventArgs e)
{
    bs.Filter = string.Format("DepositDate LIKE '%{0}%'", txtrecSearch.Text);
    objdatagrid.colorrbackgrid(grdBankData);
    objdatagrid.gridControls(grdBankData);
}

private void grdBankData_DoubleClick(object sender, EventArgs e)
{
    try
    {
        this.txtAmount.Text = this.grdBankData.CurrentRow.Cells["Amount"].Value.ToString();
        this.txtdepositor.Text = this.grdBankData.CurrentRow.Cells["DepositedBy"].Value.ToString();
        this.txtRecipt.Text = this.grdBankData.CurrentRow.Cells["BankRecieptNo"].Value.ToString();
        this.dtarival.Value = Convert.ToDateTime(this.grdBankData.CurrentRow.Cells["DepositDate"].Value.ToString());
        this.strecipt.Value = Convert.ToDateTime(this.grdBankData.CurrentRow.Cells["DepositDateBank"].Value.ToString());
        int typeid = Convert.ToInt32(this.grdBankData.CurrentRow.Cells["ServiceTypeId"].Value.ToString());
        Dep_ID = this.grdBankData.CurrentRow.Cells["DepositId"].Value.ToString();
       // BankImage = (byte[])this.grdBankData.CurrentRow.Cells["ImgBankReciept"].Value;
     //   SDCImage = (byte[])this.grdBankData.CurrentRow.Cells["ImgSDCReport"].Value;
        if (typeid == 19001)
        {
            btnfard.Checked = true;
        }
        else
        {
            btnintiqal.Checked = true;
        }

                    DataTable dtt = new DataTable();
                    Dep_ID = grdBankData.CurrentRow.Cells["DepositId"].Value.ToString();
                    dtt = bankobj.getBankRecords("Proc_Get_SDC_BankDeposit_ScanImages'" + Dep_ID + "'");
                   foreach (DataRow dr in dtt.Rows)
            {

                if (dr["ImgBankReciept"] == DBNull.Value)
                {
                    BankImage = null;
                }
                    else
                {
                    BankImage = (byte[])dr["ImgBankReciept"];
                }

                if (dr["ImgSDCReport"] == DBNull.Value)
                {
                    SDCImage = null;
                }
                else
                {
                    SDCImage = (byte[])dr["ImgSDCReport"];
                }              
            

        }

    }

    catch (Exception ex)
    { 
    }
   
}

private void grdBankData_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

    }
}
