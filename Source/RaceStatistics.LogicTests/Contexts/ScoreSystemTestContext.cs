using System.Collections.Generic;
using RaceStatistics.Dal.ContextInterfaces;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic.Tests.Contexts
{
    class ScoreSystemTestContext : IScoreSystemContext
    {
        public void AddScoreSystem(string name, int pointsForFastestLap)
        {
            // Do nothing
        }

        public List<ScoreSystemInfo> GetScoreSystems()
        {
            List<ScoreSystemInfo> scoreSystems =
                new List<ScoreSystemInfo>
                {
                    new ScoreSystemInfo("System 1", 0),
                    new ScoreSystemInfo("System 2", 1)
                };
            return scoreSystems;
        }

        public void RemoveScoreSystem(string name)
        {
            // Do Nothing
        }
    }

    public class ScoreSystemTestAddDuplicateScoreSystemContext : IScoreSystemContext
    {
        public void AddScoreSystem(string name, int pointsForFastestLap)
        {
            throw new DuplicateEntryException("The ScoreSystem exists");
        }

        public List<ScoreSystemInfo> GetScoreSystems()
        {
            return null;
        }

        public void RemoveScoreSystem(string name)
        {
        }
    }

    public class ScoreSystemTestConnectionErrorContext : IScoreSystemContext
    {
        public void AddScoreSystem(string name, int pointsForFastestLap)
        {
            throw new DatabaseException("Connection issue");
        }

        public List<ScoreSystemInfo> GetScoreSystems()
        {
            throw new DatabaseException("Connection issue");
        }

        public void RemoveScoreSystem(string name)
        {
            throw new DatabaseException("Connection issue");
        }
    }

    public class ScoreSystemTestAddEmptyScoreSystemContext : IScoreSystemContext
    {
        public void AddScoreSystem(string name, int pointsForFastestLap)
        {
            throw new InvalidDataFormatException("The ScoreSystem exists", "Name");
        }

        public List<ScoreSystemInfo> GetScoreSystems()
        {
            return null;
        }

        public void RemoveScoreSystem(string name)
        {
        }
    }

}
