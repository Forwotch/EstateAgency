using EstateAgency.DAL.Entities;
using System;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public class RentAnnouncementCreator : IRentAnnouncementCreator
    {
        public RentAnnouncement CreateRentAnnouncementForAddition(RentAnnouncementCreateDto rentAnnouncementCreateDto,
            ApartmentOwner apartmentOwner,
            Apartment apartment)
        {
            var rentAnnouncement = new RentAnnouncement
            {
                ApartmentOwnerId = apartmentOwner.Id,
                ApartmentOwner = apartmentOwner,

                ApartmentId = apartment.Id,
                Apartment = apartment,

                CreationDate = DateTime.Now,
                Status = "On review",
                Rent = rentAnnouncementCreateDto.Rent,
                TermInDays = rentAnnouncementCreateDto.TermInDays
            };
            return rentAnnouncement;
        }
    }
}