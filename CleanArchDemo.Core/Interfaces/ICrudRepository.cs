using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Core.Interfaces
{
    /// <summary>
    /// Represents a generic repository interface for CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface ICrudRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was added successfully.</returns>
        Task<int> AddAsync(T entity,CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was updated successfully.</returns>
        Task<(bool Success,string Message)> UpdateAsync(T entity);

        /// <summary>
        /// Gets an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the entity with the specified ID, or null if not found.</returns>
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a paged list of entities.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A queryable collection of entities representing the specified page.</returns>
        IQueryable<T> GetPaged(int pageNumber, int pageSize);

        /// <summary>
        /// Deletes an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was deleted successfully.</returns>
        Task<Result<(bool Success, string Message)>> DeleteAsync(int id);

    }
}
