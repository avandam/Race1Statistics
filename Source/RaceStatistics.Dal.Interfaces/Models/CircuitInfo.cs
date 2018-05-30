namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct CircuitInfo
    {
        public string Name { get; }
        public string City { get; }
        public string Country { get; }

        public CircuitInfo(string name, string city, string country)
        {
            Name = name;
            City = city;
            Country = country;
        }
    }
}
