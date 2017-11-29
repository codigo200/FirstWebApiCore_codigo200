using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Core.EntityFramework.DbContext
{
    public interface IDbContextFactory
    {
        Microsoft.EntityFrameworkCore.DbContext GetCurrentDbContext();
    }
}
