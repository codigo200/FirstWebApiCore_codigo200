using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.EntityFramework.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Web.Core.Utils.HttpContext;

namespace FirstWebApiCore.App_Start
{
    public class DbContextFactory : IDbContextFactory
    {
        private IHttpCurrentContext _httpCurrectContext;

        public DbContextFactory(IHttpCurrentContext httpCurrentContext)
        {
            _httpCurrectContext = httpCurrentContext;
        }
        
        public DbContext GetCurrentDbContext()
        {
            return _httpCurrectContext.Items["dbContext"] as DbContext;
        }
    }
}
