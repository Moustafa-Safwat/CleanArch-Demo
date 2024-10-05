namespace CleanArchDemo.Application.Dtos
{
    public sealed record CourseDto : BaseDto
    {
        public string Names { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // e.g., "CS101"
        public int Credits { get; set; } // e.g., 3
        public string Description { get; set; } = string.Empty;
        public int DepartmentId { get; set; } // Foreign key to Department

    }
}
