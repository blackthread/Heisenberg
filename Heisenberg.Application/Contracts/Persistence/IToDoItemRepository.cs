using ToDoItem = Heisenberg.Domain.Entities.ToDoItem;

namespace Heisenberg.Application.Contracts.Persistence
{
    public interface IToDoItemRepository : IAsyncRepository<ToDoItem>
    {
    }
}
