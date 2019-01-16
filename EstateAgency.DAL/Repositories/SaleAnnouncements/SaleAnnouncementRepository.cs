using EstateAgency.DAL.EF;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.DAL.Repositories.SaleAnnouncements
{
    public class SaleAnnouncementRepository : Repository<SaleAnnouncement>, ISaleAnnouncementRepository
    {
        private readonly DbSet<SaleAnnouncement> _saleAnnouncements;
        
        public SaleAnnouncementRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _saleAnnouncements = DbContext.SaleAnnouncements;
        }

        public override IQueryable<SaleAnnouncement> GetAll()
        {
            return _saleAnnouncements
                .Include(sa => sa.ApartmentOwner)
                .Include(sa => sa.Apartment);
        }

        public override async Task<SaleAnnouncement> GetAsync(int id)
        {
            return await _saleAnnouncements
                .Include(sa => sa.ApartmentOwner)
                .Include(sa => sa.Apartment)
                .FirstOrDefaultAsync(sa => sa.Id == id);
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

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await _saleAnnouncements.AnyAsync(sa => sa.Id == id);
        }
    }
}
