using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RaceStatistics.Dal.Repositories;
using RaceStatistics.Logic.Interfaces;
using RaceStatistics.LogicTests;

namespace RaceStatistics.Logic.Tests
{
    [TestClass()]
    public class RaceStatsTests
    {
        [TestMethod()]
        public void AddDisciplineTest()
        {

        }

        [TestMethod()]
        public void GetDisciplinesTest()
        {
            RaceStats raceStats = new RaceStats(new DisciplineRepository(new DisciplineTestContext()));
            List<IDiscipline> disciplines = raceStats.GetDisciplines();
            Assert.AreEqual(2, disciplines.Count);
            Assert.AreEqual("Formula 1", disciplines[0].Name);
            Assert.AreEqual("Nascar", disciplines[1].Name);
        }


    }
}