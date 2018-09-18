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
    public class DisciplineCollectionDisciplineTests
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
            DisciplineCollection disciplineCollection = new DisciplineCollection(new DisciplineRepository(new DisciplineTestAddDuplicateDisciplineContext()));
            disciplineCollection.AddDiscipline("Name");
        }

        [TestMethod]
        [ExpectedExceptionCheckMessage(typeof(InvalidInputException), "The field(s): 'Name' should not be empty", "Exception of type 'InvalidInputException' should have been thrown", "The message of the exception is incorrect")]
        public void AddDisciplineEmptyDisciplineTest()
        {
            DisciplineCollection disciplineCollection = new DisciplineCollection(new DisciplineRepository(new DisciplineTestAddEmptyDisciplineContext()));
            disciplineCollection.AddDiscipline("Name");
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void AddDisciplineDatabaseErrorTest()
        {
            DisciplineCollection disciplineCollection = new DisciplineCollection(new DisciplineRepository(new DisciplineTestConnectionErrorContext()));
            disciplineCollection.AddDiscipline("Name");
        }

        [TestMethod]
        public void GetDisciplinesTest()
        {
            DisciplineCollection disciplineCollection = new DisciplineCollection(new DisciplineRepository(new DisciplineTestContext()));
            ReadOnlyCollection<IDiscipline> disciplines = disciplineCollection.GetDisciplines() as ReadOnlyCollection<IDiscipline>;
            Assert.IsNotNull(disciplines, "There should be a correct list of disciplines");
            Assert.AreEqual(2, disciplines.Count, "There should be 2 disciplines");
            Assert.AreEqual("Formula 1", disciplines[0].Name, "There should be Formula 1 first");
            Assert.AreEqual("Nascar", disciplines[1].Name, "There should be Nascar second");
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionException), "A connection exception should be thrown")]
        public void GetDisciplinesDatabaseErrorTest()
        {
            DisciplineCollection disciplineCollection = new DisciplineCollection(new DisciplineRepository(new DisciplineTestConnectionErrorContext()));
            disciplineCollection.GetDisciplines();
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
            DisciplineCollection disciplineCollection = new DisciplineCollection(new DisciplineRepository(new DisciplineTestConnectionErrorContext()));
            disciplineCollection.RemoveDiscipline(new Discipline("Name"));
        }

    }
}