using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmAppUpdateListMessage : Form
    {
        public frmAppUpdateListMessage()
        {
            InitializeComponent();

            
        }

        private void frmAppUpdateListMessage_Load(object sender, EventArgs e)
        {
            lblVersion.Text = " ورژن " + UsersManagments._Ver.ToString() + " میں نئے فیچر اور آپڈیٹس ";
            lbl1.Text = "1. " + " خسرہ گرداوری فعال کر دیا گیا ہے۔ اس فیچر سے کھتونی کاشت و قبضہ اور نمبرات خسرہ کے قسم زمین تبدیل کیئے جاسکتے ہیں، جو کے خسرہ گرداوری کے دوران تبدیل ہو چکے ہو۔";
            lbl2.Text ="2. "+ "ریونیو افسر کے احکامات جو کہ ایس ڈی افیشیل کو کوئی کام کرنے کے لئے صادر کئے گئے ہو، کو سسٹم میں محفوظ کر کے ریونیو افسر کی بائیو مٹرک کرا دے، تاکہ روزنامچے کی شکل میں مستقبل کیلئے محفوظ ہو سکے۔";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
