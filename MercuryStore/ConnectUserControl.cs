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
    public partial class ConnectUserControl : UserControl
    {
        public ConnectUserControl()
        {
            InitializeComponent();
        }
        private string _fruser;
        private Image _fpict;
        public event EventHandler OnSelect = null;
        public string FrName
        {
            get { return _fruser; }
            set { _fruser = value; NameFriend.Text = value; }
        }
        public Image FrPic
        {
            get { return _fpict; }
            set { _fpict = value; FriendPic.Image = value; }
        }
        private void ConnUserBtn_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
        private void ConnectUserControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = BackColor = Color.FromArgb(47, 47, 47);
            ConnUserBtn.FillColor = Color.FromArgb(47, 47, 47);
            ConnUserBtn.FillColor2 = Color.FromArgb(47, 47, 47);
        }

        private void ConnectUserControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = BackColor = Color.FromArgb(20, 20, 21);
            ConnUserBtn.FillColor = Color.FromArgb(20, 20, 21);
            ConnUserBtn.FillColor2 = Color.FromArgb(20, 20, 21);
        }

        private void ConnectUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
