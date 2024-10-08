﻿namespace CleanArchDemo.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // e.g., "CS"
        public string Description { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = []; // List of courses offered by the department
        public ICollection<Instructor> Instructors { get; set; } = []; // List of instructors in the department
    }
}
