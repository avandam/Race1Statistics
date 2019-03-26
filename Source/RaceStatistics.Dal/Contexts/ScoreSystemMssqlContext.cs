using RaceStatistics.Dal.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Context
{
    public class ScoreSystemMssqlContext : IScoreSystemContext
    {
        public void AddScoreSystem(string name, int pointsForFastestLap)
        {
            List<string> errorFields = new List<string>();
            if (String.IsNullOrEmpty(name)) errorFields.Add("Name");
            if (pointsForFastestLap < 0) errorFields.Add("PointsForFastestLap");
            
            if (errorFields.Count > 0)
            {
                throw new InvalidDataFormatException("The input is incorrect", String.Join(",", errorFields));
            }

            if (ScoreSystemExists(name))
            {
                throw new DuplicateEntryException($"The scoresystem with name '{name}' already exists.");
            }

            try
                {
                    using (SqlConnection connection = Database.Connection)
                    {
                        string query = "INSERT INTO ScoreSystem (Name, FastestLapPoints) VALUES (@Name, @PointsForFastestLap)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@PointsForFastestLap", pointsForFastestLap);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DatabaseException(ex.Message);
                }
        }

        internal bool ScoreSystemExists(string name)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT COUNT(*) as nrOfRecordsFound FROM ScoreSystem as scoreSystem WHERE scoreSystem.Name = @ScoreSystemName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ScoreSystemName", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            int nrOfRecordsFound = Convert.ToInt32(reader["nrOfRecordsFound"].ToString());
                            return nrOfRecordsFound > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }

        public List<ScoreSystemInfo> GetScoreSystems()
        {
            List<ScoreSystemInfo> scoreSystems = new List<ScoreSystemInfo>();
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT scoreSystem.Name as name, scoreSystem.FastestLapPoints as points FROM ScoreSystem as scoreSystem";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scoreSystems.Add(new ScoreSystemInfo(Convert.ToString(reader["name"]), Convert.ToInt32(reader["points"])));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }

            return scoreSystems;
        }

        public void RemoveScoreSystem(string name)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "DELETE FROM ScoreSystem WHERE name = @ScoreSystemName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ScoreSystemName", name);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }
    }
}
