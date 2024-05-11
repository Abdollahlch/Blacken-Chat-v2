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
    public partial class AddPartnerForm : Form
    {
        public delegate void AddPartnerDelegate(int PartnerID);

        public event AddPartnerDelegate PartnerID;
        public AddPartnerForm(clsUser CurrentUser,List<int> Partners)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            this.Partners = Partners;
            
        }
        clsUser CurrentUser;
        List<int> Partners;
        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            clsUser user  = clsUser.FindByUsername(txtSeach.Text);
            if (user != null)
            {
                //if (user.Username == CurrentUser.Username)
                //{
                //    MessageBox.Show("You can't add yourself as a partner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                //}
                
                    if (Partners.Contains(clsUser.FindByUsername(txtSeach.Text).UserID))
                    {
                        MessageBox.Show("This user is already your partner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //CurrentUser.Partners.Add(user);
                       if (MessageBox.Show($"Do you want to add {user.Username} user as a partner?", "Add Partner", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PartnerID?.Invoke(user.UserID);
                            
                            //MessageBox.Show("User added as a partner", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                
            }
            else
            {
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPartnerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
