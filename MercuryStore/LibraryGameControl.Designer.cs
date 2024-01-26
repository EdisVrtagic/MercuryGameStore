
namespace MercuryStore
{
    partial class LibraryGameControl
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
            this.PlayBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GameRelLib = new System.Windows.Forms.Label();
            this.GameLibName = new System.Windows.Forms.Label();
            this.GameLibImg = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameLibImg)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayBtn
            // 
            this.PlayBtn.Animated = true;
            this.PlayBtn.BorderRadius = 5;
            this.PlayBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.PlayBtn.CheckedState.ForeColor = System.Drawing.Color.White;
            this.PlayBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.PlayBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.PlayBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.PlayBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.PlayBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.PlayBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(39)))));
            this.PlayBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.PlayBtn.Font = new System.Drawing.Font("Outfit", 9.5F);
            this.PlayBtn.ForeColor = System.Drawing.Color.White;
            this.PlayBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PlayBtn.Location = new System.Drawing.Point(128, 277);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(57, 25);
            this.PlayBtn.TabIndex = 390;
            this.PlayBtn.Text = "Play";
            // 
            // GameRelLib
            // 
            this.GameRelLib.AutoSize = true;
            this.GameRelLib.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GameRelLib.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            this.GameRelLib.Location = new System.Drawing.Point(6, 287);
            this.GameRelLib.Name = "GameRelLib";
            this.GameRelLib.Size = new System.Drawing.Size(78, 15);
            this.GameRelLib.TabIndex = 388;
            this.GameRelLib.Text = "Release date";
            // 
            // GameLibName
            // 
            this.GameLibName.AutoSize = true;
            this.GameLibName.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GameLibName.ForeColor = System.Drawing.Color.White;
            this.GameLibName.Location = new System.Drawing.Point(5, 252);
            this.GameLibName.Name = "GameLibName";
            this.GameLibName.Size = new System.Drawing.Size(94, 20);
            this.GameLibName.TabIndex = 389;
            this.GameLibName.Text = "Game Name";
            // 
            // GameLibImg
            // 
            this.GameLibImg.BorderRadius = 8;
            this.GameLibImg.FillColor = System.Drawing.Color.Empty;
            this.GameLibImg.ImageRotate = 0F;
            this.GameLibImg.Location = new System.Drawing.Point(5, 5);
            this.GameLibImg.Name = "GameLibImg";
            this.GameLibImg.Size = new System.Drawing.Size(180, 243);
            this.GameLibImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GameLibImg.TabIndex = 387;
            this.GameLibImg.TabStop = false;
            // 
            // LibraryGameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.GameRelLib);
            this.Controls.Add(this.GameLibName);
            this.Controls.Add(this.GameLibImg);
            this.Name = "LibraryGameControl";
            this.Size = new System.Drawing.Size(190, 310);
            ((System.ComponentModel.ISupportInitialize)(this.GameLibImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2GradientButton PlayBtn;
        private System.Windows.Forms.Label GameRelLib;
        private System.Windows.Forms.Label GameLibName;
        private Guna.UI2.WinForms.Guna2PictureBox GameLibImg;
    }
}
