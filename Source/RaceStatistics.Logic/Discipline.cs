using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic
{
    public class Discipline : IDiscipline
    {
        public string Name { get; }

        private List<Season> seasons = new List<Season>();
        public Discipline(string name) 
        {
            Name = name;
        }

        public Discipline(DisciplineInfo discipline) : this (discipline.Name)
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
