using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic
{
    public class ScoreSystemCollection : IScoreSystemCollection
    {
        private readonly List<IScoreSystem> scoreSystems = new List<IScoreSystem>();

        private readonly IScoreSystemRepository scoreSystemRepository;

        public ScoreSystemCollection(IScoreSystemRepository scoreSystemRepository)
        {
            this.scoreSystemRepository = scoreSystemRepository;
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
    }
}
