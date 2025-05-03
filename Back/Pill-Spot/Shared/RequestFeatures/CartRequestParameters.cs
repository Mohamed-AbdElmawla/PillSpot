using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class CartRequestParameters : RequestParameters
    {
        public string? CartType { get; set; }  // "User" or "Guest"
        public string? UserId { get; set; }
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public bool? IsActive { get; set; }
        public int? MinItems { get; set; }
        public int? MaxItems { get; set; }

        public bool ValidItemCountRange => MinItems == null || MaxItems == null || MinItems <= MaxItems;
    }
}
