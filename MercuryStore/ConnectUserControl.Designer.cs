
namespace MercuryStore
{
    partial class ConnectUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectUserControl));
            this.NameFriend = new System.Windows.Forms.Label();
            this.FriendPic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ConnUserBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FriendPic)).BeginInit();
            this.SuspendLayout();
            // 
            // NameFriend
            // 
            this.NameFriend.AutoSize = true;
            this.NameFriend.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameFriend.ForeColor = System.Drawing.Color.White;
            this.NameFriend.Location = new System.Drawing.Point(52, 5);
            this.NameFriend.Name = "NameFriend";
            this.NameFriend.Size = new System.Drawing.Size(79, 17);
            this.NameFriend.TabIndex = 240;
            this.NameFriend.Text = "namefriend";
            // 
            // FriendPic
            // 
            this.FriendPic.BackColor = System.Drawing.Color.Transparent;
            this.FriendPic.BorderRadius = 8;
            this.FriendPic.FillColor = System.Drawing.Color.Transparent;
            this.FriendPic.ImageRotate = 0F;
            this.FriendPic.InitialImage = null;
            this.FriendPic.Location = new System.Drawing.Point(9, 6);
            this.FriendPic.Name = "FriendPic";
            this.FriendPic.Size = new System.Drawing.Size(32, 32);
            this.FriendPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FriendPic.TabIndex = 239;
            this.FriendPic.TabStop = false;
            // 
            // ConnUserBtn
            // 
            this.ConnUserBtn.BackColor = System.Drawing.Color.Transparent;
            this.ConnUserBtn.BorderRadius = 4;
            this.ConnUserBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ConnUserBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ConnUserBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ConnUserBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ConnUserBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ConnUserBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.ConnUserBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.ConnUserBtn.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.ConnUserBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConnUserBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ConnUserBtn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ConnUserBtn.Image = ((System.Drawing.Image)(resources.GetObject("ConnUserBtn.Image")));
            this.ConnUserBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConnUserBtn.ImageOffset = new System.Drawing.Point(-11, 0);
            this.ConnUserBtn.ImageSize = new System.Drawing.Size(14, 14);
            this.ConnUserBtn.Location = new System.Drawing.Point(53, 23);
            this.ConnUserBtn.Name = "ConnUserBtn";
            this.ConnUserBtn.PressedDepth = 0;
            this.ConnUserBtn.Size = new System.Drawing.Size(85, 20);
            this.ConnUserBtn.TabIndex = 358;
            this.ConnUserBtn.Text = "Connect";
            this.ConnUserBtn.Click += new System.EventHandler(this.ConnUserBtn_Click);
            this.ConnUserBtn.MouseEnter += new System.EventHandler(this.ConnectUserControl_MouseEnter);
            this.ConnUserBtn.MouseLeave += new System.EventHandler(this.ConnectUserControl_MouseLeave);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 8;
            this.guna2Elipse1.TargetControl = this;
            // 
            // ConnectUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.Controls.Add(this.ConnUserBtn);
            this.Controls.Add(this.NameFriend);
            this.Controls.Add(this.FriendPic);
            this.Name = "ConnectUserControl";
            this.Size = new System.Drawing.Size(180, 45);
            this.Load += new System.EventHandler(this.ConnectUserControl_Load);
            this.MouseEnter += new System.EventHandler(this.ConnectUserControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ConnectUserControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.FriendPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NameFriend;
        public Guna.UI2.WinForms.Guna2PictureBox FriendPic;
        private Guna.UI2.WinForms.Guna2GradientButton ConnUserBtn;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
