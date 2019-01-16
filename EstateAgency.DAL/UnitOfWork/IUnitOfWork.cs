using EstateAgency.DAL.Repositories.Announcements;
using EstateAgency.DAL.Repositories.ApartmentOwners;
using EstateAgency.DAL.Repositories.Apartments;
using EstateAgency.DAL.Repositories.RentAnnouncements;
using EstateAgency.DAL.Repositories.SaleAnnouncements;
using System;
using System.Threading.Tasks;

namespace EstateAgency.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IApartmentOwnerRepository ApartmentOwners { get; }
        IApartmentRepository Apartments { get; }
        ISaleAnnouncementRepository SaleAnnouncements { get; }
        IRentAnnouncementRepository RentAnnouncements { get; }
        IAnnouncementRepository Announcements { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
