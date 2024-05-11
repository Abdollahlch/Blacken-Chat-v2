using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ChatAppUI
{
    public partial class ctrlMessage : UserControl
    {

        public ctrlMessage(string MessageContent,DateTime dateTime,bool isSeen)
        {
            InitializeComponent();
            
            label2.Text = dateTime.ToString("HH:mm");
            //Size messageSize = TextRenderer.MeasureText(MessageContent, pnlMessage.Font);
            //siticoneCustomGradientPanel1.Size = new Size(messageSize.Width + 35, 50);
           
            if (MessageContent.Length > 100)
            {
                
                string NewMessage = "";
                for (int i = 0; i < MessageContent.Length; i++)
                {
                    if (i % 70 == 0 && i != 0)
                    {
                        NewMessage += '\n';
                        if (MessageContent.Length>1000)
                        {
                        this.Size = new Size(this.Size.Width+13, this.Size.Height+ 15);
                        txtMessageContent.Size = new Size(txtMessageContent.Size.Width, txtMessageContent.Size.Height+17);

                        }
                        else
                        {
                            this.Size = new Size(this.Size.Width + 13, this.Size.Height + 23);
                            txtMessageContent.Size = new Size(txtMessageContent.Size.Width, txtMessageContent.Size.Height + 24);
                        }

                    }
                    NewMessage += MessageContent[i];
                }
                MessageContent = NewMessage;

            }
            else
            {
                this.Size = new Size(MessageContent.Length*6+80, this.Size.Height-20);

            }
            this.Size = new Size(this.Size.Width, this.Size.Height + 20);
            


            txtMessageContent.Text = MessageContent;
            Size messageSize = TextRenderer.MeasureText(txtMessageContent.Text, txtMessageContent.Font);

            // Adjust the size of the control based on message size
            int maxWidth = 250; // Maximum width for the message control
            int maxHeight = 100; // Maximum height for the message control
            int padding = 10; // Padding around the message content

            int controlWidth = Math.Min(messageSize.Width + padding , maxWidth);
            int controlHeight = Math.Min(messageSize.Height + padding, maxHeight);

           //this.Size = new Size(controlWidth*2, controlHeight*4);
            //txtMessageContent.Height *= 2;

            // Set the size of the control
            //if (MessageContent.Length < 20)
            //{
            //    this.Size = new Size(controlWidth + 80, controlHeight+20);
            //}
            //else
            //{
            //    this.Size = new Size(controlWidth + 120, controlHeight + MessageContent.Length/2);
            //}
            //this.Size = new Size(controlWidth+40, controlHeight+30);

            //ResizeTextBoxToFitContent();



            //how to make sure that the message displaying time correctly in right of the message
            label2.Location = new Point(pnlMessage.Width - label2.Width - 18, pnlMessage.Location.Y+pnlMessage.Height-20);
            pbIsSeen.Location = new Point(pnlMessage.Width - label2.Width+13 , label2.Location.Y-5);
            if (isSeen)
            {
                pbIsSeen.Image = imageList1.Images[1];
            }
            else
                pbIsSeen.Image = imageList1.Images[0];
            this.isSeen = isSeen;
        }


        private void ResizeTextBoxToFitContent()
        {
            // Calculate the size required to display all text
            SizeF textSize = TextRenderer.MeasureText(txtMessageContent.Text, txtMessageContent.Font);
            int textWidth = (int)Math.Ceiling(textSize.Width);
            int textHeight = (int)Math.Ceiling(textSize.Height);

            // Add some padding to the calculated size
            int padding = 10;
            int newWidth = textWidth + padding;
            int newHeight = textHeight + padding;

            // Set the new size of the TextBox
            txtMessageContent.Size = new Size(newWidth*4, newHeight*3);
        }
        

        public Color TextBoxColor
        {
            set
            {
                txtMessageContent.FillColor = value;
            }
        }


        public bool DisableSeen
        {
            set
            {
                pbIsSeen.Visible = !value;
            }
            get
            {
                return pbIsSeen.Visible;
            }

        }
        public bool isSeen { set; get; }
        public DateTime MessageTime
        {
            get
            {
                return DateTime.Parse(label2.Text);
            }
            set
            {
                label2.Text = value.ToString("HH:mm");
            }
        }
        public string MessageContent
        {
            get
            {
                return txtMessageContent.Text;
            }
            set
            {
                txtMessageContent.Text = value;
            }
        }
        public Font MessageFont
        {
            get
            {
                return txtMessageContent.Font;
            }
            set
            {
                txtMessageContent.Font = value;
            }
        }

        public Color MessageColor { set { 
                pnlMessage.FillColor = value;
                pnlMessage.FillColor2 = value;
                pnlMessage.FillColor3 = value;
                pnlMessage.FillColor4 = value;
            } }
       

        private void ctrlMessage_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void siticoneCustomGradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlMessage_Load(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //how can i copy text to clipboard
            Clipboard.SetText(txtMessageContent.Text);
        }
    }
}
