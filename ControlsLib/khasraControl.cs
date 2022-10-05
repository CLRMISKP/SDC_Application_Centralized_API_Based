using System.Collections.Generic;
using System.Windows.Forms;

namespace LandInfo.ControlsLib
{
    public partial class khasraControl : UserControl
    {
        List<Khasrajat> khasra = new List<Khasrajat>();
        public khasraControl()
        {
            InitializeComponent();
        }

        public void MockData()
        {
            Khasrajat khasra1 = new Khasrajat();
            //khasra1.NumberShumar = 1;
            khasra1.KhasraNumber = "33";
            khasra1.Raqba = "5-3-0";
            //khasra1.QismArazi = " 5-3-0 نہری اول";

            Khasrajat khasra2 = new Khasrajat();
            //khasra2.NumberShumar = 1;
            khasra2.KhasraNumber = "33";
            khasra2.Raqba = "5-3-0";
            //khasra2.QismArazi = " 5-3-0 نہری اول";

            khasra.Add(khasra1);
            khasra.Add(khasra2);

            this.dgKhasra.AutoGenerateColumns = true;
            this.dgKhasra.ReadOnly = true;

            this.dgKhasra.DataSource = khasra;

        }
    }
}
