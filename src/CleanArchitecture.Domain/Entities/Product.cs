using CleanArchitecture.Domain.Notifications;
using CleanArchitecture.Domain.Validations;
using CleanArchitecture.Domain.Validations.Interfaces;

namespace CleanArchitecture.Domain.Entities
{
    public class Product : BaseEntity, IContract
    {
        public Product(string name, string description, decimal price, int stock, int categoryId) : base(name)
        {
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; set; }

        public override bool Validate()
        {
            var contracts = new ContractValidations<Product>()
                 .NameIsOk(this.Name, 100, 3, "O nome deve ter entre 3 caracteres e 100 caracteres", "Name")
                 .DescriptionIsOk(this.Description, 200, 5, "A descrição deve ter entre 5 caracteres e 200 caracteres", "Description")
                 .PriceIsOk(this.Price, "O preço não pode ser menor que 0", "Price")
                 .PriceIsOk(this.Price, "O estoque não pode ser menor que 0", "Stock");

            this.SetNotificationList(contracts.Notifications as List<Notification>);
            return contracts.IsValid();
        }


    }
}
