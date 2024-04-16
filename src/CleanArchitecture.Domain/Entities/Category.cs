using CleanArchitecture.Domain.Notifications;
using CleanArchitecture.Domain.Validations;
using CleanArchitecture.Domain.Validations.Interfaces;

namespace CleanArchitecture.Domain.Entities
{
    public class Category : BaseEntity, IContract
    {
        public Category(string name) : base(name) { }

        public ICollection<Product> Products { get; set; }

        public override bool Validate()
        {
            var contracts = new ContractValidations<Category>()
                .NameIsOk(this.Name, 100, 3, "O nome deve ter entre 3 caracteres e 100 caracteres", "Name");

            this.SetNotificationList(contracts.Notifications as List<Notification>);
            return contracts.IsValid();
                
        }
    }
}
