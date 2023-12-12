using System;

namespace JWTAuth.DTOs
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedToUserId { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
