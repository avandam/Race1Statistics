﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal.Context;
using RaceStatistics.Domain;
using RaceStatistics.Domain.Exceptions;

namespace RaceStatistics.Dal.Tests.Context
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
                List<DisciplineInfo> disciplines = sqlContext.GetDisciplines();
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
        public void RemoveDisciplineTest()
        {
            DisciplineMssqlContext sqlContext = new DisciplineMssqlContext();

            try
            {
                sqlContext.AddDiscipline("Formule 1");
                sqlContext.AddDiscipline("Nascar");
                Assert.AreEqual(2, sqlContext.GetDisciplines().Count);
                sqlContext.RemoveDiscipline("Nascar");
                Assert.AreEqual(1, sqlContext.GetDisciplines().Count);
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
                List<DisciplineInfo> disciplines = sqlContext.GetDisciplines();
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
