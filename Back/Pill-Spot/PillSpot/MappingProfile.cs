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


        }
    }
}
