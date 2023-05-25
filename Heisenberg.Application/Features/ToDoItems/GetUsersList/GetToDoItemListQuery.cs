using MediatR;

namespace Heisenberg.Application.Features.ToDoItems.GetUsersList
{
    public class GetToDoItemListQuery : IRequest<List<ToDoItemVm>>
    {

    }
}
