using System.Collections.Generic;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services.RentAnnouncements
{
    public interface IRentAnnouncementResponseComposer
    {
        /// <summary>
        /// Composes response code for GetAll action in RentAnnouncementsController
        /// </summary>
        /// <param name="rentAnnouncementDtos">Rent announcement DTOs</param>
        /// <returns>Returns action result for GetAll action in RentAnnouncementsController</returns>
        IActionResult ComposeForGetAll(IEnumerable<RentAnnouncementDto> rentAnnouncementDtos);

        /// <summary>
        /// Composes response code for Get action in RentAnnouncementsController
        /// </summary>
        /// <param name="rentAnnouncementDto">Rent announcement DTO</param>
        /// <returns>Returns action result for Get action in RentAnnouncementsController</returns>
        IActionResult ComposeForGet(RentAnnouncementDto rentAnnouncementDto);

        /// <summary>
        /// Composes response code for Add action in RentAnnouncementsController
        /// </summary>
        /// <param name="statusCode">Code representing status of rent announcement addition operation</param>
        /// <param name="rentAnnouncementCreateDto">Rent announcement DTO for creation</param>
        /// <returns>Returns action result for Add action in RentAnnouncementsController</returns>
        IActionResult ComposeForCreate(int statusCode, RentAnnouncementCreateDto rentAnnouncementCreateDto);

        /// <summary>
        /// Composes response code for Update action in RentAnnouncementsController
        /// </summary>
        /// <param name="statusCode">Code representing status of rent announcement updating operation</param>
        /// <returns>Returns action result for Update action in RentAnnouncementsController</returns>
        IActionResult ComposeForUpdate(int statusCode);

        /// <summary>
        /// Composes response code for Delete action in RentAnnouncementsController
        /// </summary>
        /// <param name="statusCode">Code representing status of rent announcement deleting operation</param>
        /// <returns>Returns action result for Delete action in RentAnnouncementsController</returns>
        IActionResult ComposeForDelete(int statusCode);
    }
}