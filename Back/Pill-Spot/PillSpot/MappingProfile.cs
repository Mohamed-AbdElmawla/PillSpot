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

            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<Permission, CreatePermissionDto>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDto>().ReverseMap();
            
            
            CreateMap<CreateAdminPermissionDto, AdminPermission>().ReverseMap();
            CreateMap<AdminPermission, AdminPermissionDto>().ReverseMap();
            CreateMap<AdminPermission, AssignAdminPermissionDto>().ReverseMap();
            CreateMap<AdminPermission, UpdateAdminPermissionsDto>().ReverseMap();

            CreateMap<CreateEmployeePermissionDto, AdminPermission>().ReverseMap();
            CreateMap<PharmacyEmployeePermission, EmployeePermissionDto>().ReverseMap();
            CreateMap<PharmacyEmployeePermission, AssignEmployeePermissionDto>().ReverseMap();

            CreateMap<PharmacyRequestCreateDto, PharmacyRequest>();
            CreateMap<PharmacyRequest, PharmacyRequestDto>()
            .ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Location));

            

            CreateMap<Government, GovernmentDto>();
            CreateMap<LocationForCreationDto, Location>();
            CreateMap<Location, LocationDto>().ForMember(dest => dest.CityDto, opt => opt.MapFrom(src => src.City));
            CreateMap<City, CityDto>().ForMember(dest => dest.GovernmentReferenceDto, opt => opt.MapFrom(src => src.Government));
            CreateMap<CityForUpdateDto, City>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<CityForCreationDto, City>();
            CreateMap<Government, GovernmentDto>();
            CreateMap<Government, GovernmentReferenceDto>();
            CreateMap<GovernmentForCreationDto, Government>();
            CreateMap<GovernmentForUpdateDto, Government>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<PharmacyRequest, Pharmacy>().ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.UserId));


            CreateMap<Pharmacy, PharmacyDto>().ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Location));
            CreateMap<PharmacyForUpdateDto, Pharmacy>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<PharmacyForCreationDto, Pharmacy>();
        }
    }
}
