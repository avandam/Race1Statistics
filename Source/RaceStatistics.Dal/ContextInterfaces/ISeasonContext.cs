using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.ContextInterfaces
{
    public interface ISeasonContext
    {
        void AddSeason(DisciplineInfo discipline, int year);
        List<SeasonInfo> GetSeasons(DisciplineInfo discipline);
        void RemoveSeason(DisciplineInfo discipline, int year);
    }
}
