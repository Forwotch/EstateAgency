using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.Apartments.Services
{
    public interface IApartmentService
    {
        /// <summary>
        /// Gets all apartments.
        /// </summary>
        /// <returns>Returns all apartments</returns>
        Task<IEnumerable<ApartmentDto>> GetAllAsync();

        /// <summary>
        /// Gets apartment by id.
        /// </summary>
        /// <param name="id">Apartment id</param>
        /// <returns>Returns apartment by id</returns>
        Task<ApartmentDto> GetAsync(int id);

        /// <summary>
        /// Creates apartment.
        /// </summary>
        /// <param name="apartmentCreateDto">Apartment creation model</param>
        /// <returns>Returns id of the created entity or status code in case of failure</returns>
        Task<int> AddAsync(ApartmentCreateDto apartmentCreateDto);

        /// <summary>
        /// Updates apartment.
        /// </summary>
        /// <param name="apartmentUpdateDto">Apartment updating model</param>
        /// <returns>Returns id of the updated entity or status code in case of failure</returns>
        Task<int> UpdateAsync(ApartmentUpdateDto apartmentUpdateDto);

        /// <summary>
        /// Deletes apartment.
        /// </summary>
        /// <param name="id">Apartment id</param>
        /// <returns>Returns status code of operation result</returns>
        Task<int> DeleteAsync(int id);
    }
}