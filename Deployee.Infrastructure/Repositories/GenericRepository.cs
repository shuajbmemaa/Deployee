using Deployee.Domain.Interfaces;
using Deployee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Infrastructure.Repositories;

public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    protected readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(ApplicationDbContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<TKey> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity.Id;
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_dbSet.Remove(entity));
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_dbSet.Update(entity));
    }
}
