using Microsoft.AspNetCore.Http;
using System;

namespace Shared.DataTransferObjects
{
    public class CartItemForCreationDto
    {
        public Guid CartId { init; get; }
        public Guid PharmacyId { init; get; }
        public Guid ProductId { init; get; }
        public int Quantity { init; get; }
        public IFormFile? PrescriptionImage { init; get; }
    }
}