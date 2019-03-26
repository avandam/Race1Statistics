using RaceStatistics.Dal.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Context
{
    public class DisciplineMssqlContext : IDisciplineContext
    {
        public void AddDiscipline(string name)
        {
            if (DisciplineExists(name))
            {
                throw new DuplicateEntryException($"The discipline with name '{name}' already exists.");
            }

            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "INSERT INTO Discipline (Name) VALUES (@DisciplineName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DisciplineName", name);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("CK_RS_Discipline_NameNotEmpty"))
                {
                    throw new InvalidDataFormatException(ex.Message, "Name");
                }

                throw new DatabaseException(ex.Message);
            }
        }

        internal bool DisciplineExists(string name)
        {
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "SELECT COUNT(*) as nrOfRecordsFound FROM Discipline as discipline WHERE discipline.Name = @DisciplineName";

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
                    string query = "SELECT discipline.Name as name FROM Discipline as discipline";

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
                    string query = "DELETE FROM Discipline WHERE name = @DisciplineName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DisciplineName", name);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Fix FK issue specific exception
                throw new DatabaseException(ex.Message);
            }
        }
    }
}
