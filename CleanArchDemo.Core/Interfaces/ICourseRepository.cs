using CleanArchDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchDemo.Core.Interfaces
{
    public interface ICourseRepository : ICrudRepository<Course>
    {
        IQueryable<Student> GetStudentsFromCourseId(int courseId);
        IQueryable<Instructor> GetInstructorsFromCourseId(int courseId);
        Task<Department?> GetDepartmentFromCourseIdAsyncAsync(int courseId);
    }
}
