using AutoMapper;
using EstateAgency.API.Models.Apartments;
using EstateAgency.BLL.Apartments;

namespace EstateAgency.API.MappingConfigurations
{
    public class ApartmentDtoModelMappingProfile : Profile
    {
        public ApartmentDtoModelMappingProfile()
        {
            CreateMap<ApartmentDto, ApartmentModel>()
                .ForPath(dst => dst.ApartmentOwnerInfo.Email, src => src.MapFrom(ad => ad.OwnerEmail))
                .ForPath(dst => dst.ApartmentOwnerInfo.FirstName, src => src.MapFrom(ad => ad.OwnerFirstName))
                .ForPath(dst => dst.ApartmentOwnerInfo.LastName, src => src.MapFrom(ad => ad.OwnerLastName))
                .ForPath(dst => dst.ApartmentOwnerInfo.PhoneNumber, src => src.MapFrom(ad => ad.OwnerPhoneNumber));
            CreateMap<ApartmentAddOrUpdateModel, ApartmentCreateDto>();
            CreateMap<ApartmentAddOrUpdateModel, ApartmentUpdateDto>();
        }
    }
}