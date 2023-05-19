using AutoMapper;
using Heisenberg.Application.Contracts.Persistence;
using Heisenberg.Domain.Entities;
using MediatR;


namespace Heisenberg.Application.Features.Users.Queries.GetUsersList
{

    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserListVm>>
    {
        private readonly IAsyncRepository<User> _usersRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _usersRepository = userRepository;
        }

        async Task<List<UserListVm>> IRequestHandler<GetUsersListQuery, List<UserListVm>>.Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _usersRepository.ListAllAsync()).OrderBy(x => x.Name);
                 return _mapper.Map<List<UserListVm>>(allUsers);
        }
    }
}
