namespace RaceStatistics.Domain
{
    public class DisciplineInfo
    {
        public string Name { get; private set; }

        public DisciplineInfo(string name)
        {
            Name = name;
        }
    }
}
