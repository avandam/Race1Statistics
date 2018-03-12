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
