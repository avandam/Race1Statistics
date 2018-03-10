using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Discipline : DisciplineInfo
    {
        private List<Season> seasons;
        public Discipline(string name) : base(name)
        {
        }

        public void AddSeason(int year)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeason(Season season)
        {
            throw new NotImplementedException();
        }
    }
}
