using System;

namespace RaceStatistics.Logic.Interfaces.Exceptions
{
    public class DuplicateInputException : Exception
    {
        public DuplicateInputException(string message) : base(message)
        {
        }

        public DuplicateInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
