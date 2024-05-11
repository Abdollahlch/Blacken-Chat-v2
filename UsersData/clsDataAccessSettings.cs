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
        public static string ConnectionString = "Server=.;Database=ChatApp;User Id=sa;Password=sa123456;";
      
      

    }
}
