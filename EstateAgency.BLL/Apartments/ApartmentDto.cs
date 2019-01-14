using System;

namespace EstateAgency.BLL.Apartments
{
    public class ApartmentDto
    {
        public int Id { get; set; }

        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerEmail { get; set; }

        public string Address { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public double Area { get; set; }
        public string Description { get; set; }
    }
}