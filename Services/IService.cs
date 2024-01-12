namespace washbook_backend.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IService<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(string id);
    Task AddAsync(TEntity entity);
    // Task UpdateAsync(TEntity entity);
    // Task DeleteAsync(TEntity entity);
}