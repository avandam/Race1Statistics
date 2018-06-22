using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Interfaces.RepositoryInterfaces
{
    public interface IDisciplineRepository
    {
        /// <summary>
        /// Adds a discipline to the system
        /// </summary>
        /// <param name="name">The name of the discipline</param>
        /// <exception cref="DuplicateEntryException">Thrown when the discipline already exists</exception>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        /// <exception cref="InvalidDataFormatException">Thrown when the input data is incorrect</exception>
        void AddDiscipline(string name);

        /// <summary>
        /// Gets all disciplines in the system
        /// </summary>
        /// <exception cref="Exceptions.DatabaseException">Thrown when connection with the database fails</exception>
        List<DisciplineInfo> GetDisciplines();
        
        /// <summary>
        /// Remove a disciplines from the system
        /// </summary>
        /// <param name="name">The name of the discipline</param>
        /// <exception cref="Exceptions.DatabaseException">Thrown when connection with the database fails</exception>
        void RemoveDiscipline(string name);
    }
}
