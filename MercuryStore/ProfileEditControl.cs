using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercuryStore
{
    public partial class ProfileEditControl : UserControl
    {
        public ProfileEditControl()
        {
            InitializeComponent();
        }
        private string _nameuser,_protuser;
        private Image _picuser;
        public event EventHandler OnSelect = null;
        public event EventHandler TwoSelect = null;
        public string NaUser
        {
            get { return _nameuser; }
            set { _nameuser = value; }
        }
        public string ProUser
        {
            get { return _protuser; }
            set { _protuser = value;}
        }
        public Image PicUser
        {
            get { return _picuser; }
            set { _picuser = value; pic1.Image = value; pic2.Image = value; pic3.Image = value; }
        }

        private void NewAvatarBtn_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }

        private void SaveSecBtn_Click(object sender, EventArgs e)
        {
            TwoSelect?.Invoke(this, e);
        }

        private void ProfileEditControl_Load(object sender, EventArgs e)
        {
            string avinfo = "Upload a file from your device.\nThe image should be a\nmaximum size of 2MB.";
            uplInfo.Text = avinfo;
        }
    }
}
