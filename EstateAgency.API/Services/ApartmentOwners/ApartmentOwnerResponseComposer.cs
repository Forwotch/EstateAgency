using System.Collections.Generic;
using AutoMapper;
using EstateAgency.API.Models.ApartmentOwners;
using EstateAgency.API.Models.Apartments;
using EstateAgency.BLL.ApartmentOwners;
using EstateAgency.BLL.Apartments;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Services.ApartmentOwners
{
    public class ApartmentOwnerResponseComposer : IApartmentOwnerResponseComposer
    {
        private readonly IMapper _mapper;

        public ApartmentOwnerResponseComposer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult ComposeForGetAll(IEnumerable<ApartmentOwnerDto> apartmentOwnerDtos)
        {
            var apartmentOwnerModels = _mapper.Map<IEnumerable<ApartmentOwnerModel>>(apartmentOwnerDtos);
            return new OkObjectResult(apartmentOwnerModels);
        }

        public IActionResult ComposeForGet(ApartmentOwnerDto apartmentOwnerDto)
        {
            if (apartmentOwnerDto == null)
            {
                return new NotFoundResult();
            }

            var apartmentOwnerModel = _mapper.Map<ApartmentOwnerModel>(apartmentOwnerDto);
            return new OkObjectResult(apartmentOwnerModel);
        }

        public IActionResult ComposeForCreate(int statusCode, ApartmentOwnerCreateDto apartmentOwnerCreateDto)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid first name.");
                case -2:
                    return new BadRequestObjectResult("Invalid laste name.");
                case -3:
                    return new BadRequestObjectResult("Invalid email.");
                case -4:
                    return new BadRequestObjectResult("Invalid phone number.");
                default:
                    return new CreatedAtRouteResult("GetApartmentOwner", new { Id = statusCode }, apartmentOwnerCreateDto);
            }
        }

        public IActionResult ComposeForUpdate(int statusCode)
        {
            switch (statusCode)
            {
                case -1:
                    return new BadRequestObjectResult("Invalid first name.");
                case -2:
                    return new BadRequestObjectResult("Invalid laste name.");
                case -3:
                    return new BadRequestObjectResult("Invalid email.");
                case -4:
                    return new BadRequestObjectResult("Invalid phone number.");
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