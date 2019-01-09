using System;
using EstateAgency.DAL.Entities.Base;

namespace EstateAgency.DAL.Entities
{
    public class Announcement : Entity
    {
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
        public ApartmentOwner ApartmentOwner { get; set; }
        public int ApartmentOwnerId { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
