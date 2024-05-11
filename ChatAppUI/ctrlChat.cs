using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppUI
{
    public partial class ctrlChat : UserControl
    {
        public ctrlChat()
        {
            InitializeComponent();
            
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
                pbImageProfile.ImageLocation = value;
            }
            get
            {
                return pbImageProfile.ImageLocation;
            }
        }
        private void MyUserControl_CustomEvent(object sender, EventArgs e)
        {
            // Handle the event here
            
        }
        private void siticoneCustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneCustomGradientPanel1_Click(object sender, EventArgs e)
        {
            
        }

        private void ctrlChat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("yes it's works now but in the ifjewoifjewi");
        }
    }
}
