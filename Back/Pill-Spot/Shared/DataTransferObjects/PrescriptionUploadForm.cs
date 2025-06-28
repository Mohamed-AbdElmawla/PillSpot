using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects
{
    public class PrescriptionUploadForm
    {
        public string UserId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public IFormFile ImageFile { get; set; }
        public string PrescriptionProductsJson { get; set; }
    }

}