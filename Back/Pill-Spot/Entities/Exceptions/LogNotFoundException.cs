using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class LogNotFoundException : NotFoundException
    {
        public LogNotFoundException()
            : base("No logs found.") { }
        public LogNotFoundException(DateTime date)
            : base($"No logs found for {date:yyyy-MM-dd}.") { }
    }
}
