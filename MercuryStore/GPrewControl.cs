using System;
using System.Drawing;
using System.Windows.Forms;

namespace MercuryStore
{
    public partial class GPrewControl : UserControl
    {
        private class GameInfo
        {
            public Color FillColor { get; set; }
            public Image[] Images { get; set; }
            public string MinRequirements { get; set; }
            public string RecRequirements { get; set; }
        }

        private int ImgNum = 1;
        private GameInfo[] games;

        public GPrewControl()
        {
            InitializeComponent();
            InitializeGames();
        }

        private void InitializeGames()
        {
            games = new GameInfo[]
            {
                new GameInfo
                {
                    FillColor = Color.FromArgb(255, 107, 39),
                    Images = new Image[]
                    {
                        Image.FromFile(@"..\..\GameGallery\fifa1.jpg"),
                        Image.FromFile(@"..\..\GameGallery\fifa2.jpg"),
                        Image.FromFile(@"..\..\GameGallery\fifa3.jpg"),
                        Image.FromFile(@"..\..\GameGallery\fifa4.jpg"),
                    },
                    MinRequirements = "OS: Windows 10 64-bit\nProcessor: Intel Core i5 6600k or AMD Ryzen 5 1600\nMemory: 8 GB\nGraphics: NVIDIA GeForce GTX 1050 Ti or AMD Radeon RX 570\nDirectX: Version 12\nStorage: 100 GB",
                    RecRequirements = "OS: Windows 10 64-bit\nProcessor: Intel Core i7 6700 or AMD Ryzen 7 2700X\nMemory: 12 GB\nGraphics: NVIDIA GeForce GTX 1660 or AMD Radeon RX 5600 XT\nDirectX: Version 12\nStorage: 100 GB"
                },
                new GameInfo
                {
                    FillColor = Color.FromArgb(43, 43, 44),
                    Images = new Image[]
                    {
                        Image.FromFile(@"..\..\GameGallery\tlos1.jpg"),
                        Image.FromFile(@"..\..\GameGallery\tlos2.jpg"),
                        Image.FromFile(@"..\..\GameGallery\tlos3.jpg"),
                        Image.FromFile(@"..\..\GameGallery\tlos4.jpg"),
                    },
                    MinRequirements = "OS: Windows 10 64-bit\nProcessor: AMD Ryzen 5 1500X, Intel Core i7-4770K\nMemory: 16 GB\nGraphics: AMD Radeon RX 470 (4 GB), AMD Radeon RX 6500 XT (4 GB),\nNVIDIA GeForce GTX 970 (4 GB), NVIDIA GeForce 1050 Ti (4 GB)\nDirectX: Version 12\nStorage: 100 GB",
                    RecRequirements = "OS: Windows 10 64-bit\nProcessor: AMD Ryzen 5 3600X, Intel Core i7-8700\nMemory: 16 GB\nGraphics: AMD Radeon RX 5700 XT (8 GB), AMD Radeon RX 6600 XT (8 GB),\nNVIDIA GeForce RTX 2070 SUPER (8 GB), NVIDIA GeForce RTX 3060 (8 GB)\nDirectX: Version 12\nStorage: 100 GB"
                },
                new GameInfo
                {
                    FillColor = Color.FromArgb(43, 43, 44),
                    Images = new Image[]
                    {
                        Image.FromFile(@"..\..\GameGallery\gtav1.jpg"),
                        Image.FromFile(@"..\..\GameGallery\gtav2.jpg"),
                        Image.FromFile(@"..\..\GameGallery\gtav3.jpg"),
                        Image.FromFile(@"..\..\GameGallery\gtav4.jpg"),
                    },
                    MinRequirements = "OS: Windows 7, 8.1, Vista, 10 64-bit\nProcessor: Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs)\nAMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz\nMemory: 4 GB\nGraphics: NVIDIA 9800 GT 1GB / AMD HD 4870 1GB\nDirectX: Version 10,11,12\nStorage: 72 GB",
                    RecRequirements = "OS: Windows 7, 8.1, Vista, 10 64-bit\nProcessor: Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs)\nMemory: 8 GB\nGraphics: NVIDIA GTX 660 2GB / AMD HD 7870 2GB\nDirectX: Version 10,11,12\nStorage: 72 GB"
                },
                new GameInfo
                {
                    FillColor = Color.FromArgb(43, 43, 44),
                    Images = new Image[]
                    {
                        Image.FromFile(@"..\..\GameGallery\pubg1.jpg"),
                        Image.FromFile(@"..\..\GameGallery\pubg2.jpg"),
                        Image.FromFile(@"..\..\GameGallery\pubg3.jpg"),
                        Image.FromFile(@"..\..\GameGallery\pubg4.jpg"),
                    },
                    MinRequirements = "OS: Windows 7, 8.1, 10 64-bit\nProcessor: Intel Core i5-4430 / AMD FX-6300\nMemory: 8 GB\nGraphics: nVidia GeForce GTX 960 2GB / AMD Radeon R7 370 2GB\nDirectX: Version 10,11,12\nStorage: 30 GB",
                    RecRequirements = "OS: Windows 7, 8.1, 10 64-bit\nProcessor: Intel Core i5-6600K / AMD Ryzen 5 1600\nMemory: 16 GB\nGraphics: nVidia GeForce GTX 1060 3GB / AMD Radeon RX 580 4GB\nDirectX: Version 10,11,12\nStorage: 30 GB"
                }
            };
        }

