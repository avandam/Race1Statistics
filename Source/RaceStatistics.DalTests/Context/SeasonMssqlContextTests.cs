using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Tests.Context
{
    [TestClass()]
    public class SeasonMssqlContextTests : BaseTests
    {
        [TestMethod()]
        public void AddSeasonTest()
        {
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();
            int insertedId = 0;

            try
            {
                // TODO: Use a correct ScoreSystemId
                insertedId = seasonMssqlContext.AddSeason(2000, 0);
                Assert.AreNotEqual(0, insertedId, "An id bigger than 0 should have been returned");
            }
            finally
            {
                try
                {
                    seasonMssqlContext.RemoveSeason(insertedId);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataFormatException), "Adding a negative number for season should fail")]
        public void AddInvalidSeasonTest()
        {
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();
            seasonMssqlContext.AddSeason(-100, 1);
        }
    }
}