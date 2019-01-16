using EstateAgency.DAL.EF;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EstateAgency.DAL.Repositories.RentAnnouncements
{
    public class RentAnnouncementRepository : Repository<RentAnnouncement>, IRentAnnouncementRepository
    {
        private readonly DbSet<RentAnnouncement> _rentAnnouncements;
        
        public RentAnnouncementRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _rentAnnouncements = DbContext.RentAnnouncements;
        }

        public override IQueryable<RentAnnouncement> GetAll()
        {
            return _rentAnnouncements
                .Include(ra => ra.ApartmentOwner)
                .Include(ra => ra.Apartment);
        }

        public override async Task<RentAnnouncement> GetAsync(int id)
        {
            return await _rentAnnouncements
                .Include(ra => ra.ApartmentOwner)
                .Include(ra => ra.Apartment)
                .FirstOrDefaultAsync(ra => ra.Id == id);
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

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await _rentAnnouncements.AnyAsync(ra => ra.Id == id);
        }
    }
}
