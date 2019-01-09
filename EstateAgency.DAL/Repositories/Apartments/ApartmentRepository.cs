using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EstateAgency.DAL.EF;
using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.DAL.Repositories.Apartments
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        private readonly DbSet<Apartment> _apartments;

        public ApartmentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _apartments = DbContext.Apartments;
        }

        public override async Task<IEnumerable<Apartment>> GetAllAsync()
        {
            return await _apartments
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Announcements)
                .ToListAsync();
        }

        public override async Task<Apartment> GetAsync(int id)
        {
            return await _apartments
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Announcements)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<IEnumerable<Apartment>> FindAsync(Expression<Func<Apartment, bool>> predicate)
        {
            return await _apartments
                .Where(predicate)
                .Include(a => a.ApartmentOwner)
                .Include(a => a.Announcements)
                .ToListAsync();
        }

        public override async Task AddAsync(Apartment entity)
        {
            await _apartments.AddAsync(entity);
        }

        public override void Delete(int id)
        {
            var apartment = new Apartment { Id = id };
            _apartments.Remove(apartment);
        }

        public override void Update(Apartment entity)
        {
            _apartments.Update(entity);
        }
    }
}