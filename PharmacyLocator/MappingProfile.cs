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

            CreateMap<PharmacyMedicine, PharmacyMedicineDto>();
            CreateMap<PharmacyForCreationDto, Pharmacy>();
            CreateMap<PharmacyMedicineForCreationDto, PharmacyMedicine>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
