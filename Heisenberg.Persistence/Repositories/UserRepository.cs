using Heisenberg.Application.Contracts.Persistence;
using Heisenberg.Domain.Entities;

namespace Heisenberg.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HeisenbergDbContext dbContext) : base(dbContext)
        {
        }
    }
}