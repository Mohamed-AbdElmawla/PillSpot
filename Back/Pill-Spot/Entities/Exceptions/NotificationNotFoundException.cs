using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class NotificationNotFoundException : NotFoundException
    {
        public NotificationNotFoundException(Guid notificationId):base($"Notification with id: {notificationId} doesn't exist")
        {
            
        }
    }
}
