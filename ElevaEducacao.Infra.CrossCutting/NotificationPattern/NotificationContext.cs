using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace ElevaEducacao.Infra.CrossCutting.NotificationPattern
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }
        public void AddNotifications(string[] messages)
        {
            _notifications.AddRange(messages.Select(x => new Notification(x)));
        }
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorMessage);
            }
        }
    }
}
