namespace CleanArchDemo.Core.Entities
{
    public class Instructor : HumanEntity
    {
        public int DepartmentId { get; set; } // Foreign key to Department
        public Department Department { get; set; } // Navigation property
        public ICollection<Course> Courses { get; set; } = new List<Course>(); // List of courses taught by the instructor
    }
}

