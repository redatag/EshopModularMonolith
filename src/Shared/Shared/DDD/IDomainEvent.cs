using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DDD
{
    // INotification is an interface in MediatR Library hanld events asynchronously
    public class IDomainEvent : INotification
    {
        Guid EventId => Guid.NewGuid(); //unique identifier for event
        public DateTime OccurredOn => DateTime.Now;//timstamp when the event is occured
        public string EventType => GetType().AssemblyQualifiedName!; //get the fully qualified name of the event type
    }
    //domain events raised from domain aggregate and handled with mediator or notification interface
    //that can leed to integraton events used by other subscribed bounded context
     
    //Aggregate is clustuer of domain objects that can be treated as a single unit
    //an aggregate has  a root entity called aggregate root (enure the integrity of the aggregate by enforcing the invariants)
    //aggregate can raise a domain event to dignify change to the aggregate
}
