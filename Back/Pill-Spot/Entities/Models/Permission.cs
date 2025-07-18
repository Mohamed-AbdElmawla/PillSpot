﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Permission
    {
        [Key]
        public Guid PermissionId { get; set; }

        [Required(ErrorMessage = "Permission name is required.")]
        [MaxLength(50, ErrorMessage = "Permission name cannot exceed 50 characters.")]
        public required string Name { get; set; }

        public virtual ICollection<PharmacyEmployeePermission> PharmacyEmployeePermissions { get; set; } = new List<PharmacyEmployeePermission>();
        public virtual ICollection<AdminPermission> AdminPermissions { get; set; } = new List<AdminPermission>();
    }
}