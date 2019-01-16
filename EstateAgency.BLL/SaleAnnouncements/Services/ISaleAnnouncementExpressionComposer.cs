using System;
using System.Linq.Expressions;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public interface ISaleAnnouncementExpressionComposer
    {
        /// <summary>
        /// Composes expression by given parametrs.
        /// </summary>
        /// <param name="maxPrice">Max price in sale announcement</param>
        /// <param name="numberOfRooms">Number of rooms in sale announcement</param>
        /// <param name="adress">Adress in sale announcement</param>
        /// <returns>Returns expression by given parametrs</returns>
        Expression<Func<SaleAnnouncementDto, bool>> Compose(int? maxPrice, int? numberOfRooms, string adress);
    }
}