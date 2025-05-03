using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class CheckoutPreparationDto
    {
        public Guid CartId { get; init; }
        public decimal TotalAmount { get; init; }
        public IEnumerable<PharmacyCartDto> PharmacyCarts { get; init; }
        public bool RequiresPrescriptionValidation { get; init; }
    }
}
