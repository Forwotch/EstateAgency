using System;

namespace EstateAgency.BLL.RentAnnouncements
{
    public class RentAnnouncementDto
    {
        public int Id { get; set; }

        public string ApartmentAddress { get; set; }
        public byte ApartmentNumberOfRooms { get; set; }
        public byte ApartmentFloor { get; set; }
        public double ApartmentArea { get; set; }
        public string ApartmentDescription { get; set; }

        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerEmail { get; set; }

        public DateTime CreationDate { get; set; }
        public decimal Rent { get; set; }
        public int TermInDays { get; set; }
    }
}