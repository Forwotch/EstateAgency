namespace EstateAgency.API.Models.Announcements
{
    public class SaleAnnouncementAddOrUpdateModel
    {
        public int ApartmentId { get; set; }
        public int OwnerId { get; set; }

        public decimal Price { get; set; }
    }
}