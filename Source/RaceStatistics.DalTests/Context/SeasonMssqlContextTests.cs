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
            DisciplineMssqlContext disciplineMssqlContext = new DisciplineMssqlContext();
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();
            List<DisciplineInfo> disciplines = new List<DisciplineInfo>();

            try
            {
                disciplineMssqlContext.AddDiscipline("Formule 1");
                disciplines = disciplineMssqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count, "There should be 1 discipline");
                Assert.AreEqual("Formule 1", disciplines[0].Name, "The discipline should be Formule 1");

                seasonMssqlContext.AddSeason(disciplines[0], 2000);
                var seasons = seasonMssqlContext.GetSeasons(disciplines[0]);
                Assert.AreEqual(1, seasons.Count, "There should be 1 season");
                Assert.AreEqual(2000, seasons[0].Year, "The season should be 2000");

            }
            finally
            {
                seasonMssqlContext.RemoveSeason(disciplines[0], 2010);
                Assert.AreEqual(0, seasonMssqlContext.GetSeasons(disciplines[0]), "The season should be removed");
                disciplineMssqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, disciplineMssqlContext.GetDisciplines().Count, "The discipline should be removed");
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidSeasonException), "Adding a negative number for season should fail")]
        public void AddInvalidSeasonTest()
        {
            DisciplineMssqlContext disciplineMssqlContext = new DisciplineMssqlContext();
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();

            try
            {
                disciplineMssqlContext.AddDiscipline("Formule 1");
                var disciplines = disciplineMssqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count, "There should be 1 discipline");
                Assert.AreEqual("Formule 1", disciplines[0].Name, "The discipline should be Formule 1");

                seasonMssqlContext.AddSeason(disciplines[0], -100);

            }
            finally
            {
                disciplineMssqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, disciplineMssqlContext.GetDisciplines().Count, "Cleanup of the database failed");
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(SeasonExistsException), "Adding a season twice should fail")]
        public void AddSeasonTwiceTest()
        {
            DisciplineMssqlContext disciplineMssqlContext = new DisciplineMssqlContext();
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();
            List<DisciplineInfo> disciplines = new List<DisciplineInfo>();

            try
            {
                disciplineMssqlContext.AddDiscipline("Formule 1");
                disciplines = disciplineMssqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count, "There should be 1 discipline");
                Assert.AreEqual("Formule 1", disciplines[0].Name, "The discipline should be Formule 1");

                seasonMssqlContext.AddSeason(disciplines[0], 2000);
                var seasons = seasonMssqlContext.GetSeasons(disciplines[0]);
                Assert.AreEqual(1, seasons.Count, "There should be 1 season");
                Assert.AreEqual(2000, seasons[0].Year, "The season should be 2000");

                seasonMssqlContext.AddSeason(disciplines[0], 2000);
                Assert.Fail("The test should have failed");
            }
            finally
            {
                seasonMssqlContext.RemoveSeason(disciplines[0], 2010);
                Assert.AreEqual(0, seasonMssqlContext.GetSeasons(disciplines[0]), "The season should be removed");

                disciplineMssqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, disciplineMssqlContext.GetDisciplines().Count, "The discipline should be removed");
            }
        }


        [TestMethod()]
        [ExpectedException(typeof(DisciplineDoesNotExistException))]
        public void AddSeasonToNonExistingDiscipline()
        {
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();

            DisciplineInfo discipline = new DisciplineInfo("Formule 1");

            seasonMssqlContext.AddSeason(discipline, 2000);
        }

    }
}