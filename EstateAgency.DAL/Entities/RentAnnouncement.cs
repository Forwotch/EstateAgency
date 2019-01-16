namespace EstateAgency.DAL.Entities
{
    public class RentAnnouncement : Announcement
    {
        public decimal Rent { get; set; }
        public int TermInDays { get; set; }
    }
}
