using System;
using System.Collections.Generic;
using RaceStatistics.Logic.Interfaces.Exceptions;

namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface ICircuitCollection
    {
        void AddCircuit(string name, string city, string country);
        List<ICircuit> GetCircuits();
        void RemoveCircuit(ICircuit circuit);
    }
}