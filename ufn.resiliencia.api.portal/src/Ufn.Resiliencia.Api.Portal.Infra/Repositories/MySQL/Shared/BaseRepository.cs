using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;
using Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

[ExcludeFromCodeCoverage]
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    internal DbSet<TEntity> DbSet;
    internal MySqlContext DefaultContext;
    internal MySqlDbSession Session;

    public BaseRepository(MySqlContext defaultContext, MySqlDbSession session)
    {
        DefaultContext = defaultContext;
        Session = session;
        DbSet = DefaultContext.Set<TEntity>();
    }

    public Task<List<TEntity>> GetAll()
    {
        return DbSet
             .AsQueryable()
             .AsNoTracking()
             .ToListAsync();
    }

    public async Task<TEntity?> GetById(int id)
        => await DbSet.FindAsync(id);

    public async Task<TEntity> Create(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public async Task<ICollection<TEntity>> CreateMany(ICollection<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
        return entities;
    }

    public void Update(TEntity entity)
        => DbSet.Update(entity);

    public void UpdateMany(ICollection<TEntity> entities)
        => DbSet.UpdateRange(entities);

    public void DeleteAt(TEntity entity)
        => DbSet.Remove(entity);

    public void SoftDelete(TEntity entity)
    {
        DbSet.Update(entity);
    }
}