using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public interface ISaleAnnouncementService
    {
        /// <summary>
        /// Gets all sale announcements.
        /// </summary>
        /// <returns>Returns all sale announcements</returns>
        Task<IEnumerable<SaleAnnouncementDto>> GetAllAsync();

        /// <summary>
        /// Gets sale announcement by id.
        /// </summary>
        /// <param name="id">Sale announcement id</param>
        /// <returns>Returns sale announcement by id</returns>
        Task<SaleAnnouncementDto> GetAsync(int id);

        /// <summary>
        /// Filters sale announcements by expression (filtering criteria).
        /// </summary>
        /// <param name="expression">Expression (filtering criteria)</param>
        /// <returns>Returns sale announcements by expression (filtering criteria)</returns>
        Task<IEnumerable<SaleAnnouncementDto>> FindAsync(Expression<Func<SaleAnnouncementDto, bool>> expression);

        /// <summary>
        /// Creates sale announcement.
        /// </summary>
        /// <param name="saleAnnouncementCreateDto">Sale announcement creation model</param>
        /// <returns>Returns id of the created entity or status code in case of failure</returns>
        Task<int> AddAsync(SaleAnnouncementCreateDto saleAnnouncementCreateDto);

        /// <summary>
        /// Updates sale announcement.
        /// </summary>
        /// <param name="saleAnnouncementUpdateDto">Sale announcement updating model</param>
        /// <returns>Returns id of the updated entity or status code in case of failure</returns>
        Task<int> UpdateAsync(SaleAnnouncementUpdateDto saleAnnouncementUpdateDto);

        /// <summary>
        /// Deletes sale announcement.
        /// </summary>
        /// <param name="id">Sale announcement id</param>
        /// <returns>Returns status code of operation result</returns>
        Task<int> DeleteAsync(int id);
    }
}