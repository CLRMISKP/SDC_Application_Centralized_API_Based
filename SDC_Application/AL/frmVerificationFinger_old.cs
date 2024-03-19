using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPFP.Gui;
using DPFP.Processing;
using DPFP.Verification;
using System.IO;
using DPFP.Gui.Enrollment;
using DPFP.Capture;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
namespace SDC_Application.AL
{
    public partial class frmVerificationFinger_old : Form
    {
        byte[] DeSerializee; 
        DPFP.Template Template = new DPFP.Template();
       
        public string FPTempByte
        { get; set; }
        public bool Btn 
        { get; set; }
        Image RetrunImgae1;
        DL.Database ObjDB = new DL.Database();
        DataTable dt;

        public byte[] PersonFingerPrint { get; set; }
        

        public frmVerificationFinger_old()
        {
            InitializeComponent();
        }

        private void frmVerificationFinger_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            //dt = ObjDB.filldatatable_from_storedProcedure("Proc_Get_Intiqal_PersonFingerPrintOnly " + 190010003 + "," + 19001000301 + "");
            //dt.Rows.Count.ToString();
            //foreach (DataRow row in dt.Rows)
            //{


            //   // Image Person = (Image)row["PersonFingerPrint"];
            //    byte[] Finger = (byte[])row["PersonFingerPrint"];
            //    Image RetrunImgae = MStream(Finger);
            //    pictureBox1.Image = RetrunImgae;
            //}
            Image RetrunImgae = MStream(this.PersonFingerPrint);
            pictureBox1.Image = Resource1.FingerprintImage;
        }
        public Image MStream(byte[] img)
        {
            Image image=null;
            try
            {
                MemoryStream stream = new MemoryStream(img);

                image= Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return image;

        }

        private void verificationControl1_OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref EventHandlerStatus EventHandlerStatus)
        {

            if (this.PersonFingerPrint != null)
            {
                this.DeSerializee = this.PersonFingerPrint;
                DPFP.Template template = new DPFP.Template();
                MemoryStream msDB = new MemoryStream(DeSerializee);
                template.DeSerialize(msDB);



                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                Verificator.Verify(FeatureSet, template, ref result);
                if (result.Verified)
                {
                    MessageBox.Show("Machted"); //MakeReport("The fingerprint was VERIFIED.\n" + dt.Rows[x][0].ToString());
                }
                else
                {
                    MessageBox.Show("Not Matched", "Unable to Verify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("مطلوبہ فنگر پرنٹ سسٹم میں محفوظ نہیں ہے۔۔۔", "Unable to Verify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
          

        }

        //private byte[] SerializeAndDeserialize(DPFP.FeatureSet obj)
        //{
        //    StreamingContext sc = new StreamingContext(StreamingContextStates.CrossProcess, obj);
        //    BinaryFormatter bf = new BinaryFormatter(null, sc);
        //    MemoryStream ms = new MemoryStream(new byte[1632]);
        //    bf.Serialize(ms, new MyClass());
        //    return ms.ToArray();
        //}
       
    }
    //[Serializable]
    //[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    //class MyClass : ISerializable
    //{
    //    public object MinValue { get; set; }
    //    public int maxValue_value;

    //    public MyClass()
    //    {
    //        // minValue_value = int.MinValue;
    //        //maxValue_value = int.MaxValue;
    //    }

    //    void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context)
    //    {
    //        si.AddValue("minValue", MinValue);
    //        // si.AddValue("maxValue", maxValue_value);
    //    }

    //    protected MyClass(SerializationInfo si, StreamingContext context)
    //    {
    //        MinValue = (object)si.GetValue("minValue", typeof(object));
    //        //maxValue_value = (int)si.GetValue("maxValue", typeof(int));
    //    }
    //}

}
