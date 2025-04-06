using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        public bool IsComplete { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}