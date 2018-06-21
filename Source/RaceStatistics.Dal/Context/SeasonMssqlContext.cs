using RaceStatistics.Dal.ContextInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Context
{
    public class SeasonMssqlContext : ISeasonContext
    {
        public int AddSeason(int year, int scoreSystemId)
        {
            if (year < 0)
            {
                throw new InvalidDataFormatException("The year should not be below zero", "year");
            }
            int insertedId;
            try
            {
                using (SqlConnection connection = Database.Connection)
                {
                    string query = "INSERT INTO RS_Season (Year) OUTPUT INSERTED.ID VALUES (@Year)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Year", year);
                        insertedId = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }

            return insertedId;
        }

        public List<SeasonInfo> GetSeasons(DisciplineInfo discipline)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeason(int year)
        {
            throw new NotImplementedException();
        }
    }
}
