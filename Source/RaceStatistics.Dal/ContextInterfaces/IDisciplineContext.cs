using System.Collections.Generic;
using RaceStatistics.Logic;

namespace RaceStatistics.Dal.ContextInterfaces
{
    public interface IDisciplineContext
    {
        void AddDiscipline(string name);
        List<Discipline> GetDisciplines();
        void RemoveDiscipline(string name);
    }
}
