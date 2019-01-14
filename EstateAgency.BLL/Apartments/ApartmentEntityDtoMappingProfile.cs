using AutoMapper;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.Apartments
{
    public class ApartmentEntityDtoMappingProfile : Profile
    {
        public ApartmentEntityDtoMappingProfile()
        {
            CreateMap<Apartment, ApartmentDto>()
                .ForMember(dst => dst.OwnerEmail, src => src.MapFrom(a => a.ApartmentOwner.Email))
                .ForMember(dst => dst.OwnerFirstName, src => src.MapFrom(a => a.ApartmentOwner.FirstName))
                .ForMember(dst => dst.OwnerLastName, src => src.MapFrom(a => a.ApartmentOwner.LastName))
                .ForMember(dst => dst.OwnerPhoneNumber, src => src.MapFrom(a => a.ApartmentOwner.PhoneNumber));
            CreateMap<ApartmentDto, Apartment>()
                .ForPath(dst => dst.ApartmentOwner.Email, src => src.MapFrom(ad => ad.OwnerEmail))
                .ForPath(dst => dst.ApartmentOwner.FirstName, src => src.MapFrom(ad => ad.OwnerFirstName))
                .ForPath(dst => dst.ApartmentOwner.LastName, src => src.MapFrom(ad => ad.OwnerLastName))
                .ForPath(dst => dst.ApartmentOwner.PhoneNumber, src => src.MapFrom(ad => ad.OwnerPhoneNumber));
        }
    }
}