﻿using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public class OrderForCreationDto
    {
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }  // Keep as string for ASP.NET Identity

        [Required(ErrorMessage = "Location ID is required.")]
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "Total price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than zero.")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public int PaymentMethod { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        public int Currency { get; set; }

        public List<OrderItemForCreationDto> OrderItems { get; set; }
    }
}
