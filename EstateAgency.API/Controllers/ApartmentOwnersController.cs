using AutoMapper;
using EstateAgency.API.Models.ApartmentOwners;
using EstateAgency.API.Services.ApartmentOwners;
using EstateAgency.BLL.ApartmentOwners;
using EstateAgency.BLL.ApartmentOwners.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        /// <summary>
        /// Gets all apartment owners.
        /// </summary>
        /// <returns>Returns all apartments</returns>
        /// <response code="200">Always</response>
        [Authorize(Roles = "user")]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var apartmentOwnerDtos = await _apartmentOwnerService.GetAllAsync();
            var response = _apartmentOwnerResponseComposer.ComposeForGetAll(apartmentOwnerDtos);
            return response;
        }

        /// <summary>
        /// Gets apartment owner by id.
        /// </summary>
        /// <param name="id">Apartment owner id</param>
        /// <returns>Returns apartment owner by id</returns>
        /// <response code="200">If the item exists</response>
        /// <response code="404">If the item is not found</response>
        [Authorize(Roles = "user")]
        [HttpGet("{id}", Name = "GetApartmentOwner")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var apartmentOwnerDto = await _apartmentOwnerService.GetAsync(id);
            var response = _apartmentOwnerResponseComposer.ComposeForGet(apartmentOwnerDto);
            return response;
        }

        /// <summary>
        /// Creates apartment owner.
        /// </summary>
        /// <param name="apartmentOwnerAddOrUpdateModel">Apartment owner model</param>
        /// <returns>Returns route to created apartment owner</returns>
        /// <response code="201">If the item created</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "user")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Updates apartment owner.
        /// </summary>
        /// <param name="id">Apartment owner id</param>
        /// <param name="apartmentOwnerAddOrUpdateModel">Apartment owner model</param>
        /// <response code="204">If the item updated</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "admin")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Deletes apartment owner.
        /// </summary>
        /// <param name="id">Apartment owner id</param>
        /// <response code="204">If the item deleted</response>
        /// <response code="404">If the item not found</response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var statusCode = await _apartmentOwnerService.DeleteAsync(id);
            var response = _apartmentOwnerResponseComposer.ComposeForDelete(statusCode);
            return response;
        }
    }
}
