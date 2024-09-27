namespace CleanArchDemo.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // e.g., "CS101"
        public int Credits { get; set; } // e.g., 3
        public string Description { get; set; } = string.Empty;
        public int DepartmentId { get; set; } // Foreign key to Department
        public Department Department { get; set; } = null!; // Navigation property
        public ICollection<Instructor> Instructors { get; set; } = []; // List of instructors
        public ICollection<Student> Students { get; set; } = [];
    }
}
