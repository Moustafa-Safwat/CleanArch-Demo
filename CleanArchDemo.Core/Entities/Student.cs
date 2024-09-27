namespace CleanArchDemo.Core.Entities
{
    public class Student : HumanEntity
    {
        public int DepartmentId { get; set; } // Foreign key to Department
        public Department Department { get; set; } = null!;// Navigation property to Department
        public ICollection<Course> EnrolledCourses { get; } = []; // List of courses the student is enrolled in
    }
}
