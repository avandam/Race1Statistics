namespace RaceStatistics.Domain
{
    public class ScoreSystemInfo
    {
        public string Name { get; private set; }
        public int PointsForFastestLap { get; private set; }

        public ScoreSystemInfo(string name, int pointsForFastestLap)
        {
            Name = name;
            PointsForFastestLap = pointsForFastestLap;
        }

    }
}
