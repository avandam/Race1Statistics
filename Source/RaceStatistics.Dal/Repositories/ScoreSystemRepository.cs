using System.Collections.Generic;
using RaceStatistics.Dal.ContextInterfaces;
using RaceStatistics.Dal.Interfaces.Models;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;

namespace RaceStatistics.Dal.Repositories
{
    public class ScoreSystemRepository : IScoreSystemRepository
    {
        private readonly IScoreSystemContext scoreSystemContext;

        public ScoreSystemRepository(IScoreSystemContext scoreSystemContext)
        {
            this.scoreSystemContext = scoreSystemContext;
        }

        public void AddScoreSystem(string name, int pointsForFastestLap)
        {
            scoreSystemContext.AddScoreSystem(name, pointsForFastestLap);
        }

        public List<ScoreSystemInfo> GetScoreSystems()
        {
            return scoreSystemContext.GetScoreSystems();
        }

        public void RemoveScoreSystem(string name)
        {
            scoreSystemContext.RemoveScoreSystem(name);
        }
    }
}
