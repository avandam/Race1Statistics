using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class InvalidDataFormatException : Exception
    {
        public string InvalidFields { get; }
        public InvalidDataFormatException(string message, string invalidFields) : base(message)
        {
            InvalidFields = invalidFields;
        }
    }
}
