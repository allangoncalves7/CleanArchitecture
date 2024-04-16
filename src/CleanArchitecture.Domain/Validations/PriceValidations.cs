using CleanArchitecture.Domain.Notifications;

namespace CleanArchitecture.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> PriceIsOk(decimal price, string message, string propertyName)
        {
            if (price < 0)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
