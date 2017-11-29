using System;
using System.Collections.Generic;
using System.Text;
using Web.Core.Data.Repository;

namespace Web.Core.EntityFramework.UnitOfWork
{
    public interface IEFUnitOfWork: IUnitOfWork
    {
        Microsoft.EntityFrameworkCore.DbContext Context { get; }
    }
}
