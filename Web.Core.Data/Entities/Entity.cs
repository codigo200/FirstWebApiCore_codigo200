using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Core.Data.Entities
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }

    public abstract class Entity : Entity<int>
    {
    }
}
