using System;

namespace RaceStatistics.Domain.Exceptions
{
    public class SeasonExistsException : Exception
    {
        public SeasonExistsException(string message) : base(message)
        {
        }
    }
}
