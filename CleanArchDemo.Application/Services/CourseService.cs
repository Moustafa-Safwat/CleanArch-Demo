using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Core.Entities;
using CleanArchDemo.Core.Interfaces;

namespace CleanArchDemo.Application.Services
{
    public class CourseService(
        ICrudRepository<Course> courseRepository,
        ICrudRepository<Student> studentRepository)
        : CurdService<CourseDto, Course>(courseRepository),
        ICourseService
    {
        public IQueryable<HumanDto> GetStudentFromCourseId(int courseId)
        {
            return studentRepository.GetAll()
                .Where(s => s.EnrolledCourses.Any(c => c.Id == courseId))
                .Select(s => new HumanDto
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    DateOfBirth = s.DateOfBirth
                });
        }
    }
}
