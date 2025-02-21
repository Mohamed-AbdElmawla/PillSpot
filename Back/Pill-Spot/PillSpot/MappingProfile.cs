using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace PillSpot
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserForUpdateDto, User>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
