using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Interfaces.RepositoryInterfaces
{
    public interface IScoreSystemRepository
    {
        /// <summary>
        /// Adds a score system to the system
        /// </summary>
        /// <param name="name">The name of the score system</param>
        /// <param name="pointsForFastestLap">The number of points given for the holder of the fastest lap</param>
        /// <exception cref="DuplicateEntryException">Thrown when a scoresystem with the given name already exists</exception>
        /// <exception cref="InvalidDataFormatException">Thrown when the data input is incorrect</exception>
        /// <exception cref="DatabaseException">Thrown when the connection failed</exception>
        void AddScoreSystem(string name, int pointsForFastestLap);

        /// <summary>
        /// Gets all scoresystems from the system
        /// </summary>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        List<ScoreSystemInfo> GetScoreSystems();

        /// <summary>
        /// Removes a score system from the system
        /// </summary>
        /// <param name="name">The name of the score system</param>
        /// <exception cref="DatabaseException">Thrown when the connection failed</exception>
        /// <exception cref="EntryStillRelatedException">Thrown when the score system still has scores linked</exception>
        void RemoveScoreSystem(string name);
    }
}
