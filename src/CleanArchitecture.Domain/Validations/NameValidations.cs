using CleanArchitecture.Domain.Notifications;

namespace CleanArchitecture.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> NameIsOk(string name, short maxLength, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(name) || (name.Length <= minLength) || (name.Length >= maxLength))
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
