using Heisenberg.Application.Contracts.Persistence;
using Heisenberg.Domain.Entities;

namespace Heisenberg.Persistence.Repositories
{
    public class ToDoItemRepository : BaseRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(HeisenbergDbContext dbContext) : base(dbContext)
        {
        }
    }
}