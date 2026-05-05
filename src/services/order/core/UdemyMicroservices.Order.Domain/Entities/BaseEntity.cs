using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Order.Domain.Entities
{
    public abstract class BaseEntity<TEntityId>
    {
        public TEntityId Id { get; set; } = default!;
    }
}
