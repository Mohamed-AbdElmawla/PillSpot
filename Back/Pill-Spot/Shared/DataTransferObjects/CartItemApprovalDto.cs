using System;
using Entities.Models;

namespace Shared.DataTransferObjects
{
    public class CartItemApprovalDto
    {
        public Guid CartItemId { init; get; }
        public CartItemApprovalStatus? Status { init; get; }
        public string? Reason { init; get; }
        public RejectionType? Type { init; get; }
        public string? RespondedByUserId { init; get; }
    }
}