using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Score : ScoreInfo
    {
        public Score(int place, int points) : base(place, points)
        {
        }
    }
}
