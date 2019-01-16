using AutoMapper;
using EstateAgency.API.Models.Announcements;
using EstateAgency.BLL.RentAnnouncements;

namespace EstateAgency.API.MappingConfigurations
{
    public class RentAnnouncementDtoModelMappingProfile : Profile
    {
        public RentAnnouncementDtoModelMappingProfile()
        {
            CreateMap<RentAnnouncementDto, RentAnnouncementModel>()
                .ForPath(dst => dst.ApartmentInfo.Description, src => src.MapFrom(rad => rad.ApartmentDescription))
                .ForPath(dst => dst.ApartmentInfo.Address, src => src.MapFrom(rad => rad.ApartmentAddress))
                .ForPath(dst => dst.ApartmentInfo.Area, src => src.MapFrom(rad => rad.ApartmentArea))
                .ForPath(dst => dst.ApartmentInfo.Floor, src => src.MapFrom(rad => rad.ApartmentFloor))
                .ForPath(dst => dst.ApartmentInfo.NumberOfRooms, src => src.MapFrom(rad => rad.ApartmentNumberOfRooms))
                .ForPath(dst => dst.ApartmentOwnerInfo.Email, src => src.MapFrom(rad => rad.OwnerEmail))
                .ForPath(dst => dst.ApartmentOwnerInfo.FirstName, src => src.MapFrom(rad => rad.OwnerFirstName))
                .ForPath(dst => dst.ApartmentOwnerInfo.LastName, src => src.MapFrom(rad => rad.OwnerLastName))
                .ForPath(dst => dst.ApartmentOwnerInfo.PhoneNumber, src => src.MapFrom(rad => rad.OwnerPhoneNumber));
            CreateMap<RentAnnouncementAddOrUpdateModel, RentAnnouncementCreateDto>();
            CreateMap<RentAnnouncementAddOrUpdateModel, RentAnnouncementUpdateDto>();
        }
    }
}