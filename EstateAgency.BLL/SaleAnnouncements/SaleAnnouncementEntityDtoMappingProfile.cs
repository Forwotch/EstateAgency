using AutoMapper;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.SaleAnnouncements
{
    public class SaleAnnouncementEntityDtoMappingProfile : Profile
    {
        public SaleAnnouncementEntityDtoMappingProfile()
        {
            CreateMap<SaleAnnouncement, SaleAnnouncementDto>()
                .ForMember(dst => dst.ApartmentAddress, src => src.MapFrom(sa => sa.Apartment.Address))
                .ForMember(dst => dst.ApartmentArea, src => src.MapFrom(sa => sa.Apartment.Area))
                .ForMember(dst => dst.ApartmentDescription, src => src.MapFrom(sa => sa.Apartment.Description))
                .ForMember(dst => dst.ApartmentFloor, src => src.MapFrom(sa => sa.Apartment.Floor))
                .ForMember(dst => dst.ApartmentNumberOfRooms, src => src.MapFrom(sa => sa.Apartment.NumberOfRooms))
                .ForMember(dst => dst.OwnerEmail, src => src.MapFrom(sa => sa.ApartmentOwner.Email))
                .ForMember(dst => dst.OwnerFirstName, src => src.MapFrom(sa => sa.ApartmentOwner.FirstName))
                .ForMember(dst => dst.OwnerLastName, src => src.MapFrom(sa => sa.ApartmentOwner.LastName))
                .ForMember(dst => dst.OwnerPhoneNumber, src => src.MapFrom(sa => sa.ApartmentOwner.PhoneNumber));
            CreateMap<SaleAnnouncementDto, SaleAnnouncement>()
                .ForPath(dst => dst.Apartment.Address, src => src.MapFrom(sad => sad.ApartmentAddress))
                .ForPath(dst => dst.Apartment.Area, src => src.MapFrom(sad => sad.ApartmentArea))
                .ForPath(dst => dst.Apartment.Description, src => src.MapFrom(sad => sad.ApartmentDescription))
                .ForPath(dst => dst.Apartment.Floor, src => src.MapFrom(sad => sad.ApartmentFloor))
                .ForPath(dst => dst.Apartment.NumberOfRooms, src => src.MapFrom(sad => sad.ApartmentNumberOfRooms))
                .ForPath(dst => dst.ApartmentOwner.Email, src => src.MapFrom(sad => sad.OwnerEmail))
                .ForPath(dst => dst.ApartmentOwner.FirstName, src => src.MapFrom(sad => sad.OwnerFirstName))
                .ForPath(dst => dst.ApartmentOwner.LastName, src => src.MapFrom(sad => sad.OwnerLastName))
                .ForPath(dst => dst.ApartmentOwner.PhoneNumber, src => src.MapFrom(sad => sad.OwnerPhoneNumber));
        }
    }
}