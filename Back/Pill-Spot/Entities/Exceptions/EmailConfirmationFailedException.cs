﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class EmailConfirmationFailedException: Exception
    {
        public EmailConfirmationFailedException(string message):base(message)
        {
            
        }
    }
}
