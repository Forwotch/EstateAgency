using EstateAgency.BLL.RentAnnouncements;
using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.Apartments.Services
{
    public interface IApartmentCreator
    {
        Apartment CreateApartmentForAddition(ApartmentCreateDto apartmentCreateDto,
            ApartmentOwner apartmentOwner);
    }
}