using System.ComponentModel.DataAnnotations;

namespace TodoWebAPI.Contract
{
    public class UpdateTodoRequest
    {
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Discription { get; set; }
        public bool? IsComplete { get; set; }
        public DateTime? DueDate { get; set; }

        [Range(1, 5)]
        public int ? priority { get; set; }
    }
}
