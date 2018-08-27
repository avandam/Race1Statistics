using RaceStatistics.Dal.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Context
{
    public class ScoreMssqlContext : IScoreContext
    {
        public void AddOrUpdateScore(int place, int points, ScoreSystemInfo scoreSystem)
        {
            List<string> errorFields = new List<string>();
            if (place < 0) errorFields.Add("Place");
            if (points < 0) errorFields.Add("Points");

            if (errorFields.Count > 0)
            {
                throw new InvalidDataFormatException("The input is incorrect", String.Join(",", errorFields));
            }

            if (ScoreExists(place, points, scoreSystem.Name))
            {
                UpdateScore(place, points, scoreSystem);
            }
            else
            {
                AddScore(place, points, scoreSystem);
            }
        }

        private void AddScore(int place, int points, ScoreSystemInfo scoreSystem)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "INSERT INTO RS_Score (Place, Points, RS_ScoreSystemId) " +
                                   "SELECT @Place, @Points, scoreSystem.Id " +
                                   "FROM ScoreSystem as scoreSystem" +
                                   "WHERE scoreSystem.Name = @ScoreSystemName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Place", place);
                        command.Parameters.AddWithValue("@Points", points);
                        command.Parameters.AddWithValue("@ScoreSystemName", scoreSystem.Name);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }

        private void UpdateScore(int place, int points, ScoreSystemInfo scoreSystem)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "UPDATE RS_Score as score SET score.Points = @Points " +
                                   "WHERE score.Place = @Place " +
                                   "AND score.RS_ScoreSystemId = (SELECT scoreSystem.Id " +
                                   "                              FROM RS_ScoreSystem as scoreSystem " +
                                   "                              WHERE scoreSystem.Name = @ScoreSystemName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Place", place);
                        command.Parameters.AddWithValue("@Points", points);
                        command.Parameters.AddWithValue("@ScoreSystemName", scoreSystem.Name);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
        }

        private bool ScoreExists(int place, int points, string name)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT COUNT(*) as nrOfRecordsFound " +
                                   "FROM RS_Score as score " +
                                   "INNER JOIN RS_ScoreSystem as scoreSystem " +
                                   "ON score.RS_ScoreSystemId = scoreSystem.Id" +
                                   "WHERE score.Place = @Place AND score.Points = @Points AND scoreSystem.Name = @ScoreSystemName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Place", place);
                        command.Parameters.AddWithValue("@Points", points);
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

        public List<ScoreInfo> GetScoresForScoreSystem(ScoreSystemInfo scoreSystem)
        {
            List<ScoreInfo> scores = new List<ScoreInfo>();
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT score.Place as Place, score.Points as Points " +
                                   "FROM RS_Score as score " +
                                   "INNER JOIN RS_ScoreSystem as scoreSystem " +
                                   "ON score.RS_ScoreSystemId = scoreSystem.Id " +
                                   "WHERE scoreSystem.Name = @ScoreSystemName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ScoreSystemName", scoreSystem.Name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scores.Add(new ScoreInfo(Convert.ToInt32(reader["Place"]), Convert.ToInt32(reader["Points"])));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }

            return scores;
        }

        public void RemoveScore(int place, ScoreSystemInfo scoreSystem)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "DELETE FROM RS_Score " +
                                   "WHERE Place = @Place " +
                                   "AND RS_ScoreSystemId = (SELECT scoreSystem.Id " +
                                   "                              FROM RS_ScoreSystem as scoreSystem " +
                                   "                              INNER JOIN RS_Score as score " +
                                   "                              ON scoreSystem.Id = score.RS_ScoreSystemId " +
                                   "                              WHERE scoreSystem.Id = score.RS_ScoreSystemId " +
                                   "                              AND scoreSystem.Name = @ScoreSystemName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Place", place);
                        command.Parameters.AddWithValue("@ScoreSystemName", scoreSystem.Name);
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
