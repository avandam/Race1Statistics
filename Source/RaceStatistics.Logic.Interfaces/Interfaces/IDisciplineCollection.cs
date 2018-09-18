using System;
using System.Collections.Generic;
using RaceStatistics.Logic.Interfaces.Exceptions;

namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface IDisciplineCollection
    {
        /// <summary>
        /// Add a discipline to the system
        /// </summary>
        /// <param name="name">The name of the discipline</param>
        /// <exception cref="InvalidInputException">Thrown when the discipline already exists</exception>
        /// <exception cref="ConnectionException">Thrown when adding the discipline failed</exception>
        void AddDiscipline(string name);
        /// <summary>
        /// Get all disciplines in the system
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ConnectionException">Thrown when retrieving the disciplines failed</exception>
        IReadOnlyCollection<IDiscipline> GetDisciplines();
        /// <summary>
        /// Remove a disciplines from the system
        /// </summary>
        /// <param name="discipline">The discipline to remove</param>
        /// <exception cref="ConnectionException">Thrown when retrieving the disciplines failed</exception>
        void RemoveDiscipline(IDiscipline discipline);
    }
}