namespace washbook_backend.Repositories;

public interface IRepository<TEntity>
{
    // public Task SaveChangesAsync();
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity> GetByIdAsync(string id);
    public Task AddAsync(TEntity entity);
    // public void Update(TEntity entity);
    // public void Delete(TEntity entity);
}