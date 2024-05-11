using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class UserDataAccess
    {
        public static bool GetUserInfoByUsername(string Username,ref int UserID,ref string Password,ref string Bio,ref string ImagePath,ref byte[] image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Password = (string)reader["Password"];
                   
                    UserID = (int)reader["UserID"];
                    if (reader["Bio"] != DBNull.Value)
                        Bio = ((string)reader["Bio"]).Trim();
                    else
                        Bio = null;

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = ((string)reader["ImagePath"]).Trim();
                    else
                        ImagePath = null;
                    
                    if (reader["Image"] != DBNull.Value)
                        image = (byte[])reader["Image"];
                    else
                        image = null;

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool FindByID(int ID, ref string Username, ref string Password, ref string Bio,ref string ImagePath,ref byte[] image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Password = (string)reader["Password"];

                    Username = (string)reader["Username"];
                    if (reader["Bio"] != DBNull.Value)
                        Bio = (string)reader["Bio"];
                    else
                        Bio = null;
                    
                    if (reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = null;
                    if (reader["Image"] != DBNull.Value)
                        image = (byte[])reader["Image"];
                    else
                        image = null;

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool AddNewUser(string Username,string Password,string Bio,string ImagePath, byte[] image)
        {

            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Users (Username, Password, Bio,ImagePath)
                             VALUES (@Username, @Password, @Bio,@ImagePath);
                             ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            if (string.IsNullOrEmpty(Bio))
                command.Parameters.AddWithValue("@Bio", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Bio", Bio);
            
            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            if (image ==null)
                command.Parameters.AddWithValue("@Image", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Image", ImagePath);
            

            

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();


               
            }

            catch 
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return (RowAffected>0);
        }

        public static bool UpdateUser(string Username, string Password, string Bio, string ImagePath, byte[] image)
        {

            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Users
                                SET 
                                    Password = @Password,
                                    Bio = @Bio,
                                    ImagePath = @ImagePath,
                                    Image = @Image
                                WHERE 
                                    Username = @Username

                             ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Bio", Bio);
            if (image == null)
                command.Parameters.AddWithValue("@Image", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Image", image);
            
            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            


            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();



            }

            catch
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return (RowAffected > 0);
        }


        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteUser(string Username)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Users 
                                where Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsUserExist(string Username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT 1 FROM Users WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool CheckPassword(string Username,string Password)
        {
            bool isPasswordCorrect = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select Found=1 from Users where Username =@Username and Password= @Password";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                
                if (reader.Read())
                {
                    isPasswordCorrect = true;
                }
                reader.Close();
            }
            catch { isPasswordCorrect = false; }
            finally { connection.Close(); }
            return isPasswordCorrect;
        }

    public static int GetNumberOfPartners(int UserID)
    {
        int NumberOfPartners = 0;
        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        string Query = @"Select Count(*) from Users where UserID = @UserID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        try
        {
            connection.Open();
            NumberOfPartners = (int)cmd.ExecuteScalar();
        }
        catch { NumberOfPartners = 0; }
        finally { connection.Close(); }
        return NumberOfPartners;
    }

    }
}
