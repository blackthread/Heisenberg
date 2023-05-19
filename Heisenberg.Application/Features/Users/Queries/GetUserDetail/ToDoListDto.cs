using Heisenberg.Domain.Entities;

namespace Heisenberg.Application.Features.Users.Queries.GetUserDetail
{
    public class ToDoListDto
    {
        public int ID { get; set; }
        public string? Title { get; set; }

        // Foreign Key
        public int UserID { get; set; }

        public ICollection<ToDoItemDto>? ToDoItems { get; set; }
    }
}
