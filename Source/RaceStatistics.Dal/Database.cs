using System.Data.SqlClient;

namespace RaceStatistics.Dal
{
    class Database
    {
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(ConnectionSettings.GetConnectionString());
                connection.Open();
                return connection;
            }
        }
    }
}
