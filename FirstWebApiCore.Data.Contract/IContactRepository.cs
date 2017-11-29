using FirstWebApiCore.Domain.Entities;
using Web.Core.Data.Repository;
using System;

namespace FirstWebApiCore.Data.Contract
{
    public interface IContactRepository: IRepository<Contact>
    {
    }
}
