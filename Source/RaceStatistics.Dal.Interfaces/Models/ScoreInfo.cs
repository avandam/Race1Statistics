namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct ScoreInfo
    {
        public int Place { get; }
        public int Points { get; }

        public ScoreInfo(int place, int points)
        {
            Place = place;
            Points = points;
        }
    }
}
