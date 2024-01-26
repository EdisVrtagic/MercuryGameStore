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
    public partial class NotifControl : UserControl
    {
        public NotifControl()
        {
            InitializeComponent();
        }
        private string _idnotif, _datenotif, _notiftext;
        public event EventHandler OnSelect = null;
        public string IDNotif
        {
            get { return _idnotif; }
            set { _idnotif = value;}
        }
        public string DNotif
        {
            get { return _datenotif; }
            set { _datenotif = value; NotifDateLbl.Text = value; }
        }
        public string TNotif
        {
            get { return _notiftext; }
            set { _notiftext = value; NotifText.Text = value; }
        }
        private void NotifDeleteBtn_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
        private void NotifControl_Load(object sender, EventArgs e)
        {
        }
    }
}
