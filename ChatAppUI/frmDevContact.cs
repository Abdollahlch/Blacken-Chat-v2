using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppUI
{
    public partial class frmDevContact : Form
    {
        public frmDevContact()
        {
            InitializeComponent();
        }

        private void siticoneCirclePictureBox1_Click(object sender, EventArgs e)
        {
            string link = "https://t.me/Blacken13"; 

            // Open the link in the default web browser
            Process.Start(link);
        }

        private void siticoneCirclePictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("whatsapp number  : +212657039909 see you there :-)!\nDo you want to copy the phone number?", "Contact me",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                Clipboard.SetText("+212657039909");
            }
           
            
        }
    }
}
