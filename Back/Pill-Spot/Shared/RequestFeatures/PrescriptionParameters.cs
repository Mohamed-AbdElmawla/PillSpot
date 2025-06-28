
using Entities.Models;

namespace Shared.RequestFeatures
{
    public class PrescriptionParameters : RequestParameters
    {
        public PrescriptionParameters() => OrderBy = "IssueDate desc";
        public string? SearchTerm { get; set; }
    }
}
