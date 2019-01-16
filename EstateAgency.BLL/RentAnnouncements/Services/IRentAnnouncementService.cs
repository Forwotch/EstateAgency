using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public interface IRentAnnouncementService
    {
        /// <summary>
        /// Gets all rent announcements.
        /// </summary>
        /// <returns>Returns all rent announcements</returns>
        Task<IEnumerable<RentAnnouncementDto>> GetAllAsync();

        /// <summary>
        /// Gets rent announcement by id.
        /// </summary>
        /// <param name="id">Rent announcement id</param>
        /// <returns>Returns rent announcement by id</returns>
        Task<RentAnnouncementDto> GetAsync(int id);

        /// <summary>
        /// Filters rent announcements by expression (filtering criteria).
        /// </summary>
        /// <param name="expression">Expression (filtering criteria)</param>
        /// <returns>Returns rent announcements by expression (filtering criteria)</returns>
        Task<IEnumerable<RentAnnouncementDto>> FindAsync(Expression<Func<RentAnnouncementDto, bool>> expression);

        /// <summary>
        /// Creates rent announcement.
        /// </summary>
        /// <param name="rentAnnouncementCreateDto">Rent announcement creation model</param>
        /// <returns>Returns id of the created entity or status code in case of failure</returns>
        Task<int> AddAsync(RentAnnouncementCreateDto rentAnnouncementCreateDto);

        /// <summary>
        /// Updates rent announcement.
        /// </summary>
        /// <param name="rentAnnouncementUpdateDto">Rent announcement updating model</param>
        /// <returns>Returns id of the updated entity or status code in case of failure</returns>
        Task<int> UpdateAsync(RentAnnouncementUpdateDto rentAnnouncementUpdateDto);

        /// <summary>
        /// Deletes rent announcement.
        /// </summary>
        /// <param name="id">Rent announcement id</param>
        /// <returns>Returns status code of operation result</returns>
        Task<int> DeleteAsync(int id);
    }
}