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

        public override IQueryable<ApartmentOwner> GetAll()
        {
            return _apartmentOwners
                .Include(ao => ao.Announcements)
                .Include(ao => ao.Apartments);
        }

        public override async Task<ApartmentOwner> GetAsync(int id)
        {
            return await _apartmentOwners
                .Include(ao => ao.Announcements)
                .Include(ao => ao.Apartments)
                .FirstOrDefaultAsync(ao => ao.Id == id);
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

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await _apartmentOwners.AnyAsync(ao => ao.Id == id);
        }
    }
}
