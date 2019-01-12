﻿using System.Collections.Generic;
using AutoMapper;
using EstateAgency.API.Models;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services
{
    public class RentAnnouncementResponseComposer : IRentAnnouncementResponseComposer
    {
        private readonly IMapper _mapper;

        public RentAnnouncementResponseComposer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Compose(IEnumerable<RentAnnouncementDto> rentAnnouncementDtos)
        {
            var rentAnnouncementModels = _mapper.Map<IEnumerable<RentAnnouncementModel>>(rentAnnouncementDtos);
            return new OkObjectResult(rentAnnouncementModels);
        }

        public IActionResult Compose(RentAnnouncementDto rentAnnouncementDto)
        {
            if (rentAnnouncementDto == null)
            {
                return new NotFoundResult();
            }

            var rentAnnouncementModel = _mapper.Map<RentAnnouncementModel>(rentAnnouncementDto);
            return new OkObjectResult(rentAnnouncementModel);
        }

        public IActionResult ComposeForCreate(int statusCode, RentAnnouncementCreateDto rentAnnouncementCreateDto)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid apartment owner id.");
                case -2:
                    return new BadRequestObjectResult("Invalid apartment id.");
                case -3:
                    return new BadRequestObjectResult("Invalid rent value.");
                case -4:
                    return new BadRequestObjectResult("Invalid rent period value.");
                default:
                    return new CreatedAtRouteResult("GetRentAnnouncement", new { Id = statusCode }, rentAnnouncementCreateDto);
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
                    return new BadRequestObjectResult("Invalid rent value.");
                case -4:
                    return new BadRequestObjectResult("Invalid rent period value.");
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