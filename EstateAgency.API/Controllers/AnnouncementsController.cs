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

        [HttpGet]
        public async Task<IActionResult> GetAllToReviewAsync()
        {
            var announcementToReviewDtos =  await _announcementService.GetAllToReviewAsync();
            return Ok(_mapper.Map<IEnumerable<AnnouncementToReviewModel>>(announcementToReviewDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var announcementToReviewDto = await _announcementService.GetAsync(id);
            return Ok(_mapper.Map<AnnouncementToReviewModel>(announcementToReviewDto));
        }

        [HttpPut]
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