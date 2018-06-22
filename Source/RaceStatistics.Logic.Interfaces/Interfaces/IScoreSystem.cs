namespace RaceStatistics.Logic.Interfaces.Interfaces
{
    public interface IScoreSystem
    {
        string Name { get; }
        int PointsForFastestLap { get; }
        void AddScore(int place, int points);
        void RemoveScore(IScore score);

    }
}
