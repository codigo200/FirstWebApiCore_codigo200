using System;
using System.Collections.Generic;
using System.Text;
using Web.Core.Data.Entities;

namespace Web.Core.Data.Repository
{
    public interface IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey>
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add to the database</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds a set of entities to the database.
        /// </summary>
        /// <param name="entities">The entities to add to the database.</param>
        void Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates an entity on the database.
        /// </summary>
        /// <param name="entity">The entity to updated on the database.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes the first occurrence of a specific entity from the database.
        /// </summary>
        /// <param name="entity">The entity to remove from the database.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Removes the first occurrence of a specific entity from the database.
        /// </summary>
        /// <param name="id">The entity identifier to remove from the database.</param>
        void Delete(TKey id);

        /// <summary>
        /// Removes all entities from the database.
        /// </summary>
        /// <param name="entities">The entities to remove from the database.</param>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Searches for an entity with the specified id.
        /// </summary>
        /// <param name="id">The entity identifier to search</param>
        /// <param name="deleted">The entity delete status, default value is false</param>
        /// <returns>The entity with the specified id; otherwise, the default value for type TEntity.</returns>
        TEntity FindBy(TKey id);

        /// <summary>
        /// Returns all entities from the database.
        /// </summary>
        /// <param name="deleted">The entity delete status, default value is false.</param>
        /// <returns>All entities from the database.</returns>
        IList<TEntity> List();
    }

    public interface IRepository<TEntity> : IRepository<int, TEntity> where TEntity : class, IEntity<int>
    {

    }
}
