using System;

namespace RaceStatistics.Domain.Exceptions
{
    public class InvalidSeasonException : Exception
    {
        public InvalidSeasonException(string message) : base(message)
        {
        }
    }
}
