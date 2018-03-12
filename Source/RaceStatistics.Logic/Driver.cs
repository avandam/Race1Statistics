using System;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Driver : DriverInfo
    {
        public Driver(string name, DateTime birthDate, string country) : base(name, birthDate, country)
        {
        }
    }
}
