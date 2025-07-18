﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyEmployee
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public required string UserId { get; set; }

        [Required(ErrorMessage = "Pharmacy ID is required.")]
        public Guid PharmacyId { get; set; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("PharmacyId")]
        public virtual Pharmacy Pharmacy { get; set; }

        public virtual ICollection<PharmacyEmployeePermission> PharmacyEmployeePermissions { get; set; } = new List<PharmacyEmployeePermission>();
        public virtual ICollection<PharmacyEmployeeRole> PharmacyEmployeeRoles { get; set; } = new List<PharmacyEmployeeRole>();

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}