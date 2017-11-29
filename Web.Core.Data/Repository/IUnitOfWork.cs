using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Core.Data.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void SaveChanges();
    }
}
