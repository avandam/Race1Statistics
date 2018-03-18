using System;
using System.Collections.Generic;
using RaceStatistics.Dal.Interfaces;
using RaceStatistics.Logic.Interfaces;

namespace RaceStatistics.Logic
{
    public class RaceStats : IRaceStats
    {
        private readonly List<IDiscipline> disciplines = new List<IDiscipline>();
        private List<ScoreSystem> scoreSystems = new List<ScoreSystem>();
        private List<Circuit> circuits = new List<Circuit>();
        private List<Team> teams = new List<Team>();
        private List<Driver> drivers = new List<Driver>();

        private readonly IDisciplineRepository disciplineRepository;

        public RaceStats(IDisciplineRepository disciplineRepository)
        {
            this.disciplineRepository = disciplineRepository;
        }

        public void AddDiscipline(string name)
        {
            disciplineRepository.AddDiscipline(name);
        }

        public List<IDiscipline> GetDisciplines()
        {
            disciplines.Clear();
            foreach (var discipline in disciplineRepository.GetDisciplines())
            {
                disciplines.Add(new Discipline(discipline));
            }
            return disciplines;
        }

        public void RemoveDiscipline(IDiscipline discipline)
        {
            disciplineRepository.RemoveDiscipline(discipline.Name);
        }

        public void AddScoreSystem(string name, int fastestLapPoints)
        {
            throw new NotImplementedException();
        }

        public List<IScoreSystem> GetScoreSystems()
        {
            throw new NotImplementedException();
        }

        public void RemoveScoreSystem(IScoreSystem scoreSystem)
        {
            throw new NotImplementedException();
        }

        public void AddCircuit(string name, string city, string country)
        {
            throw new NotImplementedException();
        }

        public List<ICircuit> GetCircuits()
        {
            throw new NotImplementedException();
        }

        public void RemoveCircuit(ICircuit circuit)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(string name, string country)
        {
            throw new NotImplementedException();
        }

        public List<ITeam> GetTeams()
        {
            throw new NotImplementedException();
        }

        public void RemoveTeam(ITeam team)
        {
            throw new NotImplementedException();
        }

        public void AddDriver(string name, DateTime birthDate, string country)
        {
            throw new NotImplementedException();
        }
        public List<IDriver> GetDrivers()
        {
            throw new NotImplementedException();
        }

        public void RemoveDriver(IDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
