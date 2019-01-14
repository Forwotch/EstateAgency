using System;
using EstateAgency.API.Models.Announcements;

namespace EstateAgency.API.Models.Apartments
{
    public class ApartmentModel
    {
        public int Id { get; set; }
        public ApartmentOwnerInfoModel ApartmentOwnerInfo { get; set; }
        public string Address { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public double Area { get; set; }
        public string Description { get; set; }
    }
}
