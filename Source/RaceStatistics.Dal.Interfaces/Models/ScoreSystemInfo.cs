namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct ScoreSystemInfo
    {
        public string Name { get; }
        public int PointsForFastestLap { get; }

        public ScoreSystemInfo(string name, int pointsForFastestLap)
        {
            Name = name;
            PointsForFastestLap = pointsForFastestLap;
        }

    }
}
