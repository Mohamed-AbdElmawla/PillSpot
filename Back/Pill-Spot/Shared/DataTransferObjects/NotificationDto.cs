using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record NotificationDto
    {
        public Guid Id { get; init; }
        public string Message { get; init; }
        public Guid UserId { get; init; }
        public bool IsNotified { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? NotifiedDate { get; init; }
    }
}
