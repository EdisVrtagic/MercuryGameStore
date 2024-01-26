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
    public partial class WalletControl : UserControl
    {
        public WalletControl()
        {
            InitializeComponent();
        }
        public event EventHandler OnSelect = null;
        public event EventHandler TwoSelect = null;
        public event EventHandler ThreeSelect = null;
        public event EventHandler FourSelect = null;
        public event EventHandler FiveSelect = null;
        public event EventHandler SixSelect = null;
        public event EventHandler SevenSelect = null;
        public event EventHandler EightSelect = null;
        private void WalletControl_Load(object sender, EventArgs e)
        {
            FundCardPayPanel.Hide();
        }

        private void AddFundsFiveBtn_Click(object sender, EventArgs e)
        {
            TwoSelect?.Invoke(this, e);
        }

        private void AddFundsTenBtn_Click(object sender, EventArgs e)
        {
            ThreeSelect?.Invoke(this, e);
        }

        private void AddFundsTweFivBtn_Click(object sender, EventArgs e)
        {
            FourSelect?.Invoke(this, e);
        }

        private void AddFundsFiftBtn_Click(object sender, EventArgs e)
        {
            FiveSelect?.Invoke(this, e);
        }

        private void AddFundsHundBtn_Click(object sender, EventArgs e)
        {
            SixSelect?.Invoke(this, e);
        }

        private void MakPayBtn_Click(object sender, EventArgs e)
        {
            SevenSelect?.Invoke(this, e);
        }

        private void closeAddFundBtn_Click(object sender, EventArgs e)
        {
            EightSelect?.Invoke(this, e);
        }

        private void AddCardBtn_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
    }
}
