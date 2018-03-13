using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Repositories;
using RaceStatistics.Logic;

namespace RaceStatistics.Factory
{
    public static class RaceStatsFactory
    {
        public static IRaceStats GetRaceStats()
        {
            return new RaceStats(new DisciplineRepository(new DisciplineMssqlContext()));
        }
    }
}
