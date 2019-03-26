using RaceStatistics.Dal.ContextInterfaces;
using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Dal.Context
{
    public class DisciplineSeasonMssqlContext : IDisciplineSeasonContext
    {
        public void AddSeasonToDiscipline(int disciplineId, int seasonId)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeasonFromDiscipline(int disciplineId, int seasonId)
        {
            throw new NotImplementedException();
        }

        public bool SeasonExistsInDiscipline(int disciplineId, int year)
        {
            throw new NotImplementedException();
        }
    }
}
