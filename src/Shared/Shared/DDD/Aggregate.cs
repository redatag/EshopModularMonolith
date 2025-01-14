﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DDD
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly IList<IDomainEvent> _domainEvents;

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
           
       

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            if (domainEvent == null)        
                throw new ArgumentNullException(nameof(domainEvent));
            _domainEvents.Add(domainEvent);
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent dequeuedEvents = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequeuedEvents;

         }
    }
}
