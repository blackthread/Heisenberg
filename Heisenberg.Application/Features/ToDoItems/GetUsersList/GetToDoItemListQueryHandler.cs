using AutoMapper;
using Heisenberg.Application.Contracts.Persistence;
using Heisenberg.Domain.Entities;
using MediatR;


namespace Heisenberg.Application.Features.ToDoItems.GetUsersList
{

    public class GetToDoItemListQueryHandler : IRequestHandler<GetToDoItemListQuery, List<ToDoItemVm>>
    {
        private readonly IAsyncRepository<ToDoItem> _toDoItemRepository;
        private readonly IMapper _mapper;

        public GetToDoItemListQueryHandler(IMapper mapper, IAsyncRepository<ToDoItem> toDoItemRepository)
        {
            _mapper = mapper;
            _toDoItemRepository = toDoItemRepository;
        }

        async Task<List<ToDoItemVm>> IRequestHandler<GetToDoItemListQuery, List<ToDoItemVm>>.Handle(GetToDoItemListQuery request, CancellationToken cancellationToken)
        {
            var allToDoItems = (await _toDoItemRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<ToDoItemVm>>(allToDoItems);
        }
    }
}
