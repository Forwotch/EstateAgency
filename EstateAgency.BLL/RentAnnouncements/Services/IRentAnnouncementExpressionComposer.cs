using System;
using System.Linq.Expressions;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public interface IRentAnnouncementExpressionComposer
    {
        /// <summary>
        /// Composes expression by given parametrs.
        /// </summary>
        /// <param name="maxPrice">Max price in rent announcement</param>
        /// <param name="numberOfRooms">Number of rooms in rent announcement</param>
        /// <param name="adress">Adress in rent announcement</param>
        /// <returns>Returns expression by given parametrs</returns>
        Expression<Func<RentAnnouncementDto, bool>> Compose(int? maxPrice, int? numberOfRooms, string adress);
    }
}