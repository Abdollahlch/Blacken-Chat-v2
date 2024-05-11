namespace ChatAppUI
{
    partial class ctrlMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlMessage));
            this.pnlMessage = new Siticone.Desktop.UI.WinForms.SiticoneCustomGradientPanel();
            this.siticoneContextMenuStrip1 = new Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMessageContent = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.pbIsSeen = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlMessage.SuspendLayout();
            this.siticoneContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsSeen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMessage
            // 
            this.pnlMessage.BorderRadius = 10;
            this.pnlMessage.ContextMenuStrip = this.siticoneContextMenuStrip1;
            this.pnlMessage.Controls.Add(this.txtMessageContent);
            this.pnlMessage.Controls.Add(this.pbIsSeen);
            this.pnlMessage.Controls.Add(this.label2);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlMessage.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlMessage.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlMessage.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(243, 63);
            this.pnlMessage.TabIndex = 0;
            this.pnlMessage.Paint += new System.Windows.Forms.PaintEventHandler(this.siticoneCustomGradientPanel1_Paint_1);
            // 
            // siticoneContextMenuStrip1
            // 
            this.siticoneContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.toolStripMenuItem1});
            this.siticoneContextMenuStrip1.Name = "siticoneContextMenuStrip1";
            this.siticoneContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.ColorTable = null;
            this.siticoneContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.siticoneContextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "Delete";
            // 
            // txtMessageContent
            // 
            this.txtMessageContent.Animated = true;
            this.txtMessageContent.AutoRoundedCorners = true;
            this.txtMessageContent.BackColor = System.Drawing.Color.Transparent;
            this.txtMessageContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMessageContent.BorderRadius = 18;
            this.txtMessageContent.BorderThickness = 0;
            this.txtMessageContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessageContent.DefaultText = "";
            this.txtMessageContent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMessageContent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMessageContent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessageContent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessageContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessageContent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMessageContent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessageContent.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtMessageContent.ForeColor = System.Drawing.Color.Black;
            this.txtMessageContent.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessageContent.Location = new System.Drawing.Point(0, 0);
            this.txtMessageContent.Multiline = true;
            this.txtMessageContent.Name = "txtMessageContent";
            this.txtMessageContent.PasswordChar = '\0';
            this.txtMessageContent.PlaceholderForeColor = System.Drawing.Color.Transparent;
            this.txtMessageContent.PlaceholderText = "";
            this.txtMessageContent.ReadOnly = true;
            this.txtMessageContent.SelectedText = "";
            this.txtMessageContent.Size = new System.Drawing.Size(243, 39);
            this.txtMessageContent.TabIndex = 3;
            // 
            // pbIsSeen
            // 
            this.pbIsSeen.BackColor = System.Drawing.Color.Transparent;
            this.pbIsSeen.Image = global::BlackenChat.Properties.Resources.icons8_close_50__1_1;
            this.pbIsSeen.Location = new System.Drawing.Point(211, 42);
            this.pbIsSeen.Name = "pbIsSeen";
            this.pbIsSeen.Size = new System.Drawing.Size(17, 20);
            this.pbIsSeen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIsSeen.TabIndex = 2;
            this.pbIsSeen.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(163, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-done-50.png");
            this.imageList1.Images.SetKeyName(1, "check-mark.png");
            // 
            // ctrlMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMessage);
            this.Name = "ctrlMessage";
            this.Size = new System.Drawing.Size(243, 63);
            this.Load += new System.EventHandler(this.ctrlMessage_Load);
            this.MouseEnter += new System.EventHandler(this.ctrlMessage_MouseEnter);
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            this.siticoneContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIsSeen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneCustomGradientPanel pnlMessage;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip siticoneContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbIsSeen;
        private System.Windows.Forms.ImageList imageList1;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtMessageContent;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
