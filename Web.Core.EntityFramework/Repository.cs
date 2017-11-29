using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Web.Core.Data.Repository;
using Web.Core.EntityFramework.UnitOfWork;
using Web.Core.Data.Entities;

namespace Web.Core.EntityFramework
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : class, IEntity<TKey>
    {
        protected readonly IEFUnitOfWork _unitOfWork;
        protected readonly DbSet<T> _dbSet;

        public Repository(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T>();
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Entry(entity).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(TKey id)
        {
            _dbSet.Remove(FindBy(id));
        }

        public virtual T FindBy(TKey id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IList<T> List()
        {
            return _dbSet.ToList();
        }
    }

    public class Repository<T> : Repository<int, T>, IRepository<T> where T : class, IEntity<int>
    {
        public Repository(IEFUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
