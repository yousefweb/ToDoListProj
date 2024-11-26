using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoListProj.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        [Required]
        public string Title { get; set; }
        
        public bool IsCompleted { get; set; }
    }
}
