using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace MercuryStore
{
    public partial class StoreMain : Form
    {
        private readonly Timer panelMoveTimer, mlPanelMoveTimer;
        private int panelMoveTarget = 1059;
        private int panelMoveTargetMLPanel = 1059;
        public StoreMain()
        {
            InitializeComponent();
            panelMoveTimer = new Timer();
            panelMoveTimer.Interval = 1;
            panelMoveTimer.Tick += PanelMoveTimer_Tick;
            mlPanelMoveTimer = new Timer();
            mlPanelMoveTimer.Interval = 1;
            mlPanelMoveTimer.Tick += mlPanelMoveTimer_Tick;
        }
        //Database connection
        readonly static string conect = ConfigurationManager.ConnectionStrings["MSCON"].ConnectionString;
        readonly SqlConnection Con = new SqlConnection(conect);
        //Instance
        readonly GPrewControl userCont = new GPrewControl();
        readonly ProfileEditControl pred = new ProfileEditControl();
        readonly FlowLayoutPanel gamespanel = new FlowLayoutPanel();
        readonly WalletControl wcont = new WalletControl();
        readonly BuyGameControl buygcontrol = new BuyGameControl();
        readonly LibraryListControl libc = new LibraryListControl();
        readonly HelpUserControl hlc = new HelpUserControl();
        private readonly OpenFileDialog opendlg = new OpenFileDialog();
        DataTable dts;
        string imgLoc = "";
        string uscountry = "";
        private int currentGameIndex = 0;
        private int gamesPerPage = 5;
        private Image originalCoverImage;
        private void StoreMain_Load(object sender, EventArgs e)
        {
            UserInfoData();
            ShowComponents();
            dts = new DataTable();
            PrevBtn.Enabled = false;
            currentGameIndex = 0;
            DynamicGameListControl();
            DynamicNotifUser();

        }
        private void ShowComponents()
        {
            //NotifCenter.Hide();
            //ProfilePanel control
            PlaceGamePanel.Location = new Point(1059, -4);
            PlaceGamePanel.Hide();
            ProfilePanel.Location = new Point(1086, 90);
            ProfilePanel.BringToFront();
            ProfilePanel.Hide();
            //searchGame.Hide();
            succText.Hide();
            succPic.Hide();
            //GamePreview control
            userCont.Location = new Point(0, 0);
            MainPanel.Controls.Add(userCont);
            //userCont.Hide();
            //Wallet Control
            wcont.Location = new Point(51, 3);
            MainPanel.Controls.Add(wcont);
            wcont.Hide();
            pred.Hide();
            //Library control
            libc.Location = new Point(8, 3);
            libc.LibProfileName.Text = profileName.Text;
            libc.ProfileLibPic.Image = profilePic.Image;
            libc.LibLocUser.Text = uscountry;
            MainPanel.Controls.Add(libc);
            libc.Hide();
            //Help user control
            hlc.Location = new Point(3, 3);
            MainPanel.Controls.Add(hlc);
            hlc.Hide();
            //All games,see more and games panel
            AllLabel.Location = new Point(0, 445);
            PrevBtn.Location = new Point(1059, 443);
            NextBtn.Location = new Point(1090, 443);
            gamespanel.Name = "flowLayoutPanel1";
            gamespanel.Size = new Size(1131, 363);
            gamespanel.FlowDirection = FlowDirection.LeftToRight;
            gamespanel.WrapContents = true;
            gamespanel.Location = new Point(0, 476);
            MainPanel.Controls.Add(gamespanel);
            gamespanel.BringToFront();
            panflo.SendToBack();
            adconp.SendToBack();
            label6.Margin = new Padding(65, 355, 0, 0);
            NotifCenter.Controls.Add(label6);
            label6.Hide();
            DynamicFriendUser();
            DynamicWalletUser();
            DynamicCardUser();
            DynamicLibraryUser();
            DynamicWihlistUser();
            DynamicFriendCount();
            DynamicGamesCount();
            paycardpanel.Location = new Point(398, 10);
            paycardpanel.Hide();
            label21.Text = "By clicking 'Place Order' below, I represent that\nI am over 18 and an authorized user of this\npayment method, I agree to the End User\nLicense Agreement.";
        }
        private void UserInfoData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conect))
                {
                    con.Open();
                    string query = "SELECT MS_Username,MS_Country,MS_Picture FROM MSUserTbl WHERE MS_Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                profileName.Text = reader.GetString(0);
                                uscountry = reader.GetString(1);
                                if (!reader.IsDBNull(1))
                                {
                                    byte[] img = (byte[])reader.GetValue(2);
                                    MemoryStream ms = new MemoryStream(img);
                                    profilePic.Image = Image.FromStream(ms);
                                }
                                else
                                {
                                    profilePic.Image = null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void DynamicFriendCount()
        {
            try
            {
                Con.Open();
                string countFriendsQuery = "SELECT COUNT(*) FROM FriendTbl WHERE MS_Username = @Username";
                using (SqlCommand countCmd = new SqlCommand(countFriendsQuery, Con))
                {
                    countCmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                    int friendCount = (int)countCmd.ExecuteScalar();
                    libc.UserFriLbl.Text = $"{friendCount}";
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Con.Close();
            }
        }
        public void DynamicGamesCount()
        {
            try
            {
                Con.Open();
                string countGamesQuery = "SELECT COUNT(*) FROM LibraryTbl WHERE LIB_Username = @Username";
                using (SqlCommand countCmd = new SqlCommand(countGamesQuery, Con))
                {
                    countCmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                    int gamesCount = (int)countCmd.ExecuteScalar();
                    libc.UserGamLbl.Text = $"{gamesCount}";
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Con.Close();
            }
        }
        public void DynamicEditUser()
        {
            try
            {
                string query = "SELECT MS_Username, MS_Picture, MS_Protect FROM MSUserTbl WHERE MS_Username = @Username";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        pred.NaUser = row["MS_Username"].ToString();
                        pred.ProUser = row["MS_Protect"].ToString();
                        byte[] imgbyte = row["MS_Picture"] as byte[];
                        if (imgbyte != null)
                        {
                            using (MemoryStream ms = new MemoryStream(imgbyte))
                            {
                                Image imgp = Image.FromStream(ms);
                                pred.pic1.Image = imgp;
                                pred.pic2.Image = imgp;
                                pred.pic3.Image = imgp;
                            }
                        }
                        pred.Location = new Point(135, 0);
                        if (pred.ProUser.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                        {
                            pred.EDCheck.Checked = true;
                        }
                        else if (pred.ProUser.Equals("Disabled", StringComparison.OrdinalIgnoreCase))
                        {
                            pred.EDCheck.Checked = false;
                        }
                        MainPanel.Controls.Add(pred);
                        pred.OnSelect += new EventHandler(this.UploadAV_Click);
                        pred.TwoSelect += new EventHandler(this.EnabDisabProt_Click);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void DynamicWalletUser()
        {
            decimal totalWalletBalance = 0;
            try
            {
                wcont.WallProfPic.Image = profilePic.Image;
                Con.Open();
                string query = "SELECT * FROM UserCardTbl WHERE MS_Username = @MS_Username";
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string cardWallBalan = reader["Wallet_Balance"].ToString();
                        string cardType = reader["Card_Type"].ToString();
                        string cardNumber = reader["Card_Number"].ToString();
                        string cardMonth = reader["Card_Month"].ToString();
                        string cardYear = reader["Card_Year"].ToString();
                        string cardExp = reader["Card_Exp"].ToString();
                        string cardBalan = reader["Card_Balance"].ToString();
                        if (decimal.TryParse(cardWallBalan, out decimal walletBalance))
                        {
                            totalWalletBalance += walletBalance;
                        }
                    }
                }
                Con.Close();
                wcont.ProfWallLbl.Text = "€" + totalWalletBalance.ToString();
                wcont.TwoSelect += new EventHandler(this.AddFiveFundsWall_Click);
                wcont.ThreeSelect += new EventHandler(this.AddTenFundsWall_Click);
                wcont.FourSelect += new EventHandler(this.AddTweFivWall_Click);
                wcont.FiveSelect += new EventHandler(this.AddFiftWall_Click);
                wcont.SixSelect += new EventHandler(this.AddHundWall_Click);
                wcont.SevenSelect += new EventHandler(this.DynamicFundWall_Click);
                wcont.EightSelect += new EventHandler(this.CloseFundPanel_Click);
            }
            catch (Exception)
            {
            }
        }
        void CloseFundPanel_Click(object sender, EventArgs e)
        {
            wcont.CardPayChooseBox.SelectedIndex = -1;
            fundsnum = 0;
            wcont.SubLabel.Text = "";
            wcont.TotAmLabel.Text = "";
            wcont.FundCardPayPanel.Hide();
        }
        private int fundsnum;
        void AddFiveFundsWall_Click(object sender, EventArgs e)
        {
            wcont.SubLabel.Text = "";
            wcont.TotAmLabel.Text = "";
            fundsnum = 5;
            wcont.SubLabel.Text = "€" + fundsnum;
            wcont.TotAmLabel.Text = "€" + fundsnum;
            wcont.FundCardPayPanel.Show();
        }

        void AddTenFundsWall_Click(object sender, EventArgs e)
        {
            wcont.SubLabel.Text = "";
            wcont.TotAmLabel.Text = "";
            fundsnum = 10;
            wcont.SubLabel.Text = "€" + fundsnum;
            wcont.TotAmLabel.Text = "€" + fundsnum;
            wcont.FundCardPayPanel.Show();
        }

        void AddTweFivWall_Click(object sender, EventArgs e)
        {
            wcont.SubLabel.Text = "";
            wcont.TotAmLabel.Text = "";
            fundsnum = 25;
            wcont.SubLabel.Text = "€" + fundsnum;
            wcont.TotAmLabel.Text = "€" + fundsnum;
            wcont.FundCardPayPanel.Show();
        }

        void AddFiftWall_Click(object sender, EventArgs e)
        {
            wcont.SubLabel.Text = "";
            wcont.TotAmLabel.Text = "";
            fundsnum = 50;
            wcont.SubLabel.Text = "€" + fundsnum;
            wcont.TotAmLabel.Text = "€" + fundsnum;
            wcont.FundCardPayPanel.Show();
        }

        void AddHundWall_Click(object sender, EventArgs e)
        {
            wcont.SubLabel.Text = "";
            wcont.TotAmLabel.Text = "";
            fundsnum = 100;
            wcont.SubLabel.Text = "€" + fundsnum;
            wcont.TotAmLabel.Text = "€" + fundsnum;
            wcont.FundCardPayPanel.Show();
        }
        private decimal CalculateTotalWalletBalance()
        {
            decimal totalWalletBalance = 0;
            Con.Open();
            string query = "SELECT Wallet_Balance FROM UserCardTbl WHERE MS_Username = @MS_Username";
            using (SqlCommand cmd = new SqlCommand(query, Con))
            {
                cmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string cardWallBalan = reader["Wallet_Balance"].ToString();
                    if (decimal.TryParse(cardWallBalan, out decimal walletBalance))
                    {
                        totalWalletBalance += walletBalance;
                    }
                }
            }
            Con.Close();
            return totalWalletBalance;
        }
        public void DynamicFundWall_Click(object sender, EventArgs e)
        {
            if (wcont.CardPayChooseBox.SelectedIndex == -1)
            {
            }
            else
            {
                try
                {
                    string selectedCardText = wcont.CardPayChooseBox.SelectedItem.ToString();
                    string cardType = selectedCardText.Split(' ')[0];
                    string lastFourDigits = selectedCardText.Split(' ')[2];
                    Con.Open();
                    string balanceQuery = "SELECT Card_Balance FROM UserCardTbl WHERE MS_Username = @MS_Username AND Card_Type = @Card_Type AND Card_Number LIKE @LastFourDigits";
                    using (SqlCommand balanceCmd = new SqlCommand(balanceQuery, Con))
                    {
                        balanceCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                        balanceCmd.Parameters.AddWithValue("@Card_Type", cardType);
                        balanceCmd.Parameters.AddWithValue("@LastFourDigits", $"%{lastFourDigits}");

                        SqlDataReader balanceReader = balanceCmd.ExecuteReader();
                        if (balanceReader.Read())
                        {
                            decimal cardBalance = Convert.ToDecimal(balanceReader["Card_Balance"]);

                            if (cardBalance > 0)
                            {
                                if (cardBalance >= fundsnum)
                                {
                                    Con.Close();
                                    Con.Open();
                                    string updateQuery = "UPDATE UserCardTbl SET Card_Balance = Card_Balance - @FundsToDeduct, Wallet_Balance = Wallet_Balance + @FundsToDeduct WHERE MS_Username = @MS_Username AND Card_Type = @Card_Type AND Card_Number LIKE @LastFourDigits";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, Con))
                                    {
                                        updateCmd.Parameters.AddWithValue("@FundsToDeduct", fundsnum);
                                        updateCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                                        updateCmd.Parameters.AddWithValue("@Card_Type", cardType);
                                        updateCmd.Parameters.AddWithValue("@LastFourDigits", $"%{lastFourDigits}");
                                        int rowsAffected = updateCmd.ExecuteNonQuery();
                                        wcont.FundCardPayPanel.Hide();
                                    }
                                }
                                else
                                {

                                }
                            }
                            else
                            {

                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }
            }
            decimal totalWalletBalance7 = CalculateTotalWalletBalance();
            wcont.ProfWallLbl.Text = "€" + totalWalletBalance7.ToString();
        }
        public void DynamicCardUser()
        {
            try
            {
                wcont.cardpanel.Controls.Clear();
                wcont.CardPayChooseBox.Items.Clear();
                SummCardBox.Items.Clear();
                Con.Open();
                string cardQuery = "SELECT * FROM UserCardTbl WHERE MS_Username = @MS_Username";
                using (SqlCommand cardCmd = new SqlCommand(cardQuery, Con))
                {
                    cardCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                    SqlDataReader cardReader = cardCmd.ExecuteReader();

                    while (cardReader.Read())
                    {
                        string cardWallBalan = cardReader["Wallet_Balance"].ToString();
                        string cardMonth = cardReader["Card_Month"].ToString();
                        string cardYear = cardReader["Card_Year"].ToString();
                        string cardExp = cardReader["Card_Exp"].ToString();
                        string cardBalan = cardReader["Card_Balance"].ToString();
                        string cardNumber = cardReader["Card_Number"].ToString();
                        string cardType = cardReader["Card_Type"].ToString();
                        string lastFourDigits = cardNumber.Length >= 4 ? cardNumber.Substring(cardNumber.Length - 4) : cardNumber;
                        PayCardControl payCard = new PayCardControl();
                        payCard.NaCarLbl.Text = $"{cardType} **** {lastFourDigits}";
                        int index = wcont.CardPayChooseBox.Items.Add($"{cardType} **** {lastFourDigits}");
                        int index2 = SummCardBox.Items.Add($"{cardType} **** {lastFourDigits}");
                        payCard.ExpCarLbl.Text = "Expires on " + cardReader["Card_Month"].ToString() + "/" + cardReader["Card_Year"].ToString();
                        wcont.cardpanel.Controls.Add(payCard);
                        wcont.OnSelect += new EventHandler(this.AddCardPanel_Click);
                    }
                }
                Con.Close();
            }
            catch (Exception)
            {
            }
        }
        void AddCardPanel_Click(object sender, EventArgs e)
        {
            wcont.Hide();
            paycardpanel.Show();
        }
        private void closeAddCardBtn_Click(object sender, EventArgs e)
        {
            paycardpanel.Hide();
            wcont.Show();
            DynamicWalletUser();
            DynamicCardUser();
        }
        void EnabDisabProt_Click(object sender, EventArgs e)
        {
            string protectionStatus = pred.EDCheck.Checked ? "Enabled" : "Disabled";
            try
            {
                string updQuery = "UPDATE MSUserTbl SET MS_Protect = @PStatus WHERE MS_Username = @Username";
                using (SqlCommand cmd = new SqlCommand(updQuery, Con))
                {
                    cmd.Parameters.AddWithValue("@PStatus", protectionStatus);
                    cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                    Con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Con.Close();
            }
        }

        void UploadAV_Click(object sender, EventArgs e)
        {
            opendlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imgLoc = opendlg.FileName;
                    using (FileStream stream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            byte[] imgData = reader.ReadBytes((int)stream.Length);
                            if (stream.Length <= (2 * 1024 * 1024))
                            {
                                try
                                {
                                    string updQuery = "UPDATE MSUserTbl SET MS_Picture = @USImage WHERE MS_Username = @Username";
                                    using (SqlCommand cmd = new SqlCommand(updQuery, Con))
                                    {
                                        cmd.Parameters.AddWithValue("@USImage", imgData);
                                        cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                                        Con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                pred.pic1.Image = Image.FromFile(imgLoc);
                                pred.pic2.Image = Image.FromFile(imgLoc);
                                pred.pic3.Image = Image.FromFile(imgLoc);
                                profilePic.Image = Image.FromFile(imgLoc);
                            }
                            else
                            {

                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    opendlg.Dispose();
                }
            }
        }
        public void DynamicNotifUser()
        {
            NotifCenter.Controls.Clear();
            try
            {
                string query = "SELECT ID_Notif, Text_Notif, Date_Notif FROM NotifTbl WHERE MS_Username = @Username";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        label6.Visible = true;
                        NotifCenter.Controls.Add(label6);
                        return;
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        NotifControl notifControl = new NotifControl();
                        notifControl.IDNotif = row["ID_Notif"].ToString();
                        notifControl.TNotif = row["Text_Notif"].ToString();
                        if (DateTime.TryParse(row["Date_Notif"].ToString(), out DateTime dateNotif))
                        {
                            string formattedDate = dateNotif.ToString("MMM d, yyyy 'at' HH:mm");
                            formattedDate = char.ToUpper(formattedDate[0]) + formattedDate.Substring(1);
                            notifControl.DNotif = formattedDate;
                        }
                        else
                        {
                        }
                        NotifCenter.Controls.Add(notifControl);
                        notifControl.OnSelect += new EventHandler(this.NotifDelete_Click);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        void NotifDelete_Click(object sender, EventArgs ess)
        {
            NotifControl notifControl = sender as NotifControl;
            if (notifControl != null)
            {
                guna2Transition2.HideSync(notifControl);
                string idNotif = notifControl.IDNotif;
                try
                {
                    string deleteQuery = "DELETE FROM NotifTbl WHERE ID_Notif = @ID_Notif AND MS_Username = @Username";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, Con);
                    deleteCmd.Parameters.AddWithValue("@ID_Notif", idNotif);
                    deleteCmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                    Con.Open();
                    deleteCmd.ExecuteNonQuery();
                    Con.Close();
                }
                catch (Exception)
                {
                }
                DynamicNotifUser();
            }
        }
        void AddNewFriend_Click(object sender, EventArgs e)
        {
            if (sender is ConnectUserControl userControl)
            {
                string friendName = userControl.FrName;
                Image friendImage = userControl.FrPic;
                try
                {
                    Con.Open();
                    string checkQuery = "SELECT COUNT(*) FROM FriendTbl WHERE Friend_Name = @Friend_Name AND MS_Username = @MS_Username";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, Con);
                    checkCmd.Parameters.AddWithValue("@Friend_Name", friendName);
                    checkCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return;
                    }
                    string insertQuery = "INSERT INTO FriendTbl (Friend_Name, Friend_Picture, MS_Username) VALUES (@Friend_Name, @Friend_Picture, @MS_Username)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, Con);
                    insertCmd.Parameters.AddWithValue("@Friend_Name", friendName);
                    insertCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                    Bitmap friendBitmap = new Bitmap(friendImage);
                    MemoryStream ms = new MemoryStream();
                    friendBitmap.Save(ms, ImageFormat.Png);
                    byte[] pictureData = ms.ToArray();
                    insertCmd.Parameters.AddWithValue("@Friend_Picture", pictureData);
                    insertCmd.ExecuteNonQuery();
                    Con.Close();
                    DynamicFriendUser();
                }
                catch (Exception)
                {
                }
                finally
                {
                    Con.Close();
                }
            }
        }
        public void DynamicConnectUser()
        {
            adconp.Controls.Clear();
            try
            {
                string query = "SELECT * FROM MSUserTbl WHERE MS_Username LIKE '%" + searchUsers.Text + "%'";
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string username = row["MS_Username"].ToString();
                        if (!username.Equals(RegLog.nameuser, StringComparison.OrdinalIgnoreCase))
                        {
                            ConnectUserControl userControl = new ConnectUserControl();
                            MemoryStream ms = new MemoryStream((byte[])row["MS_Picture"]);
                            userControl.FrPic = new Bitmap(ms);
                            userControl.FrName = username;
                            adconp.Controls.Add(userControl);
                            userControl.OnSelect += new EventHandler(this.AddNewFriend_Click);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void searchUsers_TextChanged(object sender, EventArgs e)
        {
            DynamicConnectUser();
            string searchText = searchUsers.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                foreach (var item in adconp.Controls)
                {
                    var wdg = (ConnectUserControl)item;
                    wdg.Visible = false;
                }
            }
            else
            {
                foreach (var item in adconp.Controls)
                {
                    var wdg = (ConnectUserControl)item;
                    wdg.Visible = wdg.FrName.ToLower().Contains(searchText);
                }
            }
        }

        public void DynamicFriendUser()
        {
            panflo.Controls.Clear();
            try
            {
                string query = "SELECT Friend_Name,Friend_Picture FROM FriendTbl WHERE MS_Username = @Username";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        FriendsListControl friControl = new FriendsListControl();
                        friControl.FollowName = row["Friend_Name"].ToString();
                        MemoryStream ms = new MemoryStream((byte[])row["Friend_Picture"]);
                        friControl.FollowPic = new Bitmap(ms);
                        panflo.Controls.Add(friControl);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void DynamicLibraryUser()
        {
            libc.flowGamesLib.Controls.Clear();
            try
            {
                string query = "SELECT Name_Game,LIB_Username,LIB_Release,LIB_Image FROM LibraryTbl WHERE LIB_Username = @Username";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        LibraryGameControl lgc = new LibraryGameControl();
                        lgc.LibGameName = row["Name_Game"].ToString();
                        lgc.LibGameDate = row["LIB_Release"].ToString();
                        MemoryStream ms = new MemoryStream((byte[])row["LIB_Image"]);
                        lgc.LibGameImg = new Bitmap(ms);
                        libc.flowGamesLib.Controls.Add(lgc);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void DynamicWihlistUser()
        {
            libc.flowWishLib.Controls.Clear();
            try
            {
                string query = "SELECT ID_WISH, WI_Username, Name_Game, WI_Price, WI_Image FROM WishlistTbl WHERE WI_Username = @Username";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        WishlistControl wgc = new WishlistControl();
                        wgc.WIDGame = row["ID_WISH"].ToString();
                        wgc.WGame = row["Name_Game"].ToString();
                        wgc.WPrice = row["WI_Price"].ToString();
                        MemoryStream ms = new MemoryStream((byte[])row["WI_Image"]);
                        wgc.WiGameImg = new Bitmap(ms);
                        libc.flowWishLib.Controls.Add(wgc);
                        wgc.OnSelect += new EventHandler(this.RemoveWishGame_Click);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        void RemoveWishGame_Click(object sender, EventArgs ess)
        {
            WishlistControl wiControl = sender as WishlistControl;
            if (wiControl != null)
            {
                string idGame = wiControl.WIDGame;
                try
                {
                    string deleteQuery = "DELETE FROM WishlistTbl WHERE ID_WISH = @ID_WISH AND WI_Username = @Username";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, Con);
                    deleteCmd.Parameters.AddWithValue("@ID_WISH", idGame);
                    deleteCmd.Parameters.AddWithValue("@Username", RegLog.nameuser);
                    Con.Open();
                    deleteCmd.ExecuteNonQuery();
                    Con.Close();
                }
                catch (Exception)
                {
                }
                DynamicWihlistUser();
            }
        }
        public void DynamicGameListControl()
        {
            gamespanel.Controls.Clear();
            try
            {
                string query = "SELECT * FROM NewGameTbl";
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtss = new DataTable();
                sda.Fill(dtss);
                if (dtss != null && dtss.Rows.Count > 0)
                {
                    int startIndex = currentGameIndex;
                    int endIndex = Math.Min(startIndex + gamesPerPage, dtss.Rows.Count);
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        DataRow row = dtss.Rows[i];
                        StoreListControl listGames = new StoreListControl();
                        MemoryStream ms1 = new MemoryStream((byte[])row["Logo_Game"]);
                        listGames.GLogoImg = new Bitmap(ms1);
                        MemoryStream ms2 = new MemoryStream((byte[])row["Cover_Game"]);
                        listGames.GCoverImg = new Bitmap(ms2);
                        MemoryStream ms3 = new MemoryStream((byte[])row["Img1_Game"]);
                        listGames.GImg1 = new Bitmap(ms3);
                        MemoryStream ms4 = new MemoryStream((byte[])row["Img2_Game"]);
                        listGames.GImg2 = new Bitmap(ms4);
                        MemoryStream ms5 = new MemoryStream((byte[])row["Img3_Game"]);
                        listGames.GImg3 = new Bitmap(ms5);
                        MemoryStream ms6 = new MemoryStream((byte[])row["Img4_Game"]);
                        listGames.GImg4 = new Bitmap(ms6);
                        MemoryStream ms7 = new MemoryStream((byte[])row["Banner_Game"]);
                        listGames.GBanImg = new Bitmap(ms7);
                        listGames.GameID = row["ID_Game"].ToString();
                        listGames.GameName = row["Name_Game"].ToString();
                        string priceString = row["Price_Game"].ToString();
                        priceString = priceString.Replace(',', '.');
                        listGames.GamePrice = "€" + priceString;
                        string befpriString = row["Before_Price"].ToString();
                        befpriString = befpriString.Replace(',', '.');
                        listGames.BeforePrice = "€" + befpriString;
                        listGames.GameDesc = row["Desc_Game"].ToString();
                        listGames.ValuePrice = "-"+row["Value_Price"].ToString()+"%";
                        listGames.StatusDisc = row["Status_Disc"].ToString();
                        if (listGames.StatusDisc == "Active")
                        {
                            listGames.DiscListValLabel.Location = new Point(5, 297);
                            listGames.AftListPriceLbl.Location = new Point(62, 297);
                            listGames.DiscListValLabel.Show();
                            listGames.AftListPriceLbl.Show();
                            listGames.GP_Label.Location = new Point(121, 297);
                            buygcontrol.BuyGamePrice.Location = new Point(132, 156);
                            buygcontrol.DiscValLabel.Show();
                            buygcontrol.AftPriceLbl.Show();
                        }
                        else if (listGames.StatusDisc == "Inactive")
                        {
                            listGames.DiscListValLabel.Hide();
                            listGames.AftListPriceLbl.Hide();
                            listGames.GP_Label.Location = new Point(0, 297);
                            buygcontrol.DiscValLabel.Hide();
                            buygcontrol.AftPriceLbl.Hide();
                            buygcontrol.BuyGamePrice.Location = new Point(14, 156);
                        }
                        listGames.PublisherGame = row["Pub_Game"].ToString();
                        DateTime releaDate = DateTime.Parse(row["Release_Date"].ToString());
                        string formDate = releaDate.ToString("MMM dd, yyyy");
                        formDate = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formDate);
                        listGames.GameDate = formDate;
                        gamespanel.Controls.Add(listGames);
                        listGames.Click += new EventHandler(this.GameBuyInfo_Click);
                    }
                    if (endIndex >= dtss.Rows.Count)
                    {
                        NextBtn.Enabled = false;
                    }
                    else
                    {
                        NextBtn.Enabled = true;
                    }
                }
                else
                {
                    NextBtn.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private StoreListControl selectedGame = null;
        void GameBuyInfo_Click(object sender, EventArgs e)
        {
            searchGame.Hide();
            userCont.Hide();
            PrevBtn.Hide();
            NextBtn.Hide();
            AllLabel.Hide();
            guna2Transition3.HideSync(gamespanel);
            buygcontrol.Show();
            selectedGame = sender as StoreListControl;
            if (selectedGame != null)
            {
                buygcontrol.BuyGamePrice.Text = selectedGame.GamePrice;
                buygcontrol.BuyGameDesc.Text = selectedGame.GameDesc;
                buygcontrol.BuyGameRelease.Text = selectedGame.GameDate;
                buygcontrol.PublLabel.Text = selectedGame.PublisherGame;
                if (selectedGame.StatusDisc == "Active")
                {
                    buygcontrol.BuyGamePrice.Location = new Point(132, 156);
                    buygcontrol.AftPriceLbl.Text = selectedGame.BeforePrice;
                    buygcontrol.DiscValLabel.Text = selectedGame.ValuePrice;
                    buygcontrol.DiscValLabel.Show();
                    buygcontrol.AftPriceLbl.Show();
                }
                else if (selectedGame.StatusDisc == "Inactive")
                {
                    buygcontrol.DiscValLabel.Hide();
                    buygcontrol.AftPriceLbl.Hide();
                    buygcontrol.BuyGamePrice.Location = new Point(14, 156);
                }
                Con.Open();
                string gameNameToCheck = selectedGame.GameName;
                int ratingOneValue = 0;
                int ratingTwoValue = 0;
                int ratingThreeValue = 0;
                int ratingFourValue = 0;
                int ratingFiveValue = 0;
                float totalRating = 0;
                int totalUserRating = 0;
                string checkRateQuery = "SELECT Rating_One, Rating_Two, Rating_Three, Rating_Four, Rating_Five, Total_Rating, Total_UserRating " +"FROM RateGameTbl WHERE Name_Game = @GameName";
                using (SqlCommand checkRateCmd = new SqlCommand(checkRateQuery, Con))
                {
                    checkRateCmd.Parameters.AddWithValue("@GameName", gameNameToCheck);
                    SqlDataReader reader = checkRateCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ratingOneValue = reader.GetInt32(0);
                        ratingTwoValue = reader.GetInt32(1);
                        ratingThreeValue = reader.GetInt32(2);
                        ratingFourValue = reader.GetInt32(3);
                        ratingFiveValue = reader.GetInt32(4);
                        if (float.TryParse(reader.GetString(5), out totalRating))
                        {
                        }
                        totalUserRating = reader.GetInt32(6);
                    }

                    reader.Close();
                }
                Con.Close();
                buygcontrol.RatingOneLbl.Value = ratingOneValue;
                buygcontrol.RatingTwoLbl.Value = ratingTwoValue;
                buygcontrol.RatingThreeLbl.Value = ratingThreeValue;
                buygcontrol.RatingFourLbl.Value = ratingFourValue;
                buygcontrol.RatingFiveLbl.Value = ratingFiveValue;
                buygcontrol.RatingTotalLbl.Text = totalRating.ToString();
                buygcontrol.TotNumStar.Value = totalRating;
                buygcontrol.UserRatTotalLbl.Text = totalUserRating.ToString();
                buygcontrol.BuyGameLogo.Image = selectedGame.GLogoImg;
                buygcontrol.BuyCoverGame.Image = selectedGame.GBanImg;
                originalCoverImage = buygcontrol.BuyCoverGame.Image;
                buygcontrol.BuyGameImg1.Image = selectedGame.GImg1;
                buygcontrol.BuyGameImg2.Image = selectedGame.GImg2;
                buygcontrol.BuyGameImg3.Image = selectedGame.GImg3;
                buygcontrol.BuyGameImg4.Image = selectedGame.GImg4;
                buygcontrol.BuyGameImg1.MouseEnter += Buygcontrol_MouseEnter;
                buygcontrol.BuyGameImg2.MouseEnter += Buygcontrol2_MouseEnter;
                buygcontrol.BuyGameImg3.MouseEnter += Buygcontrol3_MouseEnter;
                buygcontrol.BuyGameImg4.MouseEnter += Buygcontrol4_MouseEnter;
                buygcontrol.BuyGameImg1.MouseLeave += Buygcontrol_MouseLeave;
                buygcontrol.BuyGameImg2.MouseLeave += Buygcontrol_MouseLeave;
                buygcontrol.BuyGameImg3.MouseLeave += Buygcontrol_MouseLeave;
                buygcontrol.BuyGameImg4.MouseLeave += Buygcontrol_MouseLeave;
            }
            buygcontrol.Location = new Point(3, 3);
            MainPanel.Controls.Add(buygcontrol);
            buygcontrol.OnSelect += new EventHandler(this.BackListGames_Click);
            buygcontrol.TwoSelect += new EventHandler(this.BuyGameLib_Click);
            buygcontrol.ThreeSelect += new EventHandler(this.WishGameUser_Click);
        }
        void BackListGames_Click(object sender, EventArgs e)
        {
            ResetBuyGame();
            buygcontrol.guna2RatingStar1.Value = 0;
            buygcontrol.Hide();
            DynamicGameListControl();
            gamespanel.Show();
            gamespanel.BringToFront();
            PrevBtn.Show();
            NextBtn.Show();
            AllLabel.Show();
            userCont.Show();
            searchGame.Show();
        }
        void WishGameUser_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();

                string checkQuery = "SELECT COUNT(*) FROM WishlistTbl WHERE WI_Username = @WI_Username AND Name_Game = @Name_Game";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, Con))
                {
                    checkCmd.Parameters.AddWithValue("@WI_Username", RegLog.nameuser);
                    checkCmd.Parameters.AddWithValue("@Name_Game", selectedGame.GameName);
                    int gameCount = (int)checkCmd.ExecuteScalar();
                    if (gameCount > 0)
                    {
                    }
                    else
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            selectedGame.GCoverImg.Save(ms, ImageFormat.Png);
                            byte[] imageBytes = ms.ToArray();
                            string insertQuery = "INSERT INTO WishlistTbl (WI_Username, Name_Game, WI_Price, WI_Image) VALUES (@WI_Username, @Name_Game, @WI_Price, @WI_Image)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, Con))
                            {
                                insertCmd.Parameters.AddWithValue("@WI_Username", RegLog.nameuser);
                                insertCmd.Parameters.AddWithValue("@Name_Game", selectedGame.GameName);
                                insertCmd.Parameters.AddWithValue("@WI_Price", selectedGame.GamePrice);
                                insertCmd.Parameters.AddWithValue("@WI_Image", imageBytes);
                                int rowsInserted = insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Con.Close();
            }
        }

        decimal gbprice;
        void BuyGameLib_Click(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                SummGameImg.Image = selectedGame.GCoverImg;
                SummName.Text = selectedGame.GameName;
                Summ_Publ.Text = selectedGame.PublisherGame;
                ordliccheckbox.Text = "Click here to agree to share your email with\n" + Summ_Publ.Text + ". " + Summ_Publ.Text + " will use your email address\nfor marketing and otherwise in accordance\nwith its privacy policy, so we encourage\nyou to read it.";
                Summ_Reld.Text = selectedGame.GameDate;
                SummPrice.Text = selectedGame.GamePrice;
                SummTotal.Text = selectedGame.GamePrice;
                string totalText = SummTotal.Text;
                totalText = totalText.Replace("€", "").Replace(".", ",");
                if (decimal.TryParse(totalText, out gbprice))
                {
                }
                closePlaceBtn.Show();
                ordliccheckbox.Show();
                ordliccheckbox.Show();
                label21.Show();
                PlaceOrderBtn.Show();
                PlaceGamePanel.Show();
            }
            PlaceGamePanel.Location = new Point(1059, -4);
        }
        private void PlaceOrderBtn_Click(object sender, EventArgs e)
        {
            if (SummCardBox.SelectedIndex == -1 || !ordliccheckbox.Checked)
            {
                return;
            }
            else
            {
                try
                {
                    string selectedCardText = SummCardBox.SelectedItem.ToString();
                    string cardType = selectedCardText.Split(' ')[0];
                    string lastFourDigits = selectedCardText.Split(' ')[2];
                    Con.Open();
                    string balanceQuery = "SELECT Card_Balance FROM UserCardTbl WHERE MS_Username = @MS_Username AND Card_Type = @Card_Type AND Card_Number LIKE @LastFourDigits";
                    using (SqlCommand balanceCmd = new SqlCommand(balanceQuery, Con))
                    {
                        balanceCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                        balanceCmd.Parameters.AddWithValue("@Card_Type", cardType);
                        balanceCmd.Parameters.AddWithValue("@LastFourDigits", $"%{lastFourDigits}");
                        SqlDataReader balanceReader = balanceCmd.ExecuteReader();
                        if (balanceReader.Read())
                        {
                            decimal cardBalance = Convert.ToDecimal(balanceReader["Card_Balance"]);
                            if (cardBalance > 0)
                            {
                                if (cardBalance >= gbprice)
                                {
                                    Con.Close();
                                    Con.Open();
                                    string updateQuery = "UPDATE UserCardTbl SET Card_Balance = Card_Balance - @FundsToDeduct WHERE MS_Username = @MS_Username AND Card_Type = @Card_Type AND Card_Number LIKE @LastFourDigits";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, Con))
                                    {
                                        updateCmd.Parameters.AddWithValue("@FundsToDeduct", gbprice);
                                        updateCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                                        updateCmd.Parameters.AddWithValue("@Card_Type", cardType);
                                        updateCmd.Parameters.AddWithValue("@LastFourDigits", $"%{lastFourDigits}");
                                        int rowsAffected = updateCmd.ExecuteNonQuery();
                                        SuccOrdTimer.Start();
                                        closePlaceBtn.Hide();
                                        ordliccheckbox.Hide();
                                        ordliccheckbox.Hide();
                                        label21.Hide();
                                        PlaceOrderBtn.Hide();
                                        succPic.Show();
                                        succText.Show();
                                    }
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        SummGameImg.Image.Save(ms, ImageFormat.Png);
                                        byte[] imageBytes = ms.ToArray();
                                        string insertQuery = "INSERT INTO LibraryTbl (Name_Game, LIB_Username, LIB_Release, LIB_Image) VALUES (@Name_Game, @LIB_Username, @LIB_Release, @LIB_Image)";
                                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, Con))
                                        {
                                            insertCmd.Parameters.AddWithValue("@Name_Game", selectedGame.GameName);
                                            insertCmd.Parameters.AddWithValue("@LIB_Username", RegLog.nameuser);
                                            insertCmd.Parameters.AddWithValue("@LIB_Release", selectedGame.GameDate);
                                            insertCmd.Parameters.AddWithValue("@LIB_Image", imageBytes);
                                            int rowsInserted = insertCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    Con.Close();
                }
            }
        }
        private void Buygcontrol_MouseEnter(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                buygcontrol.BuyCoverGame.Image = selectedGame.GImg1;
            }
        }
        private void Buygcontrol2_MouseEnter(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                buygcontrol.BuyCoverGame.Image = selectedGame.GImg2;
            }
        }
        private void Buygcontrol3_MouseEnter(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                buygcontrol.BuyCoverGame.Image = selectedGame.GImg3;
            }
        }
        private void Buygcontrol4_MouseEnter(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                buygcontrol.BuyCoverGame.Image = selectedGame.GImg4;
            }
        }
        private void Buygcontrol_MouseLeave(object sender, EventArgs e)
        {
            buygcontrol.BuyCoverGame.Image = originalCoverImage;
        }
        private void NextBtn_Click(object sender, EventArgs e)
        {
            currentGameIndex += gamesPerPage;

            if (currentGameIndex + gamesPerPage >= dts.Rows.Count)
            {
                NextBtn.Enabled = false;
            }

            if (currentGameIndex > 0)
            {
                PrevBtn.Enabled = true;
            }

            DynamicGameListControl();
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            currentGameIndex -= gamesPerPage;

            if (currentGameIndex < 0)
            {
                currentGameIndex = 0;
            }

            if (currentGameIndex == 0)
            {
                PrevBtn.Enabled = false;
            }

            NextBtn.Enabled = true;
            DynamicGameListControl();
        }


        private void GStoreButton_Click(object sender, EventArgs e)
        {
            activePanel.Location = new Point(26, 178);
            hlc.Hide();
            libc.Hide();
            userCont.Show();
            gamespanel.BringToFront();
            gamespanel.Show();
            AllLabel.Show();
            PrevBtn.Show();
            NextBtn.Show();
            searchGame.Show();
        }

        private void GLibButton_Click(object sender, EventArgs e)
        {
            searchGame.Hide();
            hlc.Hide();
            userCont.Hide();
            gamespanel.Hide();
            AllLabel.Hide();
            PrevBtn.Hide();
            NextBtn.Hide();
            activePanel.Location = new Point(26, 228);
            libc.GLibBtn.Checked = true;
            libc.Show();
            DynamicLibraryUser();
            DynamicWihlistUser();
            DynamicFriendCount();
            DynamicGamesCount();
            libc.flowGamesLib.Show();
            libc.GLibBtnClick += GLibBtn_CheckedChanged;
            libc.WishLibBtnClick += WishLibBtn_CheckedChanged;
        }
        private void GLibBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (libc.GLibBtn.Checked)
            {
                libc.WishLibBtn.Checked = false;
                DynamicLibraryUser();
                libc.flowGamesLib.Location = new Point(50, 171);
                libc.flowGamesLib.Show();
                libc.flowWishLib.Hide();
            }
            else
            {
                libc.flowGamesLib.Hide();
            }
        }
        private void WishLibBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (libc.WishLibBtn.Checked)
            {
                libc.GLibBtn.Checked = false;
                DynamicWihlistUser();
                libc.flowGamesLib.Hide();
                libc.flowWishLib.Location = new Point(50, 171);
                libc.flowWishLib.Show();
            }
            else
            {
                libc.flowWishLib.Hide();
                libc.GLibBtn.Checked = true;
            }
        }
        private void GHelpButton_Click(object sender, EventArgs e)
        {
            searchGame.Hide();
            libc.Hide();
            userCont.Hide();
            gamespanel.Hide();
            AllLabel.Hide();
            PrevBtn.Hide();
            NextBtn.Hide();
            hlc.Show();
            activePanel.Location = new Point(26, 280);
        }
        private void StoreMain_Click(object sender, EventArgs e)
        {
            proOptionsBtn.Checked = false;
            ProfilePanel.Hide();
        }
        public void NewPosFLW()
        {
            gamespanel.Location = new Point(0, 780);
            AllLabel.Location = new Point(0, 753);
            PrevBtn.Location = new Point(1059, 751);
            NextBtn.Location = new Point(1090, 751);
        }
        public void StartPosFLW()
        {
            MainPanel.AutoScrollPosition = new Point(0, 0);
            gamespanel.Location = new Point(0, 476);
            AllLabel.Location = new Point(0, 445);
            PrevBtn.Location = new Point(1059, 443);
            NextBtn.Location = new Point(1090, 443);
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimerOpac_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timerOpac.Stop();
            }
            Opacity += .2;
        }

        private void ProOptionsBtn_Click_1(object sender, EventArgs e)
        {
            if (proOptionsBtn.Checked == true)
            {
                ProfilePanel.Show();
            }
            else
            {
                ProfilePanel.Hide();
            }
        }

        private void ProLoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegLog lgot = new RegLog();
            lgot.Show();
        }

        private void EditProBtn_Click(object sender, EventArgs e)
        {
            if (editProBtn.Checked == true)
            {
                searchGame.Hide();
                proOptionsBtn.Checked = false;
                wcont.Hide();
                proWallBtn.Checked = false;
                ProfilePanel.Hide();
                userCont.Hide();
                searchGame.Hide();
                gamespanel.Hide();
                AllLabel.Hide();
                PrevBtn.Hide();
                NextBtn.Hide();
                DynamicEditUser();
                pred.Show();
            }
            else
            {
                proOptionsBtn.Checked = false;
                proWallBtn.Checked = false;
                ProfilePanel.Hide();
                wcont.Hide();
                pred.Hide();
                searchGame.Show();
                gamespanel.BringToFront();
                gamespanel.Show();
                AllLabel.Show();
                PrevBtn.Show();
                NextBtn.Show();
                userCont.Show();
                searchGame.Show();
            }
        }

        private void NotifCClose_Click(object sender, EventArgs e)
        {
            panelMoveTarget = 1405;
            panelMoveTargetMLPanel = 1405;
            panelMoveTimer.Start();
            mlPanelMoveTimer.Start();
        }
        private void PanelMoveTimer_Tick(object sender, EventArgs e)
        {
            int moveAmount = 30;
            if (NotifCenter.Left > panelMoveTarget)
            {
                moveAmount = -moveAmount;
            }
            if (Math.Abs(NotifCenter.Left - panelMoveTarget) > Math.Abs(moveAmount))
            {
                NotifCenter.Left += moveAmount;
            }
            else
            {
                panelMoveTimer.Stop();
                NotifCenter.Left = panelMoveTarget;
            }
        }
        private void mlPanelMoveTimer_Tick(object sender, EventArgs e)
        {
            int moveAmount = 30;
            if (MLPanel.Left > panelMoveTargetMLPanel)
            {
                moveAmount = -moveAmount;
            }
            if (Math.Abs(MLPanel.Left - panelMoveTargetMLPanel) > Math.Abs(moveAmount))
            {
                MLPanel.Left += moveAmount;
            }
            else
            {
                mlPanelMoveTimer.Stop();
                MLPanel.Left = panelMoveTargetMLPanel;
            }
        }
        private void CardContBtn_Click(object sender, EventArgs e)
        {
            if (CardTypeBox.SelectedIndex == -1 || CardMontBox.SelectedIndex == -1 || CardYearBox.SelectedIndex == -1 || CardNumBox.Text == "" || CardCodeBox.Text == "")
            {
                return;
            }

            Con.Open();
            try
            {
                string countQuery = "SELECT COUNT(*) FROM UserCardTbl WHERE MS_Username = @MS_Username";
                using (SqlCommand countCmd = new SqlCommand(countQuery, Con))
                {
                    countCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                    int cardCount = (int)countCmd.ExecuteScalar();

                    if (cardCount >= 4)
                    {
                        return;
                    }
                }
                string checkDuplicateQuery = "SELECT COUNT(*) FROM UserCardTbl WHERE MS_Username = @MS_Username AND Card_Type = @Card_Type AND Card_Number = @Card_Number";
                using (SqlCommand checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, Con))
                {
                    checkDuplicateCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                    checkDuplicateCmd.Parameters.AddWithValue("@Card_Type", CardTypeBox.SelectedItem.ToString());
                    checkDuplicateCmd.Parameters.AddWithValue("@Card_Number", CardNumBox.Text);
                    int duplicateCount = (int)checkDuplicateCmd.ExecuteScalar();
                    if (duplicateCount > 0)
                    {
                        return;
                    }
                }
                string query = "SELECT COUNT(*) FROM UserCardTbl WHERE MS_Username = @MS_Username";
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                    int rowCount = (int)cmd.ExecuteScalar();

                    if (rowCount == 0)
                    {
                        query = "INSERT INTO UserCardTbl(MS_Username, Wallet_Balance, Card_Type, Card_Number, Card_Month, Card_Year, Card_Exp, Card_Balance) VALUES (@MS_Username, @Wallet_Balance, @Card_Type, @Card_Number, @Card_Month, @Card_Year, @Card_Exp, @Card_Balance)";
                    }
                    else
                    {
                        query = "SELECT TOP 1 * FROM UserCardTbl WHERE MS_Username = @MS_Username";
                        using (SqlCommand checkCmd = new SqlCommand(query, Con))
                        {
                            checkCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                            using (SqlDataReader reader = checkCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    if (reader["Card_Type"] == DBNull.Value)
                                    {
                                        query = "UPDATE UserCardTbl SET Wallet_Balance = @Wallet_Balance, Card_Type = @Card_Type, Card_Number = @Card_Number, Card_Month = @Card_Month, Card_Year = @Card_Year, Card_Exp = @Card_Exp, Card_Balance = @Card_Balance WHERE MS_Username = @MS_Username";
                                    }
                                    else
                                    {
                                        query = "INSERT INTO UserCardTbl(MS_Username, Wallet_Balance, Card_Type, Card_Number, Card_Month, Card_Year, Card_Exp, Card_Balance) VALUES (@MS_Username, @Wallet_Balance, @Card_Type, @Card_Number, @Card_Month, @Card_Year, @Card_Exp, @Card_Balance)";
                                    }
                                }
                            }
                        }
                    }
                    using (SqlCommand insertOrUpdateCmd = new SqlCommand(query, Con))
                    {
                        insertOrUpdateCmd.Parameters.AddWithValue("@MS_Username", RegLog.nameuser);
                        insertOrUpdateCmd.Parameters.AddWithValue("@Wallet_Balance", 0);
                        insertOrUpdateCmd.Parameters.AddWithValue("@Card_Type", CardTypeBox.SelectedItem.ToString());
                        insertOrUpdateCmd.Parameters.AddWithValue("@Card_Number", CardNumBox.Text);
                        insertOrUpdateCmd.Parameters.AddWithValue("@Card_Month", CardMontBox.SelectedItem.ToString());
                        insertOrUpdateCmd.Parameters.AddWithValue("@Card_Year", CardYearBox.SelectedItem.ToString());
                        insertOrUpdateCmd.Parameters.AddWithValue("@Card_Exp", CardCodeBox.Text);
                        insertOrUpdateCmd.Parameters.AddWithValue("@Card_Balance", 5000);
                        insertOrUpdateCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                Con.Close();
            }

            paycardpanel.Hide();
            DynamicWalletUser();
            DynamicCardUser();
            wcont.Show();
        }

        private void proWallBtn_Click(object sender, EventArgs e)
        {
            if (proWallBtn.Checked == true)
            {
                searchGame.Hide();
                proOptionsBtn.Checked = false;
                editProBtn.Checked = false;
                ProfilePanel.Hide();
                userCont.Hide();
                searchGame.Hide();
                gamespanel.Hide();
                AllLabel.Hide();
                PrevBtn.Hide();
                NextBtn.Hide();
                wcont.Show();
            }
            else
            {
                proOptionsBtn.Checked = false;
                editProBtn.Checked = false;
                wcont.CardPayChooseBox.SelectedIndex = -1;
                fundsnum = 0;
                wcont.SubLabel.Text = "";
                wcont.TotAmLabel.Text = "";
                wcont.FundCardPayPanel.Hide();
                ProfilePanel.Hide();
                wcont.Hide();
                searchGame.Show();
                gamespanel.BringToFront();
                gamespanel.Show();
                AllLabel.Show();
                PrevBtn.Show();
                NextBtn.Show();
                userCont.Show();
                searchGame.Show();
            }
        }

        private void closePlaceBtn_Click(object sender, EventArgs e)
        {
            ResetBuyGame();
        }
        void ResetBuyGame()
        {
            SummGameImg.Image = null;
            SummName.Text = "";
            Summ_Publ.Text = "";
            Summ_Reld.Text = "";
            SummCardBox.SelectedIndex = -1;
            SummPrice.Text = "";
            SummTotal.Text = "";
            ordliccheckbox.Checked = false;
            succPic.Hide();
            succText.Hide();
            PlaceGamePanel.Hide();
        }

        private void SuccOrdTimer_Tick(object sender, EventArgs e)
        {
            if (SuccOrdTimer.Interval == 4000)
            {
                SuccOrdTimer.Stop();
                ResetBuyGame();
                PlaceGamePanel.Hide();
            }
        }

        private void searchGame_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchGame.Text.ToLower();
            PrevBtn.Visible = string.IsNullOrEmpty(searchText);
            NextBtn.Visible = string.IsNullOrEmpty(searchText);
            foreach (Control control in gamespanel.Controls)
            {
                if (control is StoreListControl gameControl)
                {
                    string gameName = gameControl.GameName.ToLower();
                    gameControl.Visible = gameName.Contains(searchText);
                }
            }
        }
        private void NotifCenterButton_Click(object sender, EventArgs e)
        {
            if (NotifCenter.Left == 1059)
            {
                panelMoveTarget = 1405;
                panelMoveTargetMLPanel = 1405;
            }
            else if (NotifCenter.Left == 1405)
            {
                panelMoveTarget = 1059;
                panelMoveTargetMLPanel = 1059;
            }
            ProfilePanel.Hide();
            proOptionsBtn.Checked = false;
            panelMoveTimer.Start();
            mlPanelMoveTimer.Start();
        }
    }
}
