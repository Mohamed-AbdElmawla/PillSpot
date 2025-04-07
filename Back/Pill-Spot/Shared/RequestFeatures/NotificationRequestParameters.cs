using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class NotificationRequestParameters : RequestParameters
    {
        public bool? IsNotified { get; init; }
    }
}
