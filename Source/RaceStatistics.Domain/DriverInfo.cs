using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Domain
{
    public class DriverInfo
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Country { get; private set; }

        public DriverInfo(string name, DateTime birthDate, string country)
        {
            Name = name;
            BirthDate = birthDate;
            Country = country;
        }
    }
}
