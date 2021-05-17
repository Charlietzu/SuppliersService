using SuppliersService.Business.Notifications;
using System.Collections.Generic;

namespace SuppliersService.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}