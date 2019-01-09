using System.Collections.Generic;
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
    }
}