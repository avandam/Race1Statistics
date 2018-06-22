using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException(string message) : base(message)
        {
        }
    }
}
