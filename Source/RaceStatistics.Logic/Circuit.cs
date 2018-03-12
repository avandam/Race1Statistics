using System;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Circuit : CircuitInfo
    {
        public Circuit(string name, string city, string country) : base(name, city, country)
        {
        }

        public void ChangeName(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
