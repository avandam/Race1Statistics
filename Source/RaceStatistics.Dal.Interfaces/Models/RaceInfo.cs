using System;

namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct RaceInfo
    {
        public string Name { get; }
        public DateTime Date { get; }

        public RaceInfo(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
}
