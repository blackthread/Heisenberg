namespace Heisenberg.Application.Features.Users.Queries.GetUserDetail
{
    public class ToDoItemDto
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int ToDoListID { get; set; }
    }
}
