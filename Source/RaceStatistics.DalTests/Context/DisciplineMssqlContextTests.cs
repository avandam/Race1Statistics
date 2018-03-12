using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Logic;

namespace RaceStatistics.DalTests.Context
{
    [TestClass]
    public class DisciplineMssqlContextTests
    {
        [TestMethod]
        public void AddDisciplineTest()
        {
            DisciplineMssqlContext sqlContext = new DisciplineMssqlContext();

            try
            {
                sqlContext.AddDiscipline("Formule 1");
                List<Discipline> disciplines = sqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count);
                Assert.AreEqual("Formule 1", disciplines[0].Name);
            }
            finally
            {
                sqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, sqlContext.GetDisciplines().Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DisciplineExistsException))]
        public void AddDisciplineTwiceTest()
        {
            DisciplineMssqlContext sqlContext = new DisciplineMssqlContext();

            try
            {
                sqlContext.AddDiscipline("Formule 1");
                List<Discipline> disciplines = sqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count);
                Assert.AreEqual("Formule 1", disciplines[0].Name);
                sqlContext.AddDiscipline("Formule 1");
                Assert.Fail("Adding a discipline twice should fail");
            }
            finally
            {
                Assert.AreEqual(1, sqlContext.GetDisciplines().Count);
                sqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, sqlContext.GetDisciplines().Count);
            }
        }
    }
}
