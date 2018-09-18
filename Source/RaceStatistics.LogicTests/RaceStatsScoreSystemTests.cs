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
    public class ScoreSystemCollectionTests
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
            ScoreSystemCollection scoreSystemCollection = new ScoreSystemCollection(new ScoreSystemRepository(new ScoreSystemTestAddDuplicateScoreSystemContext()));
            scoreSystemCollection.AddScoreSystem("System 1", 0);
        }

        [TestMethod]
        [ExpectedExceptionCheckMessage(typeof(InvalidInputException), "The field(s): 'Name' should not be empty", "Exception of type 'InvalidInputException' should have been thrown", "The message of the exception is incorrect")]
        public void AddScoreSystemEmptyScoreSystemTest()
        {
            ScoreSystemCollection scoreSystemCollection = new ScoreSystemCollection(new ScoreSystemRepository(new ScoreSystemTestAddEmptyScoreSystemContext()));
            scoreSystemCollection.AddScoreSystem("System 1", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void AddScoreSystemDatabaseErrorTest()
        {
            ScoreSystemCollection scoreSystemCollection = new ScoreSystemCollection(new ScoreSystemRepository(new ScoreSystemTestConnectionErrorContext()));
            scoreSystemCollection.AddScoreSystem("System 1", 0);
        }

        [TestMethod]
        public void GetScoreSystemsTest()
        {
            ScoreSystemCollection scoreSystemCollection = new ScoreSystemCollection(new ScoreSystemRepository(new ScoreSystemTestContext()));
            ReadOnlyCollection<IScoreSystem> scoreSystems = scoreSystemCollection.GetScoreSystems() as ReadOnlyCollection<IScoreSystem>;
            Assert.IsNotNull(scoreSystems, "There should be a correct list of ScoreSystems");
            Assert.AreEqual(2, scoreSystems.Count, "There should be 2 ScoreSystems");
            Assert.AreEqual("System 1", scoreSystems[0].Name, "There should be System 1 first");
            Assert.AreEqual("System 2", scoreSystems[1].Name, "There should be System 2 second");
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void GetScoreSystemsDatabaseErrorTest()
        {
            ScoreSystemCollection scoreSystemCollection = new ScoreSystemCollection(new ScoreSystemRepository(new ScoreSystemTestConnectionErrorContext()));
            scoreSystemCollection.GetScoreSystems();
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
            ScoreSystemCollection scoreSystemCollection = new ScoreSystemCollection(new ScoreSystemRepository(new ScoreSystemTestConnectionErrorContext()));
            scoreSystemCollection.RemoveScoreSystem(new ScoreSystem("System 1", 0));
        }

    }
}