using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic
{
    public class ScoreSystem : IScoreSystem
    {
        private List<Score> scores;

        public string Name { get; }
        public int PointsForFastestLap { get; }

        public ScoreSystem(string name, int pointsForFastestLap)
        {
            Name = name;
            PointsForFastestLap = pointsForFastestLap;
            scores = new List<Score>();
        }

        public ScoreSystem(ScoreSystemInfo scoreSystem) : this(scoreSystem.Name, scoreSystem.PointsForFastestLap)
        {
            
        }

        public void AddScore(int place, int points)
        {
            throw new NotImplementedException();
        }

        public void RemoveScore(IScore score)
        {
            throw new NotImplementedException();
        }
    }
}
