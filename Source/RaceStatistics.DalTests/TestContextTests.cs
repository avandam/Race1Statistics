using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestContext = RaceStatistics.Dal.TestContext;

namespace RaceStatistics.DalTests
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