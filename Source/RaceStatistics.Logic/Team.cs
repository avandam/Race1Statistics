using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic
{
    public class Team
    {
        private List<TeamDriver> drivers;

        public string Name { get; }
        public string Country { get; }

        public Team(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public Team(TeamInfo team) : this(team.Name, team.Country)
        {
            
        }

        public void AddDriver(Season season, Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
