using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.ContextInterfaces
{
    public interface ISeasonContext
    {
        /// <summary>
        /// Add a season to the system
        /// </summary>
        /// <param name="year">the year to add</param>
        /// <param name="scoreSystemId">The Id of the scoreSystem for this season</param>
        /// <returns>The ID of the inserted row</returns>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        /// <exception cref="InvalidDataFormatException">Thrown when the input data is incorrect</exception>
        int AddSeason(int year, int scoreSystemId);
        /// <summary>
        /// Get all the seasons for a discipline
        /// </summary>
        /// <param name="discipline">The discipline</param>
        /// <returns>The seasons</returns>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        List<SeasonInfo> GetSeasons(DisciplineInfo discipline);
        /// <summary>
        /// Renmove a season from the system
        /// </summary>
        /// <param name="year">The year of the season</param>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        void RemoveSeason(int year);
    }
}
