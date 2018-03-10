using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceStatistics.Domain;

namespace RaceStatistics.Logic
{
    public class Season : SeasonInfo
    {
        private List<Race> races;
        private List<Team> teams;
        private ScoreSystem scoreSystem;

        public Season(int year) : base(year)
        {
        }

        public void AddRace(string name, DateTime date, Circuit circuit)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void AddScoreSystem(ScoreSystem newScoreSystem)
        {
            throw new NotImplementedException();
        }
    }
}
