using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Domain.Interfaces;

public interface IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    /// <summary>
    /// Retrieves an entity by its primary key.
    /// </summary>
    /// <param name="id">The primary key of the entity to retrieve.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all the records of the given entity.
    /// </summary>
    Task<IEnumerable<TEntity>?> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new entity to the context and returns the primary key of the added entity.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    Task<TKey> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an entity from the context.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity in the context.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
}
