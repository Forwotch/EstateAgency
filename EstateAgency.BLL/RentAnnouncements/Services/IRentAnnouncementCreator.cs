using System.Threading.Tasks;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public interface IRentAnnouncementCreator
    {
        RentAnnouncement CreateRentAnnouncementForAddition(
            RentAnnouncementCreateDto rentAnnouncementCreateDto,
            ApartmentOwner apartmentOwner,
            Apartment apartment);
    }
}