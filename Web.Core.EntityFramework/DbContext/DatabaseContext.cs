using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using FirstWebApiCore.Domain.Entities;

namespace Web.Core.EntityFramework.DbContext
{
    public class DatabaseContext: Microsoft.EntityFrameworkCore.DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().ToTable("contact");
        }
    }
}
