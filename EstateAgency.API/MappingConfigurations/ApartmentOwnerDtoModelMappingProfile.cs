using AutoMapper;
using EstateAgency.API.Models.ApartmentOwners;
using EstateAgency.BLL.ApartmentOwners;

namespace EstateAgency.API.MappingConfigurations
{
    public class ApartmentOwnerDtoModelMappingProfile : Profile
    {
        public ApartmentOwnerDtoModelMappingProfile()
        {
            CreateMap<ApartmentOwnerDto, ApartmentOwnerModel>();
            CreateMap<ApartmentOwnerAddOrUpdateModel, ApartmentOwnerCreateDto>();
            CreateMap<ApartmentOwnerAddOrUpdateModel, ApartmentOwnerUpdateDto>();
        }
    }
}