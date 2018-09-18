using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic
{
    public class TeamCollection : ITeamCollection
    {
        private List<Team> teams = new List<Team>();


        public TeamCollection()
        {
        }

        public void AddTeam(string name, string country)
        {
            throw new NotImplementedException();
        }

        public List<ITeam> GetTeams()
        {
            throw new NotImplementedException();
        }

        public void RemoveTeam(ITeam team)
        {
            throw new NotImplementedException();
        }
    }
}
