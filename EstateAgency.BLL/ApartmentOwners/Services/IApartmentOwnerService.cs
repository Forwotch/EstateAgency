using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.ApartmentOwners.Services
{
    public interface IApartmentOwnerService
    {
        /// <summary>
        /// Gets all apartment owners.
        /// </summary>
        /// <returns>Returns all apartment owners</returns>
        Task<IEnumerable<ApartmentOwnerDto>> GetAllAsync();

        /// <summary>
        /// Gets apartment owner by id.
        /// </summary>
        /// <param name="id">Apartment owner id</param>
        /// <returns>Returns apartment owner by id</returns>
        Task<ApartmentOwnerDto> GetAsync(int id);

        /// <summary>
        /// Creates apartment.
        /// </summary>
        /// <param name="apartmentOwnerCreateDto">Apartment owner creation model</param>
        /// <returns>Returns id of the created entity or status code in case of failure</returns>
        Task<int> AddAsync(ApartmentOwnerCreateDto apartmentOwnerCreateDto);

        /// <summary>
        /// Updates apartment owner.
        /// </summary>
        /// <param name="apartmentOwnerUpdateDto">Apartment owner updating model</param>
        /// <returns>Returns id of the updated entity or status code in case of failure</returns>
        Task<int> UpdateAsync(ApartmentOwnerUpdateDto apartmentOwnerUpdateDto);

        /// <summary>
        /// Deletes apartment owner.
        /// </summary>
        /// <param name="id">Apartment owner id</param>
        /// <returns>Returns status code of operation result</returns>
        Task<int> DeleteAsync(int id);
    }
}