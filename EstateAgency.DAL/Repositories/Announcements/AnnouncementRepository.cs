using System;
using System.Linq;
using System.Threading.Tasks;
using EstateAgency.DAL.EF;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.DAL.Repositories.Announcements
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly DbSet<Announcement> _announcements;
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed = false;

        public AnnouncementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _announcements = _dbContext.Announcements;
        }

        public async Task<Announcement> GetAsync(int id)
        {
            return await _announcements
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public IQueryable<Announcement> GetAll()
        {
            return _announcements
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment);
        }
        
        public void Update(Announcement entity)
        {
            _announcements.Update(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _dbContext?.Dispose();
            }

            _disposed = true;
        }

        ~AnnouncementRepository()
        {
            Dispose(false);
        }
    }
}