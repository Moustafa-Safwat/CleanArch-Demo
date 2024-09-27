using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Core.Entities;

namespace CleanArchDemo.Application.Interfaces
{
    public interface ICourseService : ICurdService<CourseDto>
    {
        IQueryable<HumanDto> GetStudentFromCourseId(int courseId);
        IQueryable<HumanDto> GetInstructorFromCourseId(int courseId);
        Task<DepartmentDto?> GetDepartmentFromCourseIdAsync(int courseId);
    }
}
