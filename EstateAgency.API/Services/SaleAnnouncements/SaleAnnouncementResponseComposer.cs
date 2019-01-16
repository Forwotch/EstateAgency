using AutoMapper;
using EstateAgency.API.Models.Announcements;
using EstateAgency.BLL.SaleAnnouncements;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EstateAgency.API.Services.SaleAnnouncements
{
    public class SaleAnnouncementResponseComposer : ISaleAnnouncementResponseComposer
    {
        private readonly IMapper _mapper;

        public SaleAnnouncementResponseComposer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult ComposeForGetAll(IEnumerable<SaleAnnouncementDto> saleAnnouncementDtos)
        {
            var saleAnnouncementModels = _mapper.Map<IEnumerable<SaleAnnouncementModel>>(saleAnnouncementDtos);
            return new OkObjectResult(saleAnnouncementModels);
        }

        public IActionResult ComposeForGet(SaleAnnouncementDto saleAnnouncementDto)
        {
            if (saleAnnouncementDto == null)
            {
                return new NotFoundResult();
            }

            var saleAnnouncementModel = _mapper.Map<SaleAnnouncementModel>(saleAnnouncementDto);
            return new OkObjectResult(saleAnnouncementModel);
        }

        public IActionResult ComposeForCreate(int statusCode, SaleAnnouncementCreateDto saleAnnouncementCreateDto)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid apartment owner id.");
                case -2:
                    return new BadRequestObjectResult("Invalid apartment id.");
                case -3:
                    return new BadRequestObjectResult("Invalid price value.");
                default:
                    return new CreatedAtRouteResult("GetSaleAnnouncement", new { Id = statusCode }, saleAnnouncementCreateDto);
            }
        }

        public IActionResult ComposeForUpdate(int statusCode)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid apartment owner id.");
                case -2:
                    return new BadRequestObjectResult("Invalid apartment id.");
                case -3:
                    return new BadRequestObjectResult("Invalid price value.");
                default:
                    return new OkResult();
            }
        }

        public IActionResult ComposeForDelete(int statusCode)
        {
            switch (statusCode)
            {
                case -5:
                    return new NotFoundResult();
                default:
                    return new NoContentResult();
            }
        }
    }
}