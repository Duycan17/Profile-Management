global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace JWTAuth.Models

{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int AssignedToUserId { get; set; }

        [ForeignKey("AssignedToUserId")]
        public virtual User AssignedTo { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        // Navigation property
    }

}