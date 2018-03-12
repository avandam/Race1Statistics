namespace RaceStatistics.Domain
{
    public class SeasonInfo
    {
        public int Year { get; private set; }

        public SeasonInfo(int year)
        {
            Year = year;
        }
    }
}
