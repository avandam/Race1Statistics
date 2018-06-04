using System.Data.SqlClient;
using System.Security.Policy;

namespace RaceStatistics.Dal
{
    public static class ConnectionSettings
    {
        private const string databaseServer = "localhost";
        private static string databaseName = "RaceStatistics";
        private const bool integratedSecurity = true;

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = databaseServer,
                InitialCatalog = databaseName,
                IntegratedSecurity = integratedSecurity
            };

            return stringBuilder.ConnectionString;
        }

        internal static void ChangeDatabaseName(string newDatabaseName)
        {
            databaseName = newDatabaseName;
        }
    }
}
