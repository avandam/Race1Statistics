using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Repositories;
using RaceStatistics.Logic;

namespace RaceStatistics.Factory
{
    // TODO Alda: This name does not cover the intent of the factory.
    // TODO AldA: Split up in 2 separate factories per layer.
    public static class RaceStatsFactory
    {
        public static IRaceStats GetRaceStats()
        {
            return new RaceStats(new DisciplineRepository(new DisciplineMssqlContext()));
        }
    }
}
