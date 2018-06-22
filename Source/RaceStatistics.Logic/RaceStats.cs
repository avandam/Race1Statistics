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
        private readonly List<IScoreSystem> scoreSystems = new List<IScoreSystem>();
        private List<Circuit> circuits = new List<Circuit>();
        private List<Team> teams = new List<Team>();
        private List<Driver> drivers = new List<Driver>();

        private readonly IDisciplineRepository disciplineRepository;
        private readonly IScoreSystemRepository scoreSystemRepository;

        public RaceStats(IDisciplineRepository disciplineRepository, IScoreSystemRepository scoreSystemRepository)
        {
            this.disciplineRepository = disciplineRepository;
            this.scoreSystemRepository = scoreSystemRepository;
        }

        public void AddDiscipline(string name)
        {
            try
            {
                disciplineRepository.AddDiscipline(name);
            }
            catch (DuplicateEntryException ex)
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
            try
            {
                scoreSystemRepository.AddScoreSystem(name, fastestLapPoints);
            }
            catch (DuplicateEntryException ex)
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

        public IReadOnlyCollection<IScoreSystem> GetScoreSystems()
        {
            try
            {
                scoreSystems.Clear();
                foreach (var scoreSystem in scoreSystemRepository.GetScoreSystems())
                {
                    scoreSystems.Add(new ScoreSystem(scoreSystem));
                }
                return new ReadOnlyCollection<IScoreSystem>(scoreSystems);

            }
            catch (DatabaseException ex)
            {
                throw new ConnectionException(ex.Message);
            }
        }

        public void RemoveScoreSystem(IScoreSystem scoreSystem)
        {
            try
            {
                scoreSystemRepository.RemoveScoreSystem(scoreSystem.Name);
            }
            catch (DatabaseException ex)
            {
                throw new ConnectionException(ex.Message);
            }
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
