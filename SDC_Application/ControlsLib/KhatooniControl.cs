#region Using Directives

using System.Collections.Generic;
using System.Windows.Forms;
#endregion

namespace LandInfo.ControlsLib
{
    #region delegates

    public delegate void NewKhasraClickHandler(object sender , MyEventArgs e);
    public delegate void ChangeKhasraClickHandler(object sender , MyEventArgs e);
    public delegate void NewKashtkarClickHandler(object sender , MyEventArgs e);
    public delegate void ChangeKashtkarClickHandler(object sender , MyEventArgs e);

    public delegate void NewKatoniClickHandler(object sender, MyEventArgs e);
    #endregion

    #region Khatoni Control

    public partial class KhatooniControl : UserControl
    {
        #region Member Variables

        List<Khatooni> khatooni = new List<Khatooni>();
        List<Khasrajat> khasra = new List<Khasrajat>();


        #endregion

        #region Properties

        private int KatoniID { get; set; }
        private string  khasraID { get; set; }

        public int KataId
        {
            get { return KatoniID; }
            set { KatoniID = value; }
        }

        #endregion

        #region Event Members
        /// <summary>
        /// Event Members
        /// </summary>
        public event NewKhasraClickHandler NewKhasraClick;
        public event ChangeKhasraClickHandler ChangeKhasraClick;
        public event NewKashtkarClickHandler NewKashtkarClick;
        public event ChangeKashtkarClickHandler ChangeKashtkarClick;

        public event NewKatoniClickHandler NewKatoniClick;
        #endregion

        #region Default Constructor

        public KhatooniControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Set Grid dataSource
        /// <summary>
        /// Sets the Grid Data Source 
        /// </summary>
        /// <param name="khatooni1"></param>
        /// <param name="khasra1"></param>
        public void SetKhatooniGridDataSource(List<Khatooni> khatooni1 , List<Khasrajat> khasra1)
        {
            this.GridViewKhasra.AutoGenerateColumns = true;
            this.GridViewKhasra.ReadOnly = true;
            this.GridViewKhasra.DataSource = khasra1;

            //GridViewKhasra.Columns[0].HeaderText = "نمبر شمار";
            //GridViewKhasra.Columns[0].Width = 40;
            GridViewKhasra.Columns[0].HeaderText = "خسرہ نمبر";
           // GridViewKhasra.Columns[0].Width = 50;
            GridViewKhasra.Columns[1].HeaderText = "رقبہ";
           // GridViewKhasra.Columns[1].Width = 60;
            GridViewKhasra.Columns[2].HeaderText = "قسم اراضی";

            this.GridViewKashkaar.AutoGenerateColumns = true;
            this.GridViewKashkaar.ReadOnly = true;
            this.GridViewKashkaar.DataSource = khatooni1;

            //GridViewKashkaar.Columns[0].HeaderText = "نمبر شمار";
            //GridViewKashkaar.Columns[0].Width = 40;
            GridViewKashkaar.Columns[0].HeaderText = "حصہ داران";
            GridViewKashkaar.Columns[1].HeaderText = "کاشتکاران";
            //GridViewKashkaar.Columns[2].HeaderText = "قسم کاشتکاران";
        }
        #endregion

