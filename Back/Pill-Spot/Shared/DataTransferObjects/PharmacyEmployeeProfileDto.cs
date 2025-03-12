using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class PharmacyEmployeeProfileDto
    {
        public Guid EmployeeId { get; init; }
        public string Role { get; init; }
        public DateTime HireDate { get; init; }
        public PharmacyDto PharmacyDto { get; init; }
    }
}
