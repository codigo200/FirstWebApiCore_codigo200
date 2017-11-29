using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Web.Core.EntityFramework.DbContext;

namespace Web.Core.EntityFramework.UnitOfWork
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        public Microsoft.EntityFrameworkCore.DbContext Context => _dbContextFactory.GetCurrentDbContext();
        private readonly IDbContextFactory _dbContextFactory;

        public EFUnitOfWork(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Rollback()
        {
            Context.Database.CurrentTransaction.Rollback();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }

}