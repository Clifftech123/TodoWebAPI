namespace TodoWebAPI.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public int priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt
        {
            get; set;
        }
        public TodoItem()
        {
            IsComplete = false;
        }
    }
}
