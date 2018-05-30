using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class InvalidSeasonException : Exception
    {
        public InvalidSeasonException(string message) : base(message)
        {
        }
    }
}
