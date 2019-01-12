using System;

namespace EstateAgency.BLL.RentAnnouncements
{
    public class RentAnnouncementUpdateDto
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }
        public int OwnerId { get; set; }

        public DateTime CreationDate { get; set; }
        public decimal Rent { get; set; }
        public int TermInDays { get; set; }
    }
}