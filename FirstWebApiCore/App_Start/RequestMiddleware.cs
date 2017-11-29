using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.EntityFramework.DbContext;
using Web.Core.Utils.HttpContext;

namespace FirstWebApiCore.App_Start
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate next;
        public IHttpCurrentContext _httpCurrentContext { get; }
        public IConfiguration Configuration { get; }

        public RequestMiddleware(RequestDelegate next, IHttpCurrentContext httpCurrentContex, IConfiguration configuration)
        {
            Configuration = configuration;
            _httpCurrentContext = httpCurrentContex;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            this.BeginInvoke(context);
            await this.next.Invoke(context);
            this.EndInvoke(context);
        }

        private void BeginInvoke(HttpContext context)
        {
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var option = optionsBuilder.UseMySql(connection, b => b.MigrationsAssembly("FirstWebApiCore")).Options;
            var dbContext = new DatabaseContext(option);
            dbContext.Database.BeginTransaction();
            _httpCurrentContext.BindObject("dbContext", dbContext);
        }

        private void EndInvoke(HttpContext context)
        {
            var contex = _httpCurrentContext.UnBindObject("dbContext") as DbContext;
            try
            {
                contex.SaveChanges();
                if (contex.Database.CurrentTransaction != null)
                {
                    contex.Database.CurrentTransaction.Commit();
                }
            }
            catch (Exception e)
            {
                contex.Database.CurrentTransaction.Rollback();
            }
            finally
            {
                contex.Dispose();
            }
        }
    }
}
