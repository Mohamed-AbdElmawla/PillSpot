using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserAddressDto(
        Guid AddressId,
        string Label,
        LocationDto Location,
        bool IsDefault);
}
