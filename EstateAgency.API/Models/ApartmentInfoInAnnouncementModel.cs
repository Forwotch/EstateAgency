namespace EstateAgency.API.Models
{
    public class ApartmentInfoInAnnouncementModel
    {
        public string Address { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte Floor { get; set; }
        public double Area { get; set; }
        public string Description { get; set; }
    }
}