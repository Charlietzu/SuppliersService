using System.Collections.Generic;
using SuppliersService.Business.Notifications;

namespace SuppliersService.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}