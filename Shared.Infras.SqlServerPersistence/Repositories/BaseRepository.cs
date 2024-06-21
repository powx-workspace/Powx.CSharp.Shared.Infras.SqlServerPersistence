using Microsoft.EntityFrameworkCore;
using Shared.Core.Domain.Entities;
using Shared.Core.Drivens.Persistence.EFCore;
using Shared.Core.Drivens.Persistence.Repositories;

namespace Shared.Infras.SqlServerPersistence.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext dbContext) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public Task<TEntity?> GetByIdAsync(string id)
        => _dbSet.SingleOrDefaultAsync(e => e.Id == id);

    public Task<List<TEntity>> GetAllAsync()
        => _dbSet.ToListAsync();
}