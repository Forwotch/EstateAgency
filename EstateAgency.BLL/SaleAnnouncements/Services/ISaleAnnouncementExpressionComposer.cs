using System;
using System.Linq.Expressions;
using EstateAgency.BLL.RentAnnouncements;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public interface ISaleAnnouncementExpressionComposer
    {
        Expression<Func<SaleAnnouncementDto, bool>> Compose(int? maxPrice, int? numberOfRooms, string adress);
    }
}