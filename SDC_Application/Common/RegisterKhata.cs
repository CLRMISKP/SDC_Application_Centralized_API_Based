using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandInfo.Common
{
    public class RegisterKhata
    {
        private string kafiat;
        private int kanal;
        private int khattaid;
        private string khattano;
        private int kullhissay;
        private string malya;
        private int marla;
        private int registerno;
        private int sarsai;

        /// <summary>
        /// Get or Set kafiat
        /// </summary>
        public string Kafiat
        {
            get { return kafiat; }
            set { kafiat = value; }
        }
        /// <summary>
        /// Get or Set kanal
        /// </summary>
        public int Kanal
        {
            get { return kanal; }
            set { kanal = value; }
        }
        /// <summary>
        /// Get or Set Khatta id
        /// </summary>
        public int KhattaId
        {
            get { return khattaid; }
            set { khattaid = value; }
        }
        /// <summary>
        /// Get or Set Khatta no
        /// </summary>
        public string KhattaNo
        {
            get { return khattano; }
            set { khattano = value; }
        } 
        /// <summary>
        /// Get or Set Kull Hissay
        /// </summary>

        public int KullHissay
        {
            get { return kullhissay; }
            set { kullhissay = value; }
        }
        /// <summary>
        /// Get or Set Malya
        /// </summary>
        public string Malya
        {
            get { return malya; }
            set { malya = value; }
        }
        /// <summary>
        /// Get or Set Marla
        /// </summary>
        public int Marla
        {
            get { return marla; }
            set { marla = value; }
        }
        /// <summary>
        /// Get or Set Register No
        /// </summary>
        public int RegisterNo
        {
            get { return registerno; }
            set { registerno = value; }
        }
        /// <summary>
        /// Get or Set Sarsai
        /// </summary>
        public int SarSai
        {
            get { return sarsai; }
            set { sarsai = value; }
        }
    }
}
