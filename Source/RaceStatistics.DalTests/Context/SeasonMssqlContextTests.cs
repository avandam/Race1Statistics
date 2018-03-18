using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceStatistics.Domain;
using RaceStatistics.Domain.Exceptions;

namespace RaceStatistics.Dal.Context.Tests
{
    [TestClass()]
    public class SeasonMssqlContextTests
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
                Assert.AreEqual(1, disciplines.Count);
                Assert.AreEqual("Formule 1", disciplines[0].Name);

                seasonMssqlContext.AddSeason(disciplines[0], 2000);
                var seasons = seasonMssqlContext.GetSeasons(disciplines[0]);
                Assert.AreEqual(1, seasons.Count);
                Assert.AreEqual(2000, seasons[0].Year);

            }
            finally
            {
                seasonMssqlContext.RemoveSeason(disciplines[0], 2010);
                Assert.AreEqual(0, seasonMssqlContext.GetSeasons(disciplines[0]));
                disciplineMssqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, disciplineMssqlContext.GetDisciplines().Count);
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidSeasonException))]
        public void AddInvalidSeasonTest()
        {
            DisciplineMssqlContext disciplineMssqlContext = new DisciplineMssqlContext();
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();

            try
            {
                disciplineMssqlContext.AddDiscipline("Formule 1");
                var disciplines = disciplineMssqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count);
                Assert.AreEqual("Formule 1", disciplines[0].Name);

                seasonMssqlContext.AddSeason(disciplines[0], -100);

            }
            finally
            {
                disciplineMssqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, disciplineMssqlContext.GetDisciplines().Count);
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(SeasonExistsException))]
        public void AddSeasonTwiceTest()
        {
            DisciplineMssqlContext disciplineMssqlContext = new DisciplineMssqlContext();
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();
            List<DisciplineInfo> disciplines = new List<DisciplineInfo>();

            try
            {
                disciplineMssqlContext.AddDiscipline("Formule 1");
                disciplines = disciplineMssqlContext.GetDisciplines();
                Assert.AreEqual(1, disciplines.Count);
                Assert.AreEqual("Formule 1", disciplines[0].Name);

                seasonMssqlContext.AddSeason(disciplines[0], 2000);
                var seasons = seasonMssqlContext.GetSeasons(disciplines[0]);
                Assert.AreEqual(1, seasons.Count);
                Assert.AreEqual(2000, seasons[0].Year);

                seasonMssqlContext.AddSeason(disciplines[0], 2000);
            }
            finally
            {
                seasonMssqlContext.RemoveSeason(disciplines[0], 2010);
                Assert.AreEqual(0, seasonMssqlContext.GetSeasons(disciplines[0]));

                disciplineMssqlContext.RemoveDiscipline("Formule 1");
                Assert.AreEqual(0, disciplineMssqlContext.GetDisciplines().Count);
            }
        }


        [TestMethod()]
        [ExpectedException(typeof(DisciplineDoesNotExistException))]
        public void AddSeasonToNonExistingDiscipline()
        {
            DisciplineMssqlContext disciplineMssqlContext = new DisciplineMssqlContext();
            SeasonMssqlContext seasonMssqlContext = new SeasonMssqlContext();

            DisciplineInfo discipline = new DisciplineInfo("Formule 1");

            seasonMssqlContext.AddSeason(discipline, 2000);
        }

    }
}