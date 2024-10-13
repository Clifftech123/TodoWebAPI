using System.ComponentModel.DataAnnotations;

namespace TodoWebAPI.Contract
{
    public class CreateTodoRequest
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        [StringLength(50)]
        public string Discription { get; set; }
        [Range(1, 5)]
        public int priority { get; set; }
    }
}
