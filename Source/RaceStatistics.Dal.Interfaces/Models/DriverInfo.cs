using System;

namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct DriverInfo
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public string Country { get; }

        public DriverInfo(string name, DateTime birthDate, string country)
        {
            Name = name;
            BirthDate = birthDate;
            Country = country;
        }
    }
}
