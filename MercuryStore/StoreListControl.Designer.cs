
namespace MercuryStore
{
    partial class StoreListControl
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
            this.GameImg = new Guna.UI2.WinForms.Guna2PictureBox();
            this.RE_Label = new System.Windows.Forms.Label();
            this.GA_Label = new System.Windows.Forms.Label();
            this.GlPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.GP_Label = new System.Windows.Forms.Label();
            this.DiscListValLabel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.AftListPriceLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameImg)).BeginInit();
            this.SuspendLayout();
            // 
            // GameImg
            // 
            this.GameImg.BorderRadius = 8;
            this.GameImg.FillColor = System.Drawing.Color.Empty;
            this.GameImg.ImageRotate = 0F;
            this.GameImg.Location = new System.Drawing.Point(0, 2);
            this.GameImg.Name = "GameImg";
            this.GameImg.Size = new System.Drawing.Size(198, 243);
            this.GameImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GameImg.TabIndex = 9;
            this.GameImg.TabStop = false;
            // 
            // RE_Label
            // 
            this.RE_Label.AutoSize = true;
            this.RE_Label.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RE_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            this.RE_Label.Location = new System.Drawing.Point(2, 253);
            this.RE_Label.Name = "RE_Label";
            this.RE_Label.Size = new System.Drawing.Size(72, 13);
            this.RE_Label.TabIndex = 11;
            this.RE_Label.Text = "Release date";
            this.RE_Label.MouseEnter += new System.EventHandler(this.GlPanel_MouseEnter);
            this.RE_Label.MouseLeave += new System.EventHandler(this.GlPanel_MouseLeave);
            // 
            // GA_Label
            // 
            this.GA_Label.AutoSize = true;
            this.GA_Label.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GA_Label.ForeColor = System.Drawing.Color.White;
            this.GA_Label.Location = new System.Drawing.Point(0, 271);
            this.GA_Label.Name = "GA_Label";
            this.GA_Label.Size = new System.Drawing.Size(81, 20);
            this.GA_Label.TabIndex = 12;
            this.GA_Label.Text = "Game title";
            this.GA_Label.MouseEnter += new System.EventHandler(this.GlPanel_MouseEnter);
            this.GA_Label.MouseLeave += new System.EventHandler(this.GlPanel_MouseLeave);
            // 
            // GlPanel
            // 
            this.GlPanel.FillColor = System.Drawing.Color.Empty;
            this.GlPanel.FillColor2 = System.Drawing.Color.Empty;
            this.GlPanel.FillColor3 = System.Drawing.Color.Empty;
            this.GlPanel.FillColor4 = System.Drawing.Color.Empty;
            this.GlPanel.Location = new System.Drawing.Point(0, 0);
            this.GlPanel.Name = "GlPanel";
            this.GlPanel.Size = new System.Drawing.Size(199, 244);
            this.GlPanel.TabIndex = 14;
            this.GlPanel.MouseEnter += new System.EventHandler(this.GlPanel_MouseEnter);
            this.GlPanel.MouseLeave += new System.EventHandler(this.GlPanel_MouseLeave);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this.GlPanel;
            // 
            // GP_Label
            // 
            this.GP_Label.AutoSize = true;
            this.GP_Label.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.GP_Label.ForeColor = System.Drawing.Color.Gainsboro;
            this.GP_Label.Location = new System.Drawing.Point(121, 297);
            this.GP_Label.Name = "GP_Label";
            this.GP_Label.Size = new System.Drawing.Size(53, 20);
            this.GP_Label.TabIndex = 425;
            this.GP_Label.Text = "€12.99";
            this.GP_Label.MouseEnter += new System.EventHandler(this.GlPanel_MouseEnter);
            this.GP_Label.MouseLeave += new System.EventHandler(this.GlPanel_MouseLeave);
            // 
            // DiscListValLabel
            // 
            this.DiscListValLabel.BackColor = System.Drawing.Color.Transparent;
            this.DiscListValLabel.BorderRadius = 4;
            this.DiscListValLabel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DiscListValLabel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DiscListValLabel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DiscListValLabel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DiscListValLabel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DiscListValLabel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(39)))));
            this.DiscListValLabel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.DiscListValLabel.Font = new System.Drawing.Font("Roboto", 7F, System.Drawing.FontStyle.Bold);
            this.DiscListValLabel.ForeColor = System.Drawing.Color.White;
            this.DiscListValLabel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(39)))));
            this.DiscListValLabel.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.DiscListValLabel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DiscListValLabel.ImageOffset = new System.Drawing.Point(21, 0);
            this.DiscListValLabel.ImageSize = new System.Drawing.Size(27, 27);
            this.DiscListValLabel.Location = new System.Drawing.Point(5, 297);
            this.DiscListValLabel.Name = "DiscListValLabel";
            this.DiscListValLabel.Size = new System.Drawing.Size(52, 21);
            this.DiscListValLabel.TabIndex = 424;
            this.DiscListValLabel.Text = "-10%";
            this.DiscListValLabel.MouseEnter += new System.EventHandler(this.GlPanel_MouseEnter);
            this.DiscListValLabel.MouseLeave += new System.EventHandler(this.GlPanel_MouseLeave);
            // 
            // AftListPriceLbl
            // 
            this.AftListPriceLbl.AutoSize = true;
            this.AftListPriceLbl.Font = new System.Drawing.Font("Open Sans", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.AftListPriceLbl.ForeColor = System.Drawing.Color.DarkGray;
            this.AftListPriceLbl.Location = new System.Drawing.Point(62, 297);
            this.AftListPriceLbl.Name = "AftListPriceLbl";
            this.AftListPriceLbl.Size = new System.Drawing.Size(53, 20);
            this.AftListPriceLbl.TabIndex = 423;
            this.AftListPriceLbl.Text = "€25.99";
            this.AftListPriceLbl.MouseEnter += new System.EventHandler(this.GlPanel_MouseEnter);
            this.AftListPriceLbl.MouseLeave += new System.EventHandler(this.GlPanel_MouseLeave);
            // 
            // StoreListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.Controls.Add(this.GP_Label);
            this.Controls.Add(this.GlPanel);
            this.Controls.Add(this.DiscListValLabel);
            this.Controls.Add(this.AftListPriceLbl);
            this.Controls.Add(this.RE_Label);
            this.Controls.Add(this.GA_Label);
            this.Controls.Add(this.GameImg);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.Name = "StoreListControl";
            this.Size = new System.Drawing.Size(198, 322);
            this.Load += new System.EventHandler(this.StoreListControl_Load);
            this.MouseEnter += new System.EventHandler(this.GlPanel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.GlPanel_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.GameImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox GameImg;
        private System.Windows.Forms.Label RE_Label;
        private System.Windows.Forms.Label GA_Label;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel GlPanel;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.Label GP_Label;
        public Guna.UI2.WinForms.Guna2GradientButton DiscListValLabel;
        public System.Windows.Forms.Label AftListPriceLbl;
    }
}
