using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EstateAgency.BLL.RentAnnouncements;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public interface ISaleAnnouncementService
    {
        Task<IEnumerable<SaleAnnouncementDto>> GetAllAsync();
        Task<SaleAnnouncementDto> GetAsync(int id);
        Task<IEnumerable<SaleAnnouncementDto>> FindAsync(Expression<Func<SaleAnnouncementDto, bool>> expression);
        Task<int> AddAsync(SaleAnnouncementCreateDto saleAnnouncementCreateDto);
        Task<int> UpdateAsync(SaleAnnouncementUpdateDto saleAnnouncementUpdateDto);
        Task<int> DeleteAsync(int id);
    }
}