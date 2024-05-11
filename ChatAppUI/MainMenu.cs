using BlackenChat;
using BlackenChat.Properties;
using ChatAppBusinessLogic;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserBusnissLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChatAppUI
{
    public partial class MainMenu : Form
    {
        public MainMenu(clsUser User)
        {
            InitializeComponent();
            CurrentUser = User;

        }



        enum enMessageType { Sent, Recieved };
        public clsUser CurrentUser;
        clsUser CurrentPartner;
        int NumberOfMessages = 0;
        int NumberOfPartners = 0;
        int WidthOfMessages = 0;
        public List<int> PartnersIDs = new List<int>();
        bool isLoggedOut = false;
        Point GeneratePartnerLocationInList()
        {
            return new Point(-1, 130 + (NumberOfPartners * 70));
        }
        Point GenerateMessageLocation(enMessageType messageType, ctrlMessage message)
        {
            if (messageType == enMessageType.Sent)
            {
                Point p = new Point(22, 30 + WidthOfMessages);//22, 15 as initial size
                WidthOfMessages += message.Height + 10;

                return p;

            }
            else
            {
                int Xpostion = 925 - message.Width;

                Point p = new Point(Xpostion, 15 + WidthOfMessages);
                WidthOfMessages += message.Height + 10;
                message.TextBoxColor = Color.White;
                return p;
            }

        }

        void ClearMessagesPanel()
        {
            pnlMessages.Controls.Clear();
            NumberOfMessages = 0;
            WidthOfMessages = 0;
        }

        //private void Button_Paint(object sender, PaintEventArgs e)
        //{
        //    // Apply circular mask to the button's image
        //    Button button  = (Button)sender;
        //    using (ImageAttributes attributes = new ImageAttributes())
        //    {
        //        attributes.SetColorKey(Color.White, Color.White);
        //        e.Graphics.DrawImage(button.Image, new Rectangle(0, 0, button.Width, button.Height), 0, 0, button.Width, button.Height, GraphicsUnit.Pixel, attributes);
        //    }
        //}
        //private void pbPartner_enter(object sender, EventArgs e)
        //{

        //    ((Button)sender).Image = ChangeImageBackColor(((Button)sender).Image, Color.Red);

        //}
        //private Image ChangeImageBackColor(Image image, Color backColor)
        //{
        //    Bitmap bitmap = new Bitmap(image.Width, image.Height);

        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        graphics.Clear(backColor);
        //        graphics.DrawImage(image, Point.Empty);
        //    }

        //    return bitmap;
        //}



        public bool AddPartner(int ID)
        {
            clsUser Partner = clsUser.FindByID(ID);
            if (Partner == null)
                return false;
            //Button button = new Button();
            //// button1.TextAlign = ContentAlignment.MiddleLeft;
            //button.TextAlign = ContentAlignment.BottomCenter;
            //button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            //button.Text = Partner.Username;
            //button.Size = new Size(300, 65);
            //button.BackColor = Color.Transparent;
            //button.FlatStyle = FlatStyle.Flat;
            //button.FlatAppearance.BorderSize = 0;
            ////button.MouseEnter += pbPartner_enter;
            //button.Image = Image.FromFile(Partner.ImagePath);
            //button.ImageAlign = ContentAlignment.TopLeft;
            //button.TextImageRelation = TextImageRelation.ImageBeforeText;
            //button.Tag = Partner.UserID;   
            ////could you handle image size to make it better because it's so big
            //button.Image = new Bitmap(button.Image, new Size(50, 50));
            ////use #FFFFFF as backcolor for the button
            //button.BackColor = ColorTranslator.FromHtml("#FFFFFF");

            //button.FlatAppearance.BorderSize = 0;
            //button.FlatStyle = FlatStyle.Flat;

            //button.Location = GeneratePartnerLocationInList();
            //PartnersIDs.Add(Partner.UserID);

            //button.Click += BtnPartner_Click;
            //panel1.Controls.Add(button);



            ctrlPartner pnl = new ctrlPartner(Partner.Username, Partner.Image, clsMessage.GetUnseenMessages(CurrentUser.UserID, Partner.UserID),tsmiDarkMode.Checked);
            pnl.Size = new Size(300, 75);
            //pnl.Font = new Font("Segoe UI", 10, FontStyle.Regular);


            DataTable dt = CurrentUser.GetLastMessageBetweenUserPartner(Partner.UserID);
            string LastMessage = "";
            if (dt != null)
                LastMessage = dt.Rows[0][3].ToString();

            pnl.LastMessage = LastMessage;

            pnl.Location = GeneratePartnerLocationInList();

            //pnl.Cursor = Cursors.Hand;
            // pnl.Click += BtnPartner_Click;
            pnl.Click += new System.EventHandler(this.BtnPartner_Click);

            panel1.Controls.Add(pnl);
            NumberOfPartners++;
            return true;
        }

        private void Form2_DataBack(int PartnerID)
        {
            CurrentPartner = clsUser.FindByID(PartnerID);
            ShowMessagesPanel(CurrentUser, CurrentPartner);
            return;
            //if (!AddPartner(PartnerID))
            //{
            //    MessageBox.Show("Error occure while adding the partner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //NumberOfPartners++; 


        }
        private void ClearPartnersPanel()
        {
            //here delete all buttons on the panel (Partners panel)
            //delete only buttons not the other controls
            foreach (Control Control in panel1.Controls)
            {
                if (Control is ctrlPartner)
                {
                    panel1.Controls.Remove(Control);

                }
            }
            NumberOfPartners = 0;
        }
        public bool CheckChatAlreadyExist(int ID)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    if (PartnersIDs.Contains(ID) && ((Button)control).Tag.ToString() == ID.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public void LoadAllPartners()
        {
            ClearPartnersPanel();

            List<int> PartnersIDs = CurrentUser.GetAllPartnersByUserID();
            if (PartnersIDs.Count == 0)
            {

                lblNoPartners.Visible = true;
                btnAddPartner.Visible = true;




                return;
            }
            lblNoPartners.Visible = false;
            btnAddPartner.Visible = false;
            foreach (int partnerID in PartnersIDs)
            {

                if (CheckChatAlreadyExist(partnerID))
                {
                    //NumberOfPartners++;
                    continue;
                }
                AddPartner(partnerID);

            }

        }
        //pnlMessages.ScrollControlIntoView(message);
        void LoadMessagesToPanel(int UserID, int PartnerID)
        {
            ClearMessagesPanel();
            if (CurrentUser == null || CurrentPartner == null) return;
            DataTable Messages = clsMessage.GetMessagesBetweenUsers(UserID, PartnerID);
            if (Messages == null || Messages.Rows.Count == 0) return;
            foreach (DataRow Row in Messages.Rows)
            {

                ctrlMessage message = new ctrlMessage(Row["Content"].ToString(), (DateTime)Row["TimeStamp"], (bool)Row["isSeen"]);


                if (Row["SenderID"].ToString() != CurrentUser.UserID.ToString() && !(bool)Row["isSeen"]
                    && CurrentPartner.UserID == CurrentUser.UserID)
                {
                    clsMessage Msg = clsMessage.FindMessageByID((int)Row["MessageID"]);
                    Msg.isSeen = true;
                    Msg.Save();
                }


                if (Row["SenderID"].ToString() == CurrentUser.UserID.ToString())
                {
                    message.Location = GenerateMessageLocation(enMessageType.Sent, message);

                }
                else
                {
                    message.DisableSeen = true;
                    message.Location = GenerateMessageLocation(enMessageType.Recieved, message);
                    message.MessageColor = Color.White;
                    message.isSeen = true;
                    clsMessage Msg = clsMessage.FindMessageByID((int)Row["MessageID"]);
                    Msg.isSeen = true;
                    Msg.Save();




                }
                message.Tag = Row["MessageID"].ToString();
                pnlMessages.Controls.Add(message);

                NumberOfMessages++;
            }

            pnlMessages.ScrollControlIntoView(pnlMessages.Controls[pnlMessages.Controls.Count - 1]);

        }

        void AddExistsMessage(clsMessage Message)
        {
            ctrlMessage message = new ctrlMessage(Message.Content, Message.MessageDate, Message.isSeen);


            if (Message.SenderID == CurrentUser.UserID)
                message.Location = GenerateMessageLocation(enMessageType.Sent, message);
            else
            {
                message.Location = GenerateMessageLocation(enMessageType.Recieved, message);
                message.MessageColor = Color.White;
            }
            message.Tag = Message.MessageID.ToString();
            if (CurrentUser.UserID == Message.ReceiverID)
            {
                message.DisableSeen = true;
            }
            pnlMessages.Controls.Add(message);
            NumberOfMessages++;
            //WidthOfMessages += message.Height + 10;
            pnlMessages.ScrollControlIntoView(pnlMessages.Controls[pnlMessages.Controls.Count - 1]);
        }



        //bool AddNewMessage(string MessageContent, int SenderID, int ReceiverID, DateTime time)
        //{

        //}
        private void MainMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (CurrentUser.Image != null && CurrentUser.Image.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(CurrentUser.Image))
                {
                    pbProfile.Image = Image.FromStream(ms);
                }
            }
                LoadAllPartners();
            lblGreeting.Text = "Welcome " + CurrentUser.Username.Split(' ')[0];

            //how can i center that label horizontally
            lblGreeting.Anchor = AnchorStyles.None; // Ensure the label is not anchored to any side
            //lblGreeting.TextAlign = ContentAligpnment.MiddleCenter; // Center the text horizontally
            lblUsername.Text = CurrentUser.Username;



        }
        private void ShowNotification(string title, string message)
        {
            // Display a notification balloon
            //when a message is long add '...' to the end of the message
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            if (message.Length > 20)
                message = message.Substring(0, 20) + "...";
            notifyIcon1.ShowBalloonTip(3000, title, message, ToolTipIcon.Info);
        }

        void ShowMessagesPanel(clsUser CurrentUser, clsUser CurrentPartner)
        {
            LoadMessagesToPanel(CurrentUser.UserID, CurrentPartner.UserID);
            pnlChatHeader.Visible = true;
            if (CurrentPartner.UserID != CurrentUser.UserID)
                lblUsernameHeader.Text = CurrentPartner.Username;
            else
                lblUsernameHeader.Text = "You";
            pnlDown.Visible = true;
            txtInput.Focus();
            lblGreeting.Visible = false;
            pbLogo.Visible = false;
            pbPartnerProfile.ImageLocation = CurrentPartner.ImagePath;
        }



        private void BtnPartner_Click(object sender, EventArgs e)
        {

            
            string Username = ((ctrlPartner)sender).Tag.ToString();
            CurrentPartner = clsUser.FindByUsername(Username);
            ((ctrlPartner)sender).UnseenMessages = 0;
            
            if (CurrentPartner == null)
            {
                MessageBox.Show("invalid Partner");
                return;
            }
            RefrechUnseenMessagesInPartnerPanel(CurrentPartner);
            if (!tsmiDarkMode.Checked)
            pnlChatHeader.BackColor = Color.White;
            else
                pnlChatHeader.BackColor = Color.FromArgb(31, 31, 31);
            ShowMessagesPanel(CurrentUser, CurrentPartner);
            timer1.Start();

        }


        private void siticoneTextBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        bool SendMessage(string MessageContent, int SenderID, int ReceiverID, bool isSeen = false)
        {
            clsMessage message = new clsMessage();
           
            message.Content = MessageContent;
            message.SenderID = SenderID;
            message.ReceiverID = ReceiverID;


            return message.Save();
        }

        private void siticoneTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        void RefrechLastMessageInPartnerPanel(string LastMessage, clsUser Partner)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is ctrlPartner)
                {
                    if (((ctrlPartner)control).Username == Partner.Username)
                    {
                        ((ctrlPartner)control).LastMessage = LastMessage;
                        break;
                    }
                }
            }
        }
        void RefrechUnseenMessagesInPartnerPanel(clsUser Partner)
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is ctrlPartner)
                {
                    if (((ctrlPartner)control).Username == Partner.Username)
                    {
                        ((ctrlPartner)control).UnseenMessages = clsMessage.GetUnseenMessages(CurrentUser.UserID, Partner.UserID);
                        break;
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (clsUser.GetTotalNumberOfPartnersByUserID(CurrentUser.UserID) > NumberOfPartners)
                LoadAllPartners();
            if (CurrentPartner == null)
            {

                return;
            }
            clsUser Partner = clsUser.FindByID(CurrentPartner.UserID);
            DataTable Messages = clsMessage.GetMessagesBetweenUsers(CurrentUser.UserID, Partner.UserID);
            if (NumberOfMessages < Messages.Rows.Count)
            {
                clsMessage message = clsMessage.GetTheLastMessage();
                LoadMessagesToPanel(CurrentUser.UserID, Partner.UserID);
                //edit the message to be seen
                if (message.ReceiverID == CurrentUser.UserID)
                {

                    ShowNotification($"You Received a New Message for {CurrentUser.Username}", message.Content);
                    message.Save();
                }
                RefrechLastMessageInPartnerPanel(message.Content, Partner);


                RefrechUnseenMessagesInPartnerPanel(Partner);
            }

        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggedOut)
                Application.OpenForms[0].Close();

            //this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isLoggedOut = true;
            Application.OpenForms[0].Show();

            this.Close();

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.OpenForms[0].Show();
        }

        async private void txtInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string Input = txtInput.Text;
            if (string.IsNullOrEmpty(Input))
            {
               
                return;
            }
            clsUser Partner = clsUser.FindByID(CurrentPartner.UserID);
            if (e.KeyCode == Keys.Enter)
            {
                txtInput.Clear();
                if (NumberOfMessages == 0)
                {
                    AddPartner(CurrentPartner.UserID);
                    lblNoPartners.Visible = false;
                    btnAddPartner.Visible = false;
                }
                SendMessage(Input, CurrentUser.UserID, CurrentPartner.UserID);
                LoadMessagesToPanel(CurrentUser.UserID, CurrentPartner.UserID);
                //instead of load the messages again i want to track the latest message and add it to the panel
                //AddExistsMessage(clsMessage.GetTheLastMessage());
                //what if GetTheLastMessage return a message that is not for the user and the partner


                //use RefrechLastMessageInPartnerPanel function here
                RefrechLastMessageInPartnerPanel(Input, Partner);
                if (CurrentPartner.UserID == 47)
                {

                    string AiAnswer = await ChatGPTClient.GetAiAnswer(Input);
                    if (string.IsNullOrEmpty(AiAnswer))
                    {
                        MessageBox.Show("Error while getting the answer from the AI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    
                    if (CurrentPartner==Partner)
                    {
                        SendMessage(AiAnswer, CurrentPartner.UserID, CurrentUser.UserID, true);
                    }
                    else
                    {
                        SendMessage(AiAnswer, CurrentPartner.UserID, CurrentUser.UserID);
                    }
                   
                        RefrechLastMessageInPartnerPanel(AiAnswer, Partner);
                    



                }
                if (CurrentPartner.UserID == 48)
                {

                    GeminiAI gemini = new GeminiAI("AIzaSyBGutUuM6OuHY7YONta7ECgh1r0sQyEZUw");
                    string AiAnswer = await gemini.GetAiResponse(Input);
                    if (string.IsNullOrEmpty(AiAnswer) || AiAnswer == "Error: InternalServerError - Internal Server Error")
                    {
                        MessageBox.Show("Error Check your internet connection and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    if (CurrentPartner == Partner)
                    {
                        SendMessage(AiAnswer, CurrentPartner.UserID, CurrentUser.UserID, true);
                    }
                    else
                    {
                        SendMessage(AiAnswer, CurrentPartner.UserID, CurrentUser.UserID);
                    }

                    RefrechLastMessageInPartnerPanel(AiAnswer, Partner);
                }

                RefrechUnseenMessagesInPartnerPanel(Partner);

                // Prevent the key press event from being handled by the control
                e.IsInputKey = true;
            }
        }

        private void btnAddPartner_Click(object sender, EventArgs e)
        {
            AddPartnerForm form = new AddPartnerForm(CurrentUser, PartnersIDs);
            form.PartnerID += Form2_DataBack;

            form.ShowDialog();
            pnlChatHeader.BackColor = (tsmiDarkMode.Checked) ? Color.FromArgb(31, 31, 31) : Color.White;
            if (NumberOfPartners > 0)
            {
                lblNoPartners.Visible = false;
                btnAddPartner.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnAddPartner_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmUserInfo form = new frmUserInfo(CurrentPartner);
            form.ShowDialog();
        }

        void DeletePartnerButton(string Username)
        {
            //here find and delete the button that it's text equal Username text
            foreach (Control button in panel1.Controls)
            {
                if (button is ctrlMessage)
                {
                    if (((ctrlMessage)button).Text == Username)
                    {
                        panel1.Controls.Remove(button);
                        NumberOfPartners--;
                        break;
                    }
                }
            }
        }
        void ClearPartnerPanel()
        {
            //dont delete everything delete only ctrlPartner controls
            foreach (Control control in panel1.Controls)
            {
                if (control is ctrlPartner)
                {
                    panel1.Controls.Remove(control);
                }
            }
            NumberOfPartners = 0;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (NumberOfMessages == 0)
            {
                MessageBox.Show("There is no message to delete");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete all messages between you and " + CurrentPartner.Username, "Delete All Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsMessage.DeleteAllMessagesBetweenUserPartner(CurrentUser.UserID, CurrentPartner.UserID))
                {

                    ClearPartnerPanel();
                    LoadAllPartners();
                    ClearMessagesPanel();


                    PartnersIDs.Remove(CurrentPartner.UserID);

                }
                else
                {
                    if (CurrentPartner != null)
                    {
                        ClearPartnerPanel();
                        LoadAllPartners();
                        ClearMessagesPanel();
                        DeletePartnerButton(CurrentPartner.Username);
                        PartnersIDs.Remove(CurrentPartner.UserID);

                    }
                    else
                        MessageBox.Show("Error while deleting the messages", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                PictureBox pb = new PictureBox();
                pb = pbLogo;
                pb.Visible = true;
                pnlMessages.Controls.Add(pb);

                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label = lblGreeting;
                label.Visible = true;
                pnlMessages.Controls.Add(label);
                pnlChatHeader.Visible = false;
                pnlDown.Visible = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmUpdateProfile frmUpdateProfile = new frmUpdateProfile(ref CurrentUser);
            frmUpdateProfile.ShowDialog();
            CurrentUser.Save();
            if (CurrentUser.Image != null)
            {
                //load it from the database
                using (MemoryStream ms = new MemoryStream(CurrentUser.Image))
                {
                    pbProfile.Image = Image.FromStream(ms);
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I'm lazy to add this feature but it will coming Soon!", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pnlMessages_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmDevContact frmDevContact = new frmDevContact();
            frmDevContact.ShowDialog();
        }

        private void pnl_Click(object sender, EventArgs e)
        {

        }

        private void siticoneContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            // Show the context menu strip at the location of the mouse click
            cmsMenu.Show(pb, new Point(pb.Location.X, pb.Location.Y + 40));


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox7_Click(sender, e);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void pnlChatHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chatWithBlackenAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


        }

        private void pnlMessages_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // Scroll the panel upward
                pnlMessages.VerticalScroll.Value -= pnlMessages.VerticalScroll.SmallChange;
            }
            // Check if the down arrow key is pressed
            else if (e.KeyCode == Keys.Down)
            {
                // Scroll the panel downward
                pnlMessages.VerticalScroll.Value += pnlMessages.VerticalScroll.LargeChange;
            }
        }

        private void blackenAIOfflineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentPartner = clsUser.FindByID(47);
            ShowMessagesPanel(CurrentUser, CurrentPartner);
            timer1.Start();
        }

        private void blacknerAIOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentPartner = clsUser.FindByID(48);
            ShowMessagesPanel(CurrentUser, CurrentPartner);
            timer1.Start();
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dark mode
            //this.BackColor = Color.FromArgb(31, 31, 31);
            //pnlMessages.BackColor = Color.FromArgb(31, 31, 31);
            //pnlChatHeader.BackColor = Color.FromArgb(31, 31, 31);
            //pnlDown.BackColor = Color.FromArgb(31, 31, 31);
            //panel1.BackColor = Color.FromArgb(31, 31, 31);
            //lblGreeting.ForeColor = Color.White;
            //lblUsername.ForeColor = Color.White;
            //lblUsernameHeader.ForeColor = Color.White;
            //txtInput.BackColor = Color.FromArgb(31, 31, 31);
            //txtInput.ForeColor = Color.White;
            //txtInput.BorderColor = Color.White;
            //txtInput.FillColor = Color.FromArgb(31, 31, 31);


            //this.BackgroundImage = null;


        }

        void SetDarkModeToPatners(bool value)
        {
           //here we will set the dark mode to the partners
           //use foreach
           foreach (Control control in panel1.Controls)
            {
                if (control is ctrlPartner)
                {
                    ((ctrlPartner)control).DarkMode = value;
                }
            }
        }
        private void darkModeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tsmiDarkMode.Checked = !tsmiDarkMode.Checked;
            if (tsmiDarkMode.Checked)
            {
                this.BackgroundImage = Resources.pxfuel;
                
                
                lblGreeting.ForeColor = Color.White;
                lblUsername.ForeColor = Color.White;
                lblUsernameHeader.ForeColor = Color.White;
                txtInput.BackColor = Color.FromArgb(31, 31, 31);
                txtInput.ForeColor = Color.White;
                txtInput.BorderColor = Color.White;
                txtInput.FillColor = Color.FromArgb(31, 31, 31);
                pnlChatHeader.BackColor = Color.FromArgb(31, 31, 31);
                pnlDown.BackColor = Color.FromArgb(31, 31, 31);
                panel1.BackColor = Color.Black;
                SetDarkModeToPatners(true) ;

               pnlMessages.BackgroundImage = Resources.pxfuel;
            }
            else
            {
                //light mode
                this.BackColor = Color.White;
                SetDarkModeToPatners(false);



                lblGreeting.ForeColor = Color.Black;
                lblUsername.ForeColor = Color.Black;
                lblUsernameHeader.ForeColor = Color.Black;
                txtInput.BackColor = Color.White;
                txtInput.ForeColor = Color.Black;
                txtInput.BorderColor = Color.Black;
                txtInput.FillColor = Color.White;
                this.BackgroundImage = Resources.qwd83nc4xxf41;
                lblGreeting.ForeColor = Color.Black;
                lblUsername.ForeColor = Color.Black;
                lblUsernameHeader.ForeColor = Color.Black;
                pnlDown.BackColor = Color.White;
                pnlChatHeader.BackColor = Color.White;
                panel1.BackColor = Color.White;

                pnlMessages.BackgroundImage = Resources.qwd83nc4xxf41;


            }
        }
    }
}
