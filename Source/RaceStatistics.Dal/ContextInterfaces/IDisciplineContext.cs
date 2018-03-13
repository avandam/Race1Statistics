﻿using System.Collections.Generic;
using RaceStatistics.Domain;

namespace RaceStatistics.Dal.ContextInterfaces
{
    public interface IDisciplineContext
    {
        void AddDiscipline(string name);
        List<DisciplineInfo> GetDisciplines();
        void RemoveDiscipline(string name);
    }
}
