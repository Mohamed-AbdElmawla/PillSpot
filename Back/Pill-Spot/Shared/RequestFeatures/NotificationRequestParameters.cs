using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Shared.RequestFeatures
{
    public class NotificationRequestParameters : RequestParameters
    {
        public bool? IsRead { get; init; }
        public bool? IsNotified { get; init; }
        public NotificationType? Type { get; init; }
    }
}
