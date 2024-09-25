using CleanArchDemo.Core.Entities;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICurdService<T> 
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetPaged(int pageNumber, int pageSize);
        Task<bool> DeleteAsync(int id);
    }
}
