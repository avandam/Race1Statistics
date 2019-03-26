using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Tests.Context
{
    [TestClass]
    public class ScoreMssqlContextTests : BaseTests
    {
        [TestMethod]
        public void AddScoreTest()
        {
            ScoreSystemInfo scoreSystem = new ScoreSystemInfo("System 1", 0);
            ScoreSystemMssqlContext scoreSystemContext = new ScoreSystemMssqlContext();
            ScoreMssqlContext scoreContext = new ScoreMssqlContext();

            try
            {
                Assert.AreEqual(0, scoreSystemContext.GetScoreSystems().Count, "Cleanup of database failed");
                scoreSystemContext.AddScoreSystem(scoreSystem.Name, scoreSystem.PointsForFastestLap);

                scoreContext.AddOrUpdateScore(1, 10, scoreSystem);
                Assert.AreEqual(1, scoreContext.GetScoresForScoreSystem(scoreSystem).Count);
                Assert.AreEqual(10, scoreContext.GetScoresForScoreSystem(scoreSystem)[0].Points);
            }
            finally
            {
                scoreContext.RemoveScore(1, scoreSystem);
                Assert.AreEqual(0, scoreContext.GetScoresForScoreSystem(scoreSystem).Count);
                scoreSystemContext.RemoveScoreSystem("System 1");
                Assert.AreEqual(0, scoreSystemContext.GetScoreSystems().Count, "Cleanup of database failed");
            }
        }

        // TODO: Update is not updating, but adding. This is incorrect!
        [TestMethod]
        public void UpdateScoreTest()
        {
            ScoreSystemInfo scoreSystem = new ScoreSystemInfo("System 1", 0);
            ScoreSystemMssqlContext scoreSystemContext = new ScoreSystemMssqlContext();
            ScoreMssqlContext scoreContext = new ScoreMssqlContext();

            try
            {
                Assert.AreEqual(0, scoreSystemContext.GetScoreSystems().Count, "Cleanup of database failed");
                scoreSystemContext.AddScoreSystem(scoreSystem.Name, scoreSystem.PointsForFastestLap);

                scoreContext.AddOrUpdateScore(1, 10, scoreSystem);
                Assert.AreEqual(1, scoreContext.GetScoresForScoreSystem(scoreSystem).Count);
                Assert.AreEqual(10, scoreContext.GetScoresForScoreSystem(scoreSystem)[0].Points);
                scoreContext.AddOrUpdateScore(1, 5, scoreSystem);
                Assert.AreEqual(1, scoreContext.GetScoresForScoreSystem(scoreSystem).Count);
                Assert.AreEqual(5, scoreContext.GetScoresForScoreSystem(scoreSystem)[0].Points);
            }
            finally
            {
                scoreContext.RemoveScore(1, scoreSystem);
                Assert.AreEqual(0, scoreContext.GetScoresForScoreSystem(scoreSystem).Count);
                scoreSystemContext.RemoveScoreSystem("System 1");
                Assert.AreEqual(0, scoreSystemContext.GetScoreSystems().Count, "Cleanup of database failed");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataFormatException), "The score points below zero should fail")]
        public void AddInvalidNumberOfPontsTest()
        {
            ScoreSystemInfo scoreSystem = new ScoreSystemInfo("System 1", 0);
            ScoreMssqlContext sqlContext = new ScoreMssqlContext();
            sqlContext.AddOrUpdateScore(1, -1, scoreSystem);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataFormatException), "The score place below zero should fail")]
        public void AddInvalidPlaceTest()
        {
            ScoreSystemInfo scoreSystem = new ScoreSystemInfo("System 1", 0);
            ScoreMssqlContext sqlContext = new ScoreMssqlContext();
            sqlContext.AddOrUpdateScore(-1, 1, scoreSystem);
        }

        [TestMethod]
        public void RemoveScoreSystemTest()
        {
            ScoreSystemInfo scoreSystem = new ScoreSystemInfo("System 1", 0);
            ScoreSystemMssqlContext scoreSystemContext = new ScoreSystemMssqlContext();
            ScoreMssqlContext scoreContext = new ScoreMssqlContext();

            try
            {
                Assert.AreEqual(0, scoreSystemContext.GetScoreSystems().Count, "Cleanup of database failed");
                scoreSystemContext.AddScoreSystem(scoreSystem.Name, scoreSystem.PointsForFastestLap);

                scoreContext.AddOrUpdateScore(1, 10, scoreSystem);
                Assert.AreEqual(1, scoreContext.GetScoresForScoreSystem(scoreSystem).Count);
                scoreContext.RemoveScore(1, scoreSystem);
                Assert.AreEqual(0, scoreContext.GetScoresForScoreSystem(scoreSystem).Count);
            }
            finally
            {
                scoreSystemContext.RemoveScoreSystem("System 1");
                Assert.AreEqual(0, scoreSystemContext.GetScoreSystems().Count, "Cleanup of database failed");
            }
        }


    }
}
