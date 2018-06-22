using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Tests.Context
{
    [TestClass]
    public class ScoreSystemMssqlContextTests : BaseTests
    {
        [TestMethod]
        public void AddScoreSystemTest()
        {
            ScoreSystemMssqlContext sqlContext = new ScoreSystemMssqlContext();

            try
            {
                List<ScoreSystemInfo> scoreSystems = sqlContext.GetScoreSystems();
                Assert.AreEqual(0, scoreSystems.Count, "Precondition for this test is an empty ScoreSystem table");
                sqlContext.AddScoreSystem("System 1", 0);
                scoreSystems = sqlContext.GetScoreSystems();
                Assert.AreEqual(1, scoreSystems.Count, "The number of scoresystems should be 1");
                Assert.AreEqual("System 1", scoreSystems[0].Name, "The added scoresystem should be 'System 1'");
            }
            finally
            {
                sqlContext.RemoveScoreSystem("System 1");
                Assert.AreEqual(0, sqlContext.GetScoreSystems().Count, "Cleanup of database failed");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException), "Adding a ScoreSystem twice should fail with the correct exception")]
        public void AddScoreSystemTwiceTest()
        {
            ScoreSystemMssqlContext sqlContext = new ScoreSystemMssqlContext();

            try
            {
                sqlContext.AddScoreSystem("System 1", 0);
                List<ScoreSystemInfo> scoreSystems = sqlContext.GetScoreSystems();
                Assert.AreEqual(1, scoreSystems.Count, "There should be 1 scoresystem");
                Assert.AreEqual("System 1", scoreSystems[0].Name, "The scoresystem should be System 1");
                sqlContext.AddScoreSystem("System 1", 0);
                Assert.Fail("Adding a discipline twice should fail");
            }
            finally
            {
                Assert.AreEqual(1, sqlContext.GetScoreSystems().Count, "Cleanup cannot be executed");
                sqlContext.RemoveScoreSystem("System 1");
                Assert.AreEqual(0, sqlContext.GetScoreSystems().Count, "Cleanup of the database failed");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataFormatException), "The scoreSystem name empty should fail")]
        public void AddEmptScoreSystemTest()
        {
            ScoreSystemMssqlContext sqlContext = new ScoreSystemMssqlContext();
            sqlContext.AddScoreSystem("", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataFormatException), "The scoreSystem points below zero should fail")]
        public void AddInvalidNumberOfPontsTest()
        {
            ScoreSystemMssqlContext sqlContext = new ScoreSystemMssqlContext();
            sqlContext.AddScoreSystem("System 1", -1);
        }


        [TestMethod]
        public void RemoveScoreSystemTest()
        {
            ScoreSystemMssqlContext sqlContext = new ScoreSystemMssqlContext();

            try
            {
                sqlContext.AddScoreSystem("System 1", 0);
                sqlContext.AddScoreSystem("System 2", 0);
                Assert.AreEqual(2, sqlContext.GetScoreSystems().Count, "There should be 2 Score systems");
                sqlContext.RemoveScoreSystem("System 2");
                Assert.AreEqual(1, sqlContext.GetScoreSystems().Count, "There should be 1 Score system");
            }
            finally
            {
                sqlContext.RemoveScoreSystem("System 1");
                Assert.AreEqual(0, sqlContext.GetScoreSystems().Count, "Cleanup of the database failed");
            }
        }


    }
}
