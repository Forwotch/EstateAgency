using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.Announcements.Services
{
    public interface IAnnouncementService
    {
        Task UpdateStatusAsync(int announcementId, string status);
        Task<IEnumerable<AnnouncementDto>> GetAllToReviewAsync();
        Task<AnnouncementDto> GetAsync(int id);
    }
}