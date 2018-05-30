using System.Collections.Generic;
using RaceStatistics.Dal.ContextInterfaces;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic.Tests
{
    class DisciplineTestContext : IDisciplineContext
    {
        public void AddDiscipline(string name)
        {
            // Do nothing
        }

        public List<DisciplineInfo> GetDisciplines()
        {
            List<DisciplineInfo> disciplines =
                new List<DisciplineInfo>
                {
                    new DisciplineInfo("Formula 1"),
                    new DisciplineInfo("Nascar")
                };
            return disciplines;
        }

        public void RemoveDiscipline(string name)
        {
            // Do Nothing
        }
    }
}
