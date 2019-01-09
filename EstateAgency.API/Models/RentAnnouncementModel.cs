using System;

namespace EstateAgency.API.Models
{
    public class RentAnnouncementModel
    {
        public int Id { get; set; }
        public ApartmentInfoInAnnouncementModel ApartmentInfo { get; set; }
        public ApartmentOwnerInfoInAnnouncementModel ApartmentOwnerInfo { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Rent { get; set; }
        public int TermInDays { get; set; }
    }
}
