using System.Collections.Generic;
using EstateAgency.BLL.Apartments;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services.Apartments
{
    public interface IApartmentResponseComposer
    {
        IActionResult ComposeForGetAll(IEnumerable<ApartmentDto> apartmentDtos);
        IActionResult ComposeForGet(ApartmentDto apartmentDto);
        IActionResult ComposeForCreate(int statusCode, ApartmentCreateDto apartmentCreateDto);
        IActionResult ComposeForUpdate(int statusCode);
        IActionResult ComposeForDelete(int statusCode);
    }
}