using ChatAppBusinessLogic;
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
    public partial class frmUserInfo : Form
    {
        public frmUserInfo(clsUser Partner)
        {
            InitializeComponent();
            this.Partner = Partner;
        }
        clsUser Partner;



        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Partner.Username;
            txtBio.Text = Partner.Bio;
            pbProfileImage.ImageLocation = Partner.ImagePath;
            pbProfileImage.SizeMode= PictureBoxSizeMode.StretchImage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbProfileImage_Click(object sender, EventArgs e)
        {

        }
    }
}
