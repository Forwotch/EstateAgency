using System.Collections.Generic;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services
{
    public interface IRentAnnouncementResponseComposer
    {
        IActionResult Compose(IEnumerable<RentAnnouncementDto> rentAnnouncementDtos);
        IActionResult Compose(RentAnnouncementDto rentAnnouncementDto);
    }
}