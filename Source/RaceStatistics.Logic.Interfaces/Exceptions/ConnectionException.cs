using System;

namespace RaceStatistics.Logic.Interfaces.Exceptions
{
    public class ConnectionException : Exception
    {
        public ConnectionException(string message) : base(message)
        {
        }

        public ConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}