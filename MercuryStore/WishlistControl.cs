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
    public partial class WishlistControl : UserControl
    {
        public WishlistControl()
        {
            InitializeComponent();
        }
        private string _wiid, _wibgame, _wiprice;
        private Image _wiimg;
        public event EventHandler OnSelect = null;
        public string WIDGame
        {
            get { return _wiid; }
            set { _wiid = value;}
        }
        public string WGame
        {
            get { return _wibgame; }
            set { _wibgame = value; GameWishName.Text = value; }
        }

        private void RemBtn_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }

        public string WPrice
        {
            get { return _wiprice; }
            set { _wiprice = value; GameWishPrice.Text = value; }
        }
        public Image WiGameImg
        {
            get { return _wiimg; }
            set { _wiimg = value; GameWishImg.Image = value; }
        }
    }
}
