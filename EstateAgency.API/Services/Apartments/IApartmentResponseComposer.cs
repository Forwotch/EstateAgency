using EstateAgency.BLL.Apartments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EstateAgency.API.Services.Apartments
{
    public interface IApartmentResponseComposer
    {
        /// <summary>
        /// Composes response code for GetAll action in ApartmentsController
        /// </summary>
        /// <param name="apartmentDtos">Apartment DTOs</param>
        /// <returns>Returns action result for GetAll action in ApartmentsController</returns>
        IActionResult ComposeForGetAll(IEnumerable<ApartmentDto> apartmentDtos);

        /// <summary>
        /// Composes response code for Get action in ApartmentsController
        /// </summary>
        /// <param name="apartmentDto">Apartment DTO</param>
        /// <returns>Returns action result for Get action in ApartmentsController</returns>
        IActionResult ComposeForGet(ApartmentDto apartmentDto);

        /// <summary>
        /// Composes response code for Add action in ApartmentsController
        /// </summary>
        /// <param name="statusCode">Code representing status of apartment addition operation</param>
        /// <param name="apartmentCreateDto">Apartment DTO for creation</param>
        /// <returns>Returns action result for Add action in ApartmentsController</returns>
        IActionResult ComposeForCreate(int statusCode, ApartmentCreateDto apartmentCreateDto);

        /// <summary>
        /// Composes response code for Update action in ApartmentsController
        /// </summary>
        /// <param name="statusCode">Code representing status of apartment updating operation</param>
        /// <returns>Returns action result for Update action in ApartmentsController</returns>
        IActionResult ComposeForUpdate(int statusCode);

        /// <summary>
        /// Composes response code for Delete action in ApartmentsController
        /// </summary>
        /// <param name="statusCode">Code representing status of apartment deleting operation</param>
        /// <returns>Returns action result for Delete action in ApartmentsController</returns>
        IActionResult ComposeForDelete(int statusCode);
    }
}