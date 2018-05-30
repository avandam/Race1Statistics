using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic
{
    public class Season
    {
        private List<Race> races;
        private List<Team> teams;
        private ScoreSystem scoreSystem;

        public int Year { get; }

        public Season(int year) 
        {
            Year = year;
        }

        public Season(SeasonInfo season) : this(season.Year)
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
