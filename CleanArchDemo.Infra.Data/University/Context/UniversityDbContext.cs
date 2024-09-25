using CleanArchDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchDemo.Infra.Data.University.Context
{
    public class UniversityDbContext(DbContextOptions<UniversityDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Department> Departments => Set<Department>();

        // Replace this code by [Primary Constructor]
        //public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        //{

        //}
    }
}
