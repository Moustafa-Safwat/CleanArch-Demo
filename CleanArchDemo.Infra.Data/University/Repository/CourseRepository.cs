using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;
using CleanArchDemo.Infra.Data.University.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDemo.Infra.Data.University.Repository
{
    /// <summary>
    /// Repository for managing <see cref="Course"/> entities.
    /// </summary>
    /// <param name="context">The database context for the university.</param>
    public class CourseRepository(UniversityDbContext context) :
        CurdRepository<Course>(context),
        ICourseRepository
    {
        /// <summary>
        /// Gets the department associated with a specific course ID asynchronously.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="Department"/> associated with the course, or null if not found.</returns>
        public async Task<Department?> GetDepartmentFromCourseIdAsyncAsync(int courseId)
        {
            return await Task.FromResult(context.Courses.
                Include(course => course.Department).
                FirstOrDefault(course => course.Id == courseId)?.
                Department);
        }

        /// <summary>
        /// Gets the instructors associated with a specific course ID.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A queryable collection of <see cref="Instructor"/> entities associated with the course.</returns>
        public IQueryable<Instructor> GetInstructorsFromCourseId(int courseId)
        {
            return context.Courses.
                Include(course => course.Instructors)
                .Where(course => course.Id == courseId)
                .SelectMany(course => course.Instructors);
        }

        /// <summary>
        /// Gets the students associated with a specific course ID.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A queryable collection of <see cref="Student"/> entities associated with the course.</returns>
        public IQueryable<Student> GetStudentsFromCourseId(int courseId)
        {
            return context.Courses
                .Include(course => course.Students)
                .Where(course => course.Id == courseId)
                .SelectMany(course => course.Students);
        }
    }
}
