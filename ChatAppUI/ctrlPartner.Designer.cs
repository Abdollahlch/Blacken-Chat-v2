namespace BlackenChat
{
    partial class ctrlPartner
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
            this.pbImageProfile = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.lblLastMessage = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUnseenMessages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImageProfile
            // 
            this.pbImageProfile.BackColor = System.Drawing.Color.Transparent;
            this.pbImageProfile.Image = global::BlackenChat.Properties.Resources.icons8_test_account_96;
            this.pbImageProfile.ImageRotate = 0F;
            this.pbImageProfile.Location = new System.Drawing.Point(12, 7);
            this.pbImageProfile.Name = "pbImageProfile";
            this.pbImageProfile.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.pbImageProfile.Size = new System.Drawing.Size(60, 54);
            this.pbImageProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImageProfile.TabIndex = 5;
            this.pbImageProfile.TabStop = false;
            // 
            // lblLastMessage
            // 
            this.lblLastMessage.AutoSize = true;
            this.lblLastMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblLastMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMessage.Location = new System.Drawing.Point(87, 52);
            this.lblLastMessage.Name = "lblLastMessage";
            this.lblLastMessage.Size = new System.Drawing.Size(41, 17);
            this.lblLastMessage.TabIndex = 4;
            this.lblLastMessage.Text = "label2";
            this.lblLastMessage.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(87, 11);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(38, 17);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "label";
            // 
            // lblUnseenMessages
            // 
            this.lblUnseenMessages.AutoSize = true;
            this.lblUnseenMessages.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnseenMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblUnseenMessages.Location = new System.Drawing.Point(271, 36);
            this.lblUnseenMessages.Name = "lblUnseenMessages";
            this.lblUnseenMessages.Size = new System.Drawing.Size(38, 13);
            this.lblUnseenMessages.TabIndex = 6;
            this.lblUnseenMessages.Text = "label1";
            // 
            // ctrlPartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblUnseenMessages);
            this.Controls.Add(this.pbImageProfile);
            this.Controls.Add(this.lblLastMessage);
            this.Controls.Add(this.lblUsername);
            this.Name = "ctrlPartner";
            this.Size = new System.Drawing.Size(269, 83);
            this.Load += new System.EventHandler(this.ctrlPartner_Load);
            this.Enter += new System.EventHandler(this.ctrlPartner_Enter);
            this.MouseEnter += new System.EventHandler(this.ctrlPartner_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ctrlPartner_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox pbImageProfile;
        private System.Windows.Forms.Label lblLastMessage;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUnseenMessages;
    }
}
