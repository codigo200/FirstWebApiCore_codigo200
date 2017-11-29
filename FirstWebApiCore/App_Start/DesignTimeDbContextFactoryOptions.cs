using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.EntityFramework.DbContext;

namespace FirstWebApiCore.App_Start
{
    public class DesignTimeDbContextFactoryOptions: IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseMySql("server=localhost;port=3306;user=root;password=root;database=contact_db", b => b.MigrationsAssembly("FirstWebApiCore"));
            return new DatabaseContext(builder.Options);
        }
    }
}
