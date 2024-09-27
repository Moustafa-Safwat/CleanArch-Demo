using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;
using CleanArchDemo.Infra.Data.University.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDemo.Infra.Data.University.Repository
{
    /// <summary>
    /// Represents a generic repository for CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public class CurdRepository<T>(UniversityDbContext context) : ICrudRepository<T> where T : BaseEntity,new()
    {
        protected readonly UniversityDbContext context = context;

        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was added successfully.</returns>
        public async Task<int> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            bool isExecuted = await context.SaveChangesAsync() > 0;
            if (isExecuted)
            {
                return entity.Id;
            }
            return -1;
        }

        /// <summary>
        /// Deletes an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was deleted successfully.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = new T { Id = id };
            context.Entry(entity).State = EntityState.Deleted;
            return await context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Gets an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A queryable collection of entities representing the specified ID.</returns>
        public IQueryable<T> GetByIdAsync(int id)
        {
            return context.Set<T>()
                .Where(entity => entity.Id == id)
                .AsQueryable();
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
        /// <returns>A task representing the asynchronous operation. The task result contains a boolean value indicating whether the entity was updated successfully.</returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
