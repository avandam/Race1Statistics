using System;
using System.Collections.Generic;
using RaceStatistics.Domain;
using RaceStatistics.Logic.Interfaces;

namespace RaceStatistics.Logic
{
    public class Discipline : DisciplineInfo, IDiscipline
    {
        private List<Season> seasons = new List<Season>();
        public Discipline(string name) : base(name)
        {
        }

        public Discipline(DisciplineInfo discipline) : base (discipline.Name)
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

        public override string ToString()
        {
            return Name;
        }
    }
}
