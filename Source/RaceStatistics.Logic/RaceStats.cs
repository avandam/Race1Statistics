using System;
using System.Collections.Generic;

namespace RaceStatistics.Logic
{
    public class RaceStats
    {
        private List<Discipline> disciplines;
        private List<ScoreSystem> scoreSystems;
        private List<Circuit> circuits;
        private List<Team> teams;
        private List<Driver> drivers;

        public void AddDiscipline(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            throw new NotImplementedException();
        }

        public void AddScoreSystem(string name, bool fastestLapPoints)
        {
            throw new NotImplementedException();
        }

        public void RemoveScoreSystem(ScoreSystem scoreSystem)
        {
            throw new NotImplementedException();
        }

        public void AddCircuit(string name, string city, string country)
        {
            throw new NotImplementedException();
        }

        public void RemoveCircuit(Circuit circuit)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(string name, string country)
        {
            throw new NotImplementedException();
        }

        public void RemoveTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void AddDriver(string name, DateTime birthDate, string country)
        {
            throw new NotImplementedException();
        }

        public void RemoveDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
