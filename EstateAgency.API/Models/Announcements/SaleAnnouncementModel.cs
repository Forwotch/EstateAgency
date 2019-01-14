using System;

namespace EstateAgency.API.Models.Announcements
{
    public class SaleAnnouncementModel
    {
        public int Id { get; set; }
        public ApartmentInfoModel ApartmentInfo { get; set; }
        public ApartmentOwnerInfoModel ApartmentOwnerInfo { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
    }
}
