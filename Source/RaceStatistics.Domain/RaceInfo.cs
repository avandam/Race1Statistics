using System;

namespace RaceStatistics.Domain
{
    public class RaceInfo
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public RaceInfo(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
}
