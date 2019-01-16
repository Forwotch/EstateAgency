using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public interface IRentAnnouncementCreator
    {
        /// <summary>
        /// Prepares rent announcement entity to persist to database.
        /// </summary>
        /// <param name="rentAnnouncementCreateDto">Rent announcement creation DTO</param>
        /// <param name="apartmentOwner">Apartment owner from database</param>
        /// <param name="apartment">Apartment from database</param>
        /// <returns>Returns rent announcement entity</returns>
        RentAnnouncement CreateRentAnnouncementForAddition(
            RentAnnouncementCreateDto rentAnnouncementCreateDto,
            ApartmentOwner apartmentOwner,
            Apartment apartment);
    }
}