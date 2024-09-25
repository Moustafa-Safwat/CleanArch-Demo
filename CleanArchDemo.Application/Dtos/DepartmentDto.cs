namespace CleanArchDemo.Application.Dtos
{
    public class DepartmentDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // e.g., "CS"
        public string Description { get; set; } = string.Empty;
    }
}
