using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DPFP.Capture;
using DPFP.Gui;
using DPFP.Processing;
using DPFP.Verification;
using DPFP.Error;
using System.Windows.Forms;

namespace SDC_Application.Classess
{
    class DPFP
    {
        Capture fpCapture = new Capture();

        //public void init()
        //{
        //    fpCapture.EventHandler = this;
        //}

        public void Capture(string ReaderSerialNumber, Priority CapturePriority)
        {
            fpCapture.StartCapture();

        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
           // MessageBox.Show("ٹچ ٹھیک ہے");
        }

      
    }
}
