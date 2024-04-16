using CleanArchitecture.Domain.Notifications;

namespace CleanArchitecture.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> StockIsOk(int stock, string message, string propertyName)
        {
            if (stock < 0 || stock > 9999)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
