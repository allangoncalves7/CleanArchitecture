using CleanArchitecture.Domain.Notifications;
using CleanArchitecture.Domain.Validations.Interfaces;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class BaseEntity : IValidate
    {
        private List<Notification> _notifications;
        protected BaseEntity(string name)
        {
            Name = name;
            DateCreated = DateTime.Now;
            _notifications = new List<Notification>();
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateCreated { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void SetNotificationList(List<Notification> notifications)
        {
            _notifications = notifications;
        }
        public abstract bool Validate();
    }
}
