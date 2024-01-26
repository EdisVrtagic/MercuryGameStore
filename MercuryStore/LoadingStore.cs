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
    public partial class LoadingStore : Form
    {
        public LoadingStore()
        {
            InitializeComponent();
        }

        private void LoadingStore_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            closeBtn.Parent = pictureBox1;
            label8.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
        }
        private void LoadingStore_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval == 4000)
            {
                timer1.Stop();
                this.Hide();
                RegLog rl = new RegLog();
                rl.Show();
            }
        }
    }
}
