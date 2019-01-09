using System.Collections.Generic;
using EstateAgency.DAL.Entities.Base;

namespace EstateAgency.DAL.Entities
{
    public class ApartmentOwner : Entity
    {
        public ICollection<Announcement> Announcements { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
