using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Web.Configuration;
using Newtonsoft.Json;
namespace DataAccess
{
    public static class clsDataAccessSettings
    {
        //public static string ConnectionString = "Server=.;Database=ChatApp;User Id=sa;Password=sa123456;";
        static string Ip_add = "34.175.189.218";
       
        static string your_database_name = "ChatAppDB";
        static string your_sqlserver_username = "sqlserver";
        static string your_sqlserver_password = "ONEprof@2021";
       


        //static string jsonData = @"
        //                {
        //                                    ""type"": ""service_account"",
        //          ""project_id"": ""skilful-sphere-422618-a0"",
        //          ""private_key_id"": ""f3fc7292de1c3a20fcd170eac44e346f46134208"",
        //          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCjzPGCJVOEBATo\nwoU9jG6KxvxfFTeIUv0J3BQJNGD/O0awEmNUNarFftXGCUYtuVsAt9l+qWbxPHqh\nv4/TUEvZdTAgnd5EJeNjJVoLkyD3jk9njcyNDY/YhgzZlQktt+Y19c8ctNjWayPc\ngg3dZCaJTpTlD7z1jG6x4cbNmQmFY9uMgWP0csAvdferYWhLheulu89Lf064Wxnc\nwu/zLPGUBCBCBJwOvMhXVbbmkSQ84aFDul0CWSjIza4byOY1ZDfKl+tcqaP8mSaJ\nJl3hV0MGdxIDWDTfNNA/vaQC6sDjnX0g4ND1IpLhe+ZRLrO47h4MdQk54v13CiPh\nOEOzaIzVAgMBAAECggEAJUpbEQ3+XWes1nCydLir0dxLSDpEUjzSbpQz24SZMIIG\nLb+B7YHqRtwBPvyNhYtVNGymjzdxwCnMoVZDIBB/tBoBwust1sXpZoDyZwAv2SwE\n18ZocxRLUzfxZPeRB19+gXpclGR3mRj7KRBSp7xNKaVCMIPMuPonmUeVQuk8Sal8\ndayIAts0UsSE98BPnEePYs85q6jV6AXor5/huBl4ooRYoqwxI5NGaVCtFVzRmJYD\nHrG2fe/v1SqdcpodyW0x1/Z+IcT0/qKdq8LmV6KBfCTTnx66fTOLz/wsiVWrISPg\n4b18YRamnNHaplkudxElDRLmdraxVuMSVoLLMRUuAQKBgQDiTCoGyxfmz5ZLy3X7\nPe/4CvM3rHB/gVfRVxtsACHpkEWpdj7VV6Okok2FnQKQs+N/IUV70t0uq4AcIQoD\nJ7d8P1lcNlmi3O4KB+xAxfUbV5Ox8O9eMmS8+Xu/Y7qXC0CB9ndOn1f8pfqYJIs6\nxqIA7KoZ1SbvXI4DIf03JSYEcQKBgQC5TNC/CtOoIYpvIU3+VqAL3CVOi+9ZSgb6\nL5RGdG38sMAOoNzon6/1yCCnO2LOd23w6a7amk3Bv4I8PIDWFvUnEk7KCDLJvn29\naF9GystH9rT7zOm0BEjZ+WOVMBpC/DTda4EDhr4880ukyQ4urn6xrQonXr5jP+H1\nNOqVEXqwpQKBgHefETwkEU9l/im0tHoJpJb2mticI5+S7KvxIsK1UzfWlqxcoBxA\nRnWZgecWNyvsm14xZTxuG5M2/vJfmJ5QWVKpXgA7jqhjpsTQqVcYDVfVtHIETVP6\nyXuHWZ2zBwge34uTkD+URXt89XmFH8ADDdH1SHl9TiaLQ1pulh6XWYBRAoGAQHqn\nZOMKlcXeGx+WuTtBg/7+CGAPUJ2+4c4upXmcUELdAfoeBOCUZU1Xd3nlvvy2CA/4\n5V6uUg4m7nkLR/RDKG5pdkn2Cle7/23TQZoNtKP3hGtgo2CeTSNH8MEFUmvapXXk\nNersRd9PYi8IPVxA/+i70MlaLMUtBpt8SZUEgXUCgYBDXkzWzJuPIcvJ1IyJR1EG\niEP6I4QjN6uQXFQX2XffDabOAY5fX8GIHTXmQjGm6Yy5jQ2An3mf5QMjGtBnEWh4\n9KxUGgRYdWyAjAAwf060ruranW9uyVkib2xVYWu0Mq91cwK3gf6c5HVNIAIeAtcY\n8XewIJrCCnWW3pB4vrFQ3w==\n-----END PRIVATE KEY-----\n"",
        //          ""client_email"": ""demo-service-account@skilful-sphere-422618-a0.iam.gserviceaccount.com"",
        //          ""client_id"": ""100017823260236442569"",
        //          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
        //          ""token_uri"": ""https://oauth2.googleapis.com/token"",
        //          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
        //          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/demo-service-account%40skilful-sphere-422618-a0.iam.gserviceaccount.com"",
        //          ""universe_domain"": ""googleapis.com""
        //                }";

        // Parse the JSON string
        //static dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

        // Extract relevant data (replace with your actual key names)
        //static string projectId = jsonObject["project_id"];
        //static string clientId = jsonObject["client_id"];



        //this is the connection string to connect to the database
        public static string ConnectionString = $"server={Ip_add};" +

                                $"database={your_database_name};" +
                                $"uid={your_sqlserver_username};" +
                                $"pwd={your_sqlserver_password};";






        //public static string ConnectionString = $"Server=34.69.227.60;Database=ChatAppDB;" +
        //                                $"Uid=sqlserver;Pwd=ONEprof@2021;" +
        //                                $"CertificateFile={serviceAccountKey};";


        //private static string GetServiceAccountKey()
        //{
        //    // Get the assembly containing your application
        //    Assembly assembly = Assembly.GetExecutingAssembly();

        //    // Specify the resource name (the path within the project)
        //    string resourceName = "ChatAppUi.Solution_Items.skilful-sphere-422618-a0-f3fc7292de1c.json";




        //    // Read the embedded resource stream
        //    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        //    using (StreamReader reader = new StreamReader(stream))
        //    {
        //        // Read the contents of the resource (service account key)
        //        return reader.ReadToEnd();
        //    }
        //}


        //private static string GetServiceAccountKey()
        //{
        //    // Assuming jsonData is already populated with the JSON content

        //    dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

        //    // Extract the certificate file path from the JSON (for demonstration only, avoid using in production)
        //    string certificateFile = jsonObject["client_x509_cert_url"];

        //    // Validate the certificate file path (optional)
        //    if (string.IsNullOrEmpty(certificateFile))
        //    {
        //        throw new Exception("Certificate file path not found in JSON data.");
        //    }

        //    return certificateFile;
        //}


        //public static bool TestConnection()
        //{
        //    SqlConnection connection = new SqlConnection(ConnectionString);
        //    //check if this connection is success or not?
        //    try
        //    {
        //        connection.Open();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
