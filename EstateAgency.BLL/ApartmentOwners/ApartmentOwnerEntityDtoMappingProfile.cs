using AutoMapper;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.ApartmentOwners
{
    public class ApartmentOwnerEntityDtoMappingProfile : Profile
    {
        public ApartmentOwnerEntityDtoMappingProfile()
        {
            CreateMap<ApartmentOwner, ApartmentOwnerDto>();
            CreateMap<ApartmentOwnerDto, ApartmentOwner>();
            CreateMap<ApartmentOwnerCreateDto, ApartmentOwner>();
        }
    }
}