
namespace MercuryStore
{
    partial class FriendsListControl
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
            this.FollPic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.FollName = new System.Windows.Forms.Label();
            this.FollStatus = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FollPic)).BeginInit();
            this.SuspendLayout();
            // 
            // FollPic
            // 
            this.FollPic.BackColor = System.Drawing.Color.Transparent;
            this.FollPic.BorderRadius = 8;
            this.FollPic.FillColor = System.Drawing.Color.Transparent;
            this.FollPic.ImageRotate = 0F;
            this.FollPic.InitialImage = null;
            this.FollPic.Location = new System.Drawing.Point(9, 6);
            this.FollPic.Name = "FollPic";
            this.FollPic.Size = new System.Drawing.Size(32, 32);
            this.FollPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FollPic.TabIndex = 236;
            this.FollPic.TabStop = false;
            this.FollPic.MouseEnter += new System.EventHandler(this.FriendsListControl_MouseEnter);
            this.FollPic.MouseLeave += new System.EventHandler(this.FriendsListControl_MouseLeave);
            // 
            // FollName
            // 
            this.FollName.AutoSize = true;
            this.FollName.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FollName.ForeColor = System.Drawing.Color.White;
            this.FollName.Location = new System.Drawing.Point(52, 5);
            this.FollName.Name = "FollName";
            this.FollName.Size = new System.Drawing.Size(79, 17);
            this.FollName.TabIndex = 237;
            this.FollName.Text = "friendname";
            this.FollName.MouseEnter += new System.EventHandler(this.FriendsListControl_MouseEnter);
            this.FollName.MouseLeave += new System.EventHandler(this.FriendsListControl_MouseLeave);
            // 
            // FollStatus
            // 
            this.FollStatus.AutoSize = true;
            this.FollStatus.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FollStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.FollStatus.Location = new System.Drawing.Point(52, 23);
            this.FollStatus.Name = "FollStatus";
            this.FollStatus.Size = new System.Drawing.Size(42, 15);
            this.FollStatus.TabIndex = 238;
            this.FollStatus.Text = "Offline";
            this.FollStatus.MouseEnter += new System.EventHandler(this.FriendsListControl_MouseEnter);
            this.FollStatus.MouseLeave += new System.EventHandler(this.FriendsListControl_MouseLeave);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 8;
            this.guna2Elipse1.TargetControl = this;
            // 
            // FriendsListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.Controls.Add(this.FollStatus);
            this.Controls.Add(this.FollName);
            this.Controls.Add(this.FollPic);
            this.Name = "FriendsListControl";
            this.Size = new System.Drawing.Size(180, 45);
            this.Load += new System.EventHandler(this.FriendsListControl_Load);
            this.MouseEnter += new System.EventHandler(this.FriendsListControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FriendsListControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.FollPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2PictureBox FollPic;
        private System.Windows.Forms.Label FollName;
        private System.Windows.Forms.Label FollStatus;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
