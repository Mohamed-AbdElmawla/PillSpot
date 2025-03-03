using System;

namespace Shared.DataTransferObjects
{
    public record BatchDto
    {
        public ulong BatchId { get; init; }
        public string BatchNumber { get; init; }
        public DateTime ManufactureDate { get; init; }
        public DateTime ExpirationDate { get; init; }
    }
}