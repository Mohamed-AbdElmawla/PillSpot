﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record GuestCartCreateDto
    {
        public Guid? GuestCartId { get; init; }  // Null for new carts
    }
}
