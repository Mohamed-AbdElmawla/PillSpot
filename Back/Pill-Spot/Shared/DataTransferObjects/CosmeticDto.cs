using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CosmeticDto : ProductDto
    {
        public string Brand { get; init; }
        public SkinType SkinType { get; init; }
        public string UsageInstructions { get; init; }
        public int Volume { get; init; }
    }
}
