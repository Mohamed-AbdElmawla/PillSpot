using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyEmployeePermission
    {
        [Key, Column(Order = 0)]
        public ulong EmployeeID { get; set; }

        [Key, Column(Order = 1)]
        public int PermissionID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual PharmacyEmployee PharmacyEmployee { get; set; }

        [ForeignKey("PermissionID")]
        public virtual Permission Permission { get; set; }
    }
}
