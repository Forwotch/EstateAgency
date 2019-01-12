using System.Collections.Generic;
using EstateAgency.BLL.RentAnnouncements;
using EstateAgency.BLL.SaleAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services.SaleAnnouncements
{
    public interface ISaleAnnouncementResponseComposer
    {
        IActionResult ComposeForGetAll(IEnumerable<SaleAnnouncementDto> saleAnnouncementDtos);
        IActionResult ComposeForGet(SaleAnnouncementDto saleAnnouncementDto);
        IActionResult ComposeForCreate(int statusCode, SaleAnnouncementCreateDto saleAnnouncementCreateDto);
        IActionResult ComposeForUpdate(int statusCode);
        IActionResult ComposeForDelete(int statusCode);
    }
}