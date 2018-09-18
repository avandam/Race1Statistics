using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic
{
    public class DriverCollection : IDriverCollection
    {
        private List<Driver> drivers = new List<Driver>();

        public DriverCollection()
        {
        }

        public void AddDriver(string name, DateTime birthDate, string country)
        {
            throw new NotImplementedException();
        }
        public List<IDriver> GetDrivers()
        {
            throw new NotImplementedException();
        }

        public void RemoveDriver(IDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
