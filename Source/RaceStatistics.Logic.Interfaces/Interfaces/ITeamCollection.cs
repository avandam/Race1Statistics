using System;
using System.Collections.Generic;
using RaceStatistics.Logic.Interfaces.Exceptions;

namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface ITeamCollection
    {
        void AddTeam(string name, string country);
        List<ITeam> GetTeams();
        void RemoveTeam(ITeam team);
    }
}