using System;
using System.Collections.Generic;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class ScoreSystem : ScoreSystemInfo
    {
        private List<Score> scores;
        public ScoreSystem(string name, int pointsForFastestLap) : base(name, pointsForFastestLap)
        {
            scores = new List<Score>();
        }

        public void AddScore(int place, int points)
        {
            throw new NotImplementedException();
        }
    }
}
