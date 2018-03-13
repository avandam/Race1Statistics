using System;
using System.Collections.Generic;
using RaceStatistics.Domain;
using RaceStatistics.Logic.Interfaces;

namespace RaceStatistics.Logic
{
    public interface IRaceStats
    {
        void AddDiscipline(string name);
        List<IDiscipline> GetDisciplines();
        void RemoveDiscipline(IDiscipline discipline);
        void AddScoreSystem(string name, bool fastestLapPoints);
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