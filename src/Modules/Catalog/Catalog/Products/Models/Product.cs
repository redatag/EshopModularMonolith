using Catalog.Products.Events;

namespace Catalog.Products.Models
{
    public class Product : Aggregate<Guid>
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

            product.AddDomainEvent(new ProductCreatedEvent(product));

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

            if (Price != price )
            {
                Price = price;
                AddDomainEvent(new ProductPriceChanged(this));

            }
            //TODO:  if price has changed, rais ProductPriceChanged domain event

           
        }
        //domain events somethig happened in the past and other parts of the same service boundry need to react  to these changes
        // is business event that happen  within the domain model
        //Achieve the consistency between aggregates in the same domain
        //when an order is placed,  an OrderPlaced event is triggeered and notify other parts of the system about changes within the domain
        //encapsulate the event details and dispatch them them to interested parties
        //after saving changes to DB , the domain event is dispatched to their respective handler in infrastructure layer

        //published and consumed within the same single domain the same bounded context ()aggregate)
        //send synchronsly using in-memory message bus like mediator or notification interface

        //intgration event
         //, consumed by other sub systems or other boundries (aggregate)//events between contexts
        //asynchoronously sent with messaage broker over a queue like rabbitMQ

    }
}
