namespace EstateAgency.API.Models.Announcements
{
    public class AnnouncementToReviewModel
    {
        public int Id { get; set; }
        public ApartmentInfoModel ApartmentInfo { get; set; }
        public ApartmentOwnerInfoModel ApartmentOwnerInfo { get; set; }
        public string Status { get; set; }
    }
}