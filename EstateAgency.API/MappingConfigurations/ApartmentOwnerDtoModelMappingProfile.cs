using AutoMapper;
using EstateAgency.API.Models;
using EstateAgency.API.Models.Announcements;
using EstateAgency.API.Models.ApartmentOwners;
using EstateAgency.API.Models.Apartments;
using EstateAgency.BLL.ApartmentOwners;
using EstateAgency.BLL.Apartments;
using EstateAgency.BLL.RentAnnouncements;

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