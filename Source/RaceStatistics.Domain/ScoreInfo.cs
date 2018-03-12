namespace RaceStatistics.Domain
{
    public class ScoreInfo
    {
        public int Place { get; private set; }
        public int Points { get; private set; }

        public ScoreInfo(int place, int points)
        {
            Place = place;
            Points = points;
        }
    }
}
