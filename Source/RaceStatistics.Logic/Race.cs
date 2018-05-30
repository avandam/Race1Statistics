using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;
using RaceStatistics.Logic.Interfaces.Models;

namespace RaceStatistics.Logic
{
    public class Race
    {
        private Season season;
        private Circuit circuit;
        private List<Result> results;

        public string Name { get; }
        public DateTime Date { get; }

        public Race(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public Race(RaceInfo race) : this(race.Name, race.Date)
        {
            
        }

        public void AddResult(int place, bool hasFastestLap, ResultStatus status, TeamDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
