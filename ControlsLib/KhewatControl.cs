#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion

namespace LandInfo.ControlsLib
{
    #region delegates

    public delegate void NewMaalikClickHandler(object sender , MyEventArgs e);
    public delegate void ChangeMaalikClickHandler(object sender , MyEventArgs e);
    #endregion
    public partial class KhewatControl : UserControl
    {
        List<KhewatMain> khewats = new List<KhewatMain>();
        List<KhewatAfraad> afraad = new List<KhewatAfraad>();

        #region Properties
        /// <summary>
        /// Member variables
        /// </summary>
        private string maddnumber;
        private string hissajaat;
        private string qismmalikan;
        private int kehwatgroupid;


        /// <summary>
        /// KhewatGroupId holds value of a Khewat Group
        /// </summary>
        public int KhewatGroupId
        {
            get { return kehwatgroupid; }
            set { kehwatgroupid = value; }
        }
        
        /// <summary>
        /// Madd Number 
        /// </summary>
        public string MaddNumber
        {
            get
            {
                maddnumber = this.lblMaddNumber.Text;
                return maddnumber;
            }
            set
            {
                maddnumber = value;
                this.lblMaddNumber.Text = value;
            }
        }

        /// <summary>
        /// Hissa Jaat 
        /// </summary>
        public string HissaJaat
        {
            get
            {
                hissajaat = this.lblKullHissay.Text;
                return hissajaat;
            }
            set
            {
                hissajaat = value;
                this.lblKullHissay.Text = value;
            }
        }

        /// <summary>
        /// Qism Maalikan
        /// </summary>
        public string QismMalikan
        {
            get 
            {
                qismmalikan = this.lblQismMalikan.Text;
                return qismmalikan; 
            }
            set
            { 
                qismmalikan = value;
                this.lblQismMalikan.Text = value;
            }
        }


        #endregion

        #region Event Members
        /// <summary>
        /// Event Members
        /// </summary>
        public event NewMaalikClickHandler NewMaalikClick;
        public event ChangeMaalikClickHandler ChangeMaalikClick;

        #endregion

        #region Virtual Events
        protected virtual void OnNewMaalikClick(MyEventArgs e)
        {
            NewMaalikClick(this , e);
        }
        protected virtual void OnChangeMaalikClick(MyEventArgs e)
        {
            ChangeMaalikClick(this , e);
        }

        #endregion

        #region Routed Events
        private void llbNewMalik_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnNewMaalikClick(x);
        }

        private void llbModify_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnChangeMaalikClick(x);
        }
        #endregion
        public KhewatControl()
        {
            InitializeComponent();
        }

        public void MockData()
        {
            KhewatAfraad fard1 = new KhewatAfraad();
            fard1.NumberShumar = 1;
            fard1.NaamMalik = "اجمل";
            fard1.Hissa = "8";
            fard1.Raqba = "5-2-0";
            
            KhewatAfraad fard2 = new KhewatAfraad();
            fard2.NumberShumar = 1;
            fard2.NaamMalik = "اجمل";
            fard2.Hissa = "8";
            fard2.Raqba = "5-2-0";

            afraad.Add(fard1);
            afraad.Add(fard2);

            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.ReadOnly = true;
            
            this.dataGridView1.DataSource = afraad;

        }

        public void FillDataAfraad(List<KhewatAfraad> afraad)
        {
          //  this.dataGridView1.DataSource = afraad;
        }
        public void FillDataMain(KhewatMain Khewat)
        {

            this.lblMaddNumber.Text = Khewat.MaddNumber.ToString();
            this.lblKullHissay.Text = Khewat.TotalHissay.ToString();
            this.lblQismMalikan.Text = Khewat.QismMalikan.ToString();
            this.dataGridView1.DataSource = Khewat.KhewatAfrad;
            dataGridView1.Columns[0].HeaderText = "نمبر شمار";
            dataGridView1.Columns[1].HeaderText = "نام مالک";
            dataGridView1.Columns[2].HeaderText = "حصہ";
            dataGridView1.Columns[3].HeaderText = "رقبہ";
        
        }


    }
}
