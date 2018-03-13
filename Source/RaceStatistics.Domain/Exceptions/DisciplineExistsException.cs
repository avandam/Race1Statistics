using System;

namespace RaceStatistics.Domain.Exceptions
{
    public class DisciplineExistsException : Exception
    {
        public DisciplineExistsException(string message) : base(message)
        {
        }
    }
}
