using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CustomDirectoryNotFoundException : NotFoundException
    {
        public CustomDirectoryNotFoundException(string directoryPath)
          : base($"The directory '{directoryPath}' was not found.") { }
    }
}
