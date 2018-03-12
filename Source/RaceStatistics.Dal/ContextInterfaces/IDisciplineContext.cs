using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
