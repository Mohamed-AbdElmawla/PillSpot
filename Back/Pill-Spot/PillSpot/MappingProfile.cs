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
            CreateMap<PharmacyRequestCreateDto, PharmacyRequest>();
            CreateMap<PharmacyRequest, PharmacyRequestDto>();
            CreateMap<LocationForCreationDto, Location>();
            CreateMap<Location, LocationDto>();
            CreateMap<City, CityDto>();
            CreateMap<CityForUpdateDto, City>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<CityForCreationDto, City>();
            CreateMap<Government, GovernmentDto>();
            CreateMap<GovernmentForCreationDto, Government>();
            CreateMap<GovernmentForUpdateDto, Government>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<PharmacyRequest, Pharmacy>();

        }
    }
}
