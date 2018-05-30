using System;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic
{
    public class Circuit
    {
        public string Name { get; }
        public string City { get; }
        public string Country { get; }

        public Circuit(string name, string city, string country)
        {
            Name = name;
            City = city;
            Country = country;
        }

        public Circuit(CircuitInfo circuit) : this(circuit.Name, circuit.City, circuit.Country)
        {
            
        }

        public void ChangeName(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
