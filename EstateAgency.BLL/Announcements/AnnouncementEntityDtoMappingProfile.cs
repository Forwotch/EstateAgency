using AutoMapper;
using EstateAgency.BLL.ApartmentOwners;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.Announcements
{
    public class AnnouncementEntityDtoMappingProfile : Profile
    {
        public AnnouncementEntityDtoMappingProfile()
        {
            CreateMap<Announcement, AnnouncementDto>()
                .ForMember(dst => dst.ApartmentAddress, src => src.MapFrom(ra => ra.Apartment.Address))
                .ForMember(dst => dst.ApartmentArea, src => src.MapFrom(ra => ra.Apartment.Area))
                .ForMember(dst => dst.ApartmentDescription, src => src.MapFrom(ra => ra.Apartment.Description))
                .ForMember(dst => dst.ApartmentFloor, src => src.MapFrom(ra => ra.Apartment.Floor))
                .ForMember(dst => dst.ApartmentNumberOfRooms, src => src.MapFrom(ra => ra.Apartment.NumberOfRooms))
                .ForMember(dst => dst.OwnerEmail, src => src.MapFrom(ra => ra.ApartmentOwner.Email))
                .ForMember(dst => dst.OwnerFirstName, src => src.MapFrom(ra => ra.ApartmentOwner.FirstName))
                .ForMember(dst => dst.OwnerLastName, src => src.MapFrom(ra => ra.ApartmentOwner.LastName))
                .ForMember(dst => dst.OwnerPhoneNumber, src => src.MapFrom(ra => ra.ApartmentOwner.PhoneNumber));
        }
    }
}