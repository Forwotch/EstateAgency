using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public interface IRentAnnouncementService
    {
        Task<IEnumerable<RentAnnouncementDto>> GetAllAsync();
        Task<RentAnnouncementDto> GetAsync(int id);
    }
}