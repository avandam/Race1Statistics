using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class EntryStillRelatedException : Exception
    {
        public EntryStillRelatedException(string message) : base(message)
        {
        }
    }
}
