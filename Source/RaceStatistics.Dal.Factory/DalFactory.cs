using RaceStatistics.Dal.Context;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;
using RaceStatistics.Dal.Repositories;

namespace RaceStatistics.Dal.Factory
{
    public static class DalFactory
    {
        public static IDisciplineRepository GetDisciplineRepository()
        {
            return new DisciplineRepository(new DisciplineMssqlContext());
        }
    }
}
