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
    public partial class LibraryGameControl : UserControl
    {
        public LibraryGameControl()
        {
            InitializeComponent();
        }
        private string _libgame, _libdate;
        private Image _libimg;
        public string LibGameName
        {
            get { return _libgame; }
            set { _libgame = value; GameLibName.Text = value; }
        }
        public string LibGameDate
        {
            get { return _libdate; }
            set { _libdate = value; GameRelLib.Text = value; }
        }
        public Image LibGameImg
        {
            get { return _libimg; }
            set { _libimg = value; GameLibImg.Image = value; }
        }
    }
}
