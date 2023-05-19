using Heisenberg.Domain.Common;

namespace Heisenberg.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Navigation property
        public ICollection<ToDoList>? ToDoLists { get; set; }
    }

}
