namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct TeamInfo
    {
        public string Name { get; }
        public string Country { get; }

        public TeamInfo(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }
}
