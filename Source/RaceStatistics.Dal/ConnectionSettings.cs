using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Dal
{
    public static class ConnectionSettings
    {
        public static string DatabaseServer = "";
        public static string DatabaseName = "";
        public static string DatabaseUser = "";
        public static string DatabasePassword = "";

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.UserID = DatabaseUser;
            stringBuilder.Password = DatabasePassword;
            stringBuilder.DataSource = DatabaseServer;
            stringBuilder.InitialCatalog = DatabaseName;

            return stringBuilder.ConnectionString;
        }
    }
}
