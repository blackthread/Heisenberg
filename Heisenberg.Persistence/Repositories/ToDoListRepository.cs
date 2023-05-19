using Heisenberg.Application.Contracts.Persistence;
using Heisenberg.Domain.Entities;

namespace Heisenberg.Persistence.Repositories
{
    public class ToDoListRepository : BaseRepository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(HeisenbergDbContext dbContext) : base(dbContext)
        {
        }
    }
}