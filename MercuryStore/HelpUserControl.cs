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
    public partial class HelpUserControl : UserControl
    {
        public HelpUserControl()
        {
            InitializeComponent();
        }

        private void HelpUserControl_Load(object sender, EventArgs e)
        {
            string merctext = "Welcome to Mercury Game Store - your favorite destination for all your gaming needs! At Mercury Game Store, we understand how important it is for our users to have the best experience when buying and playing games. That's why we're here to provide you with a comprehensive help option so you can fully enjoy the world of gaming.\n\nHow to use the Help option in Mercury Game Store\nIf you encounter any questions, issues, or need assistance while using our platform, the Help option is here to assist you. You can access the Help option from the main menu of our application, where\nyou will find a range of useful resources and information to help you resolve your issue.\n\nContact Our Customer Support\nIf your issue requires personalized assistance or if you simply want to speak with our experts, feel free to reach out to us. Our Customer Support is available via email and live chat. Here, experienced agents will provide you with quick and accurate answers to your questions and resolve any issues you may have.\n\nAdvanced Technical Support\nIf you encounter technical challenges while playing games or installing software, our team of technical support experts is at your disposal.You can contact us to receive advice and solutions for any technical issue you may be facing. Our goal at Mercury Game Store is to ensure that every user has an exceptional experience during their time with us.With our Help option, you are always covered, whether you need information, problem - solving, or just a few tips for better gaming. We thank you for being part of our gaming community and look forward to assisting you in achieving all your gaming dreams!\n\n*** Terms of Use for Mercury Game Store ***\nPlease read these Terms of Use carefully before accessing or using Mercury Game Store (hereinafter 'We' or 'Mercury Game Store') or any of its services. By accessing or using any part of Mercury Game Store, you acknowledge that you have read, understood, and agree to the following terms and conditions. If you do not agree to these terms, do not access or use Mercury Game Store.\n\n*** 1. Registration and Account ***\n\n1.1. Certain features of Mercury Game Store may require registration and the creation of a user account. You are responsible for maintaining the confidentiality of your account and password.\n1.2.By accepting these Terms of Use, you agree that you are responsible for all activities that occur on your account.\n\n*** 2. Purchase and Payment***\n\n2.1. Mercury Game Store enables the purchase of digital and physical products. Payment for products is made through the selected payment method. All payments are subject to applicable prices and taxes.\n2.2.By purchasing a product on Mercury Game Store, you agree to specific return terms and policies applicable to that particular product.\n\n*** 3. Intellectual Property ***\n\n3.1. The content of Mercury Game Store, including but not limited to games, text, graphics, logos, icons, and software, is protected by intellectual property laws and copyrights.\n3.2.Unauthorized copying, distribution, or use of any part of Mercury Game Store content is prohibited.\n\n*** 4. Usage Restrictions ***\n\n4.1. You are not authorized to use Mercury Game Store in a way that could cause harm to the platform, other users, or third parties.\n4.2.Using Mercury Game Store for illegal purposes or violating any laws or regulations is prohibited.\n\n*** 5. Privacy and Security ***\n\n5.1. All data you provide to Mercury Game Store is subject to our Privacy Policy. We commit to safeguarding your data and implementing appropriate security measures.\n\n*** 6. Amendment of Terms of Use ***\n\n6.1. Mercury Game Store reserves the right to periodically update or modify these Terms of Use. Any changes will be posted on the platform and will be effective from the date of publication.\n\n*** 7. Final Provisions ***\n\n7.1. These Terms of Use constitute the entire agreement between you and Mercury Game Store regarding the use of the platform.\n\n7.2.In case of any discrepancies or conflicts between these Terms of Use and any other agreements you may have with Mercury Game Store, these Terms shall prevail.\nThank you for using Mercury Game Store! Enjoy gaming and entertainment.\n\n*** Last Modified Date: Sep 25, 2023 ***";
            HelpRichTB.Text = merctext;
        }
    }
}
