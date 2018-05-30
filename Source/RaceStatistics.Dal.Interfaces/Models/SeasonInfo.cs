namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct SeasonInfo
    {
        public int Year { get; }

        public SeasonInfo(int year)
        {
            Year = year;
        }
    }
}
