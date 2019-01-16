using AutoMapper;
using EstateAgency.API.Models.Announcements;
using EstateAgency.API.Services.RentAnnouncements;
using EstateAgency.BLL.RentAnnouncements;
using EstateAgency.BLL.RentAnnouncements.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    public class RentAnnouncementsController : Controller
    {
        private readonly IRentAnnouncementService _rentAnnouncementService;
        private readonly IMapper _mapper;
        private readonly IRentAnnouncementResponseComposer _rentAnnouncementResponseComposer;
        private readonly IRentAnnouncementExpressionComposer _rentAnnouncementExpressionComposer;

        public RentAnnouncementsController(IRentAnnouncementService rentAnnouncementService, IMapper mapper,
            IRentAnnouncementResponseComposer rentAnnouncementResponseComposer, IRentAnnouncementExpressionComposer rentAnnouncementExpressionComposer)
        {
            _rentAnnouncementService = rentAnnouncementService;
            _mapper = mapper;
            _rentAnnouncementResponseComposer = rentAnnouncementResponseComposer;
            _rentAnnouncementExpressionComposer = rentAnnouncementExpressionComposer;
        }

        /// <summary>
        /// Gets rent announcement by id.
        /// </summary>
        /// <param name="id">Rent announcement id</param>
        /// <returns>Returns rent announcement by id</returns>
        /// <response code="200">If the item exists</response>
        /// <response code="404">If the item is not found</response>
        [HttpGet("{id}", Name = "GetRentAnnouncement")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var rentAnnouncementDto = await _rentAnnouncementService.GetAsync(id);
            var response = _rentAnnouncementResponseComposer.ComposeForGet(rentAnnouncementDto);
            return response;
        }

        /// <summary>
        /// Finds rent announcements by criteria.
        /// </summary>
        /// <param name="maxPrice">Max price in rent announcement</param>
        /// <param name="numberOfRooms">Number of rooms in rent announcement</param>
        /// <param name="adress">Adress in rent announcement</param>
        /// <returns>Returns rent announcement by criteria</returns>
        /// <response code="200">Always</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindAsync(int? maxPrice, int? numberOfRooms, string adress)
        {
            var expression = _rentAnnouncementExpressionComposer.Compose(maxPrice, numberOfRooms, adress);
            var rentAnnouncementDtos = await _rentAnnouncementService.FindAsync(expression);
            var response = _rentAnnouncementResponseComposer.ComposeForGetAll(rentAnnouncementDtos);
            return response;
        }

        /// <summary>
        /// Creates rent announcement.
        /// </summary>
        /// <param name="rentAnnouncementAddOrUpdateModel">Rent announcement model</param>
        /// <returns>Returns route to created rent announcement</returns>
        /// <response code="201">If the item created</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "user")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAsync([FromBody] RentAnnouncementAddOrUpdateModel rentAnnouncementAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rentAnnouncementCreateDto = _mapper.Map<RentAnnouncementCreateDto>(rentAnnouncementAddOrUpdateModel);
            var statusCode = await _rentAnnouncementService.AddAsync(rentAnnouncementCreateDto);
            var response = _rentAnnouncementResponseComposer.ComposeForCreate(statusCode, rentAnnouncementCreateDto);
            return response;
        }

        /// <summary>
        /// Updates rent announcement.
        /// </summary>
        /// <param name="id">Rent announcement id</param>
        /// <param name="rentAnnouncementAddOrUpdateModel">Rent announcement model</param>
        /// <response code="204">If the item updated</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "admin")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] RentAnnouncementAddOrUpdateModel rentAnnouncementAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id.HasValue)
            {
                var rentAnnouncementUpdateDto =
                    _mapper.Map<RentAnnouncementUpdateDto>(rentAnnouncementAddOrUpdateModel);
                rentAnnouncementUpdateDto.Id = id.Value;
                var statusCode = await _rentAnnouncementService.UpdateAsync(rentAnnouncementUpdateDto);
                var response = _rentAnnouncementResponseComposer.ComposeForUpdate(statusCode);
                return response;
            }
            else
            {
                var rentAnnouncementCreateDto = _mapper.Map<RentAnnouncementCreateDto>(rentAnnouncementAddOrUpdateModel);
                var statusCode = await _rentAnnouncementService.AddAsync(rentAnnouncementCreateDto);
                var response = _rentAnnouncementResponseComposer.ComposeForCreate(statusCode, rentAnnouncementCreateDto);
                return response;
            }
        }

        /// <summary>
        /// Deletes rent announcement.
        /// </summary>
        /// <param name="id">Rent announcement id</param>
        /// <response code="204">If the item deleted</response>
        /// <response code="404">If the item not found</response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var statusCode = await _rentAnnouncementService.DeleteAsync(id);
            var response = _rentAnnouncementResponseComposer.ComposeForDelete(statusCode);
            return response;
        }
    }
}
