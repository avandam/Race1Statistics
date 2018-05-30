using RaceStatistics.Dal.ContextInterfaces;
using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Context
{
    public class SeasonMssqlContext : ISeasonContext
    {
        public void AddSeason(DisciplineInfo discipline, int year)
        {
            throw new NotImplementedException();
        }

        public List<SeasonInfo> GetSeasons(DisciplineInfo discipline)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeason(DisciplineInfo discipline, int year)
        {
            throw new NotImplementedException();
        }
    }
}
