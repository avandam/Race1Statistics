using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Tests.Context
{
    [TestClass]
    public class DisciplineMssqlContextTests : BaseTests
    {
        [TestMethod]
        public void AddDisciplineTest()
        {
            DisciplineMssqlContext sqlContext = new DisciplineMssqlContext();

            try
            {
                List<DisciplineInfo> disciplines = sqlContext.GetDisciplines();
                Assert.AreEqual(0, disciplines.Count, "Precondition for this test is an empty Discipline table");
                sqlContext.AddDiscipline("Formule 1");
                disciplines = sqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count, "The number of disciplines should be 1");
                Assert.AreEqual("Formule 1", disciplines[0].Name, "The added discipline should be 'Formule 1'");
            }
            finally
            {
                sqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, sqlContext.GetDisciplines().Count, "Cleanup of database failed");
            }
        }

        [TestMethod]
        public void RemoveDisciplineTest()
        {
            DisciplineMssqlContext sqlContext = new DisciplineMssqlContext();

            try
            {
                sqlContext.AddDiscipline("Formule 1");
                sqlContext.AddDiscipline("Nascar");
                Assert.AreEqual(2, sqlContext.GetDisciplines().Count, "There should be 2 disciplines");
                sqlContext.RemoveDiscipline("Nascar");
                Assert.AreEqual(1, sqlContext.GetDisciplines().Count, "There should be 1 discipline");
            }
            finally
            {
                sqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, sqlContext.GetDisciplines().Count, "Cleanup of the database failed");
            }
        }


        [TestMethod]
        [ExpectedException(typeof(DisciplineExistsException), "Adding a discipline twice should fail with the correct exception")]
        public void AddDisciplineTwiceTest()
        {
            DisciplineMssqlContext sqlContext = new DisciplineMssqlContext();

            try
            {
                sqlContext.AddDiscipline("Formule 1");
                List<DisciplineInfo> disciplines = sqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count, "There should be 1 discipline");
                Assert.AreEqual("Formule 1", disciplines[0].Name, "The discipline should be Formule 1");
                sqlContext.AddDiscipline("Formule 1");
                Assert.Fail("Adding a discipline twice should fail");
            }
            finally
            {
                Assert.AreEqual(1, sqlContext.GetDisciplines().Count, "Cleanup cannot be executed");
                sqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, sqlContext.GetDisciplines().Count, "Cleanup of the database failed");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataFormatException), "The discipline name empty should fail")]
        public void AddEmptyDisciplineTest()
        {
            DisciplineMssqlContext sqlContext = new DisciplineMssqlContext();
            sqlContext.AddDiscipline("");
        }
    }
}
