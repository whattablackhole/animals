namespace Animals.Core.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task DeleteAsync(int id);

    Task SaveChangesAsync();

    void Update(T entity);
}