using EstateAgency.DAL.Entities;

namespace EstateAgency.BLL.Apartments.Services
{
    public interface IApartmentCreator
    {
        /// <summary>
        /// Prepares apartment entity to persist to database.
        /// </summary>
        /// <param name="apartmentCreateDto">Apartment creation DTO</param>
        /// <param name="apartmentOwner">Apartment owner from database</param>
        /// <returns>Returns apartment entity</returns>
        Apartment CreateApartmentForAddition(ApartmentCreateDto apartmentCreateDto,
            ApartmentOwner apartmentOwner);
    }
}