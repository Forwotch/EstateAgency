using AutoMapper;
using EstateAgency.API.Models;
using EstateAgency.API.Models.Announcements;
using EstateAgency.BLL.RentAnnouncements;
using EstateAgency.BLL.SaleAnnouncements;

namespace EstateAgency.API.MappingConfigurations
{
    public class SaleAnnouncementDtoModelMappingProfile : Profile
    {
        public SaleAnnouncementDtoModelMappingProfile()
        {
            CreateMap<SaleAnnouncementDto, SaleAnnouncementModel>()
                .ForPath(dst => dst.ApartmentInfo.Description, src => src.MapFrom(sad => sad.ApartmentDescription))
                .ForPath(dst => dst.ApartmentInfo.Address, src => src.MapFrom(sad => sad.ApartmentAddress))
                .ForPath(dst => dst.ApartmentInfo.Area, src => src.MapFrom(sad => sad.ApartmentArea))
                .ForPath(dst => dst.ApartmentInfo.Floor, src => src.MapFrom(sad => sad.ApartmentFloor))
                .ForPath(dst => dst.ApartmentInfo.NumberOfRooms, src => src.MapFrom(sad => sad.ApartmentNumberOfRooms))
                .ForPath(dst => dst.ApartmentOwnerInfo.Email, src => src.MapFrom(sad => sad.OwnerEmail))
                .ForPath(dst => dst.ApartmentOwnerInfo.FirstName, src => src.MapFrom(sad => sad.OwnerFirstName))
                .ForPath(dst => dst.ApartmentOwnerInfo.LastName, src => src.MapFrom(sad => sad.OwnerLastName))
                .ForPath(dst => dst.ApartmentOwnerInfo.PhoneNumber, src => src.MapFrom(sad => sad.OwnerPhoneNumber));
            CreateMap<SaleAnnouncementAddOrUpdateModel, SaleAnnouncementCreateDto>();
            CreateMap<SaleAnnouncementAddOrUpdateModel, SaleAnnouncementUpdateDto>();
        }
    }
}