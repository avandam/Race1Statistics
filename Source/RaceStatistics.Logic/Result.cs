using System;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Result : ResultInfo
    {
        private TeamDriver driver;
        public Result(int place, ResultStatus status, bool hasFastestLap) : base(place, status, hasFastestLap)
        {
        }

        public void UpdateStatus(ResultStatus newResultStatus)
        {
            throw new NotImplementedException();
        }
    }
}
