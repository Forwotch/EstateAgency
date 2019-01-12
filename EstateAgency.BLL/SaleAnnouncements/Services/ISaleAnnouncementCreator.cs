using EstateAgency.BLL.RentAnnouncements;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public interface ISaleAnnouncementCreator
    {
        SaleAnnouncement CreateSaleAnnouncementForAddition(
            SaleAnnouncementCreateDto saleAnnouncementCreateDto,
            ApartmentOwner apartmentOwner,
            Apartment apartment);
    }
}