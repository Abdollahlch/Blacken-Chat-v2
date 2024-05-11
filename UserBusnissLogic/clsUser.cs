using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Google.Apis.Auth.OAuth2;
namespace ChatAppBusinessLogic
{
    public class clsUser
    {
        enum enMode { AddNew, Update };

        enMode _Mode;
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }

        public string ImagePath { get; set; }

        public byte[] Image { set; get; }

        private clsUser(int UserID,string Username,string Password,string Bio,string ImagePath, byte[] image)
        {
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Bio = Bio;
            this.ImagePath = ImagePath;
            this.Image = image;
            _Mode = enMode.Update;
        }
        public clsUser()
        {
            UserID = -1;
            Username = "";
            Password = "";
            Bio = "";
            ImagePath = "";
            Image = default;
            _Mode = enMode.AddNew;
        }

        //public static bool CheckConnection()
        //{
        //    //return clsDataAccessSettings.TestConnection();
            
        //}

        public static clsUser FindByUsername(string Username)
        {
            string Password = "",Bio="",ImagePath="";
            int UserID= 0;
            byte[] image = default;
            if (UserDataAccess.GetUserInfoByUsername(Username,ref UserID,ref Password,ref Bio,ref ImagePath,ref image))
            {
                return new clsUser(UserID,Username,Password,Bio,ImagePath,image);
            }
            return null;
        }
          bool _AddNewUser(string Username, string Password,string Bio,string ImagePath, byte[] image)
        {
            return UserDataAccess.AddNewUser(Username,Password,Bio,ImagePath,image);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    
                if (_AddNewUser(this.Username, this.Password, this.Bio,this.ImagePath,this.Image))
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
                
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        public static DataTable GetAllUsers()
        {
            return UserDataAccess.GetAllUsers();
        }
         bool _UpdateUser()
        {
            return UserDataAccess.UpdateUser( this.Username, this.Password, this.Bio,this.ImagePath, this.Image);
        }
        public static bool DeleteUser(string Username)
        {
            return UserDataAccess.DeleteUser(Username);
        }
        public  bool CheckPassword(string Password)
        {
            return UserDataAccess.CheckPassword(this.Username, Password);
        }
        public List<int> GetAllPartnersByUserID()
        {
            
            return MessageDataAccess.GetAllPartnersByUserID(this.UserID);

        }

        public DataTable GetLastMessageBetweenUserPartner(int Partner)
        {
            return MessageDataAccess.GetLastMessageBetweenUserPartner(this.UserID, Partner);
        }
       public static clsUser FindByID(int id)
        {
            string Username = "", Password = "", Bio = "",ImagePath="";
            byte[] Image = default;
            if (UserDataAccess.FindByID(id, ref Username, ref Password, ref Bio,ref ImagePath,ref Image))
            {
                return new clsUser(id, Username, Password, Bio,ImagePath,Image);
            }
            else
                return null;
        }
        public static int GetTotalNumberOfPartnersByUserID(int UserID)
        {
            return MessageDataAccess.GetTotalNumberOfPartnersByUserID(UserID);
        }

    }
}
