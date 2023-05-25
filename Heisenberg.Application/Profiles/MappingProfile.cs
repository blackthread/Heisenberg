using AutoMapper;
using Heisenberg.Application.Features.ToDoItems.GetUsersList;
using Heisenberg.Domain.Entities;

namespace Heisenberg.Application.Profiles
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemVm>().ReverseMap();
        }
    }
}
