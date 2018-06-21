using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.ContextInterfaces
{
    public interface IDisciplineSeasonContext
    {
        /// <summary>
        /// Add a season to a discipline
        /// </summary>
        /// <param name="disciplineId">The disciplineId</param>
        /// <param name="seasonId">The seasonId</param>
        void AddSeasonToDiscipline(int disciplineId, int seasonId);
        /// <summary>
        /// Removes a season from a discipline
        /// </summary>
        /// <param name="disciplineId">The disciplineId</param>
        /// <param name="seasonId">The seasonId</param>
        void RemoveSeasonFromDiscipline(int disciplineId, int seasonId);
        /// <summary>
        /// Checks if a seasons already exists in a given discipline
        /// </summary>
        /// <param name="disciplineId">The discipline Id</param>
        /// <param name="year">The year of the season</param>
        /// <returns>True if the season exists, false otherwise</returns>
        bool SeasonExistsInDiscipline(int disciplineId, int year);
    }
}
