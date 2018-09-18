using System;
using System.Collections.Generic;
using RaceStatistics.Logic.Interfaces.Exceptions;

namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface IDriverCollection
    {
        void AddDriver(string name, DateTime birthDate, string country);
        List<IDriver> GetDrivers();
        void RemoveDriver(IDriver driver);
    }
}