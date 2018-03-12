using System;
using System.Collections.Generic;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Team : TeamInfo
    {
        private List<TeamDriver> drivers;
        public Team(string name, string country) : base(name, country)
        {

        }

        public void AddDriver(Season season, Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
