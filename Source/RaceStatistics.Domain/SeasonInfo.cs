using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Domain
{
    public class SeasonInfo
    {
        public int Year { get; private set; }

        public SeasonInfo(int year)
        {
            Year = year;
        }
    }
}
