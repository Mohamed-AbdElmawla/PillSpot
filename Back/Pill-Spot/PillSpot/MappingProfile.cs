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
            CreateMap<UserForUpdateDto, User>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));

            CreateMap<Permission, CreatePermissionDto>();
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDto>().ReverseMap();


            CreateMap<AdminPermission, AssignAdminPermissionDto>().ReverseMap();
            CreateMap<AdminPermission, AdminPermissionDto>().ReverseMap();

            CreateMap<PharmacyEmployeePermission, AssignEmployeePermissionDto>().ReverseMap();
            CreateMap<PharmacyEmployeePermission, EmployeePermissionDto>().ReverseMap();

            CreateMap<PharmacyRequestCreateDto, PharmacyRequest>();
            CreateMap<PharmacyRequest, PharmacyRequestDto>()
            .ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Location));

            

            CreateMap<Government, GovernmentDto>();
            CreateMap<LocationForCreationDto, Location>();
            CreateMap<Location, LocationDto>().ForMember(dest => dest.CityDto, opt => opt.MapFrom(src => src.City));
            CreateMap<City, CityDto>().ForMember(dest => dest.GovernmentReferenceDto, opt => opt.MapFrom(src => src.Government));
            CreateMap<CityForUpdateDto, City>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));
            CreateMap<CityForCreationDto, City>();
            CreateMap<Government, GovernmentDto>();
            CreateMap<Government, GovernmentReferenceDto>();
            CreateMap<GovernmentForCreationDto, Government>();
            CreateMap<GovernmentForUpdateDto, Government>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));
            CreateMap<PharmacyRequest, Pharmacy>().ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.UserId));


            CreateMap<Pharmacy, PharmacyDto>().ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Location));
            CreateMap<PharmacyForUpdateDto, Pharmacy>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));
            CreateMap<PharmacyForCreationDto, Pharmacy>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<SubCategory, SubCategoryDto>().ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));
            CreateMap<SubCategoryForCreateDto, SubCategory>();
            CreateMap<SubCategoryForUpdateDto, SubCategory>();

            CreateMap<Product, ProductDto>().ForMember(dest => dest.subCategoryDto, opt => opt.MapFrom(src => src.SubCategory));
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));

            CreateMap<Medicine, MedicineDto>().ForMember(dest => dest.subCategoryDto, opt => opt.MapFrom(src => src.SubCategory));
            CreateMap<MedicineForCreationDto, Medicine>();
            CreateMap<MedicineForUpdateDto, Medicine>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));

            CreateMap<Cosmetic, CosmeticDto>().ForMember(dest => dest.subCategoryDto, opt => opt.MapFrom(src => src.SubCategory));
            CreateMap<CosmeticForCreationDto, Cosmetic>();
            CreateMap<CosmeticForUpdateDto, Cosmetic>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));
        }
    }
}
