using Heisenberg.Domain.Entities;

namespace Heisenberg.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
