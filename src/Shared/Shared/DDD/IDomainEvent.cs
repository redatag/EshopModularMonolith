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
}
