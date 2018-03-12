using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStatistics.Dal.Interfaces.Exceptions
{
    public class DisciplineExistsException : Exception
    {
        public DisciplineExistsException(string message) : base(message)
        {
        }
    }
}
