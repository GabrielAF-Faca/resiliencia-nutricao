using Ufn.Resiliencia.Api.Portal.Domain.Entities.Shared;

namespace Ufn.Resiliencia.Api.Portal.Infra.Repositories.MySQL.Shared;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(int id);
    Task<TEntity> Create(TEntity entity);
    Task<ICollection<TEntity>> CreateMany(ICollection<TEntity> entities);
    void Update(TEntity entity);
    void UpdateMany(ICollection<TEntity> entities);
    void DeleteAt(TEntity entity);
    void SoftDelete(TEntity entity);
}