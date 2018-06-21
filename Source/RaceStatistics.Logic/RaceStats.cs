using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

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
            try
            {
                disciplineRepository.AddDiscipline(name);
            }
            catch (DisciplineExistsException ex)
            {
                throw new InvalidInputException(ex.Message);
            }
            catch (InvalidDataFormatException ex)
            {
                throw new InvalidInputException($"The field(s): '{ex.InvalidFields}' should not be empty");
            }
            catch (DatabaseException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public IReadOnlyCollection<IDiscipline> GetDisciplines()
        {
            try
            {
                disciplines.Clear();
                foreach (var discipline in disciplineRepository.GetDisciplines())
                {
                    disciplines.Add(new Discipline(discipline));
                }
                return new ReadOnlyCollection<IDiscipline>(disciplines);

            }
            catch (DatabaseException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public void RemoveDiscipline(IDiscipline discipline)
        {
            try
            {
                disciplineRepository.RemoveDiscipline(discipline.Name);

            }
            catch (DatabaseException ex)
            {
                throw new ConnectionException(ex.Message);
            }
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
