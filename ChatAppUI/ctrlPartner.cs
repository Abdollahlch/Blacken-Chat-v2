using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackenChat
{
    public partial class ctrlPartner : UserControl
    {

        public ctrlPartner(string Username,byte[] image,int NumberOfUnseenMessages,bool DarkMode)
        {
            InitializeComponent();
            this.Username = Username;
           
           UnseenMessages = NumberOfUnseenMessages;
            if (image != null )
            {
                using (MemoryStream ms = new MemoryStream(image))
                {
                    pbImageProfile.Image = Image.FromStream(ms);
                }
            }
            this.DarkMode = DarkMode;

        }
        //create a function that convert byte array to image






        public bool DarkMode
        {
            set
            {
                if (value)
                {
                    this.BackColor = Color.Black;
                    lblUsername.ForeColor = Color.White;
                    lblLastMessage.ForeColor = Color.White;
                   
                }
                else
                {
                    this.BackColor = Color.White;
                    lblUsername.ForeColor = Color.Black;
                    lblLastMessage.ForeColor = Color.Black;
                    
                }
            }
            get
            {
                
                return this.BackColor == Color.Black;
            }
            
        }
        public int x { set; get; }
       public bool isDarkMode()
        {
            return this.BackColor == Color.Black;
        }
       
        public int UnseenMessages
        {
            set
            {
                if (value > 0)
                {
                    lblUnseenMessages.Text = value.ToString();
                    lblUnseenMessages.Visible = true ;
                }
                else
                    lblUnseenMessages.Visible = false;
            }
            get
            {
                return int.Parse(lblUnseenMessages.Text);
            }
        }


        public string Username
        {
            set
            {
                lblUsername.Text = value;
            }
            get
            {
                return lblUsername.Text;
            }

        }
        public string LastMessage
        {
            set
            {
                lblLastMessage.Text = value;
                lblLastMessage.Visible = true;
            }
            get
            {
                return lblLastMessage.Text;
            }
        }
        public string ImageProfile
        {
            set
            {
               //load it from database

                pbImageProfile.ImageLocation = value;
            }
            get
            {
                return pbImageProfile.ImageLocation;
            }
        }

        private void ctrlPartner_Load(object sender, EventArgs e)
        {
            
            this.Tag = Username;
            
        }

        private void ctrlPartner_Enter(object sender, EventArgs e)
        {
            
        }

        
        private void ctrlPartner_MouseEnter(object sender, EventArgs e)
        {
            if (DarkMode)
            {
                this.BackColor = Color.FromArgb(64, 64, 64); // Adjust color for dark mode
            }
            else
            {
                this.BackColor = Color.FromArgb(224, 224, 224); // Adjust color for light mode
               
            }
        }

        private void ctrlPartner_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor==Color.FromArgb(64,64,64))
            {
                this.BackColor = Color.Black;
            }
            else
                this.BackColor = Color.White;
            

        }
    }
}
