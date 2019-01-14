using AutoMapper;
using EstateAgency.API.Services;
using EstateAgency.BLL.RentAnnouncements.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EstateAgency.API.Models;
using EstateAgency.API.Models.Announcements;
using EstateAgency.API.Models.ApartmentOwners;
using EstateAgency.API.Models.Apartments;
using EstateAgency.API.Services.ApartmentOwners;
using EstateAgency.API.Services.Apartments;
using EstateAgency.API.Services.RentAnnouncements;
using EstateAgency.BLL.ApartmentOwners;
using EstateAgency.BLL.ApartmentOwners.Services;
using EstateAgency.BLL.Apartments;
using EstateAgency.BLL.Apartments.Services;
using EstateAgency.BLL.RentAnnouncements;

namespace EstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentOwnersController : Controller
    {
        private readonly IApartmentOwnerService _apartmentOwnerService;
        private readonly IMapper _mapper;
        private readonly IApartmentOwnerResponseComposer _apartmentOwnerResponseComposer;

        public ApartmentOwnersController(IApartmentOwnerService apartmentOwnerService, IMapper mapper,
            IApartmentOwnerResponseComposer apartmentOwnerResponseComposer)
        {
            _apartmentOwnerService = apartmentOwnerService;
            _mapper = mapper;
            _apartmentOwnerResponseComposer = apartmentOwnerResponseComposer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var apartmentOwnerDtos = await _apartmentOwnerService.GetAllAsync();
            var response = _apartmentOwnerResponseComposer.ComposeForGetAll(apartmentOwnerDtos);
            return response;
        }

        [HttpGet("{id}", Name = "GetApartmentOwner")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var apartmentOwnerDto = await _apartmentOwnerService.GetAsync(id);
            var response = _apartmentOwnerResponseComposer.ComposeForGet(apartmentOwnerDto);
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ApartmentOwnerAddOrUpdateModel apartmentOwnerAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var apartmentOwnerCreateDto = _mapper.Map<ApartmentOwnerCreateDto>(apartmentOwnerAddOrUpdateModel);
            var statusCode = await _apartmentOwnerService.AddAsync(apartmentOwnerCreateDto);
            var response = _apartmentOwnerResponseComposer.ComposeForCreate(statusCode, apartmentOwnerCreateDto);
            return response;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] ApartmentOwnerAddOrUpdateModel apartmentOwnerAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id.HasValue)
            {
                var apartmentOwnerUpdateDto =
                    _mapper.Map<ApartmentOwnerUpdateDto>(apartmentOwnerAddOrUpdateModel);
                apartmentOwnerUpdateDto.Id = id.Value;
                var statusCode = await _apartmentOwnerService.UpdateAsync(apartmentOwnerUpdateDto);
                var response = _apartmentOwnerResponseComposer.ComposeForUpdate(statusCode);
                return response;
            }
            else
            {
                var apartmentOwnerCreateDto = _mapper.Map<ApartmentOwnerCreateDto>(apartmentOwnerAddOrUpdateModel);
                var statusCode = await _apartmentOwnerService.AddAsync(apartmentOwnerCreateDto);
                var response = _apartmentOwnerResponseComposer.ComposeForCreate(statusCode, apartmentOwnerCreateDto);
                return response;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var statusCode = await _apartmentOwnerService.DeleteAsync(id);
            var response = _apartmentOwnerResponseComposer.ComposeForDelete(statusCode);
            return response;
        }
    }
}
