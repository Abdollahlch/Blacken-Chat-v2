namespace ChatAppUI
{
    partial class ctrlChat
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
            this.pnlPartner = new Siticone.Desktop.UI.WinForms.SiticoneCustomGradientPanel();
            this.pbImageProfile = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.lblLastMessage = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlPartner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPartner
            // 
            this.pnlPartner.Controls.Add(this.pbImageProfile);
            this.pnlPartner.Controls.Add(this.lblLastMessage);
            this.pnlPartner.Controls.Add(this.lblUsername);
            this.pnlPartner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPartner.FillColor = System.Drawing.SystemColors.Info;
            this.pnlPartner.Location = new System.Drawing.Point(0, 0);
            this.pnlPartner.Name = "pnlPartner";
            this.pnlPartner.ShadowDecoration.Color = System.Drawing.Color.IndianRed;
            this.pnlPartner.Size = new System.Drawing.Size(200, 59);
            this.pnlPartner.TabIndex = 0;
            this.pnlPartner.Click += new System.EventHandler(this.siticoneCustomGradientPanel1_Click);
            this.pnlPartner.Paint += new System.Windows.Forms.PaintEventHandler(this.siticoneCustomGradientPanel1_Paint);
            // 
            // pbImageProfile
            // 
            this.pbImageProfile.Image = global::BlackenChat.Properties.Resources.profile;
            this.pbImageProfile.ImageRotate = 0F;
            this.pbImageProfile.Location = new System.Drawing.Point(3, 9);
            this.pbImageProfile.Name = "pbImageProfile";
            this.pbImageProfile.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.pbImageProfile.Size = new System.Drawing.Size(44, 40);
            this.pbImageProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImageProfile.TabIndex = 2;
            this.pbImageProfile.TabStop = false;
            // 
            // lblLastMessage
            // 
            this.lblLastMessage.AutoSize = true;
            this.lblLastMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblLastMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMessage.Location = new System.Drawing.Point(54, 32);
            this.lblLastMessage.Name = "lblLastMessage";
            this.lblLastMessage.Size = new System.Drawing.Size(41, 17);
            this.lblLastMessage.TabIndex = 1;
            this.lblLastMessage.Text = "label2";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(54, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(38, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "label";
            // 
            // ctrlChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPartner);
            this.Name = "ctrlChat";
            this.Size = new System.Drawing.Size(200, 59);
            this.Click += new System.EventHandler(this.ctrlChat_Click);
            this.pnlPartner.ResumeLayout(false);
            this.pnlPartner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneCustomGradientPanel pnlPartner;
        private System.Windows.Forms.Label lblUsername;
        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox pbImageProfile;
        private System.Windows.Forms.Label lblLastMessage;
    }
}
