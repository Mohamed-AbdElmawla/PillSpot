using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class LogFileInUseException : IOException
    {
        public LogFileInUseException(string filePath)
            : base($"The log file '{filePath}' is currently in use and cannot be cleared.")
        {
        }
    }
}
