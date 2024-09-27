namespace CleanArchDemo.Core.Entities
{
    public class Instructor : HumanEntity
    {
        public int DepartmentId { get; set; } // Foreign key to Department
        public Department Department { get; set; } = null!; // Navigation property
        public ICollection<Course> Courses { get; set; } = []; // List of courses taught by the instructor
    }
}

