using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyEmployeeRole
    {
        [Key]
        public Guid employeeRoleId { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
        
        [Required]
        public Guid PharmacyId { get; set; }

        [Required]
        public string RoleId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(EmployeeId))]
        public PharmacyEmployee Employee { get; set; }

        [ForeignKey(nameof(PharmacyId))]
        public Pharmacy Pharmacy { get; set; }

        [ForeignKey(nameof(RoleId))]
        public IdentityRole Role { get; set; }
    }
}