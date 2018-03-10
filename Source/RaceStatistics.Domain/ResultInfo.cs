using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Domain
{
    public class ResultInfo
    {
        public int Place { get; private set; }
        public ResultStatus Status { get; private set; }
        public bool HasFastestLap { get; private set; }

        public ResultInfo(int place, ResultStatus status, bool hasFastestLap)
        {
            Place = place;
            Status = status;
            HasFastestLap = hasFastestLap;
        }
    }
}
