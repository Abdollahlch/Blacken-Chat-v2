using ChatAppBusinessLogic;
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

namespace ChatAppUI
{
    public partial class frmUpdateProfile : Form
    {
        public frmUpdateProfile(ref clsUser User)
        {
            InitializeComponent();
            user = User;
        }
        clsUser user;
        void LoadUserData()
        {
            lblUsername.Text = user.Username;
            txtBio.Text = user.Bio;
            //if (user.ImagePath != null)
            //{
            //    pbProfileImage.Load(user.ImagePath);
            //}

            if (user.Image != null && user.Image.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(user.Image))
                {
                    pbProfileImage.Image = Image.FromStream(ms);
                }
            }

            }
        private void frmUpdateProfile_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        void RemoveImage()
        {
            pbProfileImage.Image = null;
            //llRemoveImage.Visible = false;
        }
        void SetImage()
        {
            openFileDialog1.Title = "Select Image";
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = @"C:\Pictures";
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.InitialDirectory = @"C:\Users\hp\Desktop\Image Resources";
            //add a filter to only show images
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbProfileImage.ImageLocation = openFileDialog1.FileName;
                //llRemoveImage.Visible = true;
            }
        }
        private void llSetImagellSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetImage();
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            user.Bio = txtBio.Text;
            user.ImagePath = pbProfileImage.ImageLocation;
            user.Image = ImageToByteArray(Image.FromFile(pbProfileImage.ImageLocation));



               
            if (MessageBox.Show("Are you sure you want to update your profile?", "Update Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                user.Save();
                MessageBox.Show("Profile Updated Successfully", "Update Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            user.Save();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
