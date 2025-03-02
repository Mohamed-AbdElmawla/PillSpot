using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyEmployeePermission
    {
        [Key, Column(Order = 0)]
        public ulong EmployeeId { get; set; }

        [Key, Column(Order = 1)]
        public int PermissionId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual PharmacyEmployee PharmacyEmployee { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
    }
}
