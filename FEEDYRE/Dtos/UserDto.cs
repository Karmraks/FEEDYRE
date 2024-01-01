namespace FEEDYRE.Web.Dtos
{
    public class UserDto
    {
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
    }
}
