using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public interface IRentAnnouncementService
    {
        Task<IEnumerable<RentAnnouncementDto>> GetAllAsync();
        Task<RentAnnouncementDto> GetAsync(int id);
        Task<IEnumerable<RentAnnouncementDto>> FindAsync(Expression<Func<RentAnnouncementDto, bool>> expression);
        Task<int> AddAsync(RentAnnouncementCreateDto rentAnnouncementCreateDto);
        Task<int> UpdateAsync(RentAnnouncementUpdateDto rentAnnouncementUpdateDto);
        Task<int> DeleteAsync(int id);
    }
}