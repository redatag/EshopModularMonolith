using Catalog.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Events
{
    public record ProductPriceChanged(Product Product) 
        : IDomainEvent;
    
}
