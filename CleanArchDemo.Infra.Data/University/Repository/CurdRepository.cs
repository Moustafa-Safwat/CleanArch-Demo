using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;
using CleanArchDemo.Core.Shared;
using CleanArchDemo.Infra.Data.University.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CleanArchDemo.Infra.Data.University.Repository
{
    /// <summary>
    /// Represents a generic repository for CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class CurdRepository<T>(UniversityDbContext context) : ICrudRepository<T> where T : BaseEntity
    {
        protected readonly UniversityDbContext context = context;

        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was added successfully.</returns>
        public async Task<int> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await context.Set<T>().AddAsync(entity, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0 ?
                entity.Id : -1;
        }

        /// <summary>
        /// Deletes an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was deleted successfully.</returns>
        public async Task<Result<(bool Success, string Message)>> DeleteAsync(int id)
        {
            try
            {
                var entity = await context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return Result<(bool, string)>.Failure(new(
                        "Course.DeleteFailed",
                        "The record you are trying to delete does not exist."));
                }
                context.Set<T>().Remove(entity);
                return await context.SaveChangesAsync() > 0 ?
                  Result<(bool, string)>.Success((true, "Deleted Successfully")) :
                  Result<(bool, string)>.Failure(new(
                        "Course.DeleteFailed",
                        "Failed to Delete, No changes were made."));
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result<(bool, string)>.Failure(new(
                        "Course.DeleteFailed",
                        "The record has been modified by another process. Please reload the data and try again."));
            }
        }

        /// <summary>
        /// Gets an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A queryable collection of entities representing the specified ID.</returns>
        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Set<T>().FindAsync([id], cancellationToken);
        }

        /// <summary>
        /// Gets a paged list of entities.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A queryable collection of entities representing the specified page.</returns>
        public IQueryable<T> GetPaged(int pageNumber, int pageSize)
        {
            return context.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a tuple with a boolean value indicating whether the entity was updated successfully and a message.
        /// The message indicates the result of the update operation:
        /// - "Updated Successfully" if the update was successful.
        /// - "Failed to Update, No changes were made." if no changes were made.
        /// - "The record you are trying to update does not exist." if the entity does not exist.
        /// - "The record has been modified by another process. Please reload the data and try again." if a concurrency conflict occurred.
        /// </returns>
        public async Task<(bool Success, string Message)> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            try
            {
                return await context.SaveChangesAsync() > 0 ?
                    (true, "Updated Successfully") :
                    (false, "Failed to Update, No changes were made.");
            }
            catch (DbUpdateConcurrencyException)
            {
                bool entityExists = context.Set<T>().Any(e => e.Id == entity.Id);
                if (!entityExists)
                {
                    return (false, "The record you are trying to update does not exist.");
                }
                return (false, "The record has been modified by another process. Please reload the data and try again.");
            }

        }
    }
}
