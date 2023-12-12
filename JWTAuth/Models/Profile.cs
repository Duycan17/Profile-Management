
namespace JWTAuth.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        public string ProfileTitle { get; set; }

        public byte[] ProfileFile { get; set; }

        // Navigation property for the one-to-many relationship with Comment
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}