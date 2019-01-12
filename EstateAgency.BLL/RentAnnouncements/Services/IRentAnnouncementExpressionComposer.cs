using System;
using System.Linq.Expressions;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public interface IRentAnnouncementExpressionComposer
    {
        Expression<Func<RentAnnouncementDto, bool>> Compose(int? maxPrice, int? numberOfRooms, string adress);
    }
}