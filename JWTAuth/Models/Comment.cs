namespace JWTAuth.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        // Thêm khóa ngoại để liên kết với Profile
        public int ProfileId { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string CommentText { get; set; }

        public DateTime Timestamp { get; set; }
    }

}