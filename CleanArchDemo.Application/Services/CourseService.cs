using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Mapping;
using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;
using CleanArchDemo.Core.Shared;

namespace CleanArchDemo.Application.Services
{
    /// <summary>
    /// Service for managing courses.
    /// </summary>
    /// <param name="courseRepository">The repository for course-related data operations.</param>
    public class CourseService(ICourseRepository courseRepository, ICurdService<DepartmentDto> departmentService)
        : CurdService<CourseDto, Course>(courseRepository),
        ICourseService
    {
        public override async Task<Result<int>> AddAsync(CourseDto dto,CancellationToken cancellationToken)
        {
            var result = await departmentService.GetByIdAsync(dto.DepartmentId, cancellationToken);
            if (result == null)// check if the department is exisst or not
            {
                return Result<int>.Failure(new(
                        "Department.NotFound",
                        $"The Department with Id [{dto.Id}] which you try to assing the course to was not found"));
            }
            return await base.AddAsync(dto,cancellationToken);
        }

        /// <summary>
        /// Gets the students associated with a specific course ID.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A queryable collection of <see cref="HumanDto"/> representing the students in the course.</returns>
        public IQueryable<HumanDto> GetStudentFromCourseId(int courseId)
        {
            return courseRepository.GetStudentsFromCourseId(courseId)
                .Select(student => student.MapObjects<Student, HumanDto>());
        }

        /// <summary>
        /// Gets the instructors associated with a specific course ID.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A queryable collection of <see cref="HumanDto"/> representing the instructors in the course.</returns>
        public IQueryable<HumanDto> GetInstructorFromCourseId(int courseId)
        {
            return courseRepository.GetInstructorsFromCourseId(courseId)
                .Select(instructor => instructor.MapObjects<Instructor, HumanDto>());
        }

        /// <summary>
        /// Gets the department associated with a specific course ID asynchronously.
        /// </summary>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="DepartmentDto"/> associated with the course, or null if not found.</returns>
        public async Task<DepartmentDto?> GetDepartmentFromCourseIdAsync(int courseId)
        {
            var result = await courseRepository.GetDepartmentFromCourseIdAsyncAsync(courseId);
            return result?.MapObjects<Department, DepartmentDto>();
        }
    }
}
