using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Dal.Tests.Context
{
    public class BaseTests
    {
        public BaseTests()
        {
            ConnectionSettings.ChangeDatabaseName("RaceStatisticsTest");
        }
    }
}
