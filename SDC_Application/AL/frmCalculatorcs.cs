using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDC_Application
{
    public partial class frmCalculatorcs : Form
    {
        #region Class Variables
        /// <summary>
        /// Class Variable, Bewa alive or not
        /// </summary>
        bool bewa = false;

        #endregion

        #region Default Constructor
     /// <summary>
     /// Default Constructor
     /// </summary>
        public frmCalculatorcs()
        {
            InitializeComponent();
        }

        #endregion

        #region Function Calculate Inheritance parts(Werasath Hissay) 
        /// <summary>
        /// This Method Calculates Werasath Hissay of a family.
        /// </summary>
       
        private void Calculate()
        {
            try
            {
            int sons = (txtSons.Text.Trim() != "" ? Convert.ToInt32(txtSons.Text.Trim()) : 0) * 2;
            int doughters = txtDoughter.Text.Trim() != "" ? Convert.ToInt32(txtDoughter.Text.Trim()) : 0;
            if (checkBoxbewa.Checked == true)
            {
                 bewa= true;
            }
            else
            {
                bewa = false;
            }

            int sonsRoughfHisay = (sons / 2) * 14;
            int doughterRoughHisay = doughters * 7;
            int SonsDoughter = sons + doughters;
            float KulHissay = txtKulHissay.Text.Trim() != "" ? float.Parse(txtKulHissay.Text) : 0;
            int RoughTotal = SonsDoughter * 8;
            float bewaHisay = RoughTotal / 8;
            if (bewa)
            {
                float dH = (RoughTotal - bewaHisay - sonsRoughfHisay) / doughters;
                float sh = (RoughTotal - bewaHisay - doughterRoughHisay) / (sons / 2);
                labelBewa.Text = ((bewaHisay / RoughTotal) * KulHissay).ToString();
                labelDoughter.Text = ((dH / RoughTotal) * KulHissay).ToString();
                labelSon.Text = ((sh / RoughTotal) * KulHissay).ToString();
            }
            else
            {


                float dH = KulHissay/SonsDoughter;
                float sh = dH*2;
                labelBewa.Text = (0.0).ToString();
                if (doughters != 0)
                {
                    labelDoughter.Text = dH.ToString();
                }
                else
                    labelDoughter.Text = "0";
                if (sons != 0)
                {
                    labelSon.Text = sh.ToString();
                }
                else
                    labelSon.Text = "0";
            }
            }
            catch (Exception)
            {

                MessageBox.Show("مہیا کردہ نمبرات چیک کر لیں۔");
            }

        }

        #endregion

        #region Button Calculate Werasath Hissay Click Event
        /// <summary>
        /// Button Calculate Werasath Hissay Click Event, Call Calculate method to calculate required portion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
          
            Calculate();
            groupBox1.Visible = true;
      
        }

        #endregion

        #region Funtion Calculate Dar Hissay (Internal Parts) of a khata.
        /// <summary>
        /// Calculates internal Dar Hissay into khatta/khewat main hissay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void btnKhataCalculate_Click(object sender, EventArgs e)
        {
            try
            {

            float KhataKulHissay = txtKhataKulHissay.Text.Trim() != "" ? float.Parse(txtKhataKulHissay.Text) : 0;
            float KhataDarHisay = txtKhataDarHisay.Text.Trim() != "" ? float.Parse(txtKhataDarHisay.Text) : 0;
            float AndroniKulHisay = txtAndroniKulHisay.Text.Trim() != "" ? float.Parse(txtAndroniKulHisay.Text) : 0;
            float fardAndroniHissay = txtAndroniFardHisay.Text.Trim() != "" ? float.Parse(txtAndroniFardHisay.Text) : 0;

            float fardhissay = (KhataDarHisay * fardAndroniHissay) / (AndroniKulHisay);
            labelfardKhataHisay.Text = fardhissay.ToString();
            groupBox2.Visible = true;

            }
            catch (Exception)
            {

                MessageBox.Show("مہیا کردہ نمبرات چیک کر لیں۔");
            }
        }

        #endregion

        #region Button Calculate Raqba Click Event
        /// <summary>
        /// This Function calculates raqba of each malik against its parts(hissay)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void btnCalculatRaqba_Click(object sender, EventArgs e)
        {
            try
            {
            float khataKulRaqbaKanal = txtKhataKanal.Text.Trim() != "" ? float.Parse(txtKhataKanal.Text) : 0;
            float khataKulRaqbaMarla = txtKhataMarla.Text.Trim() != "" ? float.Parse(txtKhataMarla.Text) : 0;
            float khataKulRaqbaSarsai = txtKhataSarsai.Text.Trim() != "" ? float.Parse(txtKhataSarsai.Text) : 0;
            float KhataKulHisay = txtKhataKulHisayforRaqba.Text.Trim() != "" ? float.Parse(txtKhataKulHisayforRaqba.Text) : 0;
            float KhatFardHissay = txtKhataFardHisayForRaqba.Text.Trim() != "" ? float.Parse(txtKhataFardHisayForRaqba.Text) : 0;
            float KanalToMarla = (khataKulRaqbaKanal * 20) + khataKulRaqbaMarla;
            float TotalFeet = (KanalToMarla * 272) + (khataKulRaqbaSarsai * float.Parse("30.25"));

            int FardRaqbaFeet = Convert.ToInt32((KhatFardHissay / KhataKulHisay) * TotalFeet);
            int FardRaqbaMarla = 0;
            int remFeet = 0;
            int FardRabqaKanal = 0;
            int remMarla = 0;
            if (FardRaqbaFeet > 272)
            {
                remFeet = FardRaqbaFeet % 272;
                FardRaqbaMarla = (FardRaqbaFeet - remFeet) / 272;

            }
            else
            {
                remFeet = FardRaqbaFeet;
            }

            if (FardRaqbaMarla >= 20)
            {
                remMarla = FardRaqbaMarla % 20;
                FardRabqaKanal = (FardRaqbaMarla - remMarla) / 20;
            }
            else
            {
                remMarla = FardRaqbaMarla;
            }

            labelkanal.Text = FardRabqaKanal.ToString();
            labelMarla.Text = remMarla.ToString();
            labelSarsai.Text = remFeet.ToString();

            groupBox3.Visible = true;
            }
            catch (Exception)
            {

                MessageBox.Show("مہیا کردہ نمبرات چیک کر لیں۔");
            }

        }

        #endregion
    }
}
