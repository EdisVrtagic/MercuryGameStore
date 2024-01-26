using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;

namespace MercuryStore
{
    public partial class RegLog : Form
    {
        public RegLog()
        {
            InitializeComponent();
        }
        //Database connection
        private readonly static string conect = ConfigurationManager.ConnectionStrings["MSCON"].ConnectionString;
        //Main strings and int
        string hashpass;
        private readonly string confirmationCode = GenerateCode();
        int ver1, ver2, ver3, ver4, ver5, ver6;
        int verl1, verl2, verl3, verl4, verl5, verl6;
        //Loading the main form
        private void RegLog_Load(object sender, EventArgs e)
        {
            VerifloginPanel.Location = new Point(88, 173);
            VerifloginPanel.Hide();
            verlogMess.Hide();
            verMess.Hide();
            verifPanel.Location = new Point(88, 173);
            verifPanel.Hide();
            RegPanel.Location = new Point(120, 122);
            RegPanel.Hide();
            LogPanel.Location = new Point(120, 175);
            close.Parent = pictureBox1;
            minimiz.Parent = pictureBox1;
            notifText.Location = new Point(123, 481);
            notifText.Hide();
        }
        //Generate random verification code register account
        private readonly static Random random = new Random();
        public static string GenerateCode(int length = 6)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //Register account button
        private void registerBtn_Click(object sender, EventArgs e)
        {
            string regusername = regUsername.Text;
            string regemail = regEmail.Text;
            string regpassword = regPassword.Text;
            string regcountry = regCountry.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(regusername) || string.IsNullOrEmpty(regemail) || string.IsNullOrEmpty(regpassword) || string.IsNullOrEmpty(regcountry) || !regTermsService.Checked)
            {
                notifText.Text = "Enter the requested information!";
                notifText.Show();
                timer1.Start();
                return;
            }
            if (regusername.Contains(" "))
            {
                notifText.Text = "Username cannot contain spaces!";
                notifText.Show();
                timer1.Start();
                return;
            }
            string specsigns = @"^[a-zA-Z0-9]+$";
            Regex regex = new Regex(specsigns);
            if (!regex.IsMatch(regusername))
            {
                notifText.Text = "Username can only contain letters and numbers!";
                notifText.Show();
                timer1.Start();
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(conect))
                {
                    con.Open();
                    using (SqlCommand checkUsername = new SqlCommand("SELECT COUNT(*) FROM MSUserTbl WHERE MS_Username = @Username", con))
                    {
                        checkUsername.Parameters.AddWithValue("@Username", regusername);
                        int usnFound = (int)checkUsername.ExecuteScalar();
                        if (usnFound > 0)
                        {
                            notifText.Text = "Username already exists!";
                            notifText.Show();
                            timer1.Start();
                            return;
                        }
                    }
                    using (SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM MSUserTbl WHERE MS_Email = @Email", con))
                    {
                        checkEmail.Parameters.AddWithValue("@Email", regemail);
                        int emFound = (int)checkEmail.ExecuteScalar();
                        if (emFound > 0)
                        {
                            notifText.Text = "Email already exists!";
                            notifText.Show();
                            timer1.Start();
                            return;
                        }
                    }
                    verTimer.Start();
                    string senderName = "Mercury Support";
                    string recipientEmail = regemail;
                    string subject = "Verification Code";
                    string body = "<html><head><style>body{font-family: Arial, sans-serif;background-color: #f4f4f4;}.container{max-width: 550px;height: 512px;margin: 0 auto;padding: 20px;background-color: #141415;border: 1px solid #ccc;border-radius: 10px;box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);}h1{text-align: center;color: #FFF;}p{text-align: left;font-size: 20px;color: #FFF;font-weight: bold;}p.p1{font-size: 28px;color: #808080;font-weight: bold;}p.p2{font-size: 15px;color: #FFF;font-weight: normal;text-align: center;margin-top: 25px; font-weight: bold;}.verification-code{justify-content: center;align-items: center;margin-top: 50px;width: 350px;margin-left: auto;margin-right: auto;font-size: 24px;font-weight: bold;color: #FFF;background-image: linear-gradient(rgba(255, 107, 39), rgba(228, 81, 85));border-radius: 5px;padding: 20px;text-align: center;}.footer{font-size: 14px;margin-top: 50px;text-align: left;color: #FFF;font-weight: normal;line-height: 1.5;}.logo{margin-top: 10px;width: 50px;height: 50px;margin-left: 7px;margin-right: 7px;}</style></head><body><div class='container'><img class='logo' src='https://i.imgur.com/BERdi0C.png'><p class='p1'>Hello,</p><p>Please use the following verification code to complete your registration:</p><div class='verification-code'>" + confirmationCode + @"</div><p class='footer'>Mercury Game Store requires that you enter a verification code during the registration of a new account or when logging into the application. The verification code will be sent to the email address you provide, which must be valid. Accepted email services include Gmail, Hotmail, and Yahoo.</p><p class='p2'>Mercury © 2023</p></div></body></html>";
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("edisdemo22@gmail.com", senderName);
                        mail.To.Add(recipientEmail);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential("edisdemo22@gmail.com", "taocfszwxqdqxdmp");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }
            }
            catch (SqlException)
            {
            }
        }
        //Profile password encryption
        private void regPassword_TextChanged(object sender, EventArgs e)
        {
            hashpass = Hash.Hash_SHA256(regPassword.Text);
        }
        //Login account button
        public static string nameuser;
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string usern = logUser.Text;
            string passw = logPass.Text;
            if (string.IsNullOrEmpty(usern) || string.IsNullOrEmpty(passw))
            {
                notifText.Text = "Enter the requested information!";
                notifText.Show();
                timer1.Start();
                return;
            }
            if (usern.Contains(" "))
            {
                notifText.Text = "Username cannot contain spaces!";
                notifText.Show();
                timer1.Start();
                return;
            }
            string specsigns = @"^[a-zA-Z0-9]+$";
            Regex regex = new Regex(specsigns);
            if (!regex.IsMatch(usern))
            {
                notifText.Text = "Username can only contain letters and numbers!";
                notifText.Show();
                timer1.Start();
                return;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(conect))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM MSUserTbl WHERE MS_Username = @Username", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", usern);
                        int usFound = (int)cmd.ExecuteScalar();
                        if (usFound == 1)
                        {
                            using (SqlCommand checkPass = new SqlCommand("SELECT MS_Pass FROM MSUserTbl WHERE MS_Username = @Username", con))
                            {
                                checkPass.Parameters.AddWithValue("@Username", usern);
                                string accPass = (string)checkPass.ExecuteScalar();
                                nameuser = usern;
                                using (SqlCommand getEmail = new SqlCommand("SELECT MS_Email FROM MSUserTbl WHERE MS_Username = @Username", con))
                                {
                                    getEmail.Parameters.AddWithValue("@Username", usern);
                                    string email = (string)getEmail.ExecuteScalar();
                                    using (SqlCommand checkProtect = new SqlCommand("SELECT MS_Protect FROM MSUserTbl WHERE MS_Username = @Username", con))
                                    {
                                        checkProtect.Parameters.AddWithValue("@Username", usern);
                                        string protectValue = (string)checkProtect.ExecuteScalar();
                                        if (accPass == Hash.Hash_SHA256(passw))
                                        {
                                            if (string.Equals(protectValue, "Enabled", StringComparison.OrdinalIgnoreCase))
                                            {
                                                verTimerL.Start();
                                                string senderName = "Mercury Support";
                                                string recipientEmail = email;
                                                string subject = "Verification Code";
                                                string body = "<html><head><style>body{font-family: Arial, sans-serif;background-color: #f4f4f4;}.container{max-width: 550px;height: 512px;margin: 0 auto;padding: 20px;background-color: #141415;border: 1px solid #ccc;border-radius: 10px;box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);}h1{text-align: center;color: #FFF;}p{text-align: left;font-size: 20px;color: #FFF;font-weight: bold;}p.p1{font-size: 28px;color: #808080;font-weight: bold;}p.p2{font-size: 15px;color: #FFF;font-weight: normal;text-align: center;margin-top: 25px; font-weight: bold;}.verification-code{justify-content: center;align-items: center;margin-top: 50px;width: 350px;margin-left: auto;margin-right: auto;font-size: 24px;font-weight: bold;color: #FFF;background-image: linear-gradient(rgba(255, 107, 39), rgba(228, 81, 85));border-radius: 5px;padding: 20px;text-align: center;}.footer{font-size: 14px;margin-top: 50px;text-align: left;color: #FFF;font-weight: normal;line-height: 1.5;}.logo{margin-top: 10px;width: 50px;height: 50px;margin-left: 7px;margin-right: 7px;}</style></head><body><div class='container'><img class='logo' src='https://i.imgur.com/BERdi0C.png'><p class='p1'>Hello,</p><p>Please use the following verification code to complete your login:</p><div class='verification-code'>" + confirmationCode + @"</div><p class='footer'>Mercury Game Store requires that you enter a verification code during the registration of a new account or when logging into the application. The verification code will be sent to the email address you provide, which must be valid. Accepted email services include Gmail, Hotmail, and Yahoo.</p><p class='p2'>Mercury © 2023</p></div></body></html>";
                                                using (MailMessage mail = new MailMessage())
                                                {
                                                    mail.From = new MailAddress("edisdemo22@gmail.com", senderName);
                                                    mail.To.Add(recipientEmail);
                                                    mail.Subject = subject;
                                                    mail.Body = body;
                                                    mail.IsBodyHtml = true;
                                                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                                    {
                                                        smtp.UseDefaultCredentials = false;
                                                        smtp.Credentials = new NetworkCredential("edisdemo22@gmail.com", "taocfszwxqdqxdmp");
                                                        smtp.EnableSsl = true;
                                                        smtp.Send(mail);
                                                    }
                                                }
                                            }
                                            else if (string.Equals(protectValue, "Disabled", StringComparison.OrdinalIgnoreCase))
                                            {
                                                this.Hide();
                                                StoreMain stm = new StoreMain();
                                                stm.Show();
                                            }
                                        }
                                        else
                                        {
                                            notifText.Text = "Invalid password!";
                                            notifText.Show();
                                            timer1.Start();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            notifText.Text = "Account does not exist!";
                            notifText.Show();
                            timer1.Start();
                        }
                    }
                }
            }
            catch (SqlException)
            {

            }
        }
        //Custom notification timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timer1.Interval == 1000)
            {
                timer1.Stop();
                notifText.Hide();
            }
        }
        //User profile already exists
        private void ALRMess_Click(object sender, EventArgs e)
        {
            regUsername.Text = "";
            regEmail.Text = "";
            regPassword.Text = "";
            regCountry.SelectedIndex = -1;
            regTermsService.Checked = false;
            RegPanel.Hide();
            LogPanel.Show();
        }
        //User is not registered
        private void DONMess_Click(object sender, EventArgs e)
        {
            logUser.Text = "";
            logPass.Text = "";
            LogPanel.Hide();
            RegPanel.Show();
        }
        //Verification textBox C1
        private void verC1_TextChanged(object sender, EventArgs e)
        {
            var text = verC1.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verC2.Focus();
            }
        }
        //Verification textBox C2
        private void verC2_TextChanged(object sender, EventArgs e)
        {
            var text = verC2.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verC3.Focus();
            }
        }
        //Verification textBox C3
        private void verC3_TextChanged(object sender, EventArgs e)
        {
            var text = verC3.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verC4.Focus();
            }
        }
        //Verification textBox C4
        private void verC4_TextChanged(object sender, EventArgs e)
        {
            var text = verC4.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verC5.Focus();
            }
        }
        //Verification textBox C5
        private void verC5_TextChanged(object sender, EventArgs e)
        {
            var text = verC5.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verC6.Focus();
            }
        }
        //Verification textBox C6
        private void verC6_TextChanged(object sender, EventArgs e)
        {
            var text = verC6.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                if (int.TryParse(verC1.Text, out ver1) &&
                    int.TryParse(verC2.Text, out ver2) &&
                    int.TryParse(verC3.Text, out ver3) &&
                    int.TryParse(verC4.Text, out ver4) &&
                    int.TryParse(verC5.Text, out ver5) &&
                    int.TryParse(verC6.Text, out ver6))
                {
                    string enteredCode = string.Concat(ver1, ver2, ver3, ver4, ver5, ver6);
                    string regusername = regUsername.Text;
                    string regemail = regEmail.Text;
                    string regcountry = regCountry.SelectedItem?.ToString();

                    if (enteredCode == confirmationCode)
                    {
                        using (SqlConnection con = new SqlConnection(conect))
                        {
                            con.Open();
                            byte[] imgs;
                            Image image = Image.FromFile(@"..\..\ProfileImg\defpic.png");
                            ImageConverter converter = new ImageConverter();
                            imgs = (byte[])converter.ConvertTo(image, typeof(byte[]));
                            using (SqlCommand insertUserCommand = new SqlCommand("INSERT INTO MSUserTbl (MS_Username, MS_Email, MS_Pass, MS_Country, MS_Picture, MS_Protect) VALUES (@Username, @Email, @Password, @Country, @Picture, @Protect)", con))
                            {
                                insertUserCommand.Parameters.AddWithValue("@Username", regusername);
                                insertUserCommand.Parameters.AddWithValue("@Email", regemail);
                                insertUserCommand.Parameters.AddWithValue("@Password", hashpass);
                                insertUserCommand.Parameters.AddWithValue("@Country", regcountry);
                                insertUserCommand.Parameters.AddWithValue("@Picture", imgs);
                                insertUserCommand.Parameters.AddWithValue("@Protect", "Disabled");
                                insertUserCommand.ExecuteNonQuery();
                            }
                            using (SqlCommand insertUserCardCommand = new SqlCommand("INSERT INTO UserCardTbl (MS_Username, Wallet_Balance, Card_Type, Card_Number, Card_Month, Card_Year, Card_Exp, Card_Balance) VALUES (@MS_Username, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", con))
                            {
                                insertUserCardCommand.Parameters.AddWithValue("@MS_Username", regusername);
                                insertUserCardCommand.ExecuteNonQuery();
                            }
                            label6.Hide(); verC1.Hide(); verC2.Hide(); verC3.Hide(); verC4.Hide(); verC5.Hide(); verC6.Hide();
                            verMess.Show();
                            regTimer.Start();
                            regUsername.Text = "";
                            regEmail.Text = "";
                            regPassword.Text = "";
                            regCountry.SelectedIndex = -1;
                            regTermsService.Checked = false;
                        }
                    }
                    else
                    {
                        notifText.Text = "The verification code is incorrect!";
                        notifText.Show();
                        timer1.Start();
                    }
                }
                else
                {
                    notifText.Text = "You have not entered other numbers!";
                    notifText.Show();
                    timer1.Start();
                }
            }
        }
        //verification timer registration
        private void verTimer_Tick(object sender, EventArgs e)
        {
            if(verTimer.Interval == 2000)
            {
                verTimer.Stop();
                RegPanel.Hide();
                verifPanel.Show();
            }
        }
        //Register timer
        private void regTimer_Tick(object sender, EventArgs e)
        {
            if (regTimer.Interval == 2000)
            {
                regTimer.Stop();
                verMess.Hide();
                verifPanel.Hide();
                LogPanel.Show();
            }
        }
        //Focus on the previous field C1
        private void verC2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verC2.Text = "";
                verC1.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field C2
        private void verC3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verC3.Text = "";
                verC2.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field C3
        private void verC4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verC4.Text = "";
                verC3.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field C4
        private void verC5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verC5.Text = "";
                verC4.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field C5
        private void verC6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verC6.Text = "";
                verC5.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field L1
        private void verL2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verL2.Text = "";
                verL1.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field L2
        private void verL3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verL3.Text = "";
                verL2.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field L3
        private void verL4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verL4.Text = "";
                verL3.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field L4
        private void verL5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verL5.Text = "";
                verL4.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Focus on the previous field L5
        private void verL6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                verL6.Text = "";
                verL5.Focus();
                e.SuppressKeyPress = true;
            }
        }
        //Verification login textBox L1
        private void verL1_TextChanged(object sender, EventArgs e)
        {
            var text = verL1.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verL2.Focus();
            }
        }
        //Verification login textBox L2
        private void verL2_TextChanged(object sender, EventArgs e)
        {
            var text = verL2.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verL3.Focus();
            }
        }
        //Verification login textBox L3
        private void verL3_TextChanged(object sender, EventArgs e)
        {
            var text = verL3.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verL4.Focus();
            }
        }
        //Verification login textBox L4
        private void verL4_TextChanged(object sender, EventArgs e)
        {
            var text = verL4.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verL5.Focus();
            }
        }
        //Verification login textBox L5
        private void verL5_TextChanged(object sender, EventArgs e)
        {
            var text = verL5.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                verL6.Focus();
            }
        }
        //Verification login textBox L6
        private void verL6_TextChanged(object sender, EventArgs e)
        {
            var text = verL6.Text;
            if (text.Length == 1 && Char.IsDigit(text[0]))
            {
                if (int.TryParse(verL1.Text, out verl1) &&
                    int.TryParse(verL2.Text, out verl2) &&
                    int.TryParse(verL3.Text, out verl3) &&
                    int.TryParse(verL4.Text, out verl4) &&
                    int.TryParse(verL5.Text, out verl5) &&
                    int.TryParse(verL6.Text, out verl6))
                {
                    string enteredCode = string.Concat(verl1, verl2, verl3, verl4, verl5, verl6);
                    if (enteredCode == confirmationCode)
                    {
                        label10.Hide(); verL1.Hide(); verL2.Hide(); verL3.Hide(); verL4.Hide(); verL5.Hide(); verL6.Hide();
                        verlogMess.Show();
                        loginTimer.Start();
                    }
                    else
                    {
                        notifText.Text = "The verification code is incorrect!";
                        notifText.Show();
                        timer1.Start();
                    }
                }
                else
                {
                    notifText.Text = "You have not entered other numbers!";
                    notifText.Show();
                    timer1.Start();
                }
            }
        }
        //Verification login timer
        private void verTimerL_Tick(object sender, EventArgs e)
        {
            if (verTimerL.Interval == 2000)
            {
                verTimerL.Stop();
                LogPanel.Hide();
                VerifloginPanel.Show();
            }
        }
        //Login timer
        private void loginTimer_Tick(object sender, EventArgs e)
        {
            if (loginTimer.Interval == 2000)
            {
                loginTimer.Stop();
                verlogMess.Hide();
                VerifloginPanel.Hide();
                this.Hide();
                StoreMain stm = new StoreMain();
                stm.Show();
            }
        }
        //Application close button
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Timer form opacity
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer2.Stop();
            }
            Opacity += .2;
        }
        //Linkedin direct link profile
        private void lnBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/edis-vrtagic22/");
        }
        //YouTube direct link channel
        private void ytBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/c/DonMarquez21");
        }
        //GitHub direct link profile
        private void gitBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/EdisVrtagic");
        }
    }
}