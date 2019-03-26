using System.Collections.Generic;
using RaceStatistics.Dal.ContextInterfaces;
using RaceStatistics.Dal.Interfaces.Models;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;

namespace RaceStatistics.Dal.Repositories
{
    // TODO: Update discipline to show that Collection and entity use the same repository.
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
