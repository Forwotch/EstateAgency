using EstateAgency.BLL.ApartmentOwners;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EstateAgency.API.Services.ApartmentOwners
{
    public interface IApartmentOwnerResponseComposer
    {
        /// <summary>
        /// Composes response code for GetAll action in ApartmentOwnersController
        /// </summary>
        /// <param name="apartmentOwnerDtos">Apartment owner DTOs</param>
        /// <returns>Returns action result for GetAll action in ApartmentOwnersController</returns>
        IActionResult ComposeForGetAll(IEnumerable<ApartmentOwnerDto> apartmentOwnerDtos);

        /// <summary>
        /// Composes response code for Get action in ApartmentOwnersController
        /// </summary>
        /// <param name="apartmentOwnerDto">Apartment owner DTO</param>
        /// <returns>Returns action result for Get action in ApartmentOwnersController</returns>
        IActionResult ComposeForGet(ApartmentOwnerDto apartmentOwnerDto);

        /// <summary>
        /// Composes response code for Add action in ApartmentOwnersController
        /// </summary>
        /// <param name="statusCode">Code representing status of apartment owner addition operation</param>
        /// <param name="apartmentOwnerCreateDto">Apartment owner DTO for creation</param>
        /// <returns>Returns action result for Add action in ApartmentOwnersController</returns>
        IActionResult ComposeForCreate(int statusCode, ApartmentOwnerCreateDto apartmentOwnerCreateDto);

        /// <summary>
        /// Composes response code for Update action in ApartmentOwnersController
        /// </summary>
        /// <param name="statusCode">Code representing status of apartment owner updating operation</param>
        /// <returns>Returns action result for Update action in ApartmentOwnersController</returns>
        IActionResult ComposeForUpdate(int statusCode);

        /// <summary>
        /// Composes response code for Delete action in ApartmentOwnersController
        /// </summary>
        /// <param name="statusCode">Code representing status of apartment owner deleting operation</param>
        /// <returns>Returns action result for Delete action in ApartmentOwnersController</returns>
        IActionResult ComposeForDelete(int statusCode);
    }
}