using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class SeasonExistsException : Exception
    {
        public SeasonExistsException(string message) : base(message)
        {
        }
    }
}
