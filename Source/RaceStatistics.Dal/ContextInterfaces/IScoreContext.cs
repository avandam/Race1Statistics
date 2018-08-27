using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.ContextInterfaces
{
    public interface IScoreContext
    {
        /// <summary>
        /// Adds a score to the system
        /// </summary>
        /// <param name="place">The place the driver finished</param>
        /// <param name="points">The number of points for finishing on this place</param>
        /// <param name="scoreSystem">The ScoreSystem the score belongs to</param>
        /// <exception cref="DuplicateEntryException">Thrown when a score / points combinaton already exists</exception>
        /// <exception cref="InvalidDataFormatException">Thrown when the data input is incorrect</exception>
        /// <exception cref="DatabaseException">Thrown when the connection failed</exception>
        void AddOrUpdateScore(int place, int points, ScoreSystemInfo scoreSystem);

        /// <summary>
        /// Gets all scores from the system, ordered by place ascending and then points descending
        /// </summary>
        /// <param name="scoreSystem">The score system</param>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        List<ScoreInfo> GetScoresForScoreSystem(ScoreSystemInfo scoreSystem);

        /// <summary>
        /// Removes a score from the system
        /// </summary>
        /// <param name="place">The place the driver finished</param>
        /// <param name="scoreSystem">The scoreSystem</param>
        /// <exception cref="DatabaseException">Thrown when the connection failed</exception>
        void RemoveScore(int place, ScoreSystemInfo scoreSystem);
    }
}
