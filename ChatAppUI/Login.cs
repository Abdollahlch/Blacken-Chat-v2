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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public clsUser User;

        private void _Login()
        {
            //check if the user connect to the internet if not tell him to do that
            


            User = clsUser.FindByUsername(txtUsername.Text);
            if (User == null || !User.CheckPassword(txtPassword.Text))
            {
                MessageBox.Show("Error : May occure because of :\n-Invalid Username or password \n-No internet connection", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPassword.Clear();
                return;
            }
            txtUsername.Focus();
            MainMenu mainScreen = new MainMenu(User);
            mainScreen.Show();
            this.Hide();
            txtUsername.Clear();
            txtPassword.Clear();
            
            


        }
        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
        
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Fill this field!");
                return;
            }
            else
                errorProvider1.SetError(txtUsername, "");

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Fill this field!");
                return;
            }
            else
                errorProvider1.SetError(txtPassword, "");
            if (btnLogin.Text == "Login")
            _Login();
            else
    {           
                clsUser user = clsUser.FindByUsername(txtUsername.Text);
                if (user!=null)
                {
                    MessageBox.Show("The user already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                User = new clsUser();
                    User.Username = txtUsername.Text;
                    User.Password = txtPassword.Text;
                User.Bio = null;
                User.ImagePath =null;
                    User.Save();
                    MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblLoginScreen.Text = "Welcome Back";
                    btnLogin.Text = "Login";
                    linkLabel1.Text = "Register";
                    lblDescription.Text = "Don't have an account yet? : ";
                       }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblLoginScreen.Text= "Registration";
            btnLogin.Text = "Register";
            linkLabel1.Text = "Login";
            lblDescription.Text = "i already have an account : ";


        }
    }
}
