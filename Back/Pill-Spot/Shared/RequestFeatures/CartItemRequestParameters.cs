using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class CartItemRequestParameters : RequestParameters
    {
        public Guid? PharmacyId { get; set; }
        public Guid? ProductId { get; set; }
        public string? ProductType { get; set; }
        public DateTime? AddedAfter { get; set; }
        public DateTime? AddedBefore { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }

        public bool ValidPriceRange => MinPrice == null || MaxPrice == null || MinPrice <= MaxPrice;
    }
}
