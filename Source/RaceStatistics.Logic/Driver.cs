using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
