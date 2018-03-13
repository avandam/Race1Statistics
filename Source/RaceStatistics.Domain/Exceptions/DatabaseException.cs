using System;

namespace RaceStatistics.Domain.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }
    }
}
