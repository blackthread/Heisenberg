using Heisenberg.Application.Features.Users.Queries.GetUserDetail;
using Heisenberg.Domain.Entities;

namespace Heisenberg.Application.Features.Users.Queries.GetUsersList
{
    public class UserDetailVm
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public List<ToDoListDto>? ToDoLists { get; set; }
    }
}
