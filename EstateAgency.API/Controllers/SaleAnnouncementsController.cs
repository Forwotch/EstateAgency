using AutoMapper;
using EstateAgency.API.Models.Announcements;
using EstateAgency.API.Services.SaleAnnouncements;
using EstateAgency.BLL.SaleAnnouncements;
using EstateAgency.BLL.SaleAnnouncements.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    public class SaleAnnouncementsController : Controller
    {
        private readonly ISaleAnnouncementService _saleAnnouncementService;
        private readonly IMapper _mapper;
        private readonly ISaleAnnouncementResponseComposer _saleAnnouncementResponseComposer;
        private readonly ISaleAnnouncementExpressionComposer _saleAnnouncementExpressionComposer;

        public SaleAnnouncementsController(ISaleAnnouncementService saleAnnouncementService, IMapper mapper,
            ISaleAnnouncementResponseComposer saleAnnouncementResponseComposer,
            ISaleAnnouncementExpressionComposer saleAnnouncementExpressionComposer)
        {
            _saleAnnouncementService = saleAnnouncementService;
            _mapper = mapper;
            _saleAnnouncementResponseComposer = saleAnnouncementResponseComposer;
            _saleAnnouncementExpressionComposer = saleAnnouncementExpressionComposer;
        }

        /// <summary>
        /// Gets sale announcement by id.
        /// </summary>
        /// <param name="id">Sale announcement id</param>
        /// <returns>Returns sale announcement by id</returns>
        /// <response code="200">If the item exists</response>
        /// <response code="404">If the item is not found</response>
        [HttpGet("{id}", Name = "GetSaleAnnouncement")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var saleAnnouncementDto = await _saleAnnouncementService.GetAsync(id);
            var response = _saleAnnouncementResponseComposer.ComposeForGet(saleAnnouncementDto);
            return response;
        }

        /// <summary>
        /// Finds sale announcements by criteria.
        /// </summary>
        /// <param name="maxPrice">Max price in sale announcement</param>
        /// <param name="numberOfRooms">Number of rooms in sale announcement</param>
        /// <param name="adress">Adress in sale announcement</param>
        /// <returns>Returns sale announcement by criteria</returns>
        /// <response code="200">Always</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindAsync(int? maxPrice, int? numberOfRooms, string adress)
        {
            var expression = _saleAnnouncementExpressionComposer.Compose(maxPrice, numberOfRooms, adress);
            var saleAnnouncementDtos = await _saleAnnouncementService.FindAsync(expression);
            var response = _saleAnnouncementResponseComposer.ComposeForGetAll(saleAnnouncementDtos);
            return response;
        }

        /// <summary>
        /// Creates sale announcement.
        /// </summary>
        /// <param name="saleAnnouncementAddOrUpdateModel">Sale announcement model</param>
        /// <returns>Returns route to created sale announcement</returns>
        /// <response code="201">If the item created</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "user")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAsync([FromBody] SaleAnnouncementAddOrUpdateModel saleAnnouncementAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var saleAnnouncementCreateDto = _mapper.Map<SaleAnnouncementCreateDto>(saleAnnouncementAddOrUpdateModel);
            var statusCode = await _saleAnnouncementService.AddAsync(saleAnnouncementCreateDto);
            var response = _saleAnnouncementResponseComposer.ComposeForCreate(statusCode, saleAnnouncementCreateDto);
            return response;
        }

        /// <summary>
        /// Updates sale announcement.
        /// </summary>
        /// <param name="id">Sale announcement id</param>
        /// <param name="saleAnnouncementAddOrUpdateModel">Sale announcement model</param>
        /// <response code="204">If the item updated</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "admin")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] SaleAnnouncementAddOrUpdateModel saleAnnouncementAddOrUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id.HasValue)
            {
                var saleAnnouncementUpdateDto =
                    _mapper.Map<SaleAnnouncementUpdateDto>(saleAnnouncementAddOrUpdateModel);
                saleAnnouncementUpdateDto.Id = id.Value;
                var statusCode = await _saleAnnouncementService.UpdateAsync(saleAnnouncementUpdateDto);
                var response = _saleAnnouncementResponseComposer.ComposeForUpdate(statusCode);
                return response;
            }
            else
            {
                var saleAnnouncementCreateDto = _mapper.Map<SaleAnnouncementCreateDto>(saleAnnouncementAddOrUpdateModel);
                var statusCode = await _saleAnnouncementService.AddAsync(saleAnnouncementCreateDto);
                var response = _saleAnnouncementResponseComposer.ComposeForCreate(statusCode, saleAnnouncementCreateDto);
                return response;
            }
        }

        /// <summary>
        /// Deletes sale announcement.
        /// </summary>
        /// <param name="id">Sale announcement id</param>
        /// <response code="204">If the item deleted</response>
        /// <response code="404">If the item not found</response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var statusCode = await _saleAnnouncementService.DeleteAsync(id);
            var response = _saleAnnouncementResponseComposer.ComposeForDelete(statusCode);
            return response;
        }
    }
}