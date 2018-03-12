using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
