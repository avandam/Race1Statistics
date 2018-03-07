using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceStatistics.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Dal.Tests
{
    [TestClass]
    public class TestContextTests
    {
        [TestMethod]
        public void GetTestTest()
        {
            TestContext testContext = new TestContext();
            Assert.AreEqual("abcd", testContext.GetTest());
        }
    }
}