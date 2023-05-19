using Heisenberg.Domain.Common;

namespace Heisenberg.Domain.Entities
{
    public class ToDoList : AuditableEntity
    {
        public int ID { get; set; }
        public string? Title { get; set; }

        // Foreign Key
        public int UserID { get; set; }

        // Navigation properties
        public User? User { get; set; }
        public ICollection<TodoItem>? Tasks { get; set; }
    }

}
