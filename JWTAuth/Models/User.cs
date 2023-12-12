using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuth.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        // Additional user-related properties

        public string Role { get; set; }
        public bool IsActive { get; set; } = false;
        public string Token { get; set; } = "";
        public User(string userName, string password, string email, string role)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Role = role;
        }
        public virtual ICollection<Task> AssignedTasks { get; set; } = new List<Task>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
    public class LoginUser
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class RegisterUser
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";

        public string Role { get; set; } = "Everyone";
    }
}