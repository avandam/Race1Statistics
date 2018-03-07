using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Dal
{
    public class TestContext
    {

        public string GetTest()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionSettings.GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT * FROM test;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        //cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return Convert.ToString(reader["Test"]);
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }


    }
}
