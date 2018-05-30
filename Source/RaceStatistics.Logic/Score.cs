using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic
{
    public class Score 
    {
        public int Place { get; }
        public int Points { get; }

        public Score(int place, int points) 
        {
            Place = place;
            Points = points;
        }

        public Score(ScoreInfo score) : this(score.Place, score.Points)
        {
            
        }
    }
}
