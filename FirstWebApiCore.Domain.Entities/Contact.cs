using System;
using Web.Core.Data.Entities;

namespace FirstWebApiCore.Domain.Entities
{
    public class Contact : Entity
    {
        public virtual string Name { get; set; }
        public virtual string LastNames { get; set; }
        public virtual int Age { get; set; }

        public string DisplayName { get { return string.Format("{0} {1}", Name, LastNames); } }
    }
}
