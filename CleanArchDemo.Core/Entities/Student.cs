namespace CleanArchDemo.Core.Entities
{
    public class Student : HumanEntity
    {
        public int DepartmentId { get; set; } // Foreign key to Department
        public Department Department { get; set; } // Navigation property to Department
        public ICollection<Course> EnrolledCourses { get; } = new HashSet<Course>(); // List of courses the student is enrolled in
    }
}
