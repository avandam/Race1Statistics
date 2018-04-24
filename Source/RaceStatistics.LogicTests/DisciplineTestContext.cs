using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceStatistics.Dal.ContextInterfaces;
using RaceStatistics.Domain;

namespace RaceStatistics.LogicTests
{
    class DisciplineTestContext : IDisciplineContext
    {
        public void AddDiscipline(string name)
        {
            // Do nothing
        }

        public List<DisciplineInfo> GetDisciplines()
        {
            List<DisciplineInfo> disciplines = new List<DisciplineInfo>();
            disciplines.Add(new DisciplineInfo("Formula 1"));
            disciplines.Add(new DisciplineInfo("Nascar"));
            return disciplines;
        }

        public void RemoveDiscipline(string name)
        {
            // Do Nothing
        }
    }
}
