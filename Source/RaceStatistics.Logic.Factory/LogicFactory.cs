
using RaceStatistics.Dal.Factory;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic.Factory
{
    public static class LogicFactory
    {
        public static IDisciplineCollection GetDisciplineCollection()
        {
            return new DisciplineCollection(DalFactory.GetDisciplineRepository());
        }

        public static IScoreSystemCollection GetScoreSystemCollection()
        {
            return new ScoreSystemCollection(DalFactory.GetScoreSystemRepository());
        }
    }
}
