
namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct ResultInfo
    {
        public int Place { get; }
        public int Status { get; }
        public bool HasFastestLap { get; }

        public ResultInfo(int place, int status, bool hasFastestLap)
        {
            Place = place;
            Status = status;
            HasFastestLap = hasFastestLap;
        }
    }
}
