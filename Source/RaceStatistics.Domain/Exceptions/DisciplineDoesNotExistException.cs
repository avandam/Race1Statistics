using System;

namespace RaceStatistics.Domain.Exceptions
{
    public class DisciplineDoesNotExistException : Exception
    {
        public DisciplineDoesNotExistException(string message) : base(message)
        {
        }
    }
}
