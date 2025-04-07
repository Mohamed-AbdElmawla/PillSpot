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
            CreateMap<Permission, PermissionDto>();
            CreateMap<UpdatePermissionDto, Permission>();

            CreateMap<AssignAdminPermissionDto, AdminPermission>();
            CreateMap<AdminPermission, AdminPermissionDto>();

            CreateMap<AssignEmployeePermissionDto, PharmacyEmployeePermission>();
            CreateMap<PharmacyEmployeePermission, EmployeePermissionDto>().ReverseMap();

            CreateMap<Government, GovernmentDto>();

            CreateMap<LocationForCreationDto, Location>();
            CreateMap<Location, LocationDto>()
                .ForMember(dest => dest.CityDto, opt => opt.MapFrom(src => src.City));

            CreateMap<City, CityDto>()
                .ForMember(dest => dest.GovernmentReferenceDto, opt => opt.MapFrom(src => src.Government));
            CreateMap<CityForUpdateDto, City>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));
            CreateMap<CityForCreationDto, City>();

            CreateMap<Government, GovernmentDto>();
            CreateMap<Government, GovernmentReferenceDto>();
            CreateMap<GovernmentForCreationDto, Government>();
            CreateMap<GovernmentForUpdateDto, Government>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));



            CreateMap<PharmacyRequestCreateDto, PharmacyRequest>();
            CreateMap<PharmacyRequest, PharmacyRequestDto>()
              .ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Location));

            CreateMap<PharmacyRequest, Pharmacy>();

            CreateMap<Pharmacy, PharmacyDto>().ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Location));
            CreateMap<PharmacyForUpdateDto, Pharmacy>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && (!(srcMember is Guid) || (Guid)srcMember != Guid.Empty)));
            CreateMap<PharmacyForCreationDto, Pharmacy>();


            CreateMap<PharmacyEmployee, PharmacyDto>()
             .ForMember(dest => dest.PharmacyId, opt => opt.MapFrom(src => src.Pharmacy.PharmacyId))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Pharmacy.Name))
             .ForMember(dest => dest.LogoURL, opt => opt.MapFrom(src => src.Pharmacy.LogoURL))
             .ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Pharmacy.Location))
             .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.Pharmacy.ContactNumber))
             .ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.Pharmacy.OpeningTime))
             .ForMember(dest => dest.ClosingTime, opt => opt.MapFrom(src => src.Pharmacy.ClosingTime))
             .ForMember(dest => dest.IsOpen24, opt => opt.MapFrom(src => src.Pharmacy.IsOpen24))
             .ForMember(dest => dest.DaysOpen, opt => opt.MapFrom(src => src.Pharmacy.DaysOpen))
             .ForMember(dest => dest.logo, opt => opt.Ignore());

            CreateMap<PharmacyEmployeeRequestCreateDto, PharmacyEmployeeRequest>()
               .ForMember(dest => dest.RequesterId, opt => opt.Ignore())
               .ForMember(dest => dest.UserId, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => RequestStatus.Pending));

            CreateMap<PharmacyEmployeeRequest, PharmacyEmployee>()
               .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "PharmacyEmployee"));


            CreateMap<PharmacyEmployee, PharmacyEmployeeDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.PharmacyEmployeePermissions.Select(p => p.Permission.Name)))
                .ForMember(dest => dest.PharmacyName, opt => opt.MapFrom(src => src.Pharmacy.Name));  // Add this line


            CreateMap<PharmacyProduct, PharmacyProductDto>()
                .ForMember(dest => dest.ProductDto, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.PharmacyDto, opt => opt.MapFrom(src => src.Pharmacy));

            CreateMap<PharmacyProductForCreationDto, PharmacyProduct>();


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

            CreateMap<Order, OrderDto>().ForMember(dest => dest.LocationDto, opt => opt.MapFrom(src => src.Location));
            CreateMap<OrderForCreationDto, Order>();





            //  CreateMap<PharmacyEmployee, EmployeeDetailsDto>()
            //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
            //.ForMember(dest => dest.PharmacyNames, opt => opt.MapFrom(src => src.Pharmacy.Name))
            //.ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.PharmacyEmployeePermissions.Select(p => p.Permission.Name)));



            //CreateMap<PharmacyEmployee, PharmacyEmployeeProfileDto>().ForMember(dest => dest.PharmacyDto, opt => opt.MapFrom(src => src.Pharmacy)); ;
        }
    }
}
