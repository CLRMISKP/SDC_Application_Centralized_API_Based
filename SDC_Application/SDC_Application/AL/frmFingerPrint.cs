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
using System.IO;
using DPFP.Gui.Enrollment;
using DPFP.Capture;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
namespace SDC_Application.AL
{
    public partial class frmFingerPrint : Form

    {
      //  DPFP.Template Template=new DPFP.Template();
        public byte[] FPTempByte { get; set; }
        public bool Btn { get; set; }
        public string Method { get; set; }

        DPFP.Gui.Enrollment.EnrollmentControl ObjEnrol = new EnrollmentControl();
        public delegate void Function();
        public frmFingerPrint()
        {
            InitializeComponent();
            
        }

        private void btnSaveThumb_Click(object sender, EventArgs e)
        {
            Btn = true;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        //private byte[] SerializeAndDeserialize(DPFP.Template obj)
        //{
        //    StreamingContext sc = new StreamingContext(StreamingContextStates.CrossProcess, obj);
        //    BinaryFormatter bf = new BinaryFormatter(null, sc);
        //    MemoryStream ms = new MemoryStream(new byte[2048]);
        //    bf.Serialize(ms, new MyClass());
        //    return ms.ToArray();
        //}
       
        //private void axDPFPEnrollmentControl1_OnEnroll(object sender, AxDPFPCtlXLib._IDPFPEnrollmentControlEvents_OnEnrollEvent e)
        //{

            //try
            //{
            //    DPFP.Gui.EventHandlerStatus abc = EventHandlerStatus.Success;
            //    if (abc == DPFP.Gui.EventHandlerStatus.Success)
            //    {
                    
            //        if (e.pTemplate != null)
            //        {
            //            MyClass ab = new MyClass();
            //            ab.MinValue = e.pTemplate;
            //           byte[] bytes= SerializeAndDeserialize(e.pTemplate);
            //           string basestring = Convert.ToBase64String(bytes);
            //           string fingerprint_ = basestring;
            //           FPTempByte = fingerprint_;

            //        }
            //    }
            //}
            //catch (OverflowException)
            //{
            //    Console.WriteLine("The {0} value {1} is outside the range of the Byte type.");
            //    // value.GetType().Name, value);
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("The {0} value {1} is not in a recognizable format.");
            //    // value.GetType().Name, value);
            //}
            //catch (InvalidCastException)
            //{
            //    Console.WriteLine("No conversion to a Byte exists for the {0} value {1}.");
            //    //value.GetType().Name, value);

            //}


        //}
              
        //private void axDPFPEnrollmentControl1_OnComplete(object sender, AxDPFPCtlXLib._IDPFPEnrollmentControlEvents_OnCompleteEvent e)
        //{
            
        //}

        //private void axDPFPEnrollmentControl1_OnStartEnroll(object sender, AxDPFPCtlXLib._IDPFPEnrollmentControlEvents_OnStartEnrollEvent e)
        //{
            
        //}

        //private void axDPFPEnrollmentControl1_OnSampleQuality(object sender, AxDPFPCtlXLib._IDPFPEnrollmentControlEvents_OnSampleQualityEvent e)
        //{
        
        //}

        private void frmFingerPrint_Load(object sender, EventArgs e)
        {

        }
        //public Image MStream(byte[] img)
        //{
        //    MemoryStream streame = new MemoryStream(img);

        //    return Image.FromStream(streame);

        //}
        private void enrollmentControl1_OnEnroll(object Control, int FingerMask, DPFP.Template Template, ref EventHandlerStatus EventHandlerStatus)
        {
            DPFP.Template chk = new DPFP.Template();
                 
            try
            {
                DPFP.Gui.EventHandlerStatus abc = EventHandlerStatus.Success;
                if (abc == DPFP.Gui.EventHandlerStatus.Success)
                {

                    if (Template != null)
                    {
                      //  MyClass ab = new MyClass();
                        MemoryStream fingerprintData = new MemoryStream();
                        Template.Serialize(fingerprintData);
                        fingerprintData.Position = 0;
                        BinaryReader br = new BinaryReader(fingerprintData);
                        byte[] bytes = br.ReadBytes((int)fingerprintData.Length);// br.ReadBytes((Int32)fingerprintData.Length);
                      //  Image RetrunImgae = MStream(bytes);
                      //  pictureBox1.Image = RetrunImgae;
                       // Template.Serialize(ref bytes);
                       string basestring = Convert.ToBase64String(bytes);
                    //   MessageBox.Show(basestring);
                        //string fingerprint_ = basestring;
                        FPTempByte = bytes;
                       // MemoryStream ms = new MemoryStream();
                        //byte[] bytes = SerializeAndDeserialize(Template);
                        //string basestring = Encoding.ASCII.GetString(bytes);
                        //string fingerprint_ = basestring;
                        

                    }
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.");
                // value.GetType().Name, value);
            }
            catch (FormatException)
            {
                Console.WriteLine("The {0} value {1} is not in a recognizable format.");
                // value.GetType().Name, value);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("No conversion to a Byte exists for the {0} value {1}.");
                //value.GetType().Name, value);

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void enrollmentControl1_OnFingerTouch(object Control, string ReaderSerialNumber, int Finger)
        {
           //MessageBox.Show(ReaderSerialNumber);
        }

        private void enrollmentControl1_OnComplete(object Control, string ReaderSerialNumber, int Finger)
        {
          //pictureBox1.Image = (Image)Control;
        }

    }

    //[Serializable]
    //[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    //class MyClass : ISerializable
    //{
    //    public object MinValue{get;set;}
    //    public int maxValue_value;

    //    public MyClass()
    //    {
    //        // minValue_value = int.MinValue;
    //        //maxValue_value = int.MaxValue;
    //    }

    //    void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context)
    //    {
    //        si.AddValue("minValue", MinValue);
    //       // si.AddValue("maxValue", maxValue_value);
    //    }

    //    protected MyClass(SerializationInfo si, StreamingContext context)
    //    {
    //        MinValue = (object)si.GetValue("minValue", typeof(object));
    //        //maxValue_value = (int)si.GetValue("maxValue", typeof(int));
    //    }
    //}
}
