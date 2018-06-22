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
    public class RaceStatsDisciplineTests
    {
        //[TestMethod]
        public void AddDisciplineTest()
        {
            // No relevant test for the happy flow can be created here, so no test created. 
        }

        [TestMethod]
        [ExpectedExceptionCheckMessage(typeof(InvalidInputException), "The discipline exists", "Exception of type 'InvalidInputException' should have been thrown", "The message of the exception is incorrect")]
        public void AddDisciplineDuplicateDisciplineTest()
        {
            RaceStats raceStats = new RaceStats(new DisciplineRepository(new DisciplineTestAddDuplicateDisciplineContext()), null);
            raceStats.AddDiscipline("Name");
        }

        [TestMethod]
        [ExpectedExceptionCheckMessage(typeof(InvalidInputException), "The field(s): 'Name' should not be empty", "Exception of type 'InvalidInputException' should have been thrown", "The message of the exception is incorrect")]
        public void AddDisciplineEmptyDisciplineTest()
        {
            RaceStats raceStats = new RaceStats(new DisciplineRepository(new DisciplineTestAddEmptyDisciplineContext()), null);
            raceStats.AddDiscipline("Name");
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void AddDisciplineDatabaseErrorTest()
        {
            RaceStats raceStats = new RaceStats(new DisciplineRepository(new DisciplineTestConnectionErrorContext()), null);
            raceStats.AddDiscipline("Name");
        }

        [TestMethod]
        public void GetDisciplinesTest()
        {
            RaceStats raceStats = new RaceStats(new DisciplineRepository(new DisciplineTestContext()), null);
            ReadOnlyCollection<IDiscipline> disciplines = raceStats.GetDisciplines() as ReadOnlyCollection<IDiscipline>;
            Assert.IsNotNull(disciplines, "There should be a correct list of disciplines");
            Assert.AreEqual(2, disciplines.Count, "There should be 2 disciplines");
            Assert.AreEqual("Formula 1", disciplines[0].Name, "There should be Formula 1 first");
            Assert.AreEqual("Nascar", disciplines[1].Name, "There should be Nascar second");
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void GetDisciplinesDatabaseErrorTest()
        {
            RaceStats raceStats = new RaceStats(new DisciplineRepository(new DisciplineTestConnectionErrorContext()), null);
            raceStats.GetDisciplines();
        }


        //[TestMethod]
        public void RemoveDisciplineTest()
        {
            // No relevant test for the happy flow can be created here, so no test created. 
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void RemoveDisciplineDatabaseErrorTest()
        {
            RaceStats raceStats = new RaceStats(new DisciplineRepository(new DisciplineTestConnectionErrorContext()), null);
            raceStats.RemoveDiscipline(new Discipline("Name"));
        }

    }
}