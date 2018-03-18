using RaceStatistics.Dal.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RaceStatistics.Domain;
using RaceStatistics.Domain.Exceptions;

namespace RaceStatistics.Dal.Context
{
    public class SeasonMssqlContext : ISeasonContext
    {
        public void AddSeason(DisciplineInfo discipline, int year)
        {
            throw new NotImplementedException();
        }

        public List<SeasonInfo> GetSeasons(DisciplineInfo discipline)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeason(DisciplineInfo discipline, int year)
        {
            throw new NotImplementedException();
        }

        public void AddDiscipline(string name)
        {
            if (!DisciplineExists(name))
            {
                try
                {
                    using (SqlConnection connection = Database.Connection)
                    {
                        string query = "INSERT INTO RS_Discipline (Name) VALUES (@DisciplineName)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@DisciplineName", name);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DatabaseException(ex.Message);
                }
            }
            else
            {
                throw new DisciplineExistsException($"The discipline with name {name} already exists.");
            }
        }

        internal bool DisciplineExists(string name)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT COUNT(*) as nrOfRecordsFound FROM RS_Discipline as discipline WHERE discipline.Name = @DisciplineName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DisciplineName", name);
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

        public List<DisciplineInfo> GetDisciplines()
        {
            List<DisciplineInfo> disciplines = new List<DisciplineInfo>();
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT discipline.Name as name FROM RS_Discipline as discipline";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                disciplines.Add(new DisciplineInfo(Convert.ToString(reader["name"])));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }

            return disciplines;
        }

        public void RemoveDiscipline(string name)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "DELETE FROM RS_Discipline WHERE name = @DisciplineName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DisciplineName", name);
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
