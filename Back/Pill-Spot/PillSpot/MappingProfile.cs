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

            CreateMap<Permission, CreatePermissionDto>().ReverseMap();
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDto>().ReverseMap();


            CreateMap<AdminPermission, AssignAdminPermissionDto>().ReverseMap();
            CreateMap<AdminPermission, AdminPermissionDto>().ReverseMap();

            CreateMap<PharmacyEmployeePermission, AssignEmployeePermissionDto>().ReverseMap();
            CreateMap<PharmacyEmployeePermission, EmployeePermissionDto>().ReverseMap();
            
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
