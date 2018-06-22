using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class EntryDoesNotExistException : Exception
    {
        public EntryDoesNotExistException(string message) : base(message)
        {
        }
    }
}
