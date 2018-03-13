using System.Collections.Generic;
using RaceStatistics.Domain;

namespace RaceStatistics.Dal.Interfaces
{
    public interface IDisciplineRepository
    {
        void AddDiscipline(string name);
        List<DisciplineInfo> GetDisciplines();
        void RemoveDiscipline(string name);
    }
}
