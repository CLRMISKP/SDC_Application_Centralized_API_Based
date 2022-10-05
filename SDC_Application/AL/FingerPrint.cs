using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SDC_Application.AL
{
    public partial class FingerPrint : Form, DPFP.Capture.EventHandler
    {
        public DPFP.Sample samp { get; set; }

        private DPFP.Capture.Capture Capturer;
        private DPFP.Template Template;
        private DPFP.Processing.Enrollment Enrollment;
        DPFP.Sample Sample;
        private DPFP.Processing.DataPurpose purpose = DPFP.Processing.DataPurpose.Enrollment;
        DPFP.FeatureSet features = new DPFP.FeatureSet();
        
        public delegate void Function();

        public FingerPrint()
        {
            InitializeComponent();
        }

        public virtual void Init()
        {
            Enrollment = new DPFP.Processing.Enrollment();
            try
            {
                Capturer = new DPFP.Capture.Capture();              // Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;                   // Subscribe for capturing events.
                //else
                //    MessageBox.Show("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
        }

        public void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                 //   MessageBox.Show("Using the fingerprint reader, scan your fingerprint.");
                }
                catch
                {
                    MessageBox.Show("Can't initiate capture!");
                }
            }
        }

        public void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    MessageBox.Show("Can't terminate capture!");
                }
            }
        }

        #region Form Event Handlers:

        //private void CaptureForm_Load(object sender, EventArgs e)
        //{
        //    Init();
        //    Start();                                                // Start capture operation.
        //}

        public void FingerPrint_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;
            Init();
            Start();
        }

        public void FingerPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }

        #endregion

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            //MessageBox.Show("The fingerprint sample was captured.");
            //MessageBox.Show("Scan the same fingerprint again.");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
          //  MessageBox.Show("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MessageBox.Show("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
          //  MessageBox.Show("The fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
          //  MessageBox.Show("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            //if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            //    MessageBox.Show("The quality of the fingerprint sample is good.");
            //else
            //    MessageBox.Show("The quality of the fingerprint sample is poor.");
        }
        #endregion

        public Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            samp = Sample;
            //ExtractFeatures(samp, purpose);
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }

        public DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            // DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            // MessageBox.Show("features extracted");
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                return features;
            }
            else
                return null;
        }

        public void SetStatus(string status)
        {
            //this.Invoke(
            //    new Function(delegate()
            //{
            //    StatusLine.Text = status;
            //}));

            this.Invoke(
                new Function(delegate()
            {
                StatusLine.Text = status;
            }));
        }

        public void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate()
            {
              //  MessageBox.Show("prompt");
                //Prompt.Text = prompt;
            }));
        }
        public void MakeReport(string message)
        {
            this.Invoke(new Function(delegate()
            {
                // StatusText.AppendText(message + "\r\n");
              //  MessageBox.Show("Report");
            }));
        }

        public void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate()
            {
                Picture.Image = new Bitmap(bitmap, Picture.Size);   // fit the image into the picture box
            }));
        }

        public void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                btnSave.Enabled = (Template != null);
                //if (Template != null)
                //    MessageBox.Show("The fingerprint template is ready for saving.", "Fingerprint Enrollment");
                //else
                //    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
            }));

        }

        public void button1_Click(object sender, EventArgs e)
        {
            ExtractFeatures(samp, purpose);
            Enrollment.AddFeatures(features);
            switch (Enrollment.TemplateStatus)
            {

                case DPFP.Processing.Enrollment.Status.Ready: // report success and stop capturing 
                    OnTemplate(Enrollment.Template);
                    Capturer.StopCapture();
                    break;
                case DPFP.Processing.Enrollment.Status.Failed: // report failure and restart   

                    MessageBox.Show("Failed");
                    Enrollment.Clear();
                    Capturer.StopCapture();
                    break;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemoryStream fingerprintData = new MemoryStream();
            Enrollment.Template.Serialize(fingerprintData);
            fingerprintData.Position = 0;
            BinaryReader br = new BinaryReader(fingerprintData);
            Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
            Enrollment.Template.Serialize(ref bytes);
            string basestring = Convert.ToBase64String(bytes);
            string fingerprint_ = basestring;
            MessageBox.Show(fingerprint_);
           
        }
    }
}
