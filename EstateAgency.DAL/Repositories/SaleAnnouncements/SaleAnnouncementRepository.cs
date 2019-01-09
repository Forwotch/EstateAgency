using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EstateAgency.DAL.EF;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.DAL.Repositories.SaleAnnouncements
{
    public class SaleAnnouncementRepository : Repository<SaleAnnouncement>, ISaleAnnouncementRepository
    {
        private readonly DbSet<SaleAnnouncement> _saleAnnouncements;
        
        public SaleAnnouncementRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _saleAnnouncements = DbContext.SaleAnnouncements;
        }

        public override async Task<IEnumerable<SaleAnnouncement>> GetAllAsync()
        {
            return await _saleAnnouncements
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment)
                .ToListAsync();
        }

        public override async Task<SaleAnnouncement> GetAsync(int id)
        {
            return await _saleAnnouncements
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<IEnumerable<SaleAnnouncement>> FindAsync(Expression<Func<SaleAnnouncement, bool>> predicate)
        {
            return await _saleAnnouncements.Where(predicate)
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Apartment)
                .ToListAsync();
        }

        public override async Task AddAsync(SaleAnnouncement entity)
        {
            await _saleAnnouncements.AddAsync(entity);
        }

        public override void Delete(int id)
        {
            var saleAnnouncement = new SaleAnnouncement { Id = id };
            _saleAnnouncements.Remove(saleAnnouncement);
        }

        public override void Update(SaleAnnouncement entity)
        {
            _saleAnnouncements.Update(entity);
        }
    }
}
