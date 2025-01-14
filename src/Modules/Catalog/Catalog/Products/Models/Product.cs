namespace Catalog.Products.Models
{
    public class Product : Entity<Guid>
    {
        //make all props private to enforce encapsulation
        //and ensure that the props can be only accessed or modified  throw the controll methods within the entity
        //and maintaing the integrity  of the domain model
        public string Name { get; private set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }

        //add a Createmethod to initialize product entities
        public static Product Create(Guid id, string name, List<string> category, string description, string imagefile, decimal price)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            var product = new Product
            {
                Name = name,
                Category = category,
                Description = description,
                ImageFile = imagefile,
                Price = price
            };

            return product;
        }
        public void Update(string name, List<string> category, string description, string imagefile, decimal price)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            Name = name;
            Category = category;
            Description = description;
            ImageFile = imagefile;
            Price = price;

            //TODO:  if price has changed, rais ProductPriceChanged domain event
        }
    }
}
