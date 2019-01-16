using EstateAgency.BLL.SaleAnnouncements;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EstateAgency.API.Services.SaleAnnouncements
{
    public interface ISaleAnnouncementResponseComposer
    {
        /// <summary>
        /// Composes response code for GetAll action in SaleAnnouncementsController
        /// </summary>
        /// <param name="saleAnnouncementDtos">Sale announcement DTOs</param>
        /// <returns>Returns action result for GetAll action in SaleAnnouncementsController</returns>
        IActionResult ComposeForGetAll(IEnumerable<SaleAnnouncementDto> saleAnnouncementDtos);

        /// <summary>
        /// Composes response code for Get action in SaleAnnouncementsController
        /// </summary>
        /// <param name="saleAnnouncementDto">Sale announcement DTO</param>
        /// <returns>Returns action result for Get action in SaleAnnouncementsController</returns>
        IActionResult ComposeForGet(SaleAnnouncementDto saleAnnouncementDto);

        /// <summary>
        /// Composes response code for Add action in SaleAnnouncementsController
        /// </summary>
        /// <param name="statusCode">Code representing status of sale announcement addition operation</param>
        /// <param name="saleAnnouncementCreateDto">Sale announcement DTO for creation</param>
        /// <returns>Returns action result for Add action in SaleAnnouncementsController</returns>
        IActionResult ComposeForCreate(int statusCode, SaleAnnouncementCreateDto saleAnnouncementCreateDto);

        /// <summary>
        /// Composes response code for Update action in SaleAnnouncementsController
        /// </summary>
        /// <param name="statusCode">Code representing status of sale announcement updating operation</param>
        /// <returns>Returns action result for Update action in SaleAnnouncementsController</returns>
        IActionResult ComposeForUpdate(int statusCode);

        /// <summary>
        /// Composes response code for Delete action in SaleAnnouncementsController
        /// </summary>
        /// <param name="statusCode">Code representing status of sale announcement deleting operation</param>
        /// <returns>Returns action result for Delete action in SaleAnnouncementsController</returns>
        IActionResult ComposeForDelete(int statusCode);
    }
}