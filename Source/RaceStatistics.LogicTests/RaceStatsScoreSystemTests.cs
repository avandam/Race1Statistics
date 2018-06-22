using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using RaceStatistics.Dal.Repositories;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;
using RaceStatistics.Logic.Tests.Contexts;
using RaceStatistics.Test.Utilities;

namespace RaceStatistics.Logic.Tests
{
    [TestClass]
    public class RaceStatsTests
    {
        //[TestMethod]
        public void AddScoreSystemTest()
        {
            // No relevant test for the happy flow can be created here, so no test created. 
        }

        [TestMethod]
        [ExpectedExceptionCheckMessage(typeof(InvalidInputException), "The ScoreSystem exists", "Exception of type 'InvalidInputException' should have been thrown", "The message of the exception is incorrect")]
        public void AddScoreSystemDuplicateScoreSystemTest()
        {
            RaceStats raceStats = new RaceStats(null, new ScoreSystemRepository(new ScoreSystemTestAddDuplicateScoreSystemContext()));
            raceStats.AddScoreSystem("System 1", 0);
        }

        [TestMethod]
        [ExpectedExceptionCheckMessage(typeof(InvalidInputException), "The field(s): 'Name' should not be empty", "Exception of type 'InvalidInputException' should have been thrown", "The message of the exception is incorrect")]
        public void AddScoreSystemEmptyScoreSystemTest()
        {
            RaceStats raceStats = new RaceStats(null, new ScoreSystemRepository(new ScoreSystemTestAddEmptyScoreSystemContext()));
            raceStats.AddScoreSystem("System 1", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void AddScoreSystemDatabaseErrorTest()
        {
            RaceStats raceStats = new RaceStats(null, new ScoreSystemRepository(new ScoreSystemTestConnectionErrorContext()));
            raceStats.AddScoreSystem("System 1", 0);
        }

        [TestMethod]
        public void GetScoreSystemsTest()
        {
            RaceStats raceStats = new RaceStats(null, new ScoreSystemRepository(new ScoreSystemTestContext()));
            ReadOnlyCollection<IScoreSystem> scoreSystems = raceStats.GetScoreSystems() as ReadOnlyCollection<IScoreSystem>;
            Assert.IsNotNull(scoreSystems, "There should be a correct list of ScoreSystems");
            Assert.AreEqual(2, scoreSystems.Count, "There should be 2 ScoreSystems");
            Assert.AreEqual("System 1", scoreSystems[0].Name, "There should be System 1 first");
            Assert.AreEqual("System 2", scoreSystems[1].Name, "There should be System 2 second");
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void GetScoreSystemsDatabaseErrorTest()
        {
            RaceStats raceStats = new RaceStats(null, new ScoreSystemRepository(new ScoreSystemTestConnectionErrorContext()));
            raceStats.GetScoreSystems();
        }


        //[TestMethod]
        public void RemoveScoreSystemTest()
        {
            // No relevant test for the happy flow can be created here, so no test created. 
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void RemoveScoreSystemDatabaseErrorTest()
        {
            RaceStats raceStats = new RaceStats(null, new ScoreSystemRepository(new ScoreSystemTestConnectionErrorContext()));
            raceStats.RemoveScoreSystem(new ScoreSystem("System 1", 0));
        }

    }
}