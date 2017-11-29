using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Core.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; } 
    }
}
