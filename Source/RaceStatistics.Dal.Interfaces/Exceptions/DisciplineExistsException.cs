using System;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class DisciplineExistsException : Exception
    {
        public DisciplineExistsException(string message) : base(message)
        {
        }
    }
}
