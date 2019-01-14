using System.Collections.Generic;
using EstateAgency.BLL.ApartmentOwners;
using EstateAgency.BLL.Apartments;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services.ApartmentOwners
{
    public interface IApartmentOwnerResponseComposer
    {
        IActionResult ComposeForGetAll(IEnumerable<ApartmentOwnerDto> apartmentOwnerDtos);
        IActionResult ComposeForGet(ApartmentOwnerDto apartmentOwnerDto);
        IActionResult ComposeForCreate(int statusCode, ApartmentOwnerCreateDto apartmentOwnerCreateDto);
        IActionResult ComposeForUpdate(int statusCode);
        IActionResult ComposeForDelete(int statusCode);
    }
}