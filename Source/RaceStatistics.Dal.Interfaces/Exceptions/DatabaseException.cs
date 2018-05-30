using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }
    }
}
