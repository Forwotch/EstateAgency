using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.Apartments.Services
{
    public class ApartmentCreator : IApartmentCreator
    {
        public Apartment CreateApartmentForAddition(ApartmentCreateDto apartmentCreateDto,
            ApartmentOwner apartmentOwner)
        {
            var apartment = new Apartment
            {
                ApartmentOwnerId = apartmentOwner.Id,
                ApartmentOwner = apartmentOwner,
                
                Address = apartmentCreateDto.Address,
                NumberOfRooms = (byte)apartmentCreateDto.NumberOfRooms,
                Floor = (byte)apartmentCreateDto.Floor,
                Area = apartmentCreateDto.Area,
                Description = apartmentCreateDto.Description
            };
            return apartment;
        }
    }
}