using System.Collections.Generic;
using EstateAgency.DAL.Entities.Base;

namespace EstateAgency.DAL.Entities
{
    public class Apartment : Entity
    {
        public ApartmentOwner ApartmentOwner { get; set; }
        public int ApartmentOwnerId { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public string Address { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte Floor { get; set; }
        public double Area { get; set; }
        public string Description { get; set; }
    }
}
