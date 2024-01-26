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
    public partial class PayCardControl : UserControl
    {
        public PayCardControl()
        {
            InitializeComponent();
        }
        private string _idccard, _namecard, _expdate;
        public string CCardID
        {
            get { return _idccard; }
            set { _idccard = value;}
        }
        public string CCardName
        {
            get { return _namecard; }
            set { _namecard = value; NaCarLbl.Text = value; }
        }
        public string CCardExp
        {
            get { return _expdate; }
            set { _expdate = value; ExpCarLbl.Text = value; }
        }
    }
}
