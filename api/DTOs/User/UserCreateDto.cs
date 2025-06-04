namespace Transporteo.DTOs.User
{
    public class UserCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // plain password, hash later
        public string Role { get; set; } = "Client";
    }

}
