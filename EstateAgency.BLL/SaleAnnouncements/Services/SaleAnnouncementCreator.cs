using System;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public class SaleAnnouncementCreator : ISaleAnnouncementCreator
    {
        public SaleAnnouncement CreateSaleAnnouncementForAddition(SaleAnnouncementCreateDto saleAnnouncementCreateDto,
            ApartmentOwner apartmentOwner, Apartment apartment)
        {
            var saleAnnouncement = new SaleAnnouncement
            {
                ApartmentOwnerId = apartmentOwner.Id,
                ApartmentOwner = apartmentOwner,

                ApartmentId = apartment.Id,
                Apartment = apartment,

                CreationDate = DateTime.Now,
                Status = "On review",
                Price = saleAnnouncementCreateDto.Price
            };
            return saleAnnouncement;
        }
    }
}