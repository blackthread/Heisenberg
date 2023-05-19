using Heisenberg.Domain.Common;

namespace Heisenberg.Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }

        public int ToDoListID { get; set; }

        public ToDoList? ToDoList { get; set; }
    }

}
