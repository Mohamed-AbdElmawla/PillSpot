using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PharmacyLocator
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
          //  CreateMap<Pharmacy, PharmacyDto>().ForMember(ph=> ph.FullAddress,opt => opt.MapFrom(x => string.Join(' ', x.Address, x.City)));

            CreateMap<Medicine, MedicineDto>();
            CreateMap<MedicineForCreationDto, Medicine>();

            CreateMap<PharmacyMedicine, PharmacyMedicineDto>();
            CreateMap<PharmacyMedicineForCreationDto, PharmacyMedicine>();
            CreateMap<PharmacyMedicineForUpdateDto, PharmacyMedicine>();

            CreateMap<PharmacyForUpdateDto, Pharmacy>();
            CreateMap<PharmacyForCreationDto, Pharmacy>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemForCreationDto, OrderItem>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
