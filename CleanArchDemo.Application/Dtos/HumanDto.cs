using CleanArchDemo.Core.Entities;

namespace CleanArchDemo.Application.Dtos
{
    public record HumanDto : BaseDto
    {
        public string FirstName { get; set; } = string.Empty; // First name
        public string LastName { get; set; } = string.Empty; // Last name
        public string Email { get; set; } = string.Empty; // Email address
        public string PhoneNumber { get; set; } = string.Empty; // Phone number
        public DateTime DateOfBirth { get; set; } // Date of birth 
    }
}
