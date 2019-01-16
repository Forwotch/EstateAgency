using AutoMapper;
using EstateAgency.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.BLL.Announcements.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _estateAgencyDataStorage;
        private readonly IMapper _mapper;

        public AnnouncementService(IUnitOfWork estateAgencyDataStorage, IMapper mapper)
        {
            _estateAgencyDataStorage = estateAgencyDataStorage;
            _mapper = mapper;
        }
        
        public async Task UpdateStatusAsync(int announcementId, string status)
        {
            var announcementToUpdate = await _estateAgencyDataStorage.Announcements.GetAsync(announcementId);
            announcementToUpdate.Status = status;
            _estateAgencyDataStorage.Announcements.Update(announcementToUpdate);
            await _estateAgencyDataStorage.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAllToReviewAsync()
        {
            var announcementsToReview =
                await _estateAgencyDataStorage.Announcements.GetAll()
                .Where(a => a.Status == "On review").ToListAsync();
            return _mapper.Map<IEnumerable<AnnouncementDto>>(announcementsToReview);
        }

        public async Task<AnnouncementDto> GetAsync(int id)
        {
            var announcementToReview =
                await _estateAgencyDataStorage.Announcements.GetAsync(id);
            return _mapper.Map<AnnouncementDto>(announcementToReview);
        }
    }
}