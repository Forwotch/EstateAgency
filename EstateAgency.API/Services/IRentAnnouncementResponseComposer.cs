using System.Collections.Generic;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services
{
    public interface IRentAnnouncementResponseComposer
    {
        IActionResult Compose(IEnumerable<RentAnnouncementDto> rentAnnouncementDtos);
        IActionResult Compose(RentAnnouncementDto rentAnnouncementDto);
        IActionResult ComposeForCreate(int statusCode, RentAnnouncementCreateDto rentAnnouncementCreateDto);
        IActionResult ComposeForUpdate(int statusCode);
        IActionResult ComposeForDelete(int statusCode);
    }
}