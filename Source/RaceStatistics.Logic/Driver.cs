using System;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic
{
    public class Driver
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public string Country { get; }

        public Driver(string name, DateTime birthDate, string country)
        {
            Name = name;
            BirthDate = birthDate;
            Country = country;
        }

        public Driver(DriverInfo driver) : this(driver.Name, driver.BirthDate, driver.Country)
        {
            
        }
    }
}
