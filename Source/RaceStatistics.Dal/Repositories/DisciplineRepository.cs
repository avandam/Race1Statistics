using System.Collections.Generic;
using RaceStatistics.Dal.ContextInterfaces;
using RaceStatistics.Dal.Interfaces;
using RaceStatistics.Domain;

namespace RaceStatistics.Dal.Repositories
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly IDisciplineContext disciplineContext;

        public DisciplineRepository(IDisciplineContext disciplineContext)
        {
            this.disciplineContext = disciplineContext;
        }

        public void AddDiscipline(string name)
        {
            disciplineContext.AddDiscipline(name);
        }

        public List<DisciplineInfo> GetDisciplines()
        {
            return disciplineContext.GetDisciplines();
        }

        public void RemoveDiscipline(string name)
        {
            disciplineContext.RemoveDiscipline(name);
        }
    }
}
