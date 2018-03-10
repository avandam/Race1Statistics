using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Domain
{
    public class ScoreInfo
    {
        public int Place { get; private set; }
        public int Points { get; private set; }

        public ScoreInfo(int place, int points)
        {
            Place = place;
            Points = points;
        }
    }
}
