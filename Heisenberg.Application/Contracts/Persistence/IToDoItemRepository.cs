using ToDoItem = Heisenberg.Domain.Entities.TodoItem;

namespace Heisenberg.Application.Contracts.Persistence
{
    public interface IToDoItemRepository : IAsyncRepository<ToDoItem>
    {
    }
}
