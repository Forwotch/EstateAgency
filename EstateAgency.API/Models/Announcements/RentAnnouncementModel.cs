using System;

namespace EstateAgency.API.Models.Announcements
{
    public class RentAnnouncementModel
    {
        public int Id { get; set; }
        public ApartmentInfoModel ApartmentInfo { get; set; }
        public ApartmentOwnerInfoModel ApartmentOwnerInfo { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Rent { get; set; }
        public int TermInDays { get; set; }
    }
}
