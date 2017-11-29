using System;
using System.Collections.Generic;
using System.Text;
using Web.Domain.Core.Interfaces;

namespace Web.Domain.Core
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }

    public abstract class Entity : Entity<int>
    {
    }
}
