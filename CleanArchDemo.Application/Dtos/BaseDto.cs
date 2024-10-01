namespace CleanArchDemo.Application.Dtos
{
    public record BaseDto
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; } = [];
    }
}
