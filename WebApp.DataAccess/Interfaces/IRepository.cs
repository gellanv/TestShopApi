namespace WebApp.DataAccess.Interfaces;

public interface IRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task AddAsync(TEntity entity);

    void Delete(TEntity entity);

    Task DeleteByIdAsync(int id);

    void Update(TEntity entity);
}
