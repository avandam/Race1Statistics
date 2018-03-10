using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Domain
{
    public class CircuitInfo
    {
        public string Name { get; protected set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public CircuitInfo(string name, string city, string country)
        {
            Name = name;
            City = city;
            Country = country;
        }
    }
}
