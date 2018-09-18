using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic
{
    public class CircuitCollection : ICircuitCollection
    {
        private List<Circuit> circuits = new List<Circuit>();

        public CircuitCollection()
        {
        }

        public void AddCircuit(string name, string city, string country)
        {
            throw new NotImplementedException();
        }

        public List<ICircuit> GetCircuits()
        {
            throw new NotImplementedException();
        }

        public void RemoveCircuit(ICircuit circuit)
        {
            throw new NotImplementedException();
        }
    }
}
