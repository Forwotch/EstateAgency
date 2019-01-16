using EstateAgency.DAL.EF;
using EstateAgency.DAL.Repositories.Announcements;
using EstateAgency.DAL.Repositories.ApartmentOwners;
using EstateAgency.DAL.Repositories.Apartments;
using EstateAgency.DAL.Repositories.RentAnnouncements;
using EstateAgency.DAL.Repositories.SaleAnnouncements;
using System;
using System.Threading.Tasks;

namespace EstateAgency.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IApartmentOwnerRepository ApartmentOwners
        {
            get
            {
                if (_apartmentOwnerRepository == null)
                {
                    _apartmentOwnerRepository = new ApartmentOwnerRepository(_dbContext);
                }
                return _apartmentOwnerRepository;
            }
        }
        private IApartmentOwnerRepository _apartmentOwnerRepository;

        public IApartmentRepository Apartments
        {
            get
            {
                if (_apartmentRepository == null)
                {
                    _apartmentRepository = new ApartmentRepository(_dbContext);
                }
                return _apartmentRepository;
            }
        }
        private IApartmentRepository _apartmentRepository;

        public ISaleAnnouncementRepository SaleAnnouncements
        {
            get
            {
                if (_saleAnnouncementRepository == null)
                {
                    _saleAnnouncementRepository = new SaleAnnouncementRepository(_dbContext);
                }
                return _saleAnnouncementRepository;
            }
        }
        private ISaleAnnouncementRepository _saleAnnouncementRepository;

        public IRentAnnouncementRepository RentAnnouncements
        {
            get
            {
                if (_rentAnnouncementRepository == null)
                {
                    _rentAnnouncementRepository = new RentAnnouncementRepository(_dbContext);
                }
                return _rentAnnouncementRepository;
            }
        }
        private IRentAnnouncementRepository _rentAnnouncementRepository;

        public IAnnouncementRepository Announcements
        {
            get
            {
                if (_announcementRepository == null)
                {
                    _announcementRepository = new AnnouncementRepository(_dbContext);
                }
                return _announcementRepository;
            }
        }
        private IAnnouncementRepository _announcementRepository;

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
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
                ApartmentOwners?.Dispose();
                Apartments?.Dispose();
                SaleAnnouncements?.Dispose();
                RentAnnouncements?.Dispose();
                Announcements?.Dispose();

                _dbContext?.Dispose();
            }

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
