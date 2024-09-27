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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for testing
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", Code = "CS", Description = "Computer Science Department" },
                new Department { Id = 2, Name = "Mathematics", Code = "MATH", Description = "Mathematics Department" },
                new Department { Id = 3, Name = "Physics", Code = "PHYS", Description = "Physics Department" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Introduction to Programming", Code = "CS101", Credits = 3, Description = "Basic programming course", DepartmentId = 1 },
                new Course { Id = 2, Name = "Data Structures", Code = "CS102", Credits = 3, Description = "Data structures course", DepartmentId = 1 },
                new Course { Id = 3, Name = "Calculus I", Code = "MATH101", Credits = 4, Description = "Introduction to Calculus", DepartmentId = 2 },
                new Course { Id = 4, Name = "Linear Algebra", Code = "MATH102", Credits = 3, Description = "Linear Algebra course", DepartmentId = 2 },
                new Course { Id = 5, Name = "Classical Mechanics", Code = "PHYS101", Credits = 4, Description = "Introduction to Classical Mechanics", DepartmentId = 3 },
                new Course { Id = 6, Name = "Quantum Physics", Code = "PHYS102", Credits = 4, Description = "Introduction to Quantum Physics", DepartmentId = 3 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", DateOfBirth = new DateTime(2000, 1, 1), DepartmentId = 1 },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "0987654321", DateOfBirth = new DateTime(2001, 2, 2), DepartmentId = 2 },
                new Student { Id = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", PhoneNumber = "2223334444", DateOfBirth = new DateTime(1999, 3, 3), DepartmentId = 3 },
                new Student { Id = 4, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", PhoneNumber = "5556667777", DateOfBirth = new DateTime(2002, 4, 4), DepartmentId = 1 },
                new Student { Id = 5, FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com", PhoneNumber = "8889990000", DateOfBirth = new DateTime(2000, 5, 5), DepartmentId = 2 }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", PhoneNumber = "1112223333", DateOfBirth = new DateTime(1980, 3, 3), DepartmentId = 1 },
                new Instructor { Id = 2, FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com", PhoneNumber = "4445556666", DateOfBirth = new DateTime(1975, 4, 4), DepartmentId = 2 },
                new Instructor { Id = 3, FirstName = "Charlie", LastName = "Miller", Email = "charlie.miller@example.com", PhoneNumber = "7778889999", DateOfBirth = new DateTime(1985, 5, 5), DepartmentId = 3 },
                new Instructor { Id = 4, FirstName = "Diana", LastName = "Garcia", Email = "diana.garcia@example.com", PhoneNumber = "0001112222", DateOfBirth = new DateTime(1990, 6, 6), DepartmentId = 1 },
                new Instructor { Id = 5, FirstName = "Edward", LastName = "Martinez", Email = "edward.martinez@example.com", PhoneNumber = "3334445555", DateOfBirth = new DateTime(1982, 7, 7), DepartmentId = 2 }
            );

            // Configure many-to-many relationships
            modelBuilder.Entity<Student>()
                .HasMany(s => s.EnrolledCourses)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseStudent",
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId");
                        j.HasData(
                            new { StudentId = 1, CourseId = 1 },
                            new { StudentId = 1, CourseId = 2 },
                            new { StudentId = 2, CourseId = 3 },
                            new { StudentId = 2, CourseId = 4 },
                            new { StudentId = 3, CourseId = 5 },
                            new { StudentId = 3, CourseId = 6 },
                            new { StudentId = 4, CourseId = 1 },
                            new { StudentId = 5, CourseId = 3 }
                        );
                    });

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Courses)
                .WithMany(c => c.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseInstructor",
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.HasOne<Instructor>().WithMany().HasForeignKey("InstructorId"),
                    j =>
                    {
                        j.HasKey("InstructorId", "CourseId");
                        j.HasData(
                            new { InstructorId = 1, CourseId = 1 },
                            new { InstructorId = 1, CourseId = 2 },
                            new { InstructorId = 2, CourseId = 3 },
                            new { InstructorId = 2, CourseId = 4 },
                            new { InstructorId = 3, CourseId = 5 },
                            new { InstructorId = 3, CourseId = 6 },
                            new { InstructorId = 4, CourseId = 1 },
                            new { InstructorId = 5, CourseId = 3 }
                        );
                    });
        }
    }
}
