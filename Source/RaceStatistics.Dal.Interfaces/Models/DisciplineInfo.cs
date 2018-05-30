namespace RaceStatistics.Dal.Interfaces.Models
{
    public struct DisciplineInfo
    {
        public string Name { get; }

        public DisciplineInfo(string name)
        {
            Name = name;
        }
    }
}
