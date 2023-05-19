using AutoMapper;
using Heisenberg.Application.Features.Users.Queries.GetUserDetail;
using Heisenberg.Application.Features.Users.Queries.GetUsersList;
using Heisenberg.Domain.Entities;

namespace Heisenberg.Application.Profiles
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserListVm>().ReverseMap();
            CreateMap<User, UserDetailVm>().ReverseMap();
           CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
           CreateMap<ToDoList, ToDoListDto>().ReverseMap();

           CreateMap<List<ToDoItemDto>, List<ToDoItem>>().ConvertUsing(source => source.Cast<ToDoItem>().ToList());
        }
    }
}
