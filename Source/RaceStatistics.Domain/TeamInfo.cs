namespace RaceStatistics.Domain
{
    public class TeamInfo
    {
        public string Name { get; private set; }
        public string Country { get; private set; }

        public TeamInfo(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }
}
