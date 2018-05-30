using System;
using System.Collections.Generic;
using RaceStatistics.Logic.Interfaces.Exceptions;

namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface IRaceStats
    {
        /// <summary>
        /// Add a discipline to the system
        /// </summary>
        /// <param name="name">The name of the discipline</param>
        /// <exception cref="DuplicateInputException">Thrown when the discipline already exists</exception>
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
        void AddScoreSystem(string name, int fastestLapPoints);
        List<IScoreSystem> GetScoreSystems();
        void RemoveScoreSystem(IScoreSystem scoreSystem);
        void AddCircuit(string name, string city, string country);
        List<ICircuit> GetCircuits();
        void RemoveCircuit(ICircuit circuit);
        void AddTeam(string name, string country);
        List<ITeam> GetTeams();
        void RemoveTeam(ITeam team);
        void AddDriver(string name, DateTime birthDate, string country);
        List<IDriver> GetDrivers();
        void RemoveDriver(IDriver driver);
    }
}