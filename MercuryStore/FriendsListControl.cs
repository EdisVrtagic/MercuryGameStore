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
    public partial class FriendsListControl : UserControl
    {
        public FriendsListControl()
        {
            InitializeComponent();
        }
        private string _folname;
        private Image _folpic;
        public string FollowName
        {
            get { return _folname; }
            set { _folname = value; FollName.Text = value; }
        }
        public Image FollowPic
        {
            get { return _folpic; }
            set { _folpic = value; FollPic.Image = value; }
        }
        private void FriendsListControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = BackColor = Color.FromArgb(47, 47, 47);
        }

        private void FriendsListControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = BackColor = Color.FromArgb(20, 20, 20);
        }

        private void FriendsListControl_Load(object sender, EventArgs e)
        {

        }

    }
}
