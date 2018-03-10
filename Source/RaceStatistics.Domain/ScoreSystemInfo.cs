using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Domain
{
    public class ScoreSystemInfo
    {
        public string Name { get; private set; }
        public int PointsForFastestLap { get; private set; }

        public ScoreSystemInfo(string name, int pointsForFastestLap)
        {
            Name = name;
            PointsForFastestLap = pointsForFastestLap;
        }

    }
}
