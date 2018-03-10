using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Domain
{
    public class DisciplineInfo
    {
        public string Name { get; private set; }

        public DisciplineInfo(string name)
        {
            Name = name;
        }
    }
}
