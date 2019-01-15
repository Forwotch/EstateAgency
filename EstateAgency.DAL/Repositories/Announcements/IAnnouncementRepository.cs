using System;
using System.Linq;
using System.Threading.Tasks;
using EstateAgency.DAL.Entities;

namespace EstateAgency.DAL.Repositories.Announcements
{
    public interface IAnnouncementRepository : IDisposable
    {
        Task<Announcement> GetAsync(int id);

        IQueryable<Announcement> GetAll();

        void Update(Announcement entity);
    }
}