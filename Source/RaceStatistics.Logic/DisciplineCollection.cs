using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.RepositoryInterfaces;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics.Logic
{
    public class DisciplineCollection : IDisciplineCollection
    {
        private readonly List<IDiscipline> disciplines = new List<IDiscipline>();

        private readonly IDisciplineRepository disciplineRepository;

        public DisciplineCollection(IDisciplineRepository disciplineRepository)
        {
            this.disciplineRepository = disciplineRepository;
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
                foreach (var disciplineInfo in disciplineRepository.GetDisciplines())
                {
                    disciplines.Add(new Discipline(disciplineInfo));
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
    }
}
