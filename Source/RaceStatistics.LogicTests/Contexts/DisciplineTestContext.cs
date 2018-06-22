using System.Collections.Generic;
using RaceStatistics.Dal.ContextInterfaces;
using RaceStatistics.Dal.Interfaces.Exceptions;
using RaceStatistics.Dal.Interfaces.Models;

namespace RaceStatistics.Logic.Tests.Contexts
{
    class DisciplineTestContext : IDisciplineContext
    {
        public void AddDiscipline(string name)
        {
            // Do nothing
        }

        public List<DisciplineInfo> GetDisciplines()
        {
            List<DisciplineInfo> disciplines =
                new List<DisciplineInfo>
                {
                    new DisciplineInfo("Formula 1"),
                    new DisciplineInfo("Nascar")
                };
            return disciplines;
        }

        public void RemoveDiscipline(string name)
        {
            // Do Nothing
        }
    }

    public class DisciplineTestAddDuplicateDisciplineContext : IDisciplineContext
    {
        public void AddDiscipline(string name)
        {
            throw new DuplicateEntryException("The discipline exists");
        }

        public List<DisciplineInfo> GetDisciplines()
        {
            return null;
        }

        public void RemoveDiscipline(string name)
        {
        }
    }

    public class DisciplineTestConnectionErrorContext : IDisciplineContext
    {
        public void AddDiscipline(string name)
        {
            throw new DatabaseException("Connection issue");
        }

        public List<DisciplineInfo> GetDisciplines()
        {
            throw new DatabaseException("Connection issue");
        }

        public void RemoveDiscipline(string name)
        {
            throw new DatabaseException("Connection issue");
        }
    }

    public class DisciplineTestAddEmptyDisciplineContext : IDisciplineContext
    {
        public void AddDiscipline(string name)
        {
            throw new InvalidDataFormatException("The discipline exists", "Name");
        }

        public List<DisciplineInfo> GetDisciplines()
        {
            return null;
        }

        public void RemoveDiscipline(string name)
        {
        }
    }

}
