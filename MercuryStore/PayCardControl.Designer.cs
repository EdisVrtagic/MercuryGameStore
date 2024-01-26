
namespace MercuryStore
{
    partial class PayCardControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayCardControl));
            this.ExpCarLbl = new System.Windows.Forms.Label();
            this.NaCarLbl = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.CCardPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CCardPic)).BeginInit();
            this.SuspendLayout();
            // 
            // ExpCarLbl
            // 
            this.ExpCarLbl.AutoSize = true;
            this.ExpCarLbl.BackColor = System.Drawing.Color.Transparent;
            this.ExpCarLbl.Font = new System.Drawing.Font("Roboto", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExpCarLbl.ForeColor = System.Drawing.Color.LightGray;
            this.ExpCarLbl.Location = new System.Drawing.Point(57, 41);
            this.ExpCarLbl.Name = "ExpCarLbl";
            this.ExpCarLbl.Size = new System.Drawing.Size(90, 13);
            this.ExpCarLbl.TabIndex = 372;
            this.ExpCarLbl.Text = "Expires on 10/23";
            // 
            // NaCarLbl
            // 
            this.NaCarLbl.AutoSize = true;
            this.NaCarLbl.BackColor = System.Drawing.Color.Transparent;
            this.NaCarLbl.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NaCarLbl.ForeColor = System.Drawing.Color.White;
            this.NaCarLbl.Location = new System.Drawing.Point(57, 22);
            this.NaCarLbl.Name = "NaCarLbl";
            this.NaCarLbl.Size = new System.Drawing.Size(130, 14);
            this.NaCarLbl.TabIndex = 371;
            this.NaCarLbl.Text = "Name card and number";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // CCardPic
            // 
            this.CCardPic.BackColor = System.Drawing.Color.Transparent;
            this.CCardPic.Image = ((System.Drawing.Image)(resources.GetObject("CCardPic.Image")));
            this.CCardPic.Location = new System.Drawing.Point(12, 20);
            this.CCardPic.Name = "CCardPic";
            this.CCardPic.Size = new System.Drawing.Size(35, 35);
            this.CCardPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CCardPic.TabIndex = 370;
            this.CCardPic.TabStop = false;
            // 
            // PayCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.ExpCarLbl);
            this.Controls.Add(this.NaCarLbl);
            this.Controls.Add(this.CCardPic);
            this.Name = "PayCardControl";
            this.Size = new System.Drawing.Size(606, 75);
            ((System.ComponentModel.ISupportInitialize)(this.CCardPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.PictureBox CCardPic;
        public System.Windows.Forms.Label ExpCarLbl;
        public System.Windows.Forms.Label NaCarLbl;
    }
}