        #region Mock Data
        /// <summary>
        /// This is Mock data used for testing purpose only
        /// </summary>
        public void MockData()
        {
            Khatooni khatooni1 = new Khatooni();

            //khatooni1.NumberShumar = 1;
            khatooni1.Khisadaran = "نواز محمد، شکیل، عقیل";
            khatooni1.Kashtkaran = "، اعظم خان، ملانگ جان، میرپاؤجان، قدر جان، احمدجان";
            //khatooni1.QismKashtkaran = "غیر داخیل کار";

            Khatooni khatooni2 = new Khatooni();
            // khatooni2.NumberShumar = 1;
            khatooni2.Khisadaran = "ز محمد، شکیل، عقیل";
            khatooni2.Kashtkaran = " خان، ملانگ جان اعظم ";
            //khatooni2.QismKashtkaran = "غیر داخیل کار";


            /////////----------------////////////////
            Khasrajat khasra1 = new Khasrajat();
            // khasra1.NumberShumar = 1;
            khasra1.KhasraNumber = "33";
            khasra1.Raqba = "5-3-0";
            khasra1.QismArazi = " 5-3-0 نہری اول";

            Khasrajat khasra2 = new Khasrajat();
            //khasra2.NumberShumar = 1;
            khasra2.KhasraNumber = "33";
            khasra2.Raqba = "5-3-0";
            khasra2.QismArazi = " 5-3-0 نہری اول";

            khasra.Add(khasra1);
            khasra.Add(khasra2);

            this.GridViewKhasra.AutoGenerateColumns = true;
            this.GridViewKhasra.ReadOnly = true;

            this.GridViewKhasra.DataSource = khasra;
            //GridViewKhasra.Columns[0].HeaderText = "نمبر شمار";
            //GridViewKhasra.Columns[0].Width = 40;
            GridViewKhasra.Columns[0].HeaderText = "خسرہ نمبر";
            GridViewKhasra.Columns[0].Width = 50;
            GridViewKhasra.Columns[1].HeaderText = "رقبہ";
            GridViewKhasra.Columns[1].Width = 60;
            GridViewKhasra.Columns[2].HeaderText = "قسم اراضی";

            //////////////////---------------//////////////////

            khatooni.Add(khatooni1);
            khatooni.Add(khatooni2);

            this.GridViewKashkaar.AutoGenerateColumns = true;
            this.GridViewKashkaar.ReadOnly = true;

            this.GridViewKashkaar.DataSource = khatooni;
            //GridViewKashkaar.Columns[0].HeaderText = "نمبر شمار";
            //GridViewKashkaar.Columns[0].Width = 40;
            GridViewKashkaar.Columns[0].HeaderText = "حصہ داران";
            GridViewKashkaar.Columns[1].HeaderText = "کاشتکاران";
            // GridViewKashkaar.Columns[2].HeaderText = "قسم کاشتکاران";

        }
        #endregion

        #region Virtual Events
        protected virtual void OnNewKhasraClick(MyEventArgs e)
        {
            NewKhasraClick(this , e);
        }
        protected virtual void OnChangeKhasraClick(MyEventArgs e)
        {
            ChangeKhasraClick(this , e);
        }
        protected virtual void OnNewKashtkarClick(MyEventArgs e)
        {
            NewKashtkarClick(this , e);
        }
        protected virtual void OnChangeKashtkarClick(MyEventArgs e)
        {
            ChangeKashtkarClick(this , e);
        }

        protected virtual void onNewKatoniClick(MyEventArgs e)
        {
            NewKatoniClick(this, e);

        }

        #endregion

        #region Reouted events

        private void llbNewKhasrajat_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnNewKhasraClick(x);
        }

        private void llbmodifyKhasra_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnChangeKhasraClick(x);
        }

        private void llbNewKashtkar_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnNewKashtkarClick(x);
        }

        private void llbModifyKashtkaran_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.OnChangeKashtkarClick(x);
        }

        private void linkLabelNewKatoni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyEventArgs x = new MyEventArgs();
            this.onNewKatoniClick(x);
        }

        #endregion

        #region Properties
        private int khatoniid;

        public int KhatoniId
        {
            get 
            { 
                return khatoniid; 
            }
            set 
            { 
                khatoniid = value;
                
            }
        }
        private string khatoninumber;

        public string KhatoniNumber
        {
            get 
            { 
                return khatoninumber; 
            }
            set 
            { 
                khatoninumber = value;
                this.lblKhatoniNumber.Text = value.ToString();
            }
        }
        
        #endregion


        

       
    }
    #endregion
}
