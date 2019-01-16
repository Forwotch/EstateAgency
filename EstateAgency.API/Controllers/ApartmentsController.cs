using AutoMapper;
using EstateAgency.API.Models.Apartments;
using EstateAgency.API.Services.Apartments;
using EstateAgency.BLL.Apartments;
using EstateAgency.BLL.Apartments.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        /// <summary>
        /// Gets all apartments.
        /// </summary>
        /// <returns>Returns all apartments</returns>
        /// <response code="200">Always</response>
        [Authorize(Roles = "user")]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var apartmentDtos = await _apartmentService.GetAllAsync();
            var response = _apartmentResponseComposer.ComposeForGetAll(apartmentDtos);
            return response;
        }

        /// <summary>
        /// Gets apartment by id.
        /// </summary>
        /// <param name="id">Apartment id</param>
        /// <returns>Returns apartment by id</returns>
        /// <response code="200">If the item exists</response>
        /// <response code="404">If the item is not found</response>
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

        /// <summary>
        /// Creates apartment.
        /// </summary>
        /// <param name="apartmentAddOrUpdateModel">Apartment model</param>
        /// <returns>Returns route to created apartment</returns>
        /// <response code="201">If the item created</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "user")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Updates apartment.
        /// </summary>
        /// <param name="id">Apartment id</param>
        /// <param name="apartmentAddOrUpdateModel">Apartment model</param>
        /// <response code="204">If the item updated</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "admin")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Deletes apartment.
        /// </summary>
        /// <param name="id">Apartment id</param>
        /// <response code="204">If the item deleted</response>
        /// <response code="404">If the item not found</response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var statusCode = await _apartmentService.DeleteAsync(id);
            var response = _apartmentResponseComposer.ComposeForDelete(statusCode);
            return response;
        }
    }
}
