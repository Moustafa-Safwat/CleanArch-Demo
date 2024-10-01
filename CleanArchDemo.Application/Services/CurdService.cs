using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;
using System.Runtime.Serialization;
using CleanArchDemo.Application.Mapping;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Application.Services
{
    /// <summary>
    /// Represents a service for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TDto">The type of entity.</typeparam>
    public class CurdService<TDto, TEntity>(ICrudRepository<TEntity> repository)
        : ICurdService<TDto>
        where TDto : BaseDto, new()
        where TEntity : BaseEntity, new()
    {
        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="dto">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was added successfully.</returns>
        public virtual async Task<Result<int>> AddAsync(TDto dto, CancellationToken cancellationToken)
        {
            var mappedEntity = dto.MapObjects<TDto, TEntity>();
            return await repository.AddAsync(mappedEntity, cancellationToken);
        }

        /// <summary>
        /// Deletes an entity asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was deleted successfully.</returns>
        public virtual async Task<(bool Success, string Message)> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        /// <summary>
        /// Gets an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the entity with the specified ID, or null if not found.</returns>
        public virtual async Task<TDto?> GetByIdAsync(int id,CancellationToken cancellationToken)
        {
            // it's better to sue IQurable as return and use projectto method from the automapper to implement the deffer execuation
            var entity =await  repository.GetByIdAsync(id,cancellationToken);
            return entity?.MapObjects<TEntity, TDto>();
        }

        /// <summary>
        /// Gets a paged list of entities.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A queryable collection of entities representing the specified page.</returns>
        public virtual IQueryable<TDto> GetPaged(int pageNumber, int pageSize)
        {
            return repository.GetPaged(pageNumber, pageSize)
                .Select(entity => entity.MapObjects<TEntity, TDto>());
        }

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was updated successfully.</returns>
        public virtual async Task<(bool Success, string Message)> UpdateAsync(TDto entity)
        {
            var mappedEntity = entity.MapObjects<TDto, TEntity>();
            return await repository.UpdateAsync(mappedEntity);
        }
    }
}
