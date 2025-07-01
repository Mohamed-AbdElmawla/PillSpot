using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace PillSpot
{
    //dfs
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

            CreateMap<PharmacyEmployeePermission, PharmacyEmployeePermissionDto>()
                .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name));

            CreateMap<AssignAdminPermissionDto, AdminPermission>();
            CreateMap<AdminPermission, AdminPermissionDto>();

            CreateMap<AssignEmployeePermissionDto, PharmacyEmployeePermission>();
            CreateMap<PharmacyEmployeePermission, PharmacyEmployeePermissionDto>().ReverseMap();

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

            CreateMap<PharmacyEmployeeRequestCreateDto, PharmacyEmployeeRequest>()
               .ForMember(dest => dest.RequesterId, opt => opt.Ignore())
               .ForMember(dest => dest.UserId, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => RequestStatus.Pending));

            CreateMap<PharmacyEmployeeRequest, PharmacyEmployee>()
               .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<PharmacyEmployeeRequest, PharmacyEmployeeRequestDto>();

            CreateMap<PharmacyEmployee, PharmacyEmployeeDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.PharmacyEmployeePermissions.Select(p => p.Permission.Name)))
                .ForMember(dest => dest.PharmacyName, opt => opt.MapFrom(src => src.Pharmacy.Name)); 


            CreateMap<PharmacyProduct, PharmacyProductDto>()
                .ForMember(dest => dest.ProductDto, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.PharmacyDto, opt => opt.MapFrom(src => src.Pharmacy));

            CreateMap<PharmacyProduct, PharmacyProductWithDistanceDto>()
                .ForMember(dest => dest.ProductDto, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.PharmacyDto, opt => opt.MapFrom(src => src.Pharmacy));

            CreateMap<PharmacyProductForCreationDto, PharmacyProduct>();


            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<SubCategory, SubCategoryDto>().ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));
            CreateMap<SubCategoryForCreateDto, SubCategory>();
            CreateMap<SubCategoryForUpdateDto, SubCategory>();

            CreateMap<Product, ProductDto>()
                .Include<Medicine, MedicineDto>()
                .Include<Cosmetic, CosmeticDto>().ForMember(dest => dest.subCategoryDto, opt => opt.MapFrom(src => src.SubCategory));
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



            // review them again
            CreateMap<Cart, CartDto>()
            .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.Items.Count))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Items.Sum(i => i.PriceAtAddition * i.Quantity)));
            CreateMap<CartForCreationDto, Cart>();
            CreateMap<CartForUpdateDto, Cart>();
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.PriceAtAddition * src.Quantity));
            CreateMap<CartItemForCreationDto, CartItem>();
            CreateMap<CartItemForUpdateDto, CartItem>();
            
            // Prescription mappings
            CreateMap<Prescription, PrescriptionDto>();
            CreateMap<PrescriptionForCreationDto, Prescription>()
           .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
            CreateMap<PrescriptionForUpdateDto, Prescription>();
            
            // Prescription Product mappings
            CreateMap<PrescriptionProduct, PrescriptionProductDto>();
            CreateMap<PrescriptionProductForUpdateDto, PrescriptionProduct>();
            CreateMap<PrescriptionProductForCreationDto, PrescriptionProduct>();
            
            // Notification mappings
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationForCreationDto, Notification>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsNotified, opt => opt.MapFrom(src => false));
            CreateMap<NotificationForUpdateDto, Notification>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            // PharmacyProductNotificationPreference mappings
            CreateMap<PharmacyProductNotificationPreference, PharmacyProductNotificationPreferenceDto>()
                .ForMember(dest => dest.PharmacyName, opt => opt.MapFrom(src => src.Pharmacy != null ? src.Pharmacy.Name : null))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : null));
            CreateMap<PharmacyProductNotificationPreferenceForCreationDto, PharmacyProductNotificationPreference>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
            CreateMap<PharmacyProductNotificationPreferenceForUpdateDto, PharmacyProductNotificationPreference>();
        }
    }
}
