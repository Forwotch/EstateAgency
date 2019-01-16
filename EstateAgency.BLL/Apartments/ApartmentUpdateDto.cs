namespace EstateAgency.BLL.Apartments
{
    public class ApartmentUpdateDto
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string Address { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public double Area { get; set; }
        public string Description { get; set; }
    }
}