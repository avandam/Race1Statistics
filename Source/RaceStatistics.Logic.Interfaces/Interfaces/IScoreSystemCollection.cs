using System;
using System.Collections.Generic;
using RaceStatistics.Logic.Interfaces.Exceptions;

namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface IScoreSystemCollection
    {
        void AddScoreSystem(string name, int fastestLapPoints);
        IReadOnlyCollection<IScoreSystem> GetScoreSystems();
        void RemoveScoreSystem(IScoreSystem scoreSystem);
    }
}