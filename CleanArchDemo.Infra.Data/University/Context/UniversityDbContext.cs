using CleanArchDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchDemo.Infra.Data.University.Context
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Department> Departments => Set<Department>();

        public UniversityDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
