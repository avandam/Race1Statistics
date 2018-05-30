
using RaceStatistics.Dal.Factory;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic.Factory
{
    public static class LogicFactory
    {
        public static IRaceStats GetRaceStats()
        {
            return new RaceStats(DalFactory.GetDisciplineRepository());
        }
    }
}
