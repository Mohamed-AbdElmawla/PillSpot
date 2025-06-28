using System;
using Entities.Models;

namespace Shared.DataTransferObjects
{
    public class CartItemDto
    {
        public Guid CartItemId { init; get; }
        public Guid CartId { init; get; }
        public Guid PharmacyId { init; get; }
        public Guid ProductId { init; get; }
        public string? PrescriptionImageUrl { init; get; }
        public DateTime? PrescriptionUploadedAt { init; get; }
        public CartItemApprovalStatus? PharmacyApproved { init; get; }
        public DateTime? PharmacyRespondedAt { init; get; }
        public string? RejectionReason { init; get; }
        public RejectionType? RejectionType { init; get; }
        public string? RespondedByUserId { init; get; }
        public decimal PriceAtAddition { init; get; }
        public int Quantity { init; get; }
        public DateTime AddedAt { init; get; }
        public decimal TotalPrice { init; get; }
        public PharmacyProductDto? PharmacyProduct { init; get; }
    }
}