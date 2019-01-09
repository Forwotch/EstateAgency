using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EstateAgency.DAL.EF;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.DAL.Repositories.ApartmentOwners
{
    public class ApartmentOwnerRepository : Repository<ApartmentOwner>, IApartmentOwnerRepository
    {
        private readonly DbSet<ApartmentOwner> _apartmentOwners;
        
        public ApartmentOwnerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _apartmentOwners = DbContext.ApartmentOwners;
        }

        public override async Task<IEnumerable<ApartmentOwner>> GetAllAsync()
        {
            return await _apartmentOwners
                .Include(a => a.Announcements)
                .Include(a => a.Apartments)
                .ToListAsync();
        }

        public override async Task<ApartmentOwner> GetAsync(int id)
        {
            return await _apartmentOwners
                .Include(a => a.Announcements)
                .Include(a => a.Apartments)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<IEnumerable<ApartmentOwner>> FindAsync(Expression<Func<ApartmentOwner, bool>> predicate)
        {
            return await _apartmentOwners
                .Where(predicate)
                .Include(a => a.Announcements)
                .Include(a => a.Apartments)
                .ToListAsync();
        }

        public override async Task AddAsync(ApartmentOwner entity)
        {
            await _apartmentOwners.AddAsync(entity);
        }

        public override void Delete(int id)
        {
            var apartmentOwner = new ApartmentOwner { Id = id };
            _apartmentOwners.Remove(apartmentOwner);
        }

        public override void Update(ApartmentOwner entity)
        {
            _apartmentOwners.Update(entity);
        }
    }
}
