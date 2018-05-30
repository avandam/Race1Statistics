namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface IDiscipline
    {
        string Name { get; }
        void AddSeason(int year);
    }
}
