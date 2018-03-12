using System;
using System.Collections.Generic;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Race : RaceInfo
    {
        private Season season;
        private Circuit circuit;
        private List<Result> results;

        public Race(string name, DateTime date) : base(name, date)
        {
        }

        public void AddResult(int place, bool hasFastestLap, ResultStatus status, TeamDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
