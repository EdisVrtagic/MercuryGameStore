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
    public partial class LibraryListControl : UserControl
    {
        public LibraryListControl()
        {
            InitializeComponent();
        }
        public event EventHandler GLibBtnClick;
        public event EventHandler WishLibBtnClick;

        private void GLibBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (GLibBtn.Checked && GLibBtnClick != null)
            {
                GLibBtnClick(this, EventArgs.Empty);
            }
        }

        private void WishLibBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (WishLibBtn.Checked && WishLibBtnClick != null)
            {
                WishLibBtnClick(this, EventArgs.Empty);
            }
        }
    }
}
