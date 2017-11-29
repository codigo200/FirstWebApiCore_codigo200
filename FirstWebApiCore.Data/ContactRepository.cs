using FirstWebApiCore.Data.Contract;
using FirstWebApiCore.Domain.Entities;
using System;
using Web.Core.EntityFramework;
using Web.Core.EntityFramework.UnitOfWork;

namespace FirstWebApiCore.Data
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
