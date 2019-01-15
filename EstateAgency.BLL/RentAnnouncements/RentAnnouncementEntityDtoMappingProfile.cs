using AutoMapper;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.RentAnnouncements
{
    public class RentAnnouncementEntityDtoMappingProfile : Profile
    {
        public RentAnnouncementEntityDtoMappingProfile()
        {
            CreateMap<RentAnnouncement, RentAnnouncementDto>()
                .ForMember(dst => dst.ApartmentAddress, src => src.MapFrom(ra => ra.Apartment.Address))
                .ForMember(dst => dst.ApartmentArea, src => src.MapFrom(ra => ra.Apartment.Area))
                .ForMember(dst => dst.ApartmentDescription, src => src.MapFrom(ra => ra.Apartment.Description))
                .ForMember(dst => dst.ApartmentFloor, src => src.MapFrom(ra => ra.Apartment.Floor))
                .ForMember(dst => dst.ApartmentNumberOfRooms, src => src.MapFrom(ra => ra.Apartment.NumberOfRooms))
                .ForMember(dst => dst.OwnerEmail, src => src.MapFrom(ra => ra.ApartmentOwner.Email))
                .ForMember(dst => dst.OwnerFirstName, src => src.MapFrom(ra => ra.ApartmentOwner.FirstName))
                .ForMember(dst => dst.OwnerLastName, src => src.MapFrom(ra => ra.ApartmentOwner.LastName))
                .ForMember(dst => dst.OwnerPhoneNumber, src => src.MapFrom(ra => ra.ApartmentOwner.PhoneNumber));
            
            CreateMap<RentAnnouncementDto, RentAnnouncement>()
                .ForPath(dst => dst.Apartment.Address, src => src.MapFrom(rad => rad.ApartmentAddress))
                .ForPath(dst => dst.Apartment.Area, src => src.MapFrom(rad => rad.ApartmentArea))
                .ForPath(dst => dst.Apartment.Description, src => src.MapFrom(rad => rad.ApartmentDescription))
                .ForPath(dst => dst.Apartment.Floor, src => src.MapFrom(rad => rad.ApartmentFloor))
                .ForPath(dst => dst.Apartment.NumberOfRooms, src => src.MapFrom(rad => rad.ApartmentNumberOfRooms))
                .ForPath(dst => dst.ApartmentOwner.Email, src => src.MapFrom(rad => rad.OwnerEmail))
                .ForPath(dst => dst.ApartmentOwner.FirstName, src => src.MapFrom(rad => rad.OwnerFirstName))
                .ForPath(dst => dst.ApartmentOwner.LastName, src => src.MapFrom(rad => rad.OwnerLastName))
                .ForPath(dst => dst.ApartmentOwner.PhoneNumber, src => src.MapFrom(rad => rad.OwnerPhoneNumber));
        }
    }
}