using AutoMapper;
using EstateAgency.API.Services;
using EstateAgency.BLL.RentAnnouncements.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EstateAgency.API.Models;
using EstateAgency.API.Models.Announcements;
using EstateAgency.API.Models.Apartments;
using EstateAgency.API.Services.Apartments;
using EstateAgency.API.Services.RentAnnouncements;
using EstateAgency.BLL.Apartments;
using EstateAgency.BLL.Apartments.Services;
using EstateAgency.BLL.RentAnnouncements;
using Microsoft.AspNetCore.Authorization;

namespace EstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentsController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        private readonly IApartmentResponseComposer _apartmentResponseComposer;

        public ApartmentsController(IApartmentService apartmentService, IMapper mapper,
            IApartmentResponseComposer apartmentResponseComposer)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
            _apartmentResponseComposer = apartmentResponseComposer;
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var apartmentDtos = await _apartmentService.GetAllAsync();
            var response = _apartmentResponseComposer.ComposeForGetAll(apartmentDtos);
            return response;
        }

        [Authorize(Roles = "user")]
        [HttpGet("{id}", Name = "GetApartment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var apartmentDto = await _apartmentService.GetAsync(id);
            var response = _apartmentResponseComposer.ComposeForGet(apartmentDto);
            return response;
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ApartmentAddOrUpdateModel apartmentAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var apartmentCreateDto = _mapper.Map<ApartmentCreateDto>(apartmentAddOrUpdateModel);
            var statusCode = await _apartmentService.AddAsync(apartmentCreateDto);
            var response = _apartmentResponseComposer.ComposeForCreate(statusCode, apartmentCreateDto);
            return response;
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] ApartmentAddOrUpdateModel apartmentAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id.HasValue)
            {
                var apartmentUpdateDto =
                    _mapper.Map<ApartmentUpdateDto>(apartmentAddOrUpdateModel);
                apartmentUpdateDto.Id = id.Value;
                var statusCode = await _apartmentService.UpdateAsync(apartmentUpdateDto);
                var response = _apartmentResponseComposer.ComposeForUpdate(statusCode);
                return response;
            }
            else
            {
                var apartmentCreateDto = _mapper.Map<ApartmentCreateDto>(apartmentAddOrUpdateModel);
                var statusCode = await _apartmentService.AddAsync(apartmentCreateDto);
                var response = _apartmentResponseComposer.ComposeForCreate(statusCode, apartmentCreateDto);
                return response;
            }
        }
        
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var statusCode = await _apartmentService.DeleteAsync(id);
            var response = _apartmentResponseComposer.ComposeForDelete(statusCode);
            return response;
        }
    }
}
