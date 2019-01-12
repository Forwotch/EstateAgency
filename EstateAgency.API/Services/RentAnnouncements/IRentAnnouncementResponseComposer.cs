using System.Collections.Generic;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services.RentAnnouncements
{
    public interface IRentAnnouncementResponseComposer
    {
        IActionResult ComposeForGetAll(IEnumerable<RentAnnouncementDto> rentAnnouncementDtos);
        IActionResult ComposeForGet(RentAnnouncementDto rentAnnouncementDto);
        IActionResult ComposeForCreate(int statusCode, RentAnnouncementCreateDto rentAnnouncementCreateDto);
        IActionResult ComposeForUpdate(int statusCode);
        IActionResult ComposeForDelete(int statusCode);
    }
}