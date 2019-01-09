using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EstateAgency.DAL.EF;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.DAL.Repositories.RentAnnouncements
{
    public class RentAnnouncementRepository : Repository<RentAnnouncement>, IRentAnnouncementRepository
    {
        private readonly DbSet<RentAnnouncement> _rentAnnouncements;
        
        public RentAnnouncementRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _rentAnnouncements = DbContext.RentAnnouncements;
        }

        public override async Task<IEnumerable<RentAnnouncement>> GetAllAsync()
        {
            return await _rentAnnouncements
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment)
                .ToListAsync();
        }

        public override async Task<RentAnnouncement> GetAsync(int id)
        {
            return await _rentAnnouncements
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<IEnumerable<RentAnnouncement>> FindAsync(Expression<Func<RentAnnouncement, bool>> predicate)
        {
            return await _rentAnnouncements.Where(predicate)
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment)
                .ToListAsync();
        }

        public override async Task AddAsync(RentAnnouncement entity)
        {
            await _rentAnnouncements.AddAsync(entity);
        }

        public override void Delete(int id)
        {
            var rentAnnouncement = new RentAnnouncement { Id = id };
            _rentAnnouncements.Remove(rentAnnouncement);
        }

        public override void Update(RentAnnouncement entity)
        {
            _rentAnnouncements.Update(entity);
        }
    }
}
