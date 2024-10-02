using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICurdService<T>
    {
        Task<Result<int>> AddAsync(T entity,CancellationToken cancellationToken);
        Task<(bool Success, string Message)> UpdateAsync(T entity);
        Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken);
        IQueryable<T> GetPaged(int pageNumber, int pageSize);
        Task<Result<(bool Success, string Message)>> DeleteAsync(int id);
    }
}
