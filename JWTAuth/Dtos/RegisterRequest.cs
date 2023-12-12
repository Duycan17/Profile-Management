namespace JWTAuth.Dtos
{
    public class RegisterUser
    {
        public string Username { get; set; } = "";

        public string PasswordHash { get; set; } = "";

        public string Email { get; set; } = "";

        // Additional user-related properties
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "";
    }
}