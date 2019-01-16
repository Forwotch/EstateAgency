using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public interface ISaleAnnouncementCreator
    {
        /// <summary>
        /// Prepares sale announcement entity to persist to database.
        /// </summary>
        /// <param name="saleAnnouncementCreateDto">Sale announcement creation DTO</param>
        /// <param name="apartmentOwner">Apartment owner from database</param>
        /// <param name="apartment">Apartment from database</param>
        /// <returns>Returns sale announcement entity</returns>
        SaleAnnouncement CreateSaleAnnouncementForAddition(
            SaleAnnouncementCreateDto saleAnnouncementCreateDto,
            ApartmentOwner apartmentOwner,
            Apartment apartment);
    }
}