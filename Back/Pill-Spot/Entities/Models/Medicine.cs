﻿    using System.ComponentModel.DataAnnotations;

    namespace Entities.Models
    {
    public class Medicine : Product
    {
        

        [Required(ErrorMessage = "Dosage is required.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Dosage must be greater than zero.")]
        public float Dosage { get; set; }

        [Required(ErrorMessage = "Side effects are required.")]
        [MaxLength(500, ErrorMessage = "Side effects cannot exceed 500 characters.")]
        public required string SideEffects { get; set; }

        [Required(ErrorMessage = "Prescription requirement is required.")]
        public bool IsPrescriptionRequired { get; set; }
    }
}