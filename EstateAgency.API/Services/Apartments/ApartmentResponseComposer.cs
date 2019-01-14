using System.Collections.Generic;
using AutoMapper;
using EstateAgency.API.Models.Announcements;
using EstateAgency.API.Models.Apartments;
using EstateAgency.BLL.Apartments;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services.Apartments
{
    public class ApartmentResponseComposer : IApartmentResponseComposer
    {
        private readonly IMapper _mapper;

        public ApartmentResponseComposer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult ComposeForGetAll(IEnumerable<ApartmentDto> apartmentDtos)
        {
            var apartmentModels = _mapper.Map<IEnumerable<ApartmentModel>>(apartmentDtos);
            return new OkObjectResult(apartmentModels);
        }

        public IActionResult ComposeForGet(ApartmentDto apartmentDto)
        {
            if (apartmentDto == null)
            {
                return new NotFoundResult();
            }

            var apartmentModel = _mapper.Map<ApartmentModel>(apartmentDto);
            return new OkObjectResult(apartmentModel);
        }

        public IActionResult ComposeForCreate(int statusCode, ApartmentCreateDto apartmentCreateDto)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid apartment owner id.");
                case -2:
                    return new BadRequestObjectResult("Invalid number of rooms.");
                case -3:
                    return new BadRequestObjectResult("Invalid area.");
                case -4:
                    return new BadRequestObjectResult("Invalid floor.");
                case -5:
                    return new BadRequestObjectResult("Invalid adress.");
                default:
                    return new CreatedAtRouteResult("GetApartment", new { Id = statusCode }, apartmentCreateDto);
            }
        }

        public IActionResult ComposeForUpdate(int statusCode)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid apartment owner id.");
                case -2:
                    return new BadRequestObjectResult("Invalid number of rooms.");
                case -3:
                    return new BadRequestObjectResult("Invalid area.");
                case -4:
                    return new BadRequestObjectResult("Invalid floor.");
                case -5:
                    return new BadRequestObjectResult("Invalid adress.");
                default:
                    return new OkResult();
            }
        }

        public IActionResult ComposeForDelete(int statusCode)
        {
            switch (statusCode)
            {
                case -6:
                    return new NotFoundResult();
                default:
                    return new NoContentResult();
            }
        }
    }
}