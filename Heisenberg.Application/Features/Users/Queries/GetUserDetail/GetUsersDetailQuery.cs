using MediatR;

namespace Heisenberg.Application.Features.Users.Queries.GetUsersList
{
    public class GetUsersDetailQuery : IRequest<UserDetailVm>
    {
        public int Id { get; set; }
    }
}
