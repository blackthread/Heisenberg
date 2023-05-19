using AutoMapper;
using Heisenberg.Application.Contracts.Persistence;
using Heisenberg.Application.Features.Users.Queries.GetUserDetail;
using Heisenberg.Domain.Entities;
using MediatR;


namespace Heisenberg.Application.Features.Users.Queries.GetUsersList
{

    public class GetUsersDetailQueryHandler : IRequestHandler<GetUsersDetailQuery, UserDetailVm>
    {
        private readonly IAsyncRepository<User> _usersRepository;
        private readonly IAsyncRepository<ToDoList> _toDoListRepository;
        private readonly IAsyncRepository<ToDoItem> _toDoItemRepository;
        private readonly IMapper _mapper;

        public GetUsersDetailQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository, IAsyncRepository<ToDoList> toDoListRepository, IAsyncRepository<ToDoItem> toDoItemRepository)
        {
            _mapper = mapper;
            _usersRepository = userRepository;
            _toDoListRepository = toDoListRepository;
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<UserDetailVm> Handle(GetUsersDetailQuery request, CancellationToken cancellationToken)
        {
            var userDetail = await _usersRepository.GetByIdAsync(request.Id);
            var userDetailDto = _mapper.Map<UserDetailVm>(userDetail);

            var toDoLists = await _toDoListRepository.ListAllAsync();
            var filteredToDoLists = toDoLists.Where(x => x.ID == request.Id);

            if (filteredToDoLists.Any())
            {
                userDetailDto.ToDoLists = _mapper.Map<List<ToDoListDto>>(filteredToDoLists);

                foreach (var toDoListDto in userDetailDto.ToDoLists)
                {
                    var toDoItems = await _toDoItemRepository.ListAllAsync();
                    var filteredToDoItems = toDoItems.Where(x => x.ID == toDoListDto.ID);

                    if (filteredToDoItems.Any())
                    {
                        toDoListDto.ToDoItems = _mapper.Map<List<ToDoItemDto>>(filteredToDoItems);
                    }
                }
            }

            return userDetailDto;
        }

    }
}
