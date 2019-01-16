using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.Announcements.Services
{
    public interface IAnnouncementService
    {
        /// <summary>
        /// Update status of the announcement with given id.
        /// </summary>
        /// <param name="announcementId">Announcement id</param>
        /// <param name="status">New status for updating</param>
        Task UpdateStatusAsync(int announcementId, string status);

        /// <summary>
        /// Gets all announcements with "On review" status.
        /// </summary>
        /// <returns>Returns announcements with "On review" status</returns>
        Task<IEnumerable<AnnouncementDto>> GetAllToReviewAsync();

        /// <summary>
        /// Get announcement by given id.
        /// </summary>
        /// <param name="id">Announcement id</param>
        /// <returns>Returns announcement by given id</returns>
        Task<AnnouncementDto> GetAsync(int id);
    }
}