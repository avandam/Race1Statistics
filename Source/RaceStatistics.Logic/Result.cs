using System;
using RaceStatistics.Dal.Interfaces.Models;
using RaceStatistics.Logic.Interfaces.Models;

namespace RaceStatistics.Logic
{
    public class Result
    {
        private TeamDriver driver;

        public int Place { get; }
        public ResultStatus Status { get; }
        public bool HasFastestLap { get; }

        public Result(int place, ResultStatus status, bool hasFastestLap)
        {
            Place = place;
            Status = status;
            HasFastestLap = hasFastestLap;
        }

        public Result(ResultInfo result) : this(result.Place, (ResultStatus)result.Status, result.HasFastestLap)
        {
            
        }

        public void UpdateStatus(ResultStatus newResultStatus)
        {
            throw new NotImplementedException();
        }
    }
}
