using MediatR;

namespace Heisenberg.Application.Features.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<List<UserListVm>>
    {

    }
}
