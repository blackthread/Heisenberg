using AutoMapper;
using Heisenberg.Application.Features.Users.Queries.GetUsersList;
using Heisenberg.Domain.Entities;

namespace Heisenberg.Application.Profiles
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserListVm>().ReverseMap();
        }
    }
}
