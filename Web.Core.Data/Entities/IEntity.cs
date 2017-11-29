using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Core.Data.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
