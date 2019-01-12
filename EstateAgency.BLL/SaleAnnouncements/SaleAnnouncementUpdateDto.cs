using System;

namespace EstateAgency.BLL.SaleAnnouncements
{
    public class SaleAnnouncementUpdateDto
    {
        public int Id { get; set; }

        public int ApartmentId { get; set; }
        public int OwnerId { get; set; }

        public DateTime CreationDate { get; set; }
        public decimal Price { get; set; }
    }
}