using Domain.Core.Entity;

namespace Domain.Core.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task SaveAsync(T entity);
        void Edit(T entity);
        void Remove(T entity);
        Task SaveChangesAsync();
        Task DisposeAsync();
    }
}
