using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProductDto
    {
        public ulong ProductId { get; init; }
        public int SubCategoryId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public string ImageURL { get; init; }
        public DateTime CreatedDate { get; init; }
    }
}
