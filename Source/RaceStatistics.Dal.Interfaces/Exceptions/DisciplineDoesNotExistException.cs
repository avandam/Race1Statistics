using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class DisciplineDoesNotExistException : Exception
    {
        public DisciplineDoesNotExistException(string message) : base(message)
        {
        }
    }
}
