using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyEmployeeRole
    {
        [Key]
        public Guid employeeRoleId { get; set; }
        
        [ForeignKey(nameof(PharmacyEmployee))]
        public Guid EmployeeId { get; set; }
        
        [ForeignKey(nameof(Pharmacy))]
        public Guid PharmacyId { get; set; }

        [ForeignKey(nameof(IdentityRole))]
        public string RoleId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public PharmacyEmployee employees{ get; set; }
        public Pharmacy pharmacies{ get; set; }
        public IdentityRole Role{ get; set; }
    }
}