        private void GPrewControl_Load(object sender, EventArgs e)
        {
            label1.Hide();
            guna2GradientPanel1.Hide();
            SpecInfoPanel.Hide();
            prewpanel1.FillColor = games[0].FillColor;
            MainPrewPic.Image = Image.FromFile(@"..\..\GameBanner\" + ImgNum + ".jpg");
            LoadImages(games[0].Images);
        }

        private void LoadImages(Image[] images)
        {
            GamePrew1.Image = images[0];
            GamePrew2.Image = images[1];
            GamePrew3.Image = images[2];
            GamePrew4.Image = images[3];
        }

        private void GamePrew1_MouseEnter_1(object sender, EventArgs e)
        {
            GamePrew1.Size = new Size(164, 116);
            MainPrewPic.Image = GamePrew1.Image;
        }

        private void GamePrew2_MouseEnter_1(object sender, EventArgs e)
        {
            GamePrew2.Size = new Size(164, 116);
            MainPrewPic.Image = GamePrew2.Image;
        }

        private void GamePrew3_MouseEnter_1(object sender, EventArgs e)
        {
            GamePrew3.Size = new Size(164, 116);
            MainPrewPic.Image = GamePrew3.Image;
        }

        private void GamePrew4_MouseEnter_1(object sender, EventArgs e)
        {
            GamePrew4.Size = new Size(164, 116);
            MainPrewPic.Image = GamePrew4.Image;
        }

        private void GamePrew1_MouseLeave_1(object sender, EventArgs e)
        {
            GamePrew1.Size = new Size(158, 110);
            MainPrewPic.Image = Image.FromFile(@"..\..\GameBanner\" + ImgNum + ".jpg");
        }

        private void GamePrew2_MouseLeave_1(object sender, EventArgs e)
        {
            GamePrew2.Size = new Size(158, 110);
            MainPrewPic.Image = Image.FromFile(@"..\..\GameBanner\" + ImgNum + ".jpg");
        }

        private void GamePrew3_MouseLeave_1(object sender, EventArgs e)
        {
            GamePrew3.Size = new Size(158, 110);
            MainPrewPic.Image = Image.FromFile(@"..\..\GameBanner\" + ImgNum + ".jpg");
        }

        private void GamePrew4_MouseLeave_1(object sender, EventArgs e)
        {
            GamePrew4.Size = new Size(158, 110);
            MainPrewPic.Image = Image.FromFile(@"..\..\GameBanner\" + ImgNum + ".jpg");
        }

        private void rightPrewBtn_Click_1(object sender, EventArgs e)
        {
            ImgNum--;
            if (ImgNum < 1)
            {
                ImgNum = 4;
            }

            GameInfo currentGame = games[ImgNum - 1];

            label1.Hide();
            guna2GradientPanel1.Hide();
            SpecInfoPanel.Hide();

            prewpanel1.FillColor = currentGame.FillColor;
            prewpanel2.FillColor = games[(ImgNum) % games.Length].FillColor;
            prewpanel3.FillColor = games[(ImgNum + 1) % games.Length].FillColor;
            prewpanel4.FillColor = games[(ImgNum + 2) % games.Length].FillColor;
            LoadImages(currentGame.Images);
            GMainPanel.Hide();
            MainPrewPic.Image = Image.FromFile(@"..\..\GameBanner\" + ImgNum + ".jpg");
            GMainPanel.Show();
        }
        private void leftPrewBtn_Click_1(object sender, EventArgs e)
        {
            ImgNum++;
            if (ImgNum > 4)
            {
                ImgNum = 1;
            }

            GameInfo currentGame = games[ImgNum - 1];

            label1.Hide();
            guna2GradientPanel1.Hide();
            SpecInfoPanel.Hide();

            prewpanel1.FillColor = currentGame.FillColor;
            prewpanel2.FillColor = games[(ImgNum) % games.Length].FillColor;
            prewpanel3.FillColor = games[(ImgNum + 1) % games.Length].FillColor;
            prewpanel4.FillColor = games[(ImgNum + 2) % games.Length].FillColor;

            LoadImages(currentGame.Images);

            GMainPanel.Hide();
            MainPrewPic.Image = Image.FromFile(@"..\..\GameBanner\" + ImgNum + ".jpg");
            GMainPanel.Show();
        }
        private void SpecBtn_Click(object sender, EventArgs e)
        {
            if (SpecBtn.Checked == true)
            {
                if (this.ParentForm is StoreMain storeMain)
                {
                    storeMain.NewPosFLW();
                }

                GameInfo currentGame = games[ImgNum - 1];
                label1.Show();
                guna2GradientPanel1.Show();
                SpecInfoPanel.Show();

                label2.Text = "MINIMUM:\n\n" + currentGame.MinRequirements;
                label5.Text = "RECOMMENDED:\n\n" + currentGame.RecRequirements;
            }
            else
            {
                if (this.ParentForm is StoreMain storeMain)
                {
                    storeMain.StartPosFLW();
                }
                label1.Hide();
                guna2GradientPanel1.Hide();
                SpecInfoPanel.Hide();
            }
        }
    }
}