
namespace MercuryStore
{
    partial class NotifControl
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
            this.NotifDeleteBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.NotifText = new System.Windows.Forms.RichTextBox();
            this.NotifDateLbl = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // NotifDeleteBtn
            // 
            this.NotifDeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NotifDeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.NotifDeleteBtn.CustomClick = true;
            this.NotifDeleteBtn.FillColor = System.Drawing.Color.Transparent;
            this.NotifDeleteBtn.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.NotifDeleteBtn.IconColor = System.Drawing.Color.White;
            this.NotifDeleteBtn.Location = new System.Drawing.Point(317, 7);
            this.NotifDeleteBtn.Name = "NotifDeleteBtn";
            this.NotifDeleteBtn.PressedDepth = 0;
            this.NotifDeleteBtn.Size = new System.Drawing.Size(15, 17);
            this.NotifDeleteBtn.TabIndex = 381;
            this.NotifDeleteBtn.Click += new System.EventHandler(this.NotifDeleteBtn_Click);
            // 
            // NotifText
            // 
            this.NotifText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.NotifText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NotifText.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NotifText.ForeColor = System.Drawing.Color.White;
            this.NotifText.Location = new System.Drawing.Point(24, 29);
            this.NotifText.MaxLength = 184;
            this.NotifText.Name = "NotifText";
            this.NotifText.ReadOnly = true;
            this.NotifText.Size = new System.Drawing.Size(265, 105);
            this.NotifText.TabIndex = 378;
            this.NotifText.Text = "";
            // 
            // NotifDateLbl
            // 
            this.NotifDateLbl.AutoSize = true;
            this.NotifDateLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.NotifDateLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.NotifDateLbl.ForeColor = System.Drawing.Color.Gainsboro;
            this.NotifDateLbl.Location = new System.Drawing.Point(22, 9);
            this.NotifDateLbl.Name = "NotifDateLbl";
            this.NotifDateLbl.Size = new System.Drawing.Size(96, 15);
            this.NotifDateLbl.TabIndex = 380;
            this.NotifDateLbl.Text = "Notification date";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(39)))));
            this.guna2Panel1.Location = new System.Drawing.Point(7, 33);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(11, 11);
            this.guna2Panel1.TabIndex = 379;
            // 
            // NotifControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.NotifDeleteBtn);
            this.Controls.Add(this.NotifText);
            this.Controls.Add(this.NotifDateLbl);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "NotifControl";
            this.Size = new System.Drawing.Size(338, 140);
            this.Load += new System.EventHandler(this.NotifControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Guna.UI2.WinForms.Guna2ControlBox NotifDeleteBtn;
        private System.Windows.Forms.RichTextBox NotifText;
        private System.Windows.Forms.Label NotifDateLbl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
