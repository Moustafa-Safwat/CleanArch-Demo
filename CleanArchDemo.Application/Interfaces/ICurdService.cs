using CleanArchDemo.Core.Entities;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICurdService<T> 
    {
        Task<int> AddAsync(T entity);
        Task<(bool Success, string Message)> UpdateAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetPaged(int pageNumber, int pageSize);
        Task<(bool Success, string Message)> DeleteAsync(int id);
    }
}
