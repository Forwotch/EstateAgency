using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EstateAgency.API.Models.Announcements;
using EstateAgency.BLL.Announcements.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstateAgency.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementsController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets announcements with "On Review" status.
        /// </summary>
        /// <returns>Returns announcements with "On Review" status</returns>
        /// <response code="200">Always</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllToReviewAsync()
        {
            var announcementToReviewDtos =  await _announcementService.GetAllToReviewAsync();
            return Ok(_mapper.Map<IEnumerable<AnnouncementToReviewModel>>(announcementToReviewDtos));
        }

        /// <summary>
        /// Gets announcement by id.
        /// </summary>
        /// <param name="id">Announcement id</param>
        /// <returns>Returns announcement by id</returns>
        /// <response code="200">If the item exists</response>
        /// <response code="404">If the item is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var announcementToReviewDto = await _announcementService.GetAsync(id);
            if (announcementToReviewDto == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AnnouncementToReviewModel>(announcementToReviewDto));
        }

        /// <summary>
        /// Updates announcement status.
        /// </summary>
        /// <param name="id">Announcement id</param>
        /// <param name="status">Announcement status</param>
        /// <response code="204">If the item updated</response>
        /// <response code="400">If the status is invalid</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateStatusAsync(int? id, [FromBody] string status)
        {
            if (!id.HasValue || string.IsNullOrEmpty(status))
            {
                return BadRequest();
            }
            await _announcementService.UpdateStatusAsync(id.Value, status);
            return Ok();
        }
    }
}