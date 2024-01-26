using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercuryStore
{
    public partial class StoreListControl : UserControl
    {
        public StoreListControl()
        {
            InitializeComponent();
        }
        private string _idgame, _namegame, _reldate, _prgame, _desgame, _befprice, _statusdisc, _pubgame, _valprice, _ratone, _rattwo, _ratthree, _ratfour, _ratfive, _rattotal, _ratusertotal;
        private Image _loggame, _covgame, _imgone, _imgtwo, _imgthree, _imgfour, _imgbanner;
        public string GameID
        {
            get { return _idgame; }
            set { _idgame = value;}
        }
        public string GameName
        {
            get { return _namegame; }
            set { _namegame = value; GA_Label.Text = value; }
        }
        public string GameDate
        {
            get { return _reldate; }
            set { _reldate = value; RE_Label.Text = value; }
        }
        public string GamePrice
        {
            get { return _prgame; }
            set { _prgame = value; GP_Label.Text = value; }
        }
        public string GameDesc
        {
            get { return _desgame; }
            set { _desgame = value;}
        }
        public Image GLogoImg
        {
            get { return _loggame; }
            set { _loggame = value; }
        }
        public Image GCoverImg
        {
            get { return _covgame; }
            set { _covgame = value; GameImg.Image = value; }
        }
        public Image GImg1
        {
            get { return _imgone; }
            set { _imgone = value; }
        }
        public Image GImg2
        {
            get { return _imgtwo; }
            set { _imgtwo = value; }
        }
        public Image GImg3
        {
            get { return _imgthree; }
            set { _imgthree = value; }
        }
        public Image GImg4
        {
            get { return _imgfour; }
            set { _imgfour = value; }
        }
        public Image GBanImg
        {
            get { return _imgbanner; }
            set { _imgbanner = value; }
        }
        public string BeforePrice
        {
            get { return _befprice; }
            set { _befprice = value; AftListPriceLbl.Text = value; }
        }
        public string ValuePrice
        {
            get { return _valprice; }
            set { _valprice = value; DiscListValLabel.Text = value; }
        }
        public string StatusDisc
        {
            get { return _statusdisc; }
            set { _statusdisc = value; }
        }
        public string PublisherGame
        {
            get { return _pubgame; }
            set { _pubgame = value; }
        }

        public string RatingOne
        {
            get { return _ratone; }
            set { _ratone = value; }
        }

        public string RatingTwo
        {
            get { return _rattwo; }
            set { _rattwo = value; }
        }

        public string RatingThree
        {
            get { return _ratthree; }
            set { _ratthree = value; }
        }

        public string RatingFour
        {
            get { return _ratfour; }
            set { _ratfour = value; }
        }

        public string RatingFive
        {
            get { return _ratfive; }
            set { _ratfive = value; }
        }

        public string RatingTotal
        {
            get { return _rattotal; }
            set { _rattotal = value; }
        }

        public string UserRatingTotal
        {
            get { return _ratusertotal; }
            set { _ratusertotal = value; }
        }

        private void StoreListControl_Load(object sender, EventArgs e)
        {
            GlPanel.Parent = GameImg;
            GlPanel.BackColor = Color.FromArgb(0, 20, 20, 21);
            GlPanel.BringToFront();
            GlPanel.Click += new EventHandler((object senders, EventArgs gam) => this.OnClick(gam));
            GameImg.Click += new EventHandler((object senders, EventArgs gam) => this.OnClick(gam));
            RE_Label.Click += new EventHandler((object senders, EventArgs gam) => this.OnClick(gam));
            GP_Label.Click += new EventHandler((object senders, EventArgs gam) => this.OnClick(gam));
            GA_Label.Click += new EventHandler((object senders, EventArgs gam) => this.OnClick(gam));
            DiscListValLabel.Click += new EventHandler((object senders, EventArgs gam) => this.OnClick(gam));
            AftListPriceLbl.Click += new EventHandler((object senders, EventArgs gam) => this.OnClick(gam));
        }
        private void GlPanel_MouseEnter(object sender, EventArgs e)
        {
            GlPanel.BackColor = Color.FromArgb(25, Color.White);
        }

        private void GlPanel_MouseLeave(object sender, EventArgs e)
        {
            GlPanel.BackColor = Color.FromArgb(0, 20, 20, 21);
        }
    }
}
