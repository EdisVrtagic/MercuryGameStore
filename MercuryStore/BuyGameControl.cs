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
    public partial class BuyGameControl : UserControl
    {
        public BuyGameControl()
        {
            InitializeComponent();
        }
        public event EventHandler OnSelect = null;
        public event EventHandler TwoSelect = null;
        public event EventHandler ThreeSelect = null;
        private void BuyGameControl_Load(object sender, EventArgs e)
        {
            ScrollPanel.Parent = BuyCoverGame;
            BackToMainListBtn.Parent = BuyCoverGame;
            label1.Parent = BuyCoverGame;
            label34.Parent = BuyCoverGame;
        }

        private void BackToMainListBtn_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }

        private void BuyGBtn_Click(object sender, EventArgs e)
        {
            TwoSelect?.Invoke(this, e);
        }

        private void AddWishlistGameBtn_Click(object sender, EventArgs e)
        {
            ThreeSelect?.Invoke(this, e);
        }
    }
}
