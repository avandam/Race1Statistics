using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.ContextInterfaces
{
    public interface IDisciplineContext
    {
        /// <summary>
        /// Adds a discipline to the system
        /// </summary>
        /// <param name="name">The name of the discipline</param>
        /// <exception cref="DisciplineExistsException">Thrown when the discipline already exists</exception>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        /// <exception cref="InvalidDataFormatException">Thrown when the input data is incorrect</exception>
        void AddDiscipline(string name);
        /// <summary>
        /// Gets all discipline to the system
        /// </summary>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        List<DisciplineInfo> GetDisciplines();
        /// <summary>
        /// Removes a discipline from the system
        /// </summary>
        /// <param name="name">The name of the discipline</param>
        /// <exception cref="DatabaseException">Thrown when connection to the data source fails</exception>
        void RemoveDiscipline(string name);
    }
}